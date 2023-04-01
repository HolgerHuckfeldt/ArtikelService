
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using ArtikelService.PVSolrServices.Mapper;
using log4net;
using PV.DomainObjects.Artikel;

using PvKatalogsystem.Types.DTOs;
using PvKatalogsystem.Types.Enums;
using PvKatalogsystem.Types.Interfaces;
using PVSolrServices;

namespace ArtikelService.Services
{
    public class SolrArtikelService
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        private readonly IArtikelService _artikelService;
        private readonly IArtikelSQLService _artikelSQLService;

        public SolrArtikelService()
        {
            _artikelService =
                new ArtikelService("http://10.29.6.22:8777/PvKatalogsystem_Artikel",
                    "http://10.29.6.22:8777/PvKatalogsystem_Artikel");
        }

        public List<SuchbaumEintrag> GetSuchbaumEintragList(ArtikelSuchbaumRequest artikelSuchbaumRequest)
        {
            ArtikelSuchoptionenFuerGetSuchbaumknoten suchoptionen =
                new ArtikelSuchoptionenFuerGetSuchbaumknoten();
            suchoptionen.Suchbaumtyp = GetSuchbaumtyp(artikelSuchbaumRequest.Art);
            suchoptionen.FahrzeugArt = GetFahrzeugart(artikelSuchbaumRequest.Art);
            suchoptionen.FahrzeugId = artikelSuchbaumRequest.VehicleId ?? 0;
            suchoptionen.Mobile = artikelSuchbaumRequest.Mobile;

            ArtikelSuchoptionenFuerGetSuchbaumknoten suchoptionenGr =
                new ArtikelSuchoptionenFuerGetSuchbaumknoten();
            suchoptionenGr.Suchbaumtyp = GetSuchbaumtyp(artikelSuchbaumRequest.Art);
            suchoptionenGr.FahrzeugArt = GetFahrzeugart(artikelSuchbaumRequest.Art);
            suchoptionenGr.FahrzeugId = artikelSuchbaumRequest.VehicleId ?? 0;
            suchoptionenGr.Mobile = artikelSuchbaumRequest.Mobile;

            var context = GetContext(null, CsoArtikelSuchtyp.Suchbaumsuche, (int)artikelSuchbaumRequest.FirmaId,
                artikelSuchbaumRequest.AlternativeCSO);

            var contextGr = GetContext(null, CsoArtikelSuchtyp.Suchbaumsuche, (int)artikelSuchbaumRequest.FirmaId,
                artikelSuchbaumRequest.AlternativeCSO);

            //Ticket 1084417
            context.MitWeiterenHerstellern = context.WeitereHersteller_beruecksichtigen;
            contextGr.MitWeiterenHerstellern = contextGr.WeitereHersteller_beruecksichtigen;

            WaitHandle[] waitHandles = new WaitHandle[]
            {
                new ManualResetEvent(false),
                new ManualResetEvent(false)
            };

            List<Suchbaumknoten> solrResult = null;
            List<Suchbaumknoten> solrResultGrafik = null;

            // Machen wir es mal Parallel...
            ThreadPool.QueueUserWorkItem(delegate (object state)
            {
                solrResult = _artikelService.GetSuchbaumknoten(context, suchoptionen);
                (state as ManualResetEvent).Set();
            }, waitHandles[0]);


            ThreadPool.QueueUserWorkItem(delegate (object state)
            {
                if (!artikelSuchbaumRequest.Mobile && suchoptionenGr.Suchbaumtyp == Suchbaumtyp.Pkw)
                {
                    suchoptionenGr.NurSensitiveArea = true;
                    contextGr.MitWeiterenHerstellern = false;
                    solrResultGrafik = _artikelService.GetSuchbaumknoten(contextGr, suchoptionenGr);
                }
                (state as ManualResetEvent).Set();
            }, waitHandles[1]);

            foreach (var e in waitHandles) e.WaitOne();

            //List<Dto.Suchbaumknoten> solrResultTemotGrafik = new List<Dto.Suchbaumknoten>();
            //if (useGrafischeSuche)
            //{
            //    solrResultTemotGrafik = _artikelSQLService.GetSuchbaumknoten(context, suchoptionen);
            //}

            //if ((solrResultGrafik != null && solrResultGrafik.Count > 0))
            //{
            //    solrResult.AddRange(buildSuchbaumFuerGrafischeSuche(solrResultGrafik, solrResultTemotGrafik));
            //}

            var result = SuchbaumEintragMapper.Map(solrResult);

            List<SuchbaumEintrag> resultCopy = result.ToList<SuchbaumEintrag>();

            foreach (var eintrag in result)
            {
                var parents = result.Where(x => x.Parent == eintrag.Id && x.HatGenerischeArtikel && !x.SuchknotenGrafik);

                if (parents.Count() == 1)
                {
                    foreach (var par in parents)
                    {
                        if (eintrag.Bezeichnung == par.Bezeichnung)
                        {
                            resultCopy.Remove(par);
                            var eintragCopy = resultCopy.Where(x => x.Id == eintrag.Id).First();

                            eintragCopy.HatGenerischeArtikel = true;
                            eintragCopy.IdNew = par.Id;
                            eintragCopy.ParentNew = par.Parent;
                            eintragCopy.UseNewId = true;
                        }
                        break;
                    }
                }
            }
            return resultCopy;
        }

        public ArtikelProviderResult<PV.DomainObjects.Artikel.Artikel> GetArtikelListeBySuchknotenAndTyp(ArtikelProviderRequest<SuchknotenAndTyp> request)
        {
            var context = GetContext(request, CsoArtikelSuchtyp.Suchbaumsuche);
            UebergabeFuerSolr uebergabeFuerSolr = new UebergabeFuerSolr();
            bool suchstringFuerFreitextsuche = false;

            if (request.InnerRequest.Knoten == null || !request.InnerRequest.Knoten.SuchknotenGrafik)
            {
                context.MitWeiterenHerstellern = request.InnerRequest.MitWeiterenHerstellern;
            }

            uebergabeFuerSolr.SbTyp = GetSuchbaumtyp(request.InnerRequest.Art);
            uebergabeFuerSolr.FzgArt = GetFahrzeugart(request.InnerRequest.Art);
            uebergabeFuerSolr.FzgId = request.InnerRequest.VehicleId ?? 0;
            uebergabeFuerSolr.VorgaengerKnotenTiefe = request.InnerRequest.VorgaengerKnotenTiefe;

            if (!string.IsNullOrEmpty(request.InnerRequest.Suchstring))
            {
                uebergabeFuerSolr.SuchstringFuerHersteller = request.InnerRequest.SuchstringFuerHersteller;
                uebergabeFuerSolr.Suchstring = request.InnerRequest.Suchstring;

                suchstringFuerFreitextsuche = true;
            }

            if (request.InnerRequest.Mobile)
            {
                uebergabeFuerSolr.RowCount = GetMobileMaxAnzahl;
            }
            else if (uebergabeFuerSolr.SbTyp == Suchbaumtyp.Universal ||
                (request.InnerRequest.GenArtKnotenListe != null && request.InnerRequest.GenArtKnotenListe.Count > 0))
            {
                uebergabeFuerSolr.RowCount = 1000;
            }
            else
            {
                uebergabeFuerSolr.RowCount = 120;
            }

            if (request.InnerRequest.Knoten != null)
            {
                uebergabeFuerSolr.GenArtId = request.InnerRequest.Knoten.UseNewId ? request.InnerRequest.Knoten.IdNew : request.InnerRequest.Knoten.Id;
            }

            uebergabeFuerSolr.GenArtList = request.InnerRequest.GenArtKnotenListe;
            uebergabeFuerSolr.VorgaengerKnoten = request.InnerRequest.VorgaengerKnoten;
            uebergabeFuerSolr.VorgaengerParentIdKnoten = request.InnerRequest.VorgaengerParentIdKnoten;

            if (request.InnerRequest.Knoten != null)
            {
                uebergabeFuerSolr.SuchknotenGrafik = request.InnerRequest.Knoten.SuchknotenGrafik;
            }

            uebergabeFuerSolr.Mobile = request.InnerRequest.Mobile;
            uebergabeFuerSolr.StartIndex = 0;

            var backresult = new ArtikelProviderResult<PV.DomainObjects.Artikel.Artikel>(new List<PV.DomainObjects.Artikel.Artikel>(), new List<IncentiveArtikel>());
            OelEmpfehlung oelEmpfehlungen = new OelEmpfehlung();

            WaitHandle[] waitHandles = new WaitHandle[]
                    {
                        new ManualResetEvent(false),
                        new ManualResetEvent(false),
                    };
            List<WaitHandle> usedHandles = new List<WaitHandle>();

            int genArtid = 0;
            if (uebergabeFuerSolr.GenArtId > 0)
            {
                genArtid = uebergabeFuerSolr.GenArtId;
            }
            else if (uebergabeFuerSolr.GenArtList != null && uebergabeFuerSolr.GenArtList.Count == 1)
            {
                genArtid = uebergabeFuerSolr.GenArtList.First();
            }

            usedHandles.Add(waitHandles[0]);
            //ThreadPool.QueueUserWorkItem(SafelyExecuteActionAndSetEvent(() =>
            //{
            //    oelEmpfehlungen = checkOelEmpfehlung(context, genArtid, request.InnerRequest.Art, request.InnerRequest.Typ.HasValue ? request.InnerRequest.Typ.Value : 0);
            //}),
            //    waitHandles[0]);

            usedHandles.Add(waitHandles[1]);


            var searchResult = _artikelService.GetArtikelByGenerischerArtikel(
                context,
                uebergabeFuerSolr);

            bool nurWeitereHersteller = false;
            if (!request.InnerRequest.Mobile && searchResult.Artikel.Count == 0 && context.WeitereHersteller_beruecksichtigen &&
                !context.MitWeiterenHerstellern && !uebergabeFuerSolr.SuchknotenGrafik)
            {
                //Ticket 1084417
                context.MitWeiterenHerstellern = true;
                uebergabeFuerSolr.Mobile = false;

                searchResult = _artikelService.GetArtikelByGenerischerArtikel(
                context,
                uebergabeFuerSolr);

                nurWeitereHersteller = true;
            }

            List<PV.DomainObjects.Artikel.Artikel> kompassArtikelListe = new List<PV.DomainObjects.Artikel.Artikel>();

            if (request.InnerRequest.Typ != null)
            {

                foreach (var artikel in searchResult.Artikel)
                {
                    var kompassArtikel = ArtikelMapper.Map(artikel, ArtikelTypen.Normal, uebergabeFuerSolr.GenArtId, false, request.IsPitStop, request.IsStahlgruberAbfrage);

                    if (kompassArtikel == null)
                        log.Debug("kompassArtikel is null");
                    if (request.InnerRequest == null)
                        log.Debug("request.InnerRequest is null");
                    if (request.InnerRequest.Typ == null)
                        log.Debug("request.InnerRequest.Typ is null");
                    if (request.InnerRequest.VehicleId == null)
                        log.Debug("request.InnerRequest.VehicleId is null");

                    setxTypArtAndxTypNr(kompassArtikel, (int)request.InnerRequest.Typ, request.InnerRequest.Art, (int)request.InnerRequest.VehicleId);
                    kompassArtikel.NurWeitereHersteller = nurWeitereHersteller;
                    kompassArtikel.IstSuchstringFuerFreitextsucheVorhanden = suchstringFuerFreitextsuche;
                    kompassArtikelListe.Add(kompassArtikel);
                }
            }
            else
            {
                foreach (var artikel in searchResult.Artikel)
                {
                    var kompassArtikel = ArtikelMapper.Map(artikel, ArtikelTypen.Normal, uebergabeFuerSolr.GenArtId, false, request.IsPitStop, request.IsStahlgruberAbfrage);
                    kompassArtikel.NurWeitereHersteller = nurWeitereHersteller;
                    kompassArtikel.IstSuchstringFuerFreitextsucheVorhanden = suchstringFuerFreitextsuche;

                    kompassArtikelListe.Add(kompassArtikel);
                }
            }

            string genArtBezeichnung = uebergabeFuerSolr.GenArtId.ToString();
            if (kompassArtikelListe.Count() > 0)
            {
                genArtBezeichnung = ermittleGenArt(uebergabeFuerSolr.GenArtList, uebergabeFuerSolr.GenArtId, kompassArtikelListe.First().GenArtBezeichnung);
            }

            var suchbaumTypName = getSuchbaumTyp(request.InnerRequest.Art.ToString());

            //saveSuchstatistik("",
            //    genArtBezeichnung,
            //    "", kompassArtikelListe.Count, suchbaumTypName, uebergabeFuerSolr.FzgId, context.Standort, DateTime.Now,
            //    request.Firma, request.InnerRequest.Typ ?? 0, request.IsPraesentationsModus, request.Kundenummer, request.ProfilId);

            //var incentiveList = IncentiveMapper.Map(searchResult.IncentiveBundles);
            backresult = new ArtikelProviderResult<PV.DomainObjects.Artikel.Artikel>(kompassArtikelListe, new List<IncentiveArtikel>());


            //SetGenArtInEmpfehlungAndCheckForMissingArtikels(backresult, oelEmpfehlungen);

            backresult.OelEmpfehlungen = oelEmpfehlungen;
            return backresult;
        }

        private Suchbaumtyp GetSuchbaumtyp(ArtikelArt art)
        {
            switch (art)
            {
                case ArtikelArt.PKW: return Suchbaumtyp.Pkw;
                case ArtikelArt.NKW: return Suchbaumtyp.Lkw;
                case ArtikelArt.Motor: return Suchbaumtyp.Motor;
                case ArtikelArt.Achse: return Suchbaumtyp.Achse;
                default: return Suchbaumtyp.Universal;
            }
        }

        private Fahrzeugart GetFahrzeugart(GebrauchsmusterArt art)
        {
            switch (art)
            {
                case GebrauchsmusterArt.Pkw: return Fahrzeugart.Pkw;
                case GebrauchsmusterArt.Nkw: return Fahrzeugart.Lkw;
                case GebrauchsmusterArt.Motor: return Fahrzeugart.Motor;
                case GebrauchsmusterArt.Achse: return Fahrzeugart.Achse;
                default: return Fahrzeugart.Ohne;
            }
        }

        private Fahrzeugart GetFahrzeugart(ArtikelArt art)
        {
            switch (art)
            {
                case ArtikelArt.PKW: return Fahrzeugart.Pkw;
                case ArtikelArt.NKW: return Fahrzeugart.Lkw;
                case ArtikelArt.Motor: return Fahrzeugart.Motor;
                case ArtikelArt.Achse: return Fahrzeugart.Achse;
                default: return Fahrzeugart.Ohne;
            }
        }

        private ServiceContext GetContext(IArtikelProviderRequest req,
    CsoArtikelSuchtyp csoArtikelSuchtyp = CsoArtikelSuchtyp.None, int firmaId = 0, string alternativeCSO = "")
        {
            var cso = "";
            var fsa = "";
            var fsaForLogistik = "";

            if (req != null)
            {
                //if (req.IsPitStop)
                //{
                //    //cso = "073";
                //    ////cso = "555"; // Fix für PV-2329. Sven Franke: "Derzeit haben keine! Artikel mehr eine Zuordnung zur CSO 073. Man könnte die CSO 073 theoretisch löschen." (Mail vom 12.06.2015)
                //    //csoArtikelSuchtyp = CsoArtikelSuchtyp.Suchbaumsuche; // Kein Heck, sondern erweiterung der Logik.
                //    //// In der Wartung bei Artikeln würden sonst nur Pseudoartikel angezeigt und PitStop-Artikel mit CSO 073. Das sind aber nur wenige.
                //    //// Möglicherweise muss die Abfrage unten später erweitert werden
                //    //fsaForLogistik = string.Format("{0:000}.{1:000}.{2:000}", req.Firma, 0, 0);
                //    //fsa = string.Format("{0:000}.{1:000}.{2:000}", req.Firma, req.Standort, req.Abteilung);
                //}
                if (string.IsNullOrEmpty(req.AlternativeCSO))
                {
                    cso = req.Firma.ToString("000");
                    fsaForLogistik = string.Format("{0:000}.{1:000}.{2:000}", req.Firma, 0, 0);
                    fsa = string.Format("{0:000}.{1:000}.{2:000}", req.Firma, req.Standort, req.Abteilung);
                }
                else
                {
                    cso = req.AlternativeCSO;
                    fsaForLogistik = string.Format("{0}.{1:000}.{2:000}", req.AlternativeCSO, 0, 0);
                    fsa = string.Format("{0}.{1:000}.{2:000}", req.AlternativeCSO, req.Standort, req.Abteilung);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(alternativeCSO))
                {
                    cso = firmaId.ToString("000");
                }
                else
                {
                    cso = alternativeCSO;
                }
            }

            var context = new ServiceContext();
            if (req == null)
            {
                context = new ServiceContext(cso, fsa, 0, 0, 0, fsaForLogistik);
            }
            else
            {
                context = new ServiceContext(cso, fsa, req.Absatzgruppe, req.Kundengruppe, 0, fsaForLogistik);
                context.IsStahlgruberAbfrage = req.IsStahlgruberAbfrage;
            }

            if (csoArtikelSuchtyp != CsoArtikelSuchtyp.None)
            {
                var csoFuerArtikelsuche = DataHolder.Instance.CsoFuerArtikelsuche.Where(x => x.CsoCode == cso).FirstOrDefault();
                if (csoFuerArtikelsuche != null)
                {
                    switch (csoArtikelSuchtyp)
                    {
                        case CsoArtikelSuchtyp.Nummernsuche:
                            context.CsoCodeZugelassen = csoFuerArtikelsuche.AnzeigeNummernsuche;
                            context.CsoCodeNichtZugelassen = csoFuerArtikelsuche.NichtAnzeigenNummernsuche;
                            break;
                        case CsoArtikelSuchtyp.Suchbaumsuche:
                            context.CsoCodeZugelassen = csoFuerArtikelsuche.AnzeigeSuchbaum;
                            context.CsoCodeNichtZugelassen = csoFuerArtikelsuche.NichtAnzeigenSuchbaum;
                            break;
                        case CsoArtikelSuchtyp.Teaser:
                            context.CsoCodeZugelassen = csoFuerArtikelsuche.AnzeigeTeaser;
                            context.CsoCodeNichtZugelassen = csoFuerArtikelsuche.NichtAnzeigenTeaser;
                            break;
                    }
                    context.WeitereHersteller_beruecksichtigen = csoFuerArtikelsuche.WeitereHersteller_beruecksichtigen;
                }
                else
                {
                    context.WeitereHersteller_beruecksichtigen = true;
                }
            }

            return context;
        }

        private int GetMobileMaxAnzahl
        {
            get
            {
                int val = 20;
                //int.TryParse(ConfigurationManager.AppSettings["mobileMaxAnzArtikelproAufruf"], out val);

                return val;
            }
        }

        private static WaitCallback SafelyExecuteActionAndSetEvent(Action actionToExecute)
        {
            return SafelyExecuteActionAndSetEvent(actionToExecute, false);
        }

        private static WaitCallback SafelyExecuteActionAndSetEvent(Action actionToExecute, bool logException)
        {
            return state =>
            {
                try
                {
                    actionToExecute();
                }
                catch// (Exception ex)
                {
                }
                (state as ManualResetEvent).Set();
            };
        }

        private string ermittleGenArt(List<int> genArtList, int genArtId, string genArtBez)
        {
            string genArtBezeichnung = string.Empty;

            if (genArtList != null && genArtList.Count > 0)
            {
                if (genArtList.Count > 1)
                {
                    genArtBezeichnung = "Doppelclick im Suchbaum: " + genArtBez + ", IDs: " + string.Join(",", genArtList.Select(x => x));
                }
                else
                {
                    genArtBezeichnung = genArtBez + ", ID: " + genArtList.First();
                }
            }
            else
            {
                genArtBezeichnung = genArtBez + ", ID: " + genArtId.ToString();
            }

            return genArtBezeichnung;
        }

        private void setxTypArtAndxTypNr(PV.DomainObjects.Artikel.Artikel kompassArtikel, int xTypNr, ArtikelArt artikelArt, int vehicleId)
        {
            kompassArtikel.XTypNr = xTypNr;
            kompassArtikel.VehicleId = vehicleId;

            switch (artikelArt)
            {
                case ArtikelArt.PKW:
                    kompassArtikel.XTypArt = GebrauchsmusterArt.Pkw;
                    break;
                case ArtikelArt.NKW:
                    kompassArtikel.XTypArt = GebrauchsmusterArt.Nkw;
                    break;
                case ArtikelArt.Achse:
                    kompassArtikel.XTypArt = GebrauchsmusterArt.Achse;
                    break;
                case ArtikelArt.Motor:
                    kompassArtikel.XTypArt = GebrauchsmusterArt.Motor;
                    break;
            }
        }

        private string getSuchbaumTyp(string name, bool isStartseitenartikelsuche = false)
        {
            var suchbaumTypName = string.Empty;
            if (isStartseitenartikelsuche)
            {
                suchbaumTypName = "Startseitenartikelsuche " + name;
            }
            else
            {
                suchbaumTypName = name;
            }

            return suchbaumTypName;
        }
    }
}
