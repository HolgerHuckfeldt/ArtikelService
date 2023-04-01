using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Absolute.SolrClient0900;

using log4net;
using PvKatalogsystem.Services.Services.Solr.Documents.Artikel;
using PvKatalogsystem.Services.Services.Solr.Mapper;
using PvKatalogsystem.Types.DTOs;
using PvKatalogsystem.Types.Enums;
using PvKatalogsystem.Types.Interfaces;
using PvKatalogsystem.Types.Results;


namespace ArtikelService.Services
{
    public class ArtikelService : IArtikelService
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly CultureInfo _culture = new CultureInfo("en-US");
        //readonly Fallback.FallbackHandler _fallbackHandler = new FallbackHandler();
        private ArtikelService()
        {
            //SolrSerializer<ArtikelDoc>.RegisterTypeKonverter(typeof(ArtikelDoc), new SolrArtikelDocConverter());
        }

        public ArtikelService(string connectionString, string connectionString_sec)
            : this()
        {
            //_fallbackHandler.Switch = delegate (bool primary)
            //{
            //    _primaryServer = primary;
            //};
            //_fallbackHandler.TimerClick = HealthTimerCallback;
            //_fallbackHandler.Name = "ArtikelService auf " + connectionString;
            
            try
            {
                _index_prim = new SolrIndex<ArtikelDoc>(connectionString);

                _sortIndex_prim = new SolrIndex<ArtikelSortDoc>(connectionString);
                _stuecklistenIndex_prim = new SolrIndex<StuecklisteDoc>(connectionString);
                _tauschartikelIndex_prim = new SolrIndex<TauschartikelDoc>(connectionString);
                _dokumentIndex_prim = new SolrIndex<DokumentDoc>(connectionString);
                //_pkwService_prim = SafeServiceLocator<IPkwService>.GetService();
                //_lkwService_prim = SafeServiceLocator<ILkwService>.GetService();
                //_achseService_prim = SafeServiceLocator<IAchseService>.GetService();
                //_motorService_prim = SafeServiceLocator<IMotorService>.GetService();
                _verwandteartikelIndex_prim = new SolrIndex<VerwandteArtikelDoc>(connectionString);
                _logistikInfosIndex_prim = new SolrIndex<LogistikinfosDoc>(connectionString);
                _nummernIndex_prim = new SolrIndex<NummernDoc>(connectionString);
                _gefahrgutIndex_prim = new SolrIndex<GefahrgutInfosDoc>(connectionString);
                _fahrzeugIdsIndex_prim = new SolrIndex<FahrzeugIdsDoc>(connectionString);
                _dokumentUndLinksIndex_prim = new SolrIndex<DokumentUndLinksDoc>(connectionString);

            }
            catch
            {
                _primaryServer = false;
            }

            _index_sec = new SolrIndex<ArtikelDoc>(connectionString_sec);
            _sortIndex_sec = new SolrIndex<ArtikelSortDoc>(connectionString_sec);
            _stuecklistenIndex_sec = new SolrIndex<StuecklisteDoc>(connectionString_sec);
            _tauschartikelIndex_sec = new SolrIndex<TauschartikelDoc>(connectionString_sec);
            _dokumentIndex_sec = new SolrIndex<DokumentDoc>(connectionString_sec);
            //_pkwService_sec = SafeServiceLocator<IPkwService>.GetService();
            //_lkwService_sec = SafeServiceLocator<ILkwService>.GetService();
            //_achseService_sec = SafeServiceLocator<IAchseService>.GetService();
            //_motorService_sec = SafeServiceLocator<IMotorService>.GetService();
            _verwandteartikelIndex_sec = new SolrIndex<VerwandteArtikelDoc>(connectionString_sec);
            _logistikInfosIndex_sec = new SolrIndex<LogistikinfosDoc>(connectionString_sec);
            _nummernIndex_sec = new SolrIndex<NummernDoc>(connectionString_sec);
            _gefahrgutIndex_sec = new SolrIndex<GefahrgutInfosDoc>(connectionString_sec);
            _fahrzeugIdsIndex_sec = new SolrIndex<FahrzeugIdsDoc>(connectionString_sec);
            _dokumentUndLinksIndex_sec = new SolrIndex<DokumentUndLinksDoc>(connectionString_sec);


        }


        private bool _primaryServer = true;

        private void CheckPrimHealth()
        {
            if (!_index_prim.Initialized)
                _primaryServer = false;
        }

        private ISolrIndex<ArtikelDoc> _index
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _index_prim : _index_sec;
            }
        }

        private ISolrIndex<ArtikelSortDoc> _sortIndex
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _sortIndex_prim : _sortIndex_sec;
            }
        }

        private ISolrIndex<StuecklisteDoc> _stuecklistenIndex
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _stuecklistenIndex_prim : _stuecklistenIndex_sec;
            }
        }

        private ISolrIndex<VerwandteArtikelDoc> _verwandteartikelIndex
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _verwandteartikelIndex_prim : _verwandteartikelIndex_sec;
            }
        }

        private ISolrIndex<LogistikinfosDoc> _logistikInfosIndex
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _logistikInfosIndex_prim : _logistikInfosIndex_sec;
            }
        }

        private ISolrIndex<NummernDoc> _nummernIndex
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _nummernIndex_prim : _nummernIndex_sec;
            }
        }

        private ISolrIndex<GefahrgutInfosDoc> _gefahrgutIndex
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _gefahrgutIndex_prim : _gefahrgutIndex_sec;
            }
        }

        private ISolrIndex<FahrzeugIdsDoc> _fahrzeugIdsIndex
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _fahrzeugIdsIndex_prim : _fahrzeugIdsIndex_sec;
            }
        }

        private ISolrIndex<TauschartikelDoc> _tauschartikelIndex
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _tauschartikelIndex_prim : _tauschartikelIndex_sec;
            }
        }

        private ISolrIndex<DokumentDoc> _dokumentIndex
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _dokumentIndex_prim : _dokumentIndex_sec;
            }
        }

        private ISolrIndex<DokumentUndLinksDoc> _dokumentUndLinksIndex
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _dokumentUndLinksIndex_prim : _dokumentUndLinksIndex_sec;
            }
        }

        private IPkwService _pkwService
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _pkwService_prim : _pkwService_sec;
            }
        }

        private ILkwService _lkwService
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _lkwService_prim : _lkwService_sec;
            }
        }

        private IAchseService _achseService
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _achseService_prim : _achseService_sec;
            }
        }

        private IMotorService _motorService
        {
            get
            {
                CheckPrimHealth();

                return _primaryServer ? _motorService_prim : _motorService_sec;
            }
        }

        private readonly ISolrIndex<ArtikelDoc> _index_prim;
        private readonly ISolrIndex<ArtikelSortDoc> _sortIndex_prim;
        private readonly ISolrIndex<StuecklisteDoc> _stuecklistenIndex_prim;
        private readonly ISolrIndex<VerwandteArtikelDoc> _verwandteartikelIndex_prim;
        private readonly ISolrIndex<LogistikinfosDoc> _logistikInfosIndex_prim;
        private readonly ISolrIndex<NummernDoc> _nummernIndex_prim;
        private readonly ISolrIndex<GefahrgutInfosDoc> _gefahrgutIndex_prim;
        private readonly ISolrIndex<FahrzeugIdsDoc> _fahrzeugIdsIndex_prim;
        private readonly ISolrIndex<TauschartikelDoc> _tauschartikelIndex_prim;
        private readonly ISolrIndex<DokumentDoc> _dokumentIndex_prim;
        private readonly ISolrIndex<DokumentUndLinksDoc> _dokumentUndLinksIndex_prim;
        private readonly IPkwService _pkwService_prim;
        private readonly ILkwService _lkwService_prim;
        private readonly IAchseService _achseService_prim;
        private readonly IMotorService _motorService_prim;

        private readonly ISolrIndex<ArtikelDoc> _index_sec;
        private readonly ISolrIndex<ArtikelSortDoc> _sortIndex_sec;
        private readonly ISolrIndex<StuecklisteDoc> _stuecklistenIndex_sec;
        private readonly ISolrIndex<VerwandteArtikelDoc> _verwandteartikelIndex_sec;
        private readonly ISolrIndex<LogistikinfosDoc> _logistikInfosIndex_sec;
        private readonly ISolrIndex<NummernDoc> _nummernIndex_sec;
        private readonly ISolrIndex<GefahrgutInfosDoc> _gefahrgutIndex_sec;
        private readonly ISolrIndex<FahrzeugIdsDoc> _fahrzeugIdsIndex_sec;
        private readonly ISolrIndex<TauschartikelDoc> _tauschartikelIndex_sec;
        private readonly ISolrIndex<DokumentDoc> _dokumentIndex_sec;
        private readonly ISolrIndex<DokumentUndLinksDoc> _dokumentUndLinksIndex_sec;
        private readonly IPkwService _pkwService_sec;
        private readonly ILkwService _lkwService_sec;
        private readonly IAchseService _achseService_sec;
        private readonly IMotorService _motorService_sec;

        public Artikel GetArtikel(ServiceContext context, int artikelId, bool mitTauschartikel,
            bool mitTopProdukt = false,
            bool mobileArtikeldetails = false, Fahrzeugart fzgArt = null, int fzgId = 0)
        {
            try
            {
                string fzgIdent = string.Empty;
                if (fzgArt != null && fzgArt != Fahrzeugart.Ohne && fzgId > 0)
                {
                    fzgIdent = string.Format("{0}{1}", fzgArt.Name, fzgId);
                }

                var list = GetArtikelList(context, new int[] { artikelId }, mitTauschartikel, mitTopProdukt, false, false,
                    null, 0, fzgIdent, mobileArtikeldetails);
                return list.FirstOrDefault();
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                if (OnNetworkError(context, ex))

                    return GetArtikel(context, artikelId, mitTauschartikel, mitTopProdukt, mobileArtikeldetails, fzgArt,
                        fzgId);
            }
            return new Artikel();
        }

        public List<Artikel> GetArtikelList(ServiceContext context, IEnumerable<int> idList, bool mitTauschartikel,
            bool mitTopProdukt = false,
            bool nurCSOpassendeArtikel = false, bool showNurLieferbar = false,
            List<KeyValuePair<int, int>> artIdZuGenArtId = null,
            int selectedGenArtNummer = 0, string fzgIdent = "", bool mobileArtikeldetails = false,
            bool usefzgIdentForFahrzeugId = false)
        {
            try
            {
                if (idList.Count() == 0)
                {
                    return new List<Artikel>();
                }

                var qDesc = _index.NewQueryDescription();
                var qBuilder = _index.NewQueryBuilder();
                var qSubBuilderIds = _index.NewQueryBuilder();
                var qSubBuilderLieferbar = _index.NewQueryBuilder();

                AddStandardDynamicFields(context, qDesc, fzgIdent);
                //bei Tauschartikel selber keine Tauschartikel anbieten
                if (mitTauschartikel)
                {
                    AddTauschartikel(context, qDesc);
                }

                qSubBuilderIds.Join(x => x.Id, SolrQueryOperator.Or, idList.Distinct());

                qBuilder.SubQuery(qSubBuilderIds);

                if (nurCSOpassendeArtikel)
                {
                    var csoFields = AddCsoFields(context, showNurLieferbar);

                    qBuilder
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(csoFields);
                }

                if (usefzgIdentForFahrzeugId)
                {
                    qBuilder.Operator(SolrQueryOperator.And)
                        .Expression(x => x.FahrzeugId, fzgIdent);
                }

                qDesc.RowCount = int.MaxValue;
                qDesc.Query = qBuilder.Create();

                var result = _index.QueryEx(qDesc);

                var sortedResult = new List<ArtikelDoc>();
                foreach (var id in idList)
                {
                    var doc = result.Documents.SingleOrDefault(x => x.Id == id.ToString());
                    if (doc != null)
                    {
                        sortedResult.Add(doc);
                    }
                }

                var artikelList = ArtikelMapper.Map(sortedResult, selectedGenArtNummer, null, mitTopProdukt,
                    TeaserTyp.NICHTS, artIdZuGenArtId, mobileArtikeldetails);

                return artikelList;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                if (OnNetworkError(context, ex))
                    return GetArtikelList(context, idList, mitTauschartikel, mitTopProdukt, nurCSOpassendeArtikel,
                        showNurLieferbar, artIdZuGenArtId, selectedGenArtNummer, fzgIdent, mobileArtikeldetails,
                        usefzgIdentForFahrzeugId);
            }
            return new List<Artikel>();
        }

        public ArtikelSearchResult FindArtikelByVdbArtikelnummerPrefix(ServiceContext context, string vdbHlk,
            string vdbArtikelnummerPrefix, bool mitTauschartikel, bool mitTopProdukt = false)
        {
            try
            {
                var qDesc = _index.NewQueryDescription();
                var qBuilder = _index.NewQueryBuilder();

                AddStandardDynamicFields(context, qDesc);
                //bei Tauschartikel selber keine Tauschartikel anbieten
                if (mitTauschartikel)
                {
                    // ExterneArtikedaten.PimsCsofuerArtikelsuche beruecksichtigen

                    AddTauschartikel(context, qDesc);
                }

                qDesc.RowCount = int.MaxValue;
                qDesc.AddSortField(x => x.Artikelnummer, SolrSortDirection.Asc);

                qDesc.Query = qBuilder
                    .Expression(x => x.VdbArtikelnummer, vdbArtikelnummerPrefix + "*")
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.VdbHerstellerkuerzel, vdbHlk)
                    .Create();

                var qResult = _index.QueryEx(qDesc);

                var result = new ArtikelSearchResult(qResult.NumFound, qResult.StartIndex, int.MaxValue);
                result.Artikel = ArtikelMapper.Map(qResult.Documents, 0, null, mitTopProdukt);
                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                if (OnNetworkError(context, ex))
                    return FindArtikelByVdbArtikelnummerPrefix(context, vdbHlk,
                        vdbArtikelnummerPrefix, mitTauschartikel, mitTopProdukt);
            }
            return new ArtikelSearchResult(0, 0, 0);
        }

        private SolrQueryBuilder<ArtikelDoc> AddCsoFields(ServiceContext context, bool showNurLieferbar = false,
            bool keinePseudoartikel = false, bool mitWeiterenHerstellern = false)
        {

            var qSubBuilderCso = _index.NewQueryBuilder();
            var qSubBuilderCsoNegativ = _index.NewQueryBuilder();
            var qSubBuilderPseudo = _index.NewQueryBuilder();
            var qSubBuilderIsLieferbar = _index.NewQueryBuilder();

            bool mitqSubBuilderCsoNegativ = false;

            if (context.CsoCodeZugelassen != null && context.CsoCodeZugelassen.Count > 0)
            {
                mitqSubBuilderCsoNegativ = ApplyNichtZugelasseneCsos(context, qSubBuilderCsoNegativ);

                if ((!context.MitWeiterenHerstellern && !mitWeiterenHerstellern) ||
                    !context.WeitereHersteller_beruecksichtigen)
                {
                    qSubBuilderCso.Join(x => x.CsoCode, SolrQueryOperator.Or, context.CsoCodeZugelassen.Distinct());

                    if (showNurLieferbar)
                    {
                        qSubBuilderIsLieferbar.Expression(x => x.IsLieferbar, true);

                        if (context.IsStahlgruberAbfrage)
                        {
                            qSubBuilderIsLieferbar
                                .Operator(SolrQueryOperator.Or)
                                .Expression(x => x.IsStahlgruberArtikel, true);
                        }

                        if (mitqSubBuilderCsoNegativ)
                            qSubBuilderCsoNegativ.Operator(SolrQueryOperator.And)
                                .SubQuery(qSubBuilderCso)
                                .Operator(SolrQueryOperator.And)
                                .SubQuery(qSubBuilderIsLieferbar);
                        else
                        {

                        }


                    }
                    else
                    {
                        if (mitqSubBuilderCsoNegativ)
                            qSubBuilderCsoNegativ.Operator(SolrQueryOperator.And)
                                .SubQuery(qSubBuilderCso);
                    }
                }
                else
                {
                    qSubBuilderCso.Expression(x => x.CsoCode, "*");

                    if (mitqSubBuilderCsoNegativ)
                    {
                        qSubBuilderCsoNegativ.Operator(SolrQueryOperator.And)
                            .SubQuery(qSubBuilderCso);
                    }
                }
            }
            else
            {
                if (!context.MitWeiterenHerstellern && !mitWeiterenHerstellern)
                {
                    qSubBuilderCso
                        .Expression(x => x.CsoCode, context.CsoCode);
                }
                else
                {
                    qSubBuilderCso.Expression(x => x.CsoCode, "*");
                }

                if (showNurLieferbar)
                {
                    qSubBuilderIsLieferbar.Expression(x => x.IsLieferbar, true);

                    if (context.IsStahlgruberAbfrage)
                    {
                        qSubBuilderIsLieferbar
                            .Operator(SolrQueryOperator.Or)
                            .Expression(x => x.IsStahlgruberArtikel, true);
                    }

                    qSubBuilderCso.Operator(SolrQueryOperator.And)
                        .SubQuery(qSubBuilderIsLieferbar);
                }
            }

            if (keinePseudoartikel)
            {
                if (mitqSubBuilderCsoNegativ)
                {
                    qSubBuilderPseudo.Operator(SolrQueryOperator.And)
                        .SubQuery(qSubBuilderCsoNegativ);
                }
                else
                {
                    qSubBuilderPseudo.Operator(SolrQueryOperator.And)
                        .SubQuery(qSubBuilderCso);
                }
            }
            else
            {
                if (mitqSubBuilderCsoNegativ)
                {
                    qSubBuilderPseudo.Operator(SolrQueryOperator.And)
                        .SubQuery(qSubBuilderCsoNegativ)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.IsPseudoartikel, true);
                }
                else
                {
                    qSubBuilderPseudo.Operator(SolrQueryOperator.And)
                        .SubQuery(qSubBuilderCso)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.IsPseudoartikel, true);
                }
            }

            return qSubBuilderPseudo;

        }

        private static bool ApplyNichtZugelasseneCsos(ServiceContext context,
            SolrQueryBuilder<ArtikelDoc> qSubBuilderCsoNegativ)
        {
            bool mitqSubBuilderCsoNegativ = false;
            if (context.CsoCodeNichtZugelassen != null && context.CsoCodeNichtZugelassen.Count > 0)
            {
                for (int cso = 0; cso < context.CsoCodeNichtZugelassen.Count; ++cso)
                {
                    if (cso > 0)
                        qSubBuilderCsoNegativ.Operator(SolrQueryOperator.And);

                    qSubBuilderCsoNegativ.NegativeExpression(x => x.CsoCode, context.CsoCodeNichtZugelassen[cso]);
                }
                mitqSubBuilderCsoNegativ = true;
            }
            return mitqSubBuilderCsoNegativ;

        }

        private SolrQueryBuilder<ArtikelDoc> AddCsoFieldsMobile(ServiceContext context)
        {

            var qSubBuilderCso = _index.NewQueryBuilder();
            var qSubBuilderCsoNegativ = _index.NewQueryBuilder();
            var qSubBuilderPseudo = _index.NewQueryBuilder();
            var qSubBuilderIsLieferbar = _index.NewQueryBuilder();

            bool mitqSubBuilderCsoNegativ = false;

            if (context.CsoCodeZugelassen != null && context.CsoCodeZugelassen.Count > 0)
            {
                if (context.CsoCodeNichtZugelassen != null && context.CsoCodeNichtZugelassen.Count > 0)
                {
                    for (int cso = 0; cso < context.CsoCodeNichtZugelassen.Count; ++cso)
                    {
                        if (cso > 0)
                            qSubBuilderCsoNegativ.Operator(SolrQueryOperator.And);

                        qSubBuilderCsoNegativ.NegativeExpression(x => x.CsoCode, context.CsoCodeNichtZugelassen[cso]);
                    }
                    mitqSubBuilderCsoNegativ = true;
                }

                qSubBuilderCso.Join(x => x.CsoCode, SolrQueryOperator.Or, context.CsoCodeZugelassen.Distinct());

                qSubBuilderIsLieferbar.Expression(x => x.IsLieferbar, true);

                if (mitqSubBuilderCsoNegativ)
                {
                    qSubBuilderCsoNegativ.Operator(SolrQueryOperator.And)
                        .SubQuery(qSubBuilderCso)
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(qSubBuilderIsLieferbar);
                }
                else
                {

                }
            }
            else
            {
                qSubBuilderCso
                    .Expression(x => x.CsoCode, context.CsoCode);

                qSubBuilderIsLieferbar.Expression(x => x.IsLieferbar, true);

                qSubBuilderCso.Operator(SolrQueryOperator.And)
                    .SubQuery(qSubBuilderIsLieferbar);
            }

            if (mitqSubBuilderCsoNegativ)
            {
                qSubBuilderPseudo.Operator(SolrQueryOperator.And)
                    .SubQuery(qSubBuilderCsoNegativ);
            }
            else
            {
                qSubBuilderPseudo.Operator(SolrQueryOperator.And)
                    .SubQuery(qSubBuilderCso);
            }

            return qSubBuilderPseudo;

        }

        private void AddStandardDynamicFields(ServiceContext context, SolrQueryDescription<ArtikelDoc> qDesc,
            string fzgIdent = null)
        {

            qDesc.AddDynamicFieldKey(x => x.Verkaufspreis, context.Preisgruppe);
            qDesc.AddDynamicFieldKey(x => x.AktionsnummerAbsatzgruppe, context.Absatzgruppe);
            qDesc.AddDynamicFieldKey(x => x.AktionsnummerKundengruppe, context.Kundengruppe);
            qDesc.AddDynamicFieldKey(x => x.AktionsnummerPreisgruppe, context.Preisgruppe);

            qDesc.AddDynamicFieldKey(x => x.Logistikinfo, context.FSAForLogistik);
            qDesc.AddDynamicFieldKey(x => x.Logistikinfo, "000.000.000");

            if (!string.IsNullOrEmpty(fzgIdent))
            {
                qDesc.AddDynamicFieldKey(x => x.Attributblock, fzgIdent);
                qDesc.AddDynamicFieldKey(x => x.InformationByFahrzeug, fzgIdent);
                qDesc.AddDynamicFieldKey(x => x.Artikelsortiernummer, fzgIdent);
            }
        }

        private void AddTauschartikel(ServiceContext context, SolrQueryDescription<ArtikelDoc> qDesc)
        {
            // ExterneArtikedaten.PimsCsofuerArtikelsuche beruecksichtigen
            if (context.CsoCodeZugelassen != null && context.CsoCodeZugelassen.Count > 0)
            {
                foreach (var ccode in context.CsoCodeZugelassen)
                {
                    qDesc.AddDynamicFieldKey(x => x.Tauschartikel, ccode);
                }
            }
            else
            {
                qDesc.AddDynamicFieldKey(x => x.Tauschartikel, context.CsoCode);
            }
        }

        private void AddStandardNummerSucheExpression(SolrQueryBuilder<ArtikelDoc> qSubBuilder, string suchtext)
        {
            qSubBuilder
                .Expression(x => x.Artikelnummer, string.Format("\"{0}\"", suchtext), 100000)
                .Operator(SolrQueryOperator.Or)
                .Expression(x => x.ArtikelnummerSuche, string.Format("\"{0}\"", suchtext), 50000)
                .Operator(SolrQueryOperator.Or)
                .Expression(x => x.ArtikelnummerSuche, QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*",
                    10000).Operator(SolrQueryOperator.Or)
                .Expression(x => x.EaNummer, string.Format("\"{0}\"", suchtext), 100000).Operator(SolrQueryOperator.Or)
                .Expression(x => x.EaNummer, QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*", 1000)
                .Operator(SolrQueryOperator.Or)
                .Expression(x => x.GebrauchsnummerSuche, string.Format("\"{0}\"", suchtext), 500)
                .Operator(SolrQueryOperator.Or)
                .Expression(x => x.GebrauchsnummerSuche, QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*",
                    100).Operator(SolrQueryOperator.Or)
                .Expression(x => x.ReferenznummerSuche, string.Format("\"{0}\"", suchtext), 50)
                .Operator(SolrQueryOperator.Or)
                .Expression(x => x.ReferenznummerSuche, QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*",
                    10).Operator(SolrQueryOperator.Or)
                .Expression(x => x.Vergleichsnummer, string.Format("\"{0}\"", suchtext), 5)
                .Operator(SolrQueryOperator.Or)
                .Expression(x => x.Vergleichsnummer, QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*", 1)
                .Operator(SolrQueryOperator.Or);
        }

        public ArtikelDetails GetArtikelDetails(ServiceContext context, int artikelId, Fahrzeugart fahrzeugArt,
            int fahrzeugId)
        {
            try
            {
                var qDesc = _index.NewQueryDescription();
                var qBuilder = _index.NewQueryBuilder();

                string solrFahrzeugId = null;
                if (fahrzeugArt != Fahrzeugart.Ohne && fahrzeugId > 0)
                {
                    solrFahrzeugId = string.Format("{0}{1}", fahrzeugArt.Name, fahrzeugId);
                }


                //Thomas: kein subBuilder sonst können die Details vom Artikel "8120 38102" (Id: 233648785) 
                //nicht gefunden werden, denn der Artikel hat kein CSOCode und ist auch kein Pseudoartikel
                //var subBuilder = _index.NewQueryBuilder();
                //subBuilder
                //    .Expression(x => x.CsoCode, context.CsoCode)
                //    .Operator(SolrQueryOperator.Or)
                //    .Expression(x => x.IsPseudoartikel, true);

                if (Fahrzeugart.Ohne == fahrzeugArt)
                {
                    qDesc.Query = qBuilder
                        .Expression(x => x.Id, artikelId)
                        .Operator(SolrQueryOperator.And)
                        //.SubQuery(subBuilder)
                        .Create();
                }
                else
                {
                    qDesc.Query = qBuilder
                        .Expression(x => x.Id, artikelId)
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.FahrzeugId, solrFahrzeugId)
                        .Operator(SolrQueryOperator.And)
                        //.SubQuery(subBuilder)
                        .Create();
                }

                AddStandardDynamicFields(context, qDesc, solrFahrzeugId);

                var qResult = _index.QueryEx(qDesc);
                if (qResult.Documents.Count == 0)
                {
                    return null;
                }
                var doc = qResult.Documents.First();

                var artikel = ArtikelMapper.Map(doc);
                var subArtikel = LoadUnterartikel(doc, context);

                var artikelDetails = ArtikelDetailsMapper.Map(doc, subArtikel);

                if (doc.FahrzeugId != null)
                {
                    var pkwIdList = new List<int>();
                    var lkwIdList = new List<int>();
                    var achseIdList = new List<int>();
                    var motorIdList = new List<int>();

                    var regex = new Regex(@"^([A-Z]+)(\d+)$");
                    foreach (var item in doc.FahrzeugId)
                    {
                        var match = regex.Match(item);
                        if (!match.Success)
                        {
                            continue;
                        }
                        var typ = match.Groups[1].Value;
                        var id = int.Parse(match.Groups[2].Value);
                        switch (typ)
                        {
                            case "PC":
                                pkwIdList.Add(id);
                                break;
                            case "CV":
                                lkwIdList.Add(id);
                                break;
                            case "AX":
                                achseIdList.Add(id);
                                break;
                            case "ENG":
                                motorIdList.Add(id);
                                break;
                        }
                    }
                    var verwendetIn = new ArtikelVerwendetIn();
                    verwendetIn.Pkws = _pkwService.GetPkwList(pkwIdList.Take(50));
                    verwendetIn.Lkws = _lkwService.GetLkwList(lkwIdList.Take(50));
                    verwendetIn.Achsen = _achseService.GetAchseList(achseIdList.Take(50));
                    verwendetIn.Motoren = _motorService.GetMotorList(motorIdList.Take(50));
                    artikelDetails.VerwendetIn = verwendetIn;

                }

                //Staffelpreise
                try
                {
                    //var _vdbService = SafeServiceLocator<IVdbService>.GetService();
                    //artikelDetails.Staffelpreise = _vdbService.GetStaffelPreise(context,
                    //    artikel.VdbInformationen.Identifikator);
                }
                catch (Exception ex)
                {
                    LogManager.GetLogger("ArtikelService").Error("Fehler beim ermitteln der Staffelpreise.", ex);
                }



                return artikelDetails;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                if (OnNetworkError(context, ex))
                    return GetArtikelDetails(context, artikelId, fahrzeugArt, fahrzeugId);
            }
            return new ArtikelDetails();
        }

        public List<Dokument> GetArtikelDokumente(ServiceContext context, int artikelId)
        {
            try
            {
                var qDesc = _dokumentIndex.NewQueryDescription();
                var qBuilder = _dokumentIndex.NewQueryBuilder();

                qDesc.Query = qBuilder
                    .Expression(x => x.Id, artikelId)
                    .Create();

                var result = _dokumentIndex.QueryEx(qDesc);
                if (result.Documents != null && result.Documents.Count > 0)
                    return DokumentMapper.Map(result.Documents.First());
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                if (OnNetworkError(context, ex))
                    return GetArtikelDokumente(context, artikelId);
            }

            return new List<Dokument>();
        }

        public ArtikelSearchResult FindArtikelByGenArtAndTyp(ServiceContext context, Fahrzeugart fzgArt, int fzgId,
            int genArtId, int genArtIdTecDoc, int startIndex, int rowCount)
        {
            try
            {
                var qDesc = _index.NewQueryDescription();
                var qBuilder = _index.NewQueryBuilder();
                var fzgIdent = string.Format("{0}{1}", fzgArt.Name, fzgId);

                var csoFields = _index.NewQueryBuilder();

                csoFields = AddCsoFields(context, false);

                qBuilder
                    .SubQuery(csoFields);

                if (genArtIdTecDoc > 0)
                {
                    qBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.GenArtNummer, genArtIdTecDoc);
                }
                else
                {
                    qBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.GenArtId, genArtId);
                }

                if (fzgArt != Fahrzeugart.Ohne && fzgId > 0)
                {
                    qBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.FahrzeugId, fzgIdent);
                }

                qDesc.Query = qBuilder.Create();

                qDesc.StartIndex = startIndex;
                qDesc.RowCount = rowCount;

                AddStandardDynamicFields(context, qDesc, fzgIdent);
                AddTauschartikel(context, qDesc);

                var qResult = _index.QueryEx(qDesc);

                var result = new ArtikelSearchResult(qResult.NumFound, qResult.StartIndex, rowCount);
                result.Artikel = ArtikelMapper.Map(qResult.Documents);

                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                if (OnNetworkError(context, ex))
                    return FindArtikelByGenArtAndTyp(context, fzgArt, fzgId, genArtId, genArtIdTecDoc, startIndex,
                        rowCount);
            }
            return new ArtikelSearchResult(0, 0, 0);
        }

        public ArtikelSearchResult FindArtikelBySuchtext(ServiceContext context, string suchtext, Suchbaumtyp sbTyp,
            Fahrzeugart fzgArt, int fzgId, int genArtId, int startIndex, int rowCount, bool suchstringFuerHersteller,
            bool mobile = false)
        {
            try
            {
                var qDesc = _index.NewQueryDescription();
                var qBuilder = _index.NewQueryBuilder();
                var qSubBuilder = _index.NewQueryBuilder();
                var qSubBuilderGenArtFahrzeug = _index.NewQueryBuilder();
                var fzgIdent = string.Format("{0}{1}", fzgArt.Name, fzgId);
                var qSubBuilderLieferbar = _index.NewQueryBuilder();

                string queryString = string.Format("(\"{0}\") OR ({0}) OR ({0}*) OR (*{1})",
                    QuoteString(suchtext.ToLower()), QuoteString(suchtext.ToLower()));


                if (suchstringFuerHersteller)
                {
                    qSubBuilder
                        .Expression(x => x.Herstellername, suchtext.Replace(" ", ""));
                }
                else
                {
                    qSubBuilder
                        .DefaultExpressionOhneStringify(queryString)
                        .Operator(SolrQueryOperator.Or);

                    if (sbTyp == Suchbaumtyp.Universal)
                    {
                        qSubBuilder
                            .Expression(x => x.Matchcode, suchtext)
                            .Operator(SolrQueryOperator.Or);
                    }

                    AddStandardNummerSucheExpression(qSubBuilder, suchtext);
                }

                var csoFields = _index.NewQueryBuilder();
                if (mobile)
                {
                    csoFields = AddCsoFieldsMobile(context);
                }
                else
                {
                    csoFields = AddCsoFields(context, true);
                }

                qBuilder
                    .SubQuery(qSubBuilder)
                    .Operator(SolrQueryOperator.And)
                    .SubQuery(csoFields)
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.Suchbaumtyp, sbTyp.Name);

                qDesc.AddSortField(x => x.IsLieferbar, SolrSortDirection.Desc);

                var listGenArtFahrzeugId = new List<string>();
                if (genArtId > 0)
                {
                    if (fzgArt != Fahrzeugart.Ohne && fzgId > 0)
                    {
                        fzgIdent = string.Format("{0}{1}", fzgArt.Name, fzgId);
                        qBuilder
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.FahrzeugId, fzgIdent)
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.GenArtIdFahrzeug, string.Format("{0}¦{1}", genArtId, fzgIdent));
                    }
                    else
                    {
                        qBuilder
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.GenArtId, genArtId);
                    }
                }
                else
                {

                    if (fzgArt != Fahrzeugart.Ohne && fzgId > 0)
                    {
                        listGenArtFahrzeugId = GetGenArtFahrzeugId(context, suchtext, sbTyp, fzgArt, fzgId, genArtId,
                            suchstringFuerHersteller);
                    }
                }

                if (listGenArtFahrzeugId.Count > 0)
                {
                    qSubBuilderGenArtFahrzeug
                        .Join(x => x.FzgGenArtId, SolrQueryOperator.Or, listGenArtFahrzeugId.Distinct());

                    qBuilder
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(qSubBuilderGenArtFahrzeug);
                }

                if (fzgArt != Fahrzeugart.Ohne && fzgId > 0)
                {
                    qBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.FahrzeugId, fzgIdent);
                }

                qDesc.Query = qBuilder.Create();

                var facetField = _index.GetFieldName(x => x.Breadcrumb, sbTyp.Name);
                var facet = new SolrFacetQuery(facetField, null, FacetSort.Index, int.MaxValue);
                qDesc.FacetQueries.Add(facet);

                qDesc.StartIndex = startIndex;
                qDesc.RowCount = rowCount;

                AddStandardDynamicFields(context, qDesc, fzgIdent);
                AddTauschartikel(context, qDesc);

                var qResult = _index.QueryEx(qDesc);
                //var qResult1 = _index.QueryEx_JSON(qDesc);
                var facetResult = qResult.Facets.SingleOrDefault(x => x.FieldName == facetField);

                var resultBreadcrumbs = new List<Suchbaumknoten>();
                if (facetResult != null)
                {
                    resultBreadcrumbs = SuchbaumknotenMapper.Map(facetResult.Counts.Select(x => x.Key), null,
                        listGenArtFahrzeugId.Count > 0 ? listGenArtFahrzeugId : null, 0, 0, 0, genArtId);
                }

                var result = new ArtikelSearchResult(qResult.NumFound, qResult.StartIndex, rowCount);
                result.Artikel = ArtikelMapper.Map(qResult.Documents, 0, resultBreadcrumbs);

                if (genArtId > 0)
                {
                    result.Artikel = sortArtikelList(result.Artikel, genArtId, 0, "");
                    if (result.Artikel.Count > 0)
                    {
                        result.Artikel = result.Artikel.Take(1000).ToList();
                    }
                }
                else if (facetResult != null)
                {
                    //Suche über GenArts
                    result.Artikel = sortArtikelList(result.Artikel, 0, 0, "", null, true);
                }

                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                if (OnNetworkError(context, ex))
                    return FindArtikelBySuchtext(context, suchtext, sbTyp,
                        fzgArt, fzgId, genArtId, startIndex, rowCount, suchstringFuerHersteller,
                        mobile);
            }
            return new ArtikelSearchResult(0, 0, 0);
        }

        private List<string> GetGenArtFahrzeugId(ServiceContext context, string suchtext, Suchbaumtyp sbTyp,
            Fahrzeugart fzgArt, int fzgId, int genArtId, bool suchstringFuerHersteller)
        {
            try
            {
                List<string> listGenArtFahrzeugId = new List<string>();

                var qDesc = _index.NewQueryDescription();
                var qBuilder = _index.NewQueryBuilder();
                var qSubBuilder = _index.NewQueryBuilder();
                var fzgIdent = string.Format("{0}{1}", fzgArt.Name, fzgId);
                var qSubBuilderLieferbar = _index.NewQueryBuilder();

                string queryString = string.Format("(\"{0}\") OR ({0}) OR ({0}*) OR (*{1})",
                    QuoteString(suchtext.ToLower()), QuoteString(suchtext.ToLower()));


                if (suchstringFuerHersteller)
                {
                    qSubBuilder
                        .Expression(x => x.Herstellername, suchtext.Replace(" ", ""));
                }
                else
                {
                    qSubBuilder
                        .DefaultExpressionOhneStringify(queryString)
                        .Operator(SolrQueryOperator.Or);

                    if (sbTyp == Suchbaumtyp.Universal)
                    {
                        qSubBuilder
                            .Expression(x => x.Matchcode, suchtext)
                            .Operator(SolrQueryOperator.Or);
                    }

                    AddStandardNummerSucheExpression(qSubBuilder, suchtext);
                }

                var csoFields = _index.NewQueryBuilder();

                csoFields = AddCsoFields(context, true);

                qBuilder
                    .SubQuery(qSubBuilder)
                    .Operator(SolrQueryOperator.And)
                    .SubQuery(csoFields)
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.Suchbaumtyp, sbTyp.Name);

                qDesc.AddSortField(x => x.IsLieferbar, SolrSortDirection.Desc);

                if (fzgArt != Fahrzeugart.Ohne && fzgId > 0)
                {
                    qBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.FahrzeugId, fzgIdent);
                }

                qDesc.Query = qBuilder.Create();

                var facetField = _index.GetFieldName(x => x.FzgGenArtId, "");

                var facet = new SolrFacetQuery(facetField, fzgIdent, FacetSort.Index, int.MaxValue, 1, FacetMethod.Enum);

                qDesc.FacetQueries.Add(facet);

                qDesc.StartIndex = 0;
                qDesc.RowCount = 0;

                AddStandardDynamicFields(context, qDesc, fzgIdent);

                var qResult = _index.QueryEx(qDesc);
                var facetResult = qResult.Facets.SingleOrDefault(x => x.FieldName == facetField);

                if (facetResult != null)
                {
                    listGenArtFahrzeugId = GenArtIdFahrzeugMapper.Map(facetResult.Counts.Select(x => x.Key), fzgIdent);
                }

                return listGenArtFahrzeugId;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                if (OnNetworkError(context, ex))
                    return GetGenArtFahrzeugId(context, suchtext, sbTyp,
                        fzgArt, fzgId, genArtId, suchstringFuerHersteller);
            }
            return new List<string>();
        }

        private ArtikelSearchResult FindArtikelSorted(ServiceContext context, string suchtext,
            ArtikelSuchoptionen options, int startIndex, int rowCount)
        {
            try
            {
                var qDesc = _sortIndex.NewQueryDescription();
                var qBuilder = _sortIndex.NewQueryBuilder();
                var fqBuilder = _sortIndex.NewQueryBuilder();
                var fqSubBuilder = _sortIndex.NewQueryBuilder();

                string breadCrumbFacetField = null;
                string genArtFacetField = null;

                //Suchtext

                #region Suchtext

                if (string.IsNullOrEmpty(suchtext))
                {
                    qBuilder.AllExpression();
                }
                else
                {
                    qBuilder.DefaultExpression(suchtext);
                }

                #endregion

                //SearchOnNumbers

                #region SearchOnNumbers

                if (options.SearchOnNumbers && !string.IsNullOrEmpty(suchtext))
                {
                    qBuilder
                        .Operator(SolrQueryOperator.Or);

                    qBuilder
                        .Expression(x => x.Artikelnummer, string.Format("\"{0}\"", suchtext), 100000)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.ArtikelnummerSuche, string.Format("\"{0}\"", suchtext), 50000)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.ArtikelnummerSuche,
                            QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*", 10000)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.EaNummer, string.Format("\"{0}\"", suchtext), 100000)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.EaNummer, QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*",
                            1000).Operator(SolrQueryOperator.Or)
                        .Expression(x => x.GebrauchsnummerSuche, string.Format("\"{0}\"", suchtext), 500)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.GebrauchsnummerSuche,
                            QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*", 100)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.ReferenznummerSuche, string.Format("\"{0}\"", suchtext), 50)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.ReferenznummerSuche,
                            QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*", 10)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.Vergleichsnummer, string.Format("\"{0}\"", suchtext), 5)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.Vergleichsnummer,
                            QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*", 1)
                        .Operator(SolrQueryOperator.Or);
                }

                #endregion

                //AktionenOnTop

                #region AktionenOnTop

                if (options.AktionenOnTop != null)
                {
                    foreach (var aktionsfilter in options.AktionenOnTop)
                    {
                        if (aktionsfilter.Absatzgruppe > 0)
                        {
                            qDesc.AddDynamicFieldKey(x => x.AktionsnummerAbsatzgruppe, aktionsfilter.Absatzgruppe);
                        }
                        if (aktionsfilter.Kundengruppe > 0)
                        {
                            qDesc.AddDynamicFieldKey(x => x.AktionsnummerKundengruppe, aktionsfilter.Kundengruppe);
                        }
                    }
                }

                #endregion

                //FilterQuery
                if (options.ShowOutletOnly)
                {
                    #region ShowOutletOnly

                    {
                        fqBuilder
                            .Expression(x => x.Aktionsnummer, 30);

                        //ShowAllPseudoartikel
                        if (options.ShowAllPseudoartikel)
                        {
                            fqBuilder
                                .Operator(SolrQueryOperator.And)
                                .Expression(x => x.IsPseudoartikel, true);
                        }

                        // Incentive Bundles ausschließen
                        fqBuilder
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.IsIncentiveBundle, false);
                    }

                    #endregion
                }
                else
                {
                    if (!string.IsNullOrEmpty(options.TeaserId))
                    {
                        //Themenwelt

                        #region Themenwelt

                        fqBuilder
                            .Expression(x => x.TeaserId, options.TeaserId);

                        fqBuilder
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.Aktionsnummer, options.Aktionsnummer);

                        #endregion

                    }
                    else
                    {
                        ////csoCode
                        //fqSubBuilder
                        //    .Expression(x => x.CsoCode, context.CsoCode);

                        fqSubBuilder
                            .Expression(x => x.Aktionsnummer, options.Aktionsnummer);

                        //ShowAllPseudoartikel
                        if (options.ShowAllPseudoartikel)
                        {
                            fqSubBuilder
                                .Operator(SolrQueryOperator.Or)
                                .Expression(x => x.IsPseudoartikel, true);
                        }
                        fqBuilder.SubQuery(fqSubBuilder);

                        // Incentive Bundles ausschließen
                        fqBuilder
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.IsIncentiveBundle, false);
                    }

                }


                //FahrzeugId
                if (options.Fahrzeug != null)
                {
                    var fzgIdent = string.Format("{0}{1}", options.Fahrzeug.Fahrzeugart.Name,
                        options.Fahrzeug.FahrzeugId);
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.FahrzeugId, fzgIdent);
                }


                //Hersteller

                #region Hersteller

                if (options.Herstellerkuerzel != null && options.Herstellerkuerzel.Count() > 0)
                {
                    var herstellerSubQuery = _sortIndex.NewQueryBuilder();
                    foreach (var hlk in options.Herstellerkuerzel)
                    {
                        herstellerSubQuery
                            .Operator(SolrQueryOperator.Or)
                            .Expression(x => x.VdbHerstellerkuerzel, hlk);
                    }
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(herstellerSubQuery);
                }

                #endregion

                //Artikelnummer

                #region Artikelnummer

                if (options.Artikelnummer != null && options.Artikelnummer.Count() > 0)
                {
                    var ArtikelnummerSubQuery = _sortIndex.NewQueryBuilder();
                    foreach (var item in options.Artikelnummer)
                    {
                        ArtikelnummerSubQuery
                            .Operator(SolrQueryOperator.Or)
                            .Expression(x => x.VdbArtikelnummer, item);
                    }
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(ArtikelnummerSubQuery);
                }

                #endregion

                //IsLieferbar

                #region IsLieferbar

                if (options.ShowNurLieferbar)
                {
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.IsLieferbar, true);
                }
                else
                {
                    qDesc.AddSortField(x => x.IsLieferbar, SolrSortDirection.Desc);
                }

                #endregion


                //isNfzUniversalArtikel
                fqBuilder
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.IsNfzUniversalArtikel, options.IsNfzUniversalArtikel);


                //Suchbaumtyp Suchbaumtyp und GenArt

                #region Suchbaumtyp und GenArt

                if (options.Suchbaumtyp != null)
                {
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.Suchbaumtyp, options.Suchbaumtyp.Name);

                    breadCrumbFacetField = _index.GetFieldName(x => x.Breadcrumb, options.Suchbaumtyp.Name);
                    qDesc.FacetQueries.Add(new SolrFacetQuery(breadCrumbFacetField, null, FacetSort.Index, int.MaxValue));
                }

                // GenArtFacets
                if (options.ShowGenArtFacets)
                {
                    genArtFacetField = _index.GetFieldName(x => x.GenerischerArtikel);
                    qDesc.FacetQueries.Add(new SolrFacetQuery(genArtFacetField, null, FacetSort.Index, int.MaxValue));
                }


                //GenArtId
                if (options.GenArtId > 0)
                {
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.GenArtId, options.GenArtId);
                }

                #endregion

                qDesc.Query = qBuilder.Create();
                qDesc.FilterQuery = fqBuilder.Create();

                qDesc.StartIndex = 0;
                qDesc.RowCount = int.MaxValue;

                var qResult = _sortIndex.QueryEx(qDesc);
                var idList = new List<int>();

                if (options.AktionenOnTop != null
                    && options.AktionenOnTop.Count() > 0
                    && (qResult.Documents.Any(x => x.AktionsnummerAbsatzgruppe != null)
                        || qResult.Documents.Any(x => x.AktionsnummerKundengruppe != null)))
                {
                    var aktionsList = new List<int>();
                    var otherList = new List<int>();
                    foreach (var doc in qResult.Documents)
                    {

                        foreach (var aktionsfilter in options.AktionenOnTop)
                        {

                            if (doc.AktionsnummerAbsatzgruppe != null &&
                                doc.AktionsnummerAbsatzgruppe.Any(x => x == aktionsfilter.Aktionsnummer)
                                ||
                                doc.AktionsnummerKundengruppe != null &&
                                doc.AktionsnummerKundengruppe.Any(x => x == aktionsfilter.Aktionsnummer))
                            {
                                aktionsList.Add(int.Parse(doc.Id));
                            }
                            else
                            {
                                otherList.Add(int.Parse(doc.Id));
                            }

                        }
                    }
                    idList.AddRange(aktionsList);
                    idList.AddRange(otherList);
                }
                else
                {
                    idList = qResult.Documents.Select(x => int.Parse(x.Id)).ToList();
                }

                var result = new ArtikelSearchResult(qResult.NumFound, startIndex, rowCount);

                if (breadCrumbFacetField != null)
                {
                    var facetResult = qResult.Facets.SingleOrDefault(x => x.FieldName == breadCrumbFacetField);
                    if (facetResult != null)
                    {
                        result.Suchbaumknoten = SuchbaumknotenMapper.Map(facetResult.Counts.Select(x => x.Key));
                        result.BreadCrumbs =
                            SuchbaumknotenMapper.MapBreadCrumbs(facetResult.Counts)
                                .OrderBy(x => x.Value)
                                .ToDictionary(x => x.Key, x => x.Value);
                    }
                }

                if (genArtFacetField != null)
                {
                    var facetResult = qResult.Facets.SingleOrDefault(x => x.FieldName == genArtFacetField);
                    if (facetResult != null)
                    {
                        result.GenerischeArtikel = GenArtMapper.MapFacet(facetResult.Counts);
                    }
                }

                result.Artikel = GetArtikelList(context, idList.Skip(startIndex).Distinct().Take(rowCount), true);

                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                if (OnNetworkError(context, ex))
                    return FindArtikelSorted(context, suchtext,
                        options, startIndex, rowCount);
            }
            return new ArtikelSearchResult(0, 0, 0);
        }

        private ArtikelSearchResult FindArtikelUnsorted(ServiceContext context, string suchtext,
            ArtikelSuchoptionen options, int startIndex, int rowCount)
        {
            try
            {
                var qDesc = _index.NewQueryDescription();
                var qBuilder = _index.NewQueryBuilder();
                var fqBuilder = _index.NewQueryBuilder();
                var fqSubBuilder = _index.NewQueryBuilder();

                string breadCrumbFacetField = null;
                string genArtFacetField = null;

                //Query
                //Suchtext

                #region Suchtext

                if (string.IsNullOrEmpty(suchtext))
                {
                    qBuilder.AllExpression();
                }
                else
                {
                    qBuilder.DefaultExpression(suchtext);
                }

                #endregion

                //SearchOnNumbers

                #region SearchOnNumbers

                if (options.SearchOnNumbers && !string.IsNullOrEmpty(suchtext))
                {
                    qBuilder
                        .Operator(SolrQueryOperator.Or);
                    AddStandardNummerSucheExpression(qBuilder, suchtext);
                }

                #endregion

                //FilterQuery
                if (options.ShowOutletOnly)
                {
                    #region ShowOutletOnly

                    {
                        fqBuilder
                            .Expression(x => x.Aktionsnummer, 30);

                        //ShowAllPseudoartikel
                        if (options.ShowAllPseudoartikel)
                        {
                            fqBuilder
                                .Operator(SolrQueryOperator.And)
                                .Expression(x => x.IsPseudoartikel, true);
                        }

                        // Incentive Bundles ausschließen
                        fqBuilder
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.IsIncentiveBundle, false);
                    }

                    #endregion
                }
                else
                {
                    if (!string.IsNullOrEmpty(options.TeaserId))
                    {
                        //Themenwelt

                        #region Themenwelt

                        fqBuilder
                            .Expression(x => x.TeaserId, options.TeaserId);

                        fqBuilder
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.Aktionsnummer, options.Aktionsnummer);

                        #endregion

                    }
                    else
                    {
                        ////csoCode
                        //fqSubBuilder
                        //    .Expression(x => x.CsoCode, context.CsoCode);

                        fqSubBuilder
                            .Expression(x => x.Aktionsnummer, options.Aktionsnummer);

                        //ShowAllPseudoartikel
                        if (options.ShowAllPseudoartikel)
                        {
                            fqSubBuilder
                                .Operator(SolrQueryOperator.Or)
                                .Expression(x => x.IsPseudoartikel, true);
                        }
                        fqBuilder.SubQuery(fqSubBuilder);

                        // Incentive Bundles ausschließen
                        fqBuilder
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.IsIncentiveBundle, false);
                    }
                }

                var fzgIdent = "";

                //FahrzeugId

                #region FahrzeugId

                if (options.Fahrzeug != null)
                {
                    fzgIdent = string.Format("{0}{1}", options.Fahrzeug.Fahrzeugart.Name, options.Fahrzeug.FahrzeugId);
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.FahrzeugId, fzgIdent);
                }

                #endregion

                //Suchbaumtyp und GenArt

                #region Suchbaumtyp und GenArt

                if (options.Suchbaumtyp != null)
                {
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.Suchbaumtyp, options.Suchbaumtyp.Name);

                    breadCrumbFacetField = _index.GetFieldName(x => x.Breadcrumb, options.Suchbaumtyp.Name);
                    qDesc.FacetQueries.Add(new SolrFacetQuery(breadCrumbFacetField, null, FacetSort.Index, int.MaxValue));
                }

                // GenArtFacets
                if (options.ShowGenArtFacets)
                {
                    genArtFacetField = _index.GetFieldName(x => x.GenerischerArtikel);
                    qDesc.FacetQueries.Add(new SolrFacetQuery(genArtFacetField, null, FacetSort.Index, int.MaxValue));
                }


                //GenArtId
                if (options.GenArtId > 0)
                {
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.GenArtId, options.GenArtId);
                }

                #endregion

                //Hersteller

                #region Hersteller

                if (options.Herstellerkuerzel != null && options.Herstellerkuerzel.Count() > 0)
                {
                    var herstellerSubQuery = _index.NewQueryBuilder();
                    foreach (var hlk in options.Herstellerkuerzel)
                    {
                        herstellerSubQuery
                            .Operator(SolrQueryOperator.Or)
                            .Expression(x => x.VdbHerstellerkuerzel, hlk);
                    }
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(herstellerSubQuery);
                }

                #endregion

                //Artikelnummer

                #region Artikelnummer

                if (options.Artikelnummer != null && options.Artikelnummer.Count() > 0)
                {
                    var artNrSubQuery = _index.NewQueryBuilder();
                    foreach (var artNr in options.Artikelnummer)
                    {
                        artNrSubQuery
                            .Operator(SolrQueryOperator.Or)
                            .Expression(x => x.Artikelnummer, artNr);
                    }
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(artNrSubQuery);
                }

                #endregion

                //IsLieferbar
                if (options.ShowNurLieferbar)
                {
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.IsLieferbar, true);
                }
                else
                {
                    qDesc.AddSortField(x => x.IsLieferbar, SolrSortDirection.Desc);
                }

                //isNfzUniversalArtikel
                fqBuilder
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.IsNfzUniversalArtikel, options.IsNfzUniversalArtikel);


                qDesc.Query = qBuilder.Create();
                qDesc.FilterQuery = fqBuilder.Create();

                qDesc.StartIndex = startIndex;
                qDesc.RowCount = rowCount;

                AddStandardDynamicFields(context, qDesc, fzgIdent);
                AddTauschartikel(context, qDesc);

                var qResult = _index.QueryEx(qDesc);

                var result = new ArtikelSearchResult(qResult.NumFound, qResult.StartIndex, rowCount);

                if (breadCrumbFacetField != null)
                {
                    var facetResult = qResult.Facets.SingleOrDefault(x => x.FieldName == breadCrumbFacetField);
                    if (facetResult != null)
                    {
                        result.Suchbaumknoten = SuchbaumknotenMapper.Map(facetResult.Counts.Select(x => x.Key));
                        result.BreadCrumbs =
                            SuchbaumknotenMapper.MapBreadCrumbs(facetResult.Counts)
                                .OrderBy(x => x.Value)
                                .ToDictionary(x => x.Key, x => x.Value);
                    }
                }

                if (genArtFacetField != null)
                {
                    var facetResult = qResult.Facets.SingleOrDefault(x => x.FieldName == genArtFacetField);
                    if (facetResult != null)
                    {
                        result.GenerischeArtikel = GenArtMapper.MapFacet(facetResult.Counts);
                    }
                }

                result.Artikel = ArtikelMapper.Map(qResult.Documents, 0, result.Suchbaumknoten);
                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                OnNetworkError(context, ex);
                return FindArtikelUnsorted(context, suchtext,
                    options, startIndex, rowCount);
            }
        }

        public ArtikelSearchResult FindArtikel(ServiceContext context, string suchtext, ArtikelSuchoptionen options,
            int startIndex, int rowCount)
        {
            if (options.GenArtId > 0 || options.AktionenOnTop != null && options.AktionenOnTop.Count() > 0)
            {
                return FindArtikelSorted(context, suchtext, options, startIndex, rowCount);
            }
            else
            {
                return FindArtikelUnsorted(context, suchtext, options, startIndex, rowCount);
            }
        }

        public ArtikelSearchResult FindArtikelByOENummer(ServiceContext context,
            ArtikelSuchoptionenFuerNummernsuche suchoptionen)
        {
            try
            {
                var qDesc = _index.NewQueryDescription();
                var qBuilder = _index.NewQueryBuilder();
                var qSubBuilder = _index.NewQueryBuilder();

                qSubBuilder.Expression(x => x.ReferenznummerEindeutig, string.Format("\"{0}\"", suchoptionen.Nummer), 50);
                qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.ReferenznummerEindeutig));

                var csoFields = _index.NewQueryBuilder();

                csoFields = AddCsoFields(context, false);


                qBuilder
                    .SubQuery(qSubBuilder)
                    .Operator(SolrQueryOperator.And)
                    .SubQuery(csoFields)
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.Suchbaumtyp, suchoptionen.FzgArt.Name);

                string fzgIdent = string.Empty;

                if (suchoptionen.FzgArt != Fahrzeugart.Ohne && suchoptionen.FzgId > 0)
                {
                    fzgIdent = string.Format("{0}{1}", suchoptionen.FzgArt.Name, suchoptionen.FzgId);
                    qBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.FahrzeugId, fzgIdent);
                }

                qDesc.Query = qBuilder.Create();

                qDesc.StartIndex = suchoptionen.StartIndex;
                qDesc.RowCount = suchoptionen.RowCount;

                AddStandardDynamicFields(context, qDesc, fzgIdent);
                //bei Tauschartikel selber keine Tauschartikel anbieten

                AddTauschartikel(context, qDesc);

                var qResult = _index.QueryEx(qDesc);

                var result = new ArtikelSearchResult(qResult.NumFound, qResult.StartIndex, suchoptionen.RowCount);

                result.Artikel = ArtikelMapper.Map(qResult.Documents);

                if (result.Artikel != null && result.Artikel.Count > 0)
                {
                    //Suche über GenArts
                    result.Artikel = sortArtikelList(result.Artikel, 0, 0, "", null, true);
                }

                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                OnNetworkError(context, ex);
                return FindArtikelByOENummer(context, suchoptionen);
            }
        }

        public ArtikelSearchResult FindArtikelByNummer(ServiceContext context,
            ArtikelSuchoptionenFuerNummernsuche suchoptionen)
        {
            try
            {
                var qDesc = _index.NewQueryDescription();
                var qBuilder = _index.NewQueryBuilder();
                var qSubBuilder = _index.NewQueryBuilder();
                var qSubSuchbaumBuilder = _index.NewQueryBuilder();

                if (suchoptionen.ArtNummernsuche == ArtNummernsuche.SearchArtikelnummer)
                {
                    qSubBuilder
                        .Expression(x => x.Artikelnummer, string.Format("\"{0}\"", suchoptionen.Nummer), 100000)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.ArtikelnummerSuche, string.Format("\"{0}\"", suchoptionen.Nummer), 50000)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.ArtikelnummerSuche,
                            QuoteString(Regex.Replace(suchoptionen.Nummer.ToLower(), @"\W", "")) + "*", 10000)
                        .Operator(SolrQueryOperator.Or);
                    qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.Artikelnummer));
                    qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.ArtikelnummerSuche));
                }
                else if (suchoptionen.ArtNummernsuche == ArtNummernsuche.SearchArtikelnummerEindeutig)
                {
                    qSubBuilder
                        .Expression(x => x.Artikelnummer, string.Format("\"{0}\"", suchoptionen.Nummer), 100000);
                    qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.Artikelnummer));
                }

                if (suchoptionen.ArtNummernsuche == ArtNummernsuche.SearchEaNummer)
                {
                    qSubBuilder.Expression(x => x.EaNummer, string.Format("\"{0}\"", suchoptionen.Nummer), 5000)
                        .Operator(SolrQueryOperator.Or);
                    qSubBuilder.Expression(x => x.EaNummer,
                        QuoteString(Regex.Replace(suchoptionen.Nummer.ToLower(), @"\W", "")) + "*", 1000)
                        .Operator(SolrQueryOperator.Or);
                    qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.EaNummer));
                }
                else if (suchoptionen.ArtNummernsuche == ArtNummernsuche.SearchEaNummerEindeutig)
                {
                    qSubBuilder.Expression(x => x.EaNummerEindeutig, string.Format("\"{0}\"", suchoptionen.Nummer), 5000);
                    qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.EaNummerEindeutig));
                    //    .Operator(SolrQueryOperator.Or);
                    //qSubBuilder.Expression(x => x.EaNummer, QuoteString(Regex.Replace(nummer.ToLower(), @"\W", "")) + "*", 1000).Operator(SolrQueryOperator.Or);
                    //qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.EaNummer));
                }

                if (suchoptionen.ArtNummernsuche == ArtNummernsuche.SearchMatchcode)
                {
                    qSubBuilder.Expression(x => x.Matchcode, string.Format("\"{0}*\"", suchoptionen.Nummer), 5)
                        .Operator(SolrQueryOperator.Or);
                    qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.Matchcode));
                }
                else if (suchoptionen.ArtNummernsuche == ArtNummernsuche.SearchMatchcodeEindeutig)
                {
                    qSubBuilder.Expression(x => x.Matchcode, string.Format("\"{0}\"", suchoptionen.Nummer), 5)
                        .Operator(SolrQueryOperator.Or);
                    qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.Matchcode));
                    //    .Operator(SolrQueryOperator.Or);
                    //qSubBuilder.Expression(x => x.EaNummer, QuoteString(Regex.Replace(nummer.ToLower(), @"\W", "")) + "*", 1000).Operator(SolrQueryOperator.Or);
                    //qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.EaNummer));
                }

                if (suchoptionen.ArtNummernsuche == ArtNummernsuche.SearchGebrauchsnummer)
                {
                    qSubBuilder.Expression(x => x.GebrauchsnummerSuche, string.Format("\"{0}\"", suchoptionen.Nummer),
                        500).Operator(SolrQueryOperator.Or);
                    qSubBuilder.Expression(x => x.GebrauchsnummerSuche,
                        QuoteString(Regex.Replace(suchoptionen.Nummer.ToLower(), @"\W", "")) + "*", 100)
                        .Operator(SolrQueryOperator.Or);
                    qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.GebrauchsnummerSuche));
                }
                else if (suchoptionen.ArtNummernsuche == ArtNummernsuche.SearchGebrauchsnummerEindeutig)
                {
                    qSubBuilder.Expression(x => x.GebrauchsnummerEindeutig,
                        string.Format("\"{0}\"", suchoptionen.Nummer), 500);
                    qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.GebrauchsnummerEindeutig));
                }

                if (suchoptionen.ArtNummernsuche == ArtNummernsuche.SearchReferenznummer)
                {
                    qSubBuilder.Expression(x => x.ReferenznummerSuche, string.Format("\"{0}\"", suchoptionen.Nummer), 50)
                        .Operator(SolrQueryOperator.Or);
                    qSubBuilder.Expression(x => x.ReferenznummerSuche,
                        QuoteString(Regex.Replace(suchoptionen.Nummer.ToLower(), @"\W", "")) + "*", 10)
                        .Operator(SolrQueryOperator.Or);
                    qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.ReferenznummerSuche));
                }
                else if (suchoptionen.ArtNummernsuche == ArtNummernsuche.SearchReferenznummerEindeutig)
                {
                    qSubBuilder.Expression(x => x.ReferenznummerEindeutig, string.Format("\"{0}\"", suchoptionen.Nummer),
                        50);
                    qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.ReferenznummerEindeutig));
                }

                if (suchoptionen.ArtNummernsuche == ArtNummernsuche.SearchVergleichsnummer)
                {
                    qSubBuilder.Expression(x => x.Vergleichsnummer, string.Format("\"{0}\"", suchoptionen.Nummer), 5)
                        .Operator(SolrQueryOperator.Or);
                    qSubBuilder.Expression(x => x.Vergleichsnummer,
                        QuoteString(Regex.Replace(suchoptionen.Nummer.ToLower(), @"\W", "")) + "*", 1)
                        .Operator(SolrQueryOperator.Or);
                    qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.Vergleichsnummer));
                }
                else if (suchoptionen.ArtNummernsuche == ArtNummernsuche.SearchVergleichsnummerEindeutig)
                {
                    qSubBuilder.Expression(x => x.VergleichsnummerEindeutig,
                        string.Format("\"{0}\"", suchoptionen.Nummer), 5);
                    qDesc.Highlighting.Fields.Add(_index.GetFieldName(x => x.VergleichsnummerEindeutig));
                }

                qSubSuchbaumBuilder
                    .Expression(x => x.Suchbaumtyp, Suchbaumtyp.Lkw.Name)
                    .Operator(SolrQueryOperator.Or)
                    .Expression(x => x.Suchbaumtyp, Suchbaumtyp.Pkw.Name)
                    .Operator(SolrQueryOperator.Or)
                    .Expression(x => x.Suchbaumtyp, Suchbaumtyp.Motor.Name)
                    .Operator(SolrQueryOperator.Or)
                    .Expression(x => x.Suchbaumtyp, Suchbaumtyp.Achse.Name)
                    .Operator(SolrQueryOperator.Or)
                    .Expression(x => x.Suchbaumtyp, Suchbaumtyp.Universal.Name)
                    .Operator(SolrQueryOperator.Or)
                    .Expression(x => x.Suchbaumtyp, Suchbaumtyp.None.Name);

                var csoFields = _index.NewQueryBuilder();
                if (suchoptionen.Mobile || !string.IsNullOrEmpty(suchoptionen.Teasertyp))
                {
                    csoFields = AddCsoFieldsMobile(context);
                }
                else
                {

                    csoFields = AddCsoFields(context, suchoptionen.NurLieferbareArtikelAnzeigen,
                        suchoptionen.KeinePseudoartikel);
                }

                qBuilder
                    .SubQuery(qSubBuilder)
                    .Operator(SolrQueryOperator.And)
                    .SubQuery(qSubSuchbaumBuilder)
                    .Operator(SolrQueryOperator.And)
                    .SubQuery(csoFields);

                if (!string.IsNullOrEmpty(suchoptionen.Hersteller))
                {
                    string hersteller = suchoptionen.Hersteller.Replace(" ", "");
                    var subQuery = _index.NewQueryBuilder();
                    subQuery
                        .Expression(x => x.Herstellername, hersteller)
                        .Or().Expression(x => x.VdbHerstellerkuerzel, hersteller);

                    qBuilder
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(subQuery);
                    //qDesc.FilterQueries.Add(_index.NewQueryBuilder().Expression(x => x.Herstellername, optionen.Hersteller).Create());
                }

                if (!string.IsNullOrEmpty(suchoptionen.Teasertyp))
                {
                    qBuilder.Operator(SolrQueryOperator.And)
                        .Expression(x => x.TeaserTyp, suchoptionen.Teasertyp);
                }

                if (suchoptionen.FzgArt != Fahrzeugart.Ohne && suchoptionen.FzgId > 0)
                {
                    string fzgIdent = string.Format("{0}{1}", suchoptionen.FzgArt.Name, suchoptionen.FzgId);
                    qBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.FahrzeugId, fzgIdent);
                }

                qDesc.Query = qBuilder.Create();

                qDesc.StartIndex = suchoptionen.StartIndex;
                qDesc.RowCount = suchoptionen.RowCount;

                AddStandardDynamicFields(context, qDesc);
                //bei Tauschartikel selber keine Tauschartikel anbieten

                AddTauschartikel(context, qDesc);

                qDesc.Highlighting.RequireFieldMatch = true;

                var qResult = _index.QueryEx(qDesc);

                var result = new ArtikelSearchResult(qResult.NumFound, qResult.StartIndex, suchoptionen.RowCount);
                if (!string.IsNullOrEmpty(suchoptionen.Teasertyp))
                {
                    result.Artikel = ArtikelMapper.Map(qResult.Documents, 0, null, false, TeaserTyp.PVA);
                }
                else
                {
                    result.Artikel = ArtikelMapper.Map(qResult.Documents);
                }

                foreach (var artikel in result.Artikel)
                {
                    if (qResult.Highlights.ContainsKey(artikel.Id.ToString()))
                    {
                        foreach (var kvp in qResult.Highlights[artikel.Id.ToString()])
                        {
                            if (kvp.Key == _index.GetFieldName(x => x.ArtikelnummerSuche) ||
                                kvp.Key == _index.GetFieldName(x => x.Artikelnummer))
                            {
                                artikel.Suchergebnisfelder |= Suchergebnisfelder.Artikelnummer;
                            }
                            if (kvp.Key == _index.GetFieldName(x => x.EaNummer) ||
                                kvp.Key == _index.GetFieldName(x => x.EaNummerEindeutig))
                            {
                                artikel.Suchergebnisfelder |= Suchergebnisfelder.Ean;
                            }
                            if (kvp.Key == _index.GetFieldName(x => x.GebrauchsnummerSuche) ||
                                kvp.Key == _index.GetFieldName(x => x.GebrauchsnummerEindeutig))
                            {
                                artikel.Suchergebnisfelder |= Suchergebnisfelder.Gebrauchsnummer;
                            }
                            if (kvp.Key == _index.GetFieldName(x => x.ReferenznummerSuche) ||
                                kvp.Key == _index.GetFieldName(x => x.ReferenznummerEindeutig))
                            {
                                artikel.Suchergebnisfelder |= Suchergebnisfelder.Referenznummer;
                            }
                            if (kvp.Key == _index.GetFieldName(x => x.Vergleichsnummer) ||
                                kvp.Key == _index.GetFieldName(x => x.VergleichsnummerEindeutig))
                            {
                                artikel.Suchergebnisfelder |= Suchergebnisfelder.Vergleichsnummer;
                            }
                            if (kvp.Key == _index.GetFieldName(x => x.Matchcode))
                            {
                                artikel.Suchergebnisfelder |= Suchergebnisfelder.Matchcode;
                            }
                        }
                    }
                }

                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                OnNetworkError(context, ex);
                return FindArtikelByNummer(context, suchoptionen);
            }
        }

        public List<Suchbaumknoten> GetSuchbaumknoten(ServiceContext context,
            ArtikelSuchoptionenFuerGetSuchbaumknoten suchoptionen)
        {
            try
            {
                //log.Debug("Start");
                var qDesc = _index.NewQueryDescription();
                var fqBuilder = _index.NewQueryBuilder();

                List<string> resultGenArtIds = null;

                var csoFields = _index.NewQueryBuilder();
                if (suchoptionen.Mobile)
                {
                    csoFields = AddCsoFieldsMobile(context);
                }
                else
                {
                    csoFields = AddCsoFields(context, false);
                }

                string facetField;
                SolrFacetQuery facet;

                fqBuilder
                    .Expression(x => x.Suchbaumtyp, suchoptionen.Suchbaumtyp.Name)
                    .Operator(SolrQueryOperator.And)
                    .SubQuery(csoFields);

                qDesc.StartIndex = 0;
                qDesc.RowCount = 0;

                if (suchoptionen.FahrzeugArt != Fahrzeugart.Ohne && suchoptionen.FahrzeugId > 0)
                {
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.FahrzeugId,
                            string.Format("{0}{1}", suchoptionen.FahrzeugArt.Name, suchoptionen.FahrzeugId));

                    qDesc.Query = "*:*";
                    qDesc.FilterQuery = fqBuilder.Create();

                    facetField = _index.GetFieldName(x => x.FzgGenArtId, "");

                    string prefix = suchoptionen.FahrzeugArt.Name + suchoptionen.FahrzeugId + '¦'; // +"*";

                    facet = new SolrFacetQuery(facetField, prefix, FacetSort.Index, int.MaxValue, 1, FacetMethod.Enum);

                    qDesc.FacetQueries.Add(facet);

                    var qResult = _index.QueryEx(qDesc);

                    var facetResult = qResult.Facets.SingleOrDefault(x => x.FieldName == facetField);
                    if (facetResult == null)
                    {
                        return new List<Suchbaumknoten>();
                    }

                    resultGenArtIds = SuchbaumknotenMapper.MapGenArtIds(facetResult.Counts.Select(x => x.Key),
                        suchoptionen.FahrzeugId.ToString(), suchoptionen.FahrzeugArt.Name);

                    if (resultGenArtIds == null || !resultGenArtIds.Any())
                    {
                        return new List<Suchbaumknoten>();
                    }

                    qDesc = _index.NewQueryDescription();
                    fqBuilder = _index.NewQueryBuilder();
                    var qSubBuilderGenArtIds = _index.NewQueryBuilder();

                    qSubBuilderGenArtIds.Join(x => x.FzgGenArtId, SolrQueryOperator.Or, resultGenArtIds.Distinct());

                    fqBuilder
                        .Expression(x => x.Suchbaumtyp, suchoptionen.Suchbaumtyp.Name)
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(csoFields)
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(qSubBuilderGenArtIds);

                    if (suchoptionen.NurSensitiveArea)
                    {
                        fqBuilder
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.HasSensitiveAreas, true);
                    }
                }

                qDesc.StartIndex = 0;
                qDesc.RowCount = 0;

                qDesc.Query = "*:*";
                qDesc.FilterQuery = fqBuilder.Create();

                var genartMasterbezField = _index.GetFieldName(x => x.GenArtMasterbezeichnung, context.CsoCode);
                qDesc.FacetQueries.Add(new SolrFacetQuery(genartMasterbezField, null, FacetSort.Index, -1));

                var qResultFoprMasterbez = _index.QueryEx(qDesc);
                qDesc.FacetQueries.Clear();

                //ToDo: handle empty result
                SolrFacetResult genartMasterbezFieldResult =
                    qResultFoprMasterbez.Facets.Single(x => x.FieldName == genartMasterbezField);

                facetField = _index.GetFieldName(x => x.Breadcrumb, suchoptionen.Suchbaumtyp.Name);

                facet = new SolrFacetQuery(facetField, null, FacetSort.Index, int.MaxValue);
                qDesc.FacetQueries.Add(facet);

                var qResultB = _index.QueryEx(qDesc);

                var facetResultB = qResultB.Facets.SingleOrDefault(x => x.FieldName == facetField);
                if (facetResultB == null)
                {
                    return new List<Suchbaumknoten>();
                }

                var result = SuchbaumknotenMapper.Map(facetResultB.Counts.Select(x => x.Key), resultGenArtIds, null, 0,
                    0, 0, 0, genartMasterbezFieldResult.Counts.Select(x => x.Key));
                return result.OrderBy(x => x.Bezeichnung).OrderBy(x => x.Ebene).ToList();
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                OnNetworkError(context, ex);
                return GetSuchbaumknoten(context, suchoptionen);
            }

        }


        public ArtikelSearchResult GetArtikelForPC(ServiceContext context, UebergabeFuerSolr uebergabeFuerSolr)
        {
            //if (MasterCache.MasterCache.Instance.IsCached(uebergabeFuerSolr.FzgId))
            //    return null;

            var qDesc = _index.NewQueryDescription();
            qDesc.FieldNames.Add("FahrzeugId");
            qDesc.FieldNames.Add("Suchbaumtyp");
            qDesc.FieldNames.Add("GenArtIdFzg");
            qDesc.FieldNames.Add("CsoCode");

            var fqBuilder = _index.NewQueryBuilder();

            string fzgIdent = null;


            if (uebergabeFuerSolr.FzgArt != Fahrzeugart.Ohne && uebergabeFuerSolr.FzgId > 0)
            {
                fzgIdent = string.Format("{0}{1}", uebergabeFuerSolr.FzgArt.Name, uebergabeFuerSolr.FzgId);
            }

            fqBuilder
                .Operator(SolrQueryOperator.And)
                .Expression(x => x.FahrzeugId, fzgIdent);

            qDesc.Query = "*:*";
            qDesc.FilterQuery = fqBuilder.Create();
            qDesc.StartIndex = uebergabeFuerSolr.StartIndex;
            qDesc.RowCount = 100000;

            AddStandardDynamicFields(context, qDesc, fzgIdent);
            AddTauschartikel(context, qDesc);

            var qResult = _index.QueryEx_JSON(qDesc);

            //MasterCache.MasterCache.Instance.AddPc(uebergabeFuerSolr.FzgId, qResult.Documents);


            var result = new ArtikelSearchResult(qResult.NumFound, qResult.StartIndex, qResult.NumFound);

            result.Artikel = ArtikelMapper.Map(qResult.Documents);

            result.Artikel = sortArtikelList(result.Artikel, uebergabeFuerSolr.GenArtId, 0, "", uebergabeFuerSolr.GenArtList);

            return result;

        }


        public ArtikelSearchResult GetArtikelByGenerischerArtikel(ServiceContext context,
            UebergabeFuerSolr uebergabeFuerSolr)
        {
            try
            {
                var qDesc = _index.NewQueryDescription();
                qDesc.FieldNames.Remove("FahrzeugId");

                var fqBuilder = _index.NewQueryBuilder();
                var qSubBuilderLieferbar = _index.NewQueryBuilder();
                var qSubBuilder = _index.NewQueryBuilder();

                var csoFields = _index.NewQueryBuilder();
                if (uebergabeFuerSolr.Mobile)
                {
                    csoFields = AddCsoFieldsMobile(context);
                }
                else
                {
                    csoFields = AddCsoFields(context, true);
                }

                if (uebergabeFuerSolr.SuchstringFuerHersteller)
                {
                    qSubBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.Herstellername, uebergabeFuerSolr.Suchstring.Replace(" ", ""));

                    fqBuilder
                        .SubQuery(qSubBuilder)
                        .Operator(SolrQueryOperator.And);
                }
                else if (!string.IsNullOrEmpty(uebergabeFuerSolr.Suchstring))
                {
                    string queryString = string.Format("(\"{0}\") OR ({0}) OR ({0}*) OR (*{1})",
                        QuoteString(uebergabeFuerSolr.Suchstring.ToLower()),
                        QuoteString(uebergabeFuerSolr.Suchstring.ToLower()));

                    qSubBuilder
                        .DefaultExpressionOhneStringify(queryString)
                        .Operator(SolrQueryOperator.Or);

                    if (uebergabeFuerSolr.SbTyp == Suchbaumtyp.Universal)
                    {
                        qSubBuilder
                            .Expression(x => x.Matchcode, uebergabeFuerSolr.Suchstring)
                            .Operator(SolrQueryOperator.Or);
                    }

                    AddStandardNummerSucheExpression(qSubBuilder, uebergabeFuerSolr.Suchstring);

                    fqBuilder
                        .SubQuery(qSubBuilder)
                        .Operator(SolrQueryOperator.And);
                }

                fqBuilder
                    .SubQuery(csoFields)
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.Suchbaumtyp, uebergabeFuerSolr.SbTyp.Name);

                string fzgIdent = null;
                string facetField = string.Empty;

                if (uebergabeFuerSolr.FzgArt != Fahrzeugart.Ohne && uebergabeFuerSolr.FzgId > 0)
                {
                    fzgIdent = string.Format("{0}{1}", uebergabeFuerSolr.FzgArt.Name, uebergabeFuerSolr.FzgId);
                    if (uebergabeFuerSolr.GenArtList != null && uebergabeFuerSolr.GenArtList.Count > 0)
                    {

                        var qSubBuilderGenArtsFahrzeug = _index.NewQueryBuilder();
                        var genArtsFahrzeug = new List<string>();
                        foreach (var gen in uebergabeFuerSolr.GenArtList.Distinct())
                        {
                            genArtsFahrzeug.Add(string.Format("{0}¦{1}", gen, fzgIdent));
                        }

                        qSubBuilderGenArtsFahrzeug.Join(x => x.GenArtIdFahrzeug, SolrQueryOperator.Or, genArtsFahrzeug);

                        fqBuilder
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.FahrzeugId, fzgIdent)
                            .Operator(SolrQueryOperator.And)
                            .SubQuery(qSubBuilderGenArtsFahrzeug);

                        facetField = _index.GetFieldName(x => x.Breadcrumb, uebergabeFuerSolr.SbTyp.Name);
                        var facet = new SolrFacetQuery(facetField, null, FacetSort.Index, int.MaxValue);
                        qDesc.FacetQueries.Add(facet);
                    }
                    else
                    {
                        fqBuilder
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.FahrzeugId, fzgIdent)
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.GenArtIdFahrzeug,
                                string.Format("{0}¦{1}", uebergabeFuerSolr.GenArtId, fzgIdent));
                    }

                    if (uebergabeFuerSolr.SuchknotenGrafik)
                    {
                        fqBuilder
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.HasSensitiveAreas, true);
                    }
                }
                else
                {
                    if (uebergabeFuerSolr.GenArtList != null && uebergabeFuerSolr.GenArtList.Count > 0)
                    {
                        var qSubBuilderGenArts = _index.NewQueryBuilder();
                        qSubBuilderGenArts.Join(x => x.GenArtId, SolrQueryOperator.Or,
                            uebergabeFuerSolr.GenArtList.Distinct());

                        fqBuilder
                            .Operator(SolrQueryOperator.And)
                            .SubQuery(qSubBuilderGenArts);

                        facetField = _index.GetFieldName(x => x.Breadcrumb, uebergabeFuerSolr.SbTyp.Name);
                        var facet = new SolrFacetQuery(facetField, null, FacetSort.Index, int.MaxValue);
                        qDesc.FacetQueries.Add(facet);
                    }
                    else
                    {
                        fqBuilder
                            .Operator(SolrQueryOperator.And)
                            .Expression(x => x.GenArtId, uebergabeFuerSolr.GenArtId);

                    }
                }

                qDesc.AddSortField(x => x.IsLieferbar, SolrSortDirection.Desc);

                qDesc.Query = "*:*";
                qDesc.FilterQuery = fqBuilder.Create();
                qDesc.StartIndex = uebergabeFuerSolr.StartIndex;
                qDesc.RowCount = uebergabeFuerSolr.RowCount;

                AddStandardDynamicFields(context, qDesc, fzgIdent);
                AddTauschartikel(context, qDesc);

                SolrQueryResult<ArtikelDoc> qResult = null;

                //if (MasterCache.MasterCache.Instance.IsCached(uebergabeFuerSolr.FzgId))
                //{
                //    qResult = new SolrQueryResult<ArtikelDoc>(MasterCache.MasterCache.Instance.DoQuery(uebergabeFuerSolr.FzgId, fqBuilder.Parts), 0);
                //}
                //else
                //{
                qResult = _index.QueryEx(qDesc);
                //}

                var result = new ArtikelSearchResult(qResult.NumFound, qResult.StartIndex, uebergabeFuerSolr.RowCount);
                if (!string.IsNullOrEmpty(facetField))
                {
                    var facetResult = qResult.Facets.SingleOrDefault(x => x.FieldName == facetField);

                    var resultBreadcrumbs = new List<Suchbaumknoten>();
                    if (facetResult != null)
                    {
                        int genArtId = uebergabeFuerSolr.GenArtList != null && uebergabeFuerSolr.GenArtList.Count == 1
                            ? uebergabeFuerSolr.GenArtList.First()
                            : 0;

                        resultBreadcrumbs = SuchbaumknotenMapper.Map(facetResult.Counts.Select(x => x.Key), null,
                            null, uebergabeFuerSolr.VorgaengerKnoten, uebergabeFuerSolr.VorgaengerKnotenTiefe
                            , uebergabeFuerSolr.VorgaengerParentIdKnoten, genArtId);
                    }
                    result.Artikel = ArtikelMapper.Map(qResult.Documents, 0, resultBreadcrumbs);
                }
                else
                {
                    result.Artikel = ArtikelMapper.Map(qResult.Documents, uebergabeFuerSolr.GenArtId);
                }

                result.Artikel = sortArtikelList(result.Artikel, uebergabeFuerSolr.GenArtId, 0, "",
                    uebergabeFuerSolr.GenArtList);

                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                OnNetworkError(context, ex);
                return GetArtikelByGenerischerArtikel(context, uebergabeFuerSolr);
            }
            catch
            {

            }

            return null;
        }

        public ArtikelSearchResult GetArtikelByGenerischerArtikel_Servertest(ServiceContext context,
            UebergabeFuerSolr uebergabeFuerSolr)
        {

            var index = _index_prim;

            var qDesc = index.NewQueryDescription();
            qDesc.FieldNames.Remove("FahrzeugId");

            var fqBuilder = index.NewQueryBuilder();
            var qSubBuilderLieferbar = index.NewQueryBuilder();
            var qSubBuilder = index.NewQueryBuilder();

            var csoFields = index.NewQueryBuilder();
            if (uebergabeFuerSolr.Mobile)
            {
                csoFields = AddCsoFieldsMobile(context);
            }
            else
            {
                csoFields = AddCsoFields(context, true);
            }

            if (uebergabeFuerSolr.SuchstringFuerHersteller)
            {
                qSubBuilder
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.Herstellername, uebergabeFuerSolr.Suchstring.Replace(" ", ""));

                fqBuilder
                    .SubQuery(qSubBuilder)
                    .Operator(SolrQueryOperator.And);
            }
            else if (!string.IsNullOrEmpty(uebergabeFuerSolr.Suchstring))
            {
                string queryString = string.Format("(\"{0}\") OR ({0}) OR ({0}*) OR (*{1})",
                    QuoteString(uebergabeFuerSolr.Suchstring.ToLower()),
                    QuoteString(uebergabeFuerSolr.Suchstring.ToLower()));

                qSubBuilder
                    .DefaultExpressionOhneStringify(queryString)
                    .Operator(SolrQueryOperator.Or);

                if (uebergabeFuerSolr.SbTyp == Suchbaumtyp.Universal)
                {
                    qSubBuilder
                        .Expression(x => x.Matchcode, uebergabeFuerSolr.Suchstring)
                        .Operator(SolrQueryOperator.Or);
                }

                AddStandardNummerSucheExpression(qSubBuilder, uebergabeFuerSolr.Suchstring);

                fqBuilder
                    .SubQuery(qSubBuilder)
                    .Operator(SolrQueryOperator.And);
            }

            fqBuilder
                .SubQuery(csoFields)
                .Operator(SolrQueryOperator.And)
                .Expression(x => x.Suchbaumtyp, uebergabeFuerSolr.SbTyp.Name);

            string fzgIdent = null;
            string facetField = string.Empty;

            if (uebergabeFuerSolr.FzgArt != Fahrzeugart.Ohne && uebergabeFuerSolr.FzgId > 0)
            {
                fzgIdent = string.Format("{0}{1}", uebergabeFuerSolr.FzgArt.Name, uebergabeFuerSolr.FzgId);
                if (uebergabeFuerSolr.GenArtList != null && uebergabeFuerSolr.GenArtList.Count > 0)
                {

                    var qSubBuilderGenArtsFahrzeug = index.NewQueryBuilder();
                    var genArtsFahrzeug = new List<string>();
                    foreach (var gen in uebergabeFuerSolr.GenArtList.Distinct())
                    {
                        genArtsFahrzeug.Add(string.Format("{0}¦{1}", gen, fzgIdent));
                    }

                    qSubBuilderGenArtsFahrzeug.Join(x => x.GenArtIdFahrzeug, SolrQueryOperator.Or, genArtsFahrzeug);

                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.FahrzeugId, fzgIdent)
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(qSubBuilderGenArtsFahrzeug);

                    facetField = index.GetFieldName(x => x.Breadcrumb, uebergabeFuerSolr.SbTyp.Name);
                    var facet = new SolrFacetQuery(facetField, null, FacetSort.Index, int.MaxValue);
                    qDesc.FacetQueries.Add(facet);
                }
                else
                {
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.FahrzeugId, fzgIdent)
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.GenArtIdFahrzeug,
                            string.Format("{0}¦{1}", uebergabeFuerSolr.GenArtId, fzgIdent));
                }

                if (uebergabeFuerSolr.SuchknotenGrafik)
                {
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.HasSensitiveAreas, true);
                }
            }
            else
            {
                if (uebergabeFuerSolr.GenArtList != null && uebergabeFuerSolr.GenArtList.Count > 0)
                {
                    var qSubBuilderGenArts = index.NewQueryBuilder();
                    qSubBuilderGenArts.Join(x => x.GenArtId, SolrQueryOperator.Or,
                        uebergabeFuerSolr.GenArtList.Distinct());

                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(qSubBuilderGenArts);

                    facetField = index.GetFieldName(x => x.Breadcrumb, uebergabeFuerSolr.SbTyp.Name);
                    var facet = new SolrFacetQuery(facetField, null, FacetSort.Index, int.MaxValue);
                    qDesc.FacetQueries.Add(facet);
                }
                else
                {
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.GenArtId, uebergabeFuerSolr.GenArtId);

                    //facetField = _index.GetFieldName(x => x.Breadcrumb, uebergabeFuerSolr.SbTyp.Name);
                    //var facet = new SolrFacetQuery(facetField, null, FacetSort.Index, int.MaxValue);
                    //qDesc.FacetQueries.Add(facet);
                }
            }

            qDesc.AddSortField(x => x.IsLieferbar, SolrSortDirection.Desc);

            qDesc.Query = "*:*";
            qDesc.FilterQuery = fqBuilder.Create();
            qDesc.StartIndex = uebergabeFuerSolr.StartIndex;
            qDesc.RowCount = uebergabeFuerSolr.RowCount;

            AddStandardDynamicFields(context, qDesc, fzgIdent);
            AddTauschartikel(context, qDesc);

            var qResult = index.QueryEx(qDesc);

            var result = new ArtikelSearchResult(qResult.NumFound, qResult.StartIndex, uebergabeFuerSolr.RowCount);
            if (!string.IsNullOrEmpty(facetField))
            {
                var facetResult = qResult.Facets.SingleOrDefault(x => x.FieldName == facetField);

                var resultBreadcrumbs = new List<Suchbaumknoten>();
                if (facetResult != null)
                {
                    int genArtId = uebergabeFuerSolr.GenArtList != null && uebergabeFuerSolr.GenArtList.Count == 1
                        ? uebergabeFuerSolr.GenArtList.First()
                        : 0;

                    resultBreadcrumbs = SuchbaumknotenMapper.Map(facetResult.Counts.Select(x => x.Key), null,
                        null, uebergabeFuerSolr.VorgaengerKnoten, uebergabeFuerSolr.VorgaengerKnotenTiefe
                        , uebergabeFuerSolr.VorgaengerParentIdKnoten, genArtId);
                }
                result.Artikel = ArtikelMapper.Map(qResult.Documents, 0, resultBreadcrumbs);
            }
            else
            {
                result.Artikel = ArtikelMapper.Map(qResult.Documents, uebergabeFuerSolr.GenArtId);
            }

            result.Artikel = sortArtikelList(result.Artikel, uebergabeFuerSolr.GenArtId, 0, "",
                uebergabeFuerSolr.GenArtList);

            return result;

        }

        public Artikel GetArtikelByKatalognummerUndHLK(ServiceContext context, string katalognummer, string hlk)
        {
            try
            {
                var qDesc = _index.NewQueryDescription();
                var qBuild = _index.NewQueryBuilder();


                qDesc.Query = qBuild
                    .Expression(x => x.VdbHerstellerkuerzel, hlk)
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.Katalognummer, '"' + katalognummer + '"')
                    .Create();

                AddStandardDynamicFields(context, qDesc);

                AddTauschartikel(context, qDesc);

                var result = _index.QueryEx(qDesc);
                if (result.Documents.Count == 0)
                {
                    return null;
                }

                var doc = result.Documents.First();

                var artikel = ArtikelMapper.Map(doc);

                return artikel;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                OnNetworkError(context, ex);
                return GetArtikelByKatalognummerUndHLK(context, katalognummer, hlk);
            }
            catch
            {
                return new Artikel();
            }

        }

        public Artikel GetArtikelByArtikelnummerUndHerstellernummerOrDLNr(ServiceContext context, string artikelnummer,
            long herstellernummer = 0, int dlnr = 0)
        {
            try
            {
                var qDesc = _index.NewQueryDescription();
                var qBuild = _index.NewQueryBuilder();

                if (herstellernummer > 0)
                {
                    qDesc.Query = qBuild
                        .Expression(x => x.Artikelnummer, '"' + artikelnummer + '"')
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.Herstellernummer, herstellernummer)
                        .Create();
                }
                else
                {
                    qDesc.Query = qBuild
                        .Expression(x => x.Artikelnummer, '"' + artikelnummer + '"')
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.DLNr, dlnr)
                        .Create();
                }

                AddStandardDynamicFields(context, qDesc);

                var result = _index.QueryEx(qDesc);
                if (result.Documents.Count == 0)
                {
                    return null;
                }

                var doc = result.Documents.First();

                var artikel = ArtikelMapper.Map(doc);

                return artikel;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                OnNetworkError(context, ex);
                return GetArtikelByArtikelnummerUndHerstellernummerOrDLNr(context, artikelnummer, herstellernummer, dlnr);
            }
            catch
            {
                return new Artikel();
            }
        }

        public Artikel GetArtikelByArtikelnummerUndDLNr(ServiceContext context, string artikelnummer, int dlnr)
        {
            var qDesc = _index.NewQueryDescription();
            var qBuild = _index.NewQueryBuilder();

            try
            {
                qDesc.Query = qBuild
                    .Expression(x => x.Artikelnummer, '"' + artikelnummer + '"')
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.DLNr, dlnr)
                    .Create();

                AddStandardDynamicFields(context, qDesc);

                var result = _index.QueryEx(qDesc);
                if (result.Documents.Count == 0)
                {
                    return null;
                }

                var doc = result.Documents.First();

                var artikel = ArtikelMapper.Map(doc);

                return artikel;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                OnNetworkError(context, ex);
                return GetArtikelByArtikelnummerUndDLNr(context, artikelnummer, dlnr);
            }
            catch
            {
                return new Artikel();
            }
        }

        public Artikel GetArtikelByArtikelnummerUndHlkFuerPims1(ServiceContext context, string artikelnummer, string hlk)
        {
            var qDesc = _index.NewQueryDescription();
            var qBuild = _index.NewQueryBuilder();

            try
            {
                qDesc.Query = qBuild
                    .Expression(x => x.Artikelnummer, '"' + artikelnummer + '"')
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.VdbHerstellerkuerzel, hlk)
                    .Create();

                AddStandardDynamicFields(context, qDesc);

                var result = _index.QueryEx(qDesc);
                if (result.Documents.Count == 0)
                {
                    return null;
                }

                var doc = result.Documents.First();

                var artikel = ArtikelMapper.Map(doc);

                return artikel;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                OnNetworkError(context, ex);
                return GetArtikelByArtikelnummerUndHlkFuerPims1(context, artikelnummer, hlk);
            }
            catch
            {
                return new Artikel();
            }
        }

        public List<Stuecklistenartikel> GetStueckliste(ServiceContext context, int artikelId, StuecklisteTyp typ,
            int selectedGenArtNummer = 0, Fahrzeugart fzgArt = null, int fzgId = 0)
        {
            try
            {
                var qDesc = _stuecklistenIndex.NewQueryDescription();
                var qBuilder = _stuecklistenIndex.NewQueryBuilder();

                qBuilder.Expression(x => x.Id, artikelId);
                qDesc.Query = qBuilder.Create();

                var qResult = _stuecklistenIndex.QueryEx(qDesc);
                var slDoc = qResult.Documents.FirstOrDefault();
                if (slDoc == null || slDoc.Stueckliste == null)
                {
                    return new List<Stuecklistenartikel>();
                }

                var idList = new List<int>();
                List<KeyValuePair<int, int>> artIdZuGenArtId = new List<KeyValuePair<int, int>>();

                foreach (var item in slDoc.Stueckliste)
                {
                    var match = item.Split('¦');

                    if (match.Count() < 5 || match[0].ToLower() != typ.ToString().ToLower())
                        continue;

                    if (typ == StuecklisteTyp.Pv)
                    {
                        if (match[5] != "J")
                        {
                            continue;
                        }
                    }

                    var id = int.Parse(match[3]);
                    var genArtId = int.Parse(match[4]);

                    idList.Add(id);

                    artIdZuGenArtId.Add(new KeyValuePair<int, int>(int.Parse(match[3]), int.Parse(match[4])));

                }

                List<Artikel> artikelList = new List<Artikel>();
                if (fzgArt != null && fzgArt != Fahrzeugart.Ohne && fzgId > 0)
                {
                    string fzgIdent = string.Format("{0}{1}", fzgArt.Name, fzgId);
                    artikelList = GetArtikelList(context, idList.Distinct(), true, false, false, false, artIdZuGenArtId,
                        selectedGenArtNummer, fzgIdent);
                }
                else
                {
                    artikelList = GetArtikelList(context, idList.Distinct(), true, false, false, false, artIdZuGenArtId,
                        selectedGenArtNummer);
                }

                var listen = ArtikelStuecklistenMapper.Map(slDoc.Stueckliste, artikelList);

                if (typ == StuecklisteTyp.Pv)
                {
                    return listen.PvStueckliste;
                }
                else
                {
                    return listen.TecdocStueckliste;
                }
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                OnNetworkError(context, ex);
                return GetStueckliste(context, artikelId, typ,
                    selectedGenArtNummer, fzgArt, fzgId);
            }
        }

        public List<KeyValuePair<String, String>> GetLogistikInfos(ServiceContext context, int artikelId)
        {
            //Thomas: TechnischeMengeneinheitFaktor wird durch VerpackungsEinheitMenge ersetzt
            //unbedingt beachten, dass es die sog. hierarchie suche gibt. 
            //Also, es gibt einen Eintrag mit Fa. 0 aber keinen Eintrag mit Firma x 
            //dann zieht der Eintrag für Firma x von Firma 0. 
            //Gibt es aber einen Eintrag auf Firma x dann schlägt dieser den Eintrag auf Firma 0.

            try
            {
                var back = new List<KeyValuePair<String, String>>();

                var qDesc = _logistikInfosIndex.NewQueryDescription();
                var qBuilder = _logistikInfosIndex.NewQueryBuilder();

                qBuilder.Expression(x => x.Id, artikelId);
                qDesc.Query = qBuilder.Create();


                qDesc.AddDynamicFieldKey(x => x.Logistikinfo, context.FSAForLogistik);
                qDesc.AddDynamicFieldKey(x => x.Logistikinfo, "000.000.000");


                var qResult = _logistikInfosIndex.QueryEx(qDesc);
                var slDoc = qResult.Documents.FirstOrDefault();
                if (slDoc != null && slDoc.Logistikinfo != null && slDoc.Logistikinfo.Count > 0)
                {
                    back = ArtikelMapper.MapLogistikinfos(slDoc);
                }

                return back;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                OnNetworkError(context, ex);
                return GetLogistikInfos(context, artikelId);
            }
        }

        public ArtikelSonstigeNummern GetNummern(ServiceContext context, int artikelId)
        {
            try
            {
                var back = new ArtikelSonstigeNummern();

                var qDesc = _nummernIndex.NewQueryDescription();
                var qBuilder = _nummernIndex.NewQueryBuilder();

                qBuilder.Expression(x => x.Id, artikelId);
                qDesc.Query = qBuilder.Create();

                var qResult = _nummernIndex.QueryEx(qDesc);
                var slDoc = qResult.Documents.FirstOrDefault();
                if (slDoc == null)
                {
                    return back;
                }

                back = ArtikelMapper.MapNummern(slDoc);

                return back;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                OnNetworkError(context, ex);
                return GetNummern(context, artikelId);
            }
        }

        public Dictionary<string, string> GetGefahrengutHinweise(int artikelId)
        {
            try
            {
                var back = new Dictionary<string, string>();

                var qDesc = _gefahrgutIndex.NewQueryDescription();
                var qBuilder = _gefahrgutIndex.NewQueryBuilder();

                qBuilder.Expression(x => x.Id, artikelId);
                qDesc.Query = qBuilder.Create();

                var qResult = _gefahrgutIndex.QueryEx(qDesc);
                var slDoc = qResult.Documents.FirstOrDefault();
                if (slDoc == null || slDoc.Gefahrgutinformation == null || slDoc.Gefahrgutinformation.Count == 0)
                {
                    return null;
                }

                back = ArtikelMapper.MapGefahrgutinfos(slDoc);

                return back;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                OnNetworkError(null, ex);
                return GetGefahrengutHinweise(artikelId);
            }
        }

        /// <summary>
        /// typen
        /// "PC", "CV", "AX" oder "ENG"
        /// </summary>
        public List<int> GetFahrzeugIdsForArtikel(int artikelId, string typ, int fahrzeugTyp)
        {
            try
            {
                var back = new List<int>();

                var qDesc = _fahrzeugIdsIndex.NewQueryDescription();
                qDesc.FieldNames.Add(_index.GetFieldName(x => x.FahrzeugId));
                var qBuilder = _fahrzeugIdsIndex.NewQueryBuilder();

                qBuilder.Expression(x => x.Id, artikelId);
                qDesc.Query = qBuilder.Create();

                var qResult = _fahrzeugIdsIndex.QueryEx(qDesc);
                var slDoc = qResult.Documents.FirstOrDefault();
                if (slDoc == null || slDoc.FahrzeugId == null || slDoc.FahrzeugId.Count == 0)
                {
                    return null;
                }

                back = ArtikelMapper.MapFahrzeugIdForArtikel(slDoc, typ, fahrzeugTyp);

                if (back != null && back.Count >= 0)
                {
                    switch (typ)
                    {
                        case "PC":
                            return _pkwService.GetPkwList(back).Select(x => x.KTypNummer).ToList<int>();
                        case "CV":
                            return _lkwService.GetLkwList(back).Select(x => x.NTypNummer).ToList<int>();
                        case "AX":
                            return _achseService.GetAchseList(back).Select(x => x.Achsnummer).ToList<int>();
                        case "ENG":
                            return _motorService.GetMotorList(back).Select(x => x.Motornummer).ToList<int>();
                    }
                }

                return null;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);

                OnNetworkError(null, ex);
                return GetFahrzeugIdsForArtikel(artikelId, typ, fahrzeugTyp);
            }
        }

        public List<VerwandterArtikel> GetVerwandteArtikel(ServiceContext context, int artikelId, bool getZubehoer,
            bool mitSameKtypeOnly, Fahrzeugart fahrzeugArt, int fzgId, bool mobile = false)
        {
            try
            {
                var result = new List<VerwandterArtikel>();

                //var fzId = fahrzeug == null ? null : string.Format("{0}{1}", FahrzeugartConverter.ConvertToSolr(fahrzeug.Fahrzeugart), fahrzeug.FahrzeugId);
                var fzgIdent = string.Format("{0}{1}", fahrzeugArt.Name, fzgId);

                var qDesc = _index.NewQueryDescription();

                var qb = _index.NewQueryBuilder();
                qb.Expression(x => x.Id, artikelId);

                qDesc.Query = qb.Create();

                SolrQueryResult<ArtikelDoc> qResult = null;

                //if (MasterCache.MasterCache.Instance.IsCached(fzgId))
                //{
                //    qResult = new SolrQueryResult<ArtikelDoc>(MasterCache.MasterCache.Instance.DoQuery(fzgId, qb.Parts), 0);
                //}
                //else
                    qResult = _index.QueryEx(qDesc);

                var doc = qResult.Documents.FirstOrDefault();
                if (doc == null || doc.VerwandteArtikel == null && doc.VerwandteGenArtikel == null)
                {
                    return result;
                }

                var regex =
                    new Regex(
                        @"^([KSMZC]{1})" + '¦' + @"\d{1}" + '¦' + @"([01]{1})" + '¦' + @"(\d+)" + '¦' + @"([\d\.]+)$",
                        RegexOptions.Compiled);
                var artList = new HashSet<Tuple<VerwandterArtikelTyp, int, decimal>>();
                var artListSameKType = new HashSet<Tuple<VerwandterArtikelTyp, int, decimal>>();
                var genArtList = new HashSet<Tuple<VerwandterArtikelTyp, int, decimal>>();
                var genArtListSameKType = new HashSet<Tuple<VerwandterArtikelTyp, int, decimal>>();

                if (doc.VerwandteArtikel != null)
                {
                    foreach (var item in doc.VerwandteArtikel)
                    {
                        var match = regex.Match(item);
                        if (!match.Success)
                        {
                            continue;
                        }
                        var typ = VerwandterArtikelTypConverter.ConvertFromSolr(match.Groups[1].Value);
                        var id = int.Parse(match.Groups[3].Value);
                        var menge = decimal.Parse(match.Groups[4].Value, _culture);
                        if (match.Groups[2].Value == "1")
                        {
                            artListSameKType.Add(new Tuple<VerwandterArtikelTyp, int, decimal>(typ, id, menge));
                        }
                        else
                        {
                            artList.Add(new Tuple<VerwandterArtikelTyp, int, decimal>(typ, id, menge));
                        }
                    }
                }

                if (doc.VerwandteGenArtikel != null)
                {
                    foreach (var item in doc.VerwandteGenArtikel)
                    {
                        var match = regex.Match(item);
                        if (!match.Success)
                        {
                            continue;
                        }
                        var typ = VerwandterArtikelTypConverter.ConvertFromSolr(match.Groups[1].Value);
                        var id = int.Parse(match.Groups[3].Value);
                        var menge = decimal.Parse(match.Groups[4].Value, _culture);
                        if (match.Groups[2].Value == "1")
                        {
                            genArtListSameKType.Add(new Tuple<VerwandterArtikelTyp, int, decimal>(typ, id, menge));
                        }
                        else
                        {
                            genArtList.Add(new Tuple<VerwandterArtikelTyp, int, decimal>(typ, id, menge));
                        }
                    }
                }

                qDesc = _index.NewQueryDescription();
                qDesc.Query = "*:*";

                var filter = _index.NewQueryBuilder();
                if (artList.Count > 0)
                {
                    filter.Or().SubQuery(
                        _index.NewQueryBuilder().Join(x => x.Id, SolrQueryOperator.Or, artList.Select(x => x.Item2))
                        );
                }
                if (artListSameKType.Count > 0)
                {
                    filter.Or().SubQuery(
                        _index.NewQueryBuilder().Expression(x => x.FahrzeugId, fzgIdent).And().SubQuery(
                            _index.NewQueryBuilder()
                                .Join(x => x.Id, SolrQueryOperator.Or, artListSameKType.Select(x => x.Item2))
                            )
                        );
                }
                if (genArtList.Count > 0)
                {
                    filter.Or().SubQuery(
                        _index.NewQueryBuilder()
                            .Join(x => x.GenArtId, SolrQueryOperator.Or, genArtList.Select(x => x.Item2))
                        );
                }
                if (genArtListSameKType.Count > 0)
                {
                    filter.Or().SubQuery(
                        _index.NewQueryBuilder().Expression(x => x.FahrzeugId, fzgIdent).And().SubQuery(
                            _index.NewQueryBuilder()
                                .Join(x => x.GenArtId, SolrQueryOperator.Or, genArtListSameKType.Select(x => x.Item2))
                            )
                        );
                }

                var csoFields = _index.NewQueryBuilder();
                if (mobile)
                {
                    csoFields = AddCsoFieldsMobile(context);
                }
                else
                {
                    csoFields = AddCsoFields(context, true);
                }

                var fqBuilder = _index.NewQueryBuilder();
                fqBuilder
                    .SubQuery(csoFields)
                    .Operator(SolrQueryOperator.And)
                    .SubQuery(filter);

                qDesc.Query = fqBuilder.Create();
                ;
                qDesc.RowCount = int.MaxValue;

                qResult = _index.QueryEx(qDesc);

                var hstSortRegex = new Regex(@"¦(\d+)$", RegexOptions.Compiled);
                IEnumerable<ArtikelDoc> docResult;
                if (qResult.Documents.Count(x => x.Herstellersortiernummer != null) == qResult.Documents.Count)
                {
                    docResult =
                        qResult.Documents.OrderBy(
                            x =>
                                x.Herstellersortiernummer.Select(y => int.Parse(hstSortRegex.Match(y).Groups[1].Value))
                                    .Average());
                }
                else
                {
                    docResult = qResult.Documents.Select(x => x);
                }

                foreach (var artikel in ArtikelMapper.Map(docResult))
                {
                    var v = new VerwandterArtikel();
                    if (artList.Any(x => x.Item2 == artikel.Id))
                    {
                        var tuple = artList.First(x => x.Item2 == artikel.Id);
                        v.Menge = tuple.Item3;
                        v.Typ = tuple.Item1;
                        v.Ursprungsartikel = artikel;
                    }
                    else if (artListSameKType.Any(x => x.Item2 == artikel.Id))
                    {
                        var tuple = artListSameKType.First(x => x.Item2 == artikel.Id);
                        v.Menge = tuple.Item3;
                        v.Typ = tuple.Item1;
                        v.Ursprungsartikel = artikel;
                    }
                    else if (genArtList.Any(x => artikel.GenerischeArtikel.Any(y => y.Id == x.Item2)))
                    {
                        var tuple = genArtList.First(x => artikel.GenerischeArtikel.Any(y => y.Id == x.Item2));
                        v.Menge = tuple.Item3;
                        v.Typ = tuple.Item1;
                        v.Ursprungsartikel = artikel;
                    }
                    else if (genArtListSameKType.Any(x => artikel.GenerischeArtikel.Any(y => y.Id == x.Item2)))
                    {
                        var tuple = genArtListSameKType.First(x => artikel.GenerischeArtikel.Any(y => y.Id == x.Item2));
                        v.Menge = tuple.Item3;
                        v.Typ = tuple.Item1;
                        v.Ursprungsartikel = artikel;
                    }
                    result.Add(v);
                }

                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);
                OnNetworkError(context, ex);
                return GetVerwandteArtikel(context, artikelId, getZubehoer,
                    mitSameKtypeOnly, fahrzeugArt, fzgId, mobile);
            }
        }

        public List<Artikel> GetVerwandteArtikelByArtikelList(ServiceContext context, List<int> artikelIds,
            Fahrzeugart fahrzeugArt, int fzgId)
        {
            try
            {
                if (artikelIds.Count() == 0)
                {
                    return new List<Artikel>();
                }

                var qDesc = _index.NewQueryDescription();
                var qBuilder = _index.NewQueryBuilder();
                var qSubBuilderFahrzeug = _index.NewQueryBuilder();
                var qSubBuilderArticles = _index.NewQueryBuilder();

                AddStandardDynamicFields(context, qDesc);

                AddTauschartikel(context, qDesc);

                qSubBuilderArticles
                    .Join(x => x.Id, SolrQueryOperator.Or, artikelIds.Distinct());

                if (fzgId > 0)
                {
                    var fzgIdent = string.Format("{0}{1}", fahrzeugArt.Name, fzgId);

                    qSubBuilderFahrzeug
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.FahrzeugId, fzgIdent);

                    qBuilder
                        .SubQuery(qSubBuilderArticles)
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(qSubBuilderFahrzeug);
                }
                else
                    qBuilder
                        .SubQuery(qSubBuilderArticles);

                qDesc.RowCount = int.MaxValue;
                qDesc.Query = qBuilder.Create();

                var result = _index.QueryEx(qDesc);

                var sortedResult = new List<ArtikelDoc>();
                foreach (var id in artikelIds)
                {
                    var doc = result.Documents.SingleOrDefault(x => x.Id == id.ToString());
                    if (doc != null)
                    {
                        sortedResult.Add(doc);
                    }
                }

                var artikelList = ArtikelMapper.Map(sortedResult, 0, null);

                return artikelList;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);
                OnNetworkError(context, ex);
                return GetVerwandteArtikelByArtikelList(context, artikelIds,
                    fahrzeugArt, fzgId);
            }
        }

        public List<Artikel> GetTauschartikel(ServiceContext context, int artikelId)
        {
            try
            {
                var qDesc = _tauschartikelIndex.NewQueryDescription();
                var qBuilder = _tauschartikelIndex.NewQueryBuilder();

                qBuilder.Expression(x => x.Id, artikelId);
                qDesc.Query = qBuilder.Create();

                // ExterneArtikedaten.PimsCsofuerArtikelsuche beruecksichtigen
                if (context.CsoCodeZugelassen != null && context.CsoCodeZugelassen.Count > 0)
                {
                    foreach (var ccode in context.CsoCodeZugelassen)
                    {
                        qDesc.AddDynamicFieldKey(x => x.Tauschartikel, ccode);
                    }
                }
                else
                {
                    qDesc.AddDynamicFieldKey(x => x.Tauschartikel, context.CsoCode);
                }

                var qResult = _tauschartikelIndex.QueryEx(qDesc);
                var taDoc = qResult.Documents.FirstOrDefault();
                if (taDoc == null)
                {
                    return new List<Artikel>();
                }

                var idList = new List<KeyValuePair<int, TauschartikelTyp>>();

                //var idList = new List<int>();
                //var regex = new Regex(@"^(TECDOC|PV)¦.*¦(\d*)$");
                var regex = new Regex(@"^(PV|TECDOC)" + "¦" + @"([\d\-:Z\040]*)" + "¦" + @"(\d*)$",
                    RegexOptions.Compiled);
                foreach (var item in taDoc.Tauschartikel)
                {
                    var match = regex.Match(item);
                    if (!match.Success)
                    {
                        continue;
                    }
                    var id = int.Parse(match.Groups[3].Value);
                    // Ist das AbDatum schon erreicht?
                    if (!string.IsNullOrEmpty(match.Groups[2].Value) &&
                        DateTime.Parse(match.Groups[2].Value) > DateTime.Now)
                    {
                        continue;
                    }
                    var typ = match.Groups[1].Value == "PV" ? TauschartikelTyp.Pv : TauschartikelTyp.Tecdoc;
                    idList.Add(new KeyValuePair<int, TauschartikelTyp>(id, typ));
                }

                // Tauschartikel holen
                var result = GetArtikelList(context, idList.Select(x => x.Key).Distinct(), true,
                    nurCSOpassendeArtikel: true, showNurLieferbar: true);
                foreach (var artikel in result)
                {

                    if (idList.Any(x => x.Key == artikel.Id && x.Value == TauschartikelTyp.Tecdoc))
                    {
                        artikel.GefundenUeberNummer = "Vergleichsnummer";
                    }
                    else if (idList.Any(x => x.Key == artikel.Id && x.Value == TauschartikelTyp.Pv))
                    {
                        artikel.GefundenUeberNummer = "VergleichsPVnummern";
                    }
                }

                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);
                OnNetworkError(context, ex);
                return GetTauschartikel(context, artikelId);
            }
        }

        public ArtikelSearchResult GetTeaserArtikel(ServiceContext context, TeaserTyp teaserTyp)
        {
            try
            {


                var qDesc = _index.NewQueryDescription();
                var fqBuilder = _index.NewQueryBuilder();

                fqBuilder
                    .Expression(x => x.CsoCode, context.CsoCode)
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.TeaserTyp, teaserTyp.ToString())
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.IsLieferbar, true);

                ApplyNichtZugelasseneCsos(context, fqBuilder);

                qDesc.Query = "*:*";
                qDesc.FilterQuery = fqBuilder.Create();

                qDesc.StartIndex = 0;
                qDesc.RowCount = int.MaxValue;

                AddStandardDynamicFields(context, qDesc);

                var qResult = _index.QueryEx(qDesc);

                var result = new ArtikelSearchResult(qResult.NumFound, qResult.StartIndex, int.MaxValue);
                result.Artikel = ArtikelMapper.Map(qResult.Documents, 0, null, false, teaserTyp);

                result.Artikel.Sort(
                    delegate (Artikel a1, Artikel a2) { return a1.Sortiernummer.CompareTo(a2.Sortiernummer); });

                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);
                OnNetworkError(context, ex);
                return GetTeaserArtikel(context, teaserTyp);
            }
        }

        public ArtikelSearchResult GetArtikelFuerGenArtNummerList(ServiceContext context, List<int> genArtNummern,
            Suchbaumtyp sbTyp, Fahrzeugart fzgArt, int fzgId, int startIndex, int rowCount,
            bool mitWeiterenHerstellern = false)
        {
            try
            {
                var qDesc = _index.NewQueryDescription();
                var fqBuilder = _index.NewQueryBuilder();
                var qSubBuilderCso = _index.NewQueryBuilder();
                var qSubBuilderGenArtIds = _index.NewQueryBuilder();

                var csoFields = _index.NewQueryBuilder();

                csoFields = AddCsoFields(context, false, mitWeiterenHerstellern: mitWeiterenHerstellern);

                qSubBuilderGenArtIds.Join(x => x.GenArtNummer, SolrQueryOperator.Or, genArtNummern);

                qSubBuilderCso
                    .SubQuery(csoFields);

                fqBuilder
                    .SubQuery(qSubBuilderGenArtIds)
                    .Operator(SolrQueryOperator.And)
                    .SubQuery(qSubBuilderCso)
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.Suchbaumtyp, sbTyp.Name);

                string fzgIdent = string.Format("{0}{1}", fzgArt.Name, fzgId);

                fqBuilder
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.FahrzeugId, fzgIdent);

                qDesc.Query = "*:*";
                qDesc.FilterQuery = fqBuilder.Create();

                var facetField = _index.GetFieldName(x => x.Breadcrumb, sbTyp.Name);
                var facet = new SolrFacetQuery(facetField, null, FacetSort.Index, int.MaxValue);
                qDesc.FacetQueries.Add(facet);

                qDesc.StartIndex = startIndex;
                qDesc.RowCount = rowCount;

                AddStandardDynamicFields(context, qDesc, fzgIdent);
                //bei Tauschartikel selber keine Tauschartikel anbieten

                AddTauschartikel(context, qDesc);
                qDesc.AddSortField(x => x.IsLieferbar, SolrSortDirection.Desc);

                var qResult = _index.QueryEx(qDesc);

                var facetResult = qResult.Facets.SingleOrDefault(x => x.FieldName == facetField);

                var resultBreadcrumbs = new List<Suchbaumknoten>();
                if (facetResult != null)
                {
                    resultBreadcrumbs = SuchbaumknotenMapper.Map(facetResult.Counts.Select(x => x.Key));
                }

                var result = new ArtikelSearchResult(qResult.NumFound, qResult.StartIndex, rowCount);
                result.Artikel = ArtikelMapper.Map(qResult.Documents, 0, resultBreadcrumbs);

                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);
                if (OnNetworkError(context, ex))
                    return GetArtikelFuerGenArtNummerList(context, genArtNummern, sbTyp, fzgArt, fzgId, startIndex,
                        rowCount, mitWeiterenHerstellern);

                return new ArtikelSearchResult(0, 0, 0);
            }
        }

        /// <summary>
        /// Hiermit holt man die Unterartikel für die Artikeldetails aus den Einträgen für Stücklisten, Tauschartikel und VerwandteArtikel
        /// </summary>
        /// <param name="subdocEntries"></param>
        /// <returns></returns>
        private List<Artikel> LoadUnterartikel(ArtikelDoc doc, ServiceContext context)
        {
            try
            {
                // ArtikelIds der Unterlisten ermitteln
                var subDocIds = new List<int>();
                var regex = new Regex(@"¦(\d*)¦(\d*)$");

                // Stücklisten Ids
                if (doc.Stueckliste != null)
                {
                    foreach (var item in doc.Stueckliste)
                    {
                        var match = regex.Match(item);
                        if (!match.Success)
                        {
                            continue;
                        }
                        subDocIds.Add(int.Parse(match.Groups[1].Value));
                    }
                }
                // Tauschartikel Ids
                if (doc.Tauschartikel != null)
                {
                    foreach (var item in doc.Tauschartikel)
                    {
                        var match = regex.Match(item);
                        if (!match.Success)
                        {
                            continue;
                        }
                        subDocIds.Add(int.Parse(match.Groups[1].Value));
                    }
                }
                // Verwandte Artikel Ids
                if (doc.VerwandteArtikel != null)
                {
                    foreach (var item in doc.VerwandteArtikel)
                    {
                        var match = regex.Match(item);
                        if (!match.Success)
                        {
                            continue;
                        }
                        subDocIds.Add(int.Parse(match.Groups[1].Value));
                    }
                }

                // Liste der Unterartikel holen
                var result = GetArtikelList(context, subDocIds.Distinct(), true);
                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);
                if (OnNetworkError(context, ex))
                    return LoadUnterartikel(doc, context);

                return new List<Artikel>();
            }
        }

        private String QuoteString(string value)
        {
            string r = Regex.Replace(value,
                "(\\+|\\-|\\&\\&|\\|\\||\\!|\\{|\\}|\\[|\\]|\\^|\\(|\\)|\\\"|\\~|\\:|\\;|\\\\)", "\\$1");
            if (r.IndexOf(' ') != -1)
                r = string.Format("{0}", r);
            return r;
        }

        private List<Artikel> sortArtikelList(List<Artikel> artikelList, int genArtId, int genArtIdTecDoc,
            string fzgIdent, List<int> genArtList = null,
            bool isFreitextsuche = false)
        {
            //Anforderungen an die Artikelsortierung:
            //Sortierung bzgl. der herstellerpriorisierung
            //wenn keine GenArt vorgegeben ist (z.B. bei Grafischer Suche oder verwandten Artikeln), dann Herstellerpriorisierung über mehrere GenArts, 
            //Sortierung nach der Herstellernummer aufsteigend
            //wenn fzgIdent != null ist -> nach der Herstellerpriorisierung kommt die Sortierung nach ArtikelSortnummer

            //zuerst Herstellerpriorisierung
            //if (genArtIdTecDoc > 0)
            //{
            //    int genArt = artikelList.SelectMany(art =>art.GenerischeArtikel).Where(x=>x.GenArtNummerTecDoc== genArtIdTecDoc).First().Id;
            //    foreach (var art in artikelList)
            //    {
            //        art.HerstellerSortiernummer = art.Herstellersortiernummer.Where(x => x.GenArtId == genArt).First().Sortiernummer;
            //    }
            //}
            //else 

            if (genArtId > 0)
            {
                foreach (var art in artikelList)
                {
                    if (art.Herstellersortiernummer.Count(x => x.GenArtId == genArtId) > 0)
                        art.HerstellerSortiernummer =
                            art.Herstellersortiernummer.Where(x => x.GenArtId == genArtId).First().Sortiernummer;
                    else
                        art.HerstellerSortiernummer = 99999;
                    if (art.Artikelsortiernummer.Count(x => x.GenArtId == genArtId) > 0)
                        art.ArtikelSortiernummer =
                            art.Artikelsortiernummer.Where(x => x.GenArtId == genArtId).First().Sortiernummer;
                    else
                        art.ArtikelSortiernummer = 99999;
                }
            }
            else if ((genArtList != null && genArtList.Count > 0) || isFreitextsuche)
            {
                foreach (var art in artikelList)
                {
                    long sumHer = art.Herstellersortiernummer.Sum(x => x.Sortiernummer);
                    art.HerstellerSortiernummer = sumHer > 0 ? sumHer : 99999;

                    long sumArt = art.Artikelsortiernummer.Sum(x => x.Sortiernummer);
                    art.ArtikelSortiernummer = sumArt > 0 ? sumArt : 99999;
                }
            }

            //else
            //{
            //    //bei grafischer Suche oder verwandten Artikel können mehrere GenArts vorkommen
            //    foreach (var art in artikelList)
            //    {
            //        if (art.Herstellersortiernummer.Count > 0)
            //            art.HerstellerSortiernummer = art.Herstellersortiernummer.Where(x => x.GenArtId == genArtId).First().Sortiernummer;
            //        if (art.Artikelsortiernummer.Count > 0)
            //            art.ArtikelSortiernummer = art.Herstellersortiernummer.Where(x => x.GenArtId == genArtId).First().Sortiernummer;
            //    }
            //}

            //artikelList.Sort(delegate(Artikel a1, Artikel a2) { return a1.HerstellerSortiernummer.CompareTo(a2.HerstellerSortiernummer); });

            if ((genArtList != null && genArtList.Count > 0) || isFreitextsuche)
            {
                return
                    artikelList.OrderBy(x => x.GenArtForSortierung)
                        .ThenBy(x => x.HerstellerSortiernummer)
                        .ThenBy(x2 => x2.ArtikelSortiernummer)
                        .ToList<Artikel>();
            }

            return
                artikelList.OrderBy(x => x.HerstellerSortiernummer)
                    .ThenBy(x2 => x2.ArtikelSortiernummer)
                    .ToList<Artikel>();
        }


        /// <summary>
        /// Liefert uns den Artikel
        /// </summary>
        /// <param name="hlk">VdbHerstellerKuerzel</param>
        /// <param name="artikelnummer">VdbArtikelnummer</param>
        /// <param name="fahrzeugId">FahrzeugId</param>
        /// <param name="csoCode">CsoCode</param>
        /// <returns></returns>
        public Artikel GetArtikelDetailsByHlkAndArtikelnummer(ServiceContext context, string hlk, string artikelnummer,
            string csoCode)
        {
            try
            {
                var qDesc = _index.NewQueryDescription();
                var qBuild = _index.NewQueryBuilder();

                qDesc.Query = qBuild
                    .Expression(x => x.VdbHerstellerkuerzel, hlk)
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.VdbArtikelnummer, artikelnummer)
                    .Create();

                AddStandardDynamicFields(context, qDesc);

                var result = _index.QueryEx(qDesc);
                if (result.Documents.Count == 0)
                {
                    return null;
                }

                var doc = result.Documents.First();

                var artikel = ArtikelMapper.Map(doc);

                return artikel;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);
                if (OnNetworkError(context, ex))
                    return GetArtikelDetailsByHlkAndArtikelnummer(context, hlk, artikelnummer, csoCode);
                return new Artikel();
            }
            catch
            {
                return new Artikel();
            }
        }

        public IDictionary<string, int> GetOutletArtikelInfo()
        {
            try
            {
                var outletArtikel = new Dictionary<string, int>();
                var qDesc = _index.NewQueryDescription();
                var qBuilder = _index.NewQueryBuilder();

                qBuilder.Expression(x => x.Aktionsnummer, 30);
                qDesc.Query = qBuilder.Create();

                //Facet
                var facetField = _index.GetFieldName(x => x.VdbHerstellerkuerzel);
                var facet = new SolrFacetQuery(facetField, null, FacetSort.Index, -1);

                qDesc.FacetQueries.Add(facet);

                var qResult = _index.QueryEx(qDesc);

                var facetresult = qResult.Facets.SingleOrDefault(x => x.FieldName == facetField);

                if (facetField != null)
                {
                    foreach (var item in facetresult.Counts)
                    {
                        outletArtikel.Add(item.Key, item.Value);
                    }
                }

                return outletArtikel;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);
                if (OnNetworkError(null, ex))
                    return GetOutletArtikelInfo();

                return new Dictionary<string, int>();
            }
        }

        public ArtikelSearchResult FindArtikelByHlkAndArtikelnummer(ServiceContext context, string suchtext,
            ArtikelSuchoptionen options, int startIndex, int rowCount)
        {
            try
            {
                var qDesc = _sortIndex.NewQueryDescription();
                var qBuilder = _sortIndex.NewQueryBuilder();
                var fqBuilder = _sortIndex.NewQueryBuilder();
                var fqSubBuilder = _sortIndex.NewQueryBuilder();

                string breadCrumbFacetField = null;
                string genArtFacetField = null;

                //Suchtext

                #region Suchtext

                if (string.IsNullOrEmpty(suchtext))
                {
                    qBuilder.AllExpression();
                }
                else
                {
                    qBuilder.SubQuery(CreateSearchPhraseNumberQuery(suchtext));
                }

                #endregion

                //SearchOnNumbers

                #region SearchOnNumbers

                if (options.SearchOnNumbers && !string.IsNullOrEmpty(suchtext))
                {
                    qBuilder
                        .Operator(SolrQueryOperator.Or);

                    qBuilder
                        .Expression(x => x.Artikelnummer, string.Format("\"{0}\"", suchtext), 100000)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.ArtikelnummerSuche, string.Format("\"{0}\"", suchtext), 50000)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.ArtikelnummerSuche,
                            QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*", 10000)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.EaNummer, string.Format("\"{0}\"", suchtext), 100000)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.EaNummer, QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*",
                            1000).Operator(SolrQueryOperator.Or)
                        .Expression(x => x.GebrauchsnummerSuche, string.Format("\"{0}\"", suchtext), 500)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.GebrauchsnummerSuche,
                            QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*", 100)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.ReferenznummerSuche, string.Format("\"{0}\"", suchtext), 50)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.ReferenznummerSuche,
                            QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*", 10)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.Vergleichsnummer, string.Format("\"{0}\"", suchtext), 5)
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.Vergleichsnummer,
                            QuoteString(Regex.Replace(suchtext.ToLower(), @"\W", "")) + "*", 1)
                        .Operator(SolrQueryOperator.Or);
                }

                #endregion

                //AktionenOnTop

                #region AktionenOnTop

                if (options.AktionenOnTop != null)
                {
                    foreach (var aktionsfilter in options.AktionenOnTop)
                    {
                        if (aktionsfilter.Absatzgruppe > 0)
                        {
                            qDesc.AddDynamicFieldKey(x => x.AktionsnummerAbsatzgruppe, aktionsfilter.Absatzgruppe);
                        }
                        if (aktionsfilter.Kundengruppe > 0)
                        {
                            qDesc.AddDynamicFieldKey(x => x.AktionsnummerKundengruppe, aktionsfilter.Kundengruppe);
                        }
                    }
                }

                #endregion


                //FilterQuery           

                //ShowAllPseudoartikel
                if (options.ShowAllPseudoartikel)
                {
                    fqSubBuilder
                        .Expression(x => x.IsPseudoartikel, true);

                    fqBuilder.SubQuery(fqSubBuilder);

                    // Incentive Bundles ausschließen
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.IsIncentiveBundle, false);
                }
                else
                {
                    // Incentive Bundles ausschließen
                    fqBuilder
                        .Expression(x => x.IsIncentiveBundle, false);
                }


                //FahrzeugId
                if (options.Fahrzeug != null)
                {
                    var fzgIdent = string.Format("{0}{1}", options.Fahrzeug.Fahrzeugart.Name,
                        options.Fahrzeug.FahrzeugId);
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.FahrzeugId, fzgIdent);
                }

                //Hersteller

                #region Hersteller

                if (options.Herstellerkuerzel != null && options.Herstellerkuerzel.Count() > 0)
                {
                    var herstellerSubQuery = _sortIndex.NewQueryBuilder();
                    foreach (var hlk in options.Herstellerkuerzel)
                    {
                        herstellerSubQuery
                            .Operator(SolrQueryOperator.Or)
                            .Expression(x => x.VdbHerstellerkuerzel, hlk);
                    }
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(herstellerSubQuery);
                }

                #endregion

                //Artikelnummer

                #region Artikelnummer

                if (options.Artikelnummer != null && options.Artikelnummer.Count() > 0)
                {
                    var ArtikelnummerSubQuery = _sortIndex.NewQueryBuilder();
                    foreach (var item in options.Artikelnummer)
                    {
                        ArtikelnummerSubQuery
                            .Operator(SolrQueryOperator.Or)
                            .Expression(x => x.VdbArtikelnummer, item);
                    }
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(ArtikelnummerSubQuery);
                }

                #endregion

                // HLK/ATNR Kombination

                #region HLK/ATNR Kombination

                var subQuery = _sortIndex.NewQueryBuilder();
                foreach (var item in options.HlkArtNr.Keys)
                {
                    var hersteller = item;
                    var herstellerSubQuery = _sortIndex.NewQueryBuilder()
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.VdbHerstellerkuerzel, hersteller);
                    var ArtikelnummerSubQuery = _sortIndex.NewQueryBuilder();
                    foreach (var nr in options.HlkArtNr[hersteller])
                    {
                        ArtikelnummerSubQuery
                            .Operator(SolrQueryOperator.Or)
                            .Expression(x => x.VdbArtikelnummer, nr);
                    }

                    herstellerSubQuery
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(ArtikelnummerSubQuery);

                    subQuery
                        .Operator(SolrQueryOperator.Or)
                        .SubQuery(herstellerSubQuery);

                }

                fqBuilder
                    .Operator(SolrQueryOperator.And)
                    .SubQuery(subQuery);

                #endregion

                //IsLieferbar

                #region IsLieferbar

                if (options.ShowNurLieferbar)
                {
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.IsLieferbar, true);
                }
                else
                {
                    qDesc.AddSortField(x => x.IsLieferbar, SolrSortDirection.Desc);
                }

                #endregion


                //isNfzUniversalArtikel
                fqBuilder
                    .Operator(SolrQueryOperator.And)
                    .Expression(x => x.IsNfzUniversalArtikel, options.IsNfzUniversalArtikel);


                //Suchbaumtyp Suchbaumtyp und GenArt

                #region Suchbaumtyp und GenArt

                if (options.Suchbaumtyp != null)
                {
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.Suchbaumtyp, options.Suchbaumtyp.Name);

                    breadCrumbFacetField = _index.GetFieldName(x => x.Breadcrumb, options.Suchbaumtyp.Name);
                    qDesc.FacetQueries.Add(new SolrFacetQuery(breadCrumbFacetField, null, FacetSort.Index, int.MaxValue));
                }

                // GenArtFacets
                if (options.ShowGenArtFacets)
                {
                    genArtFacetField = _index.GetFieldName(x => x.GenerischerArtikel);
                    qDesc.FacetQueries.Add(new SolrFacetQuery(genArtFacetField, null, FacetSort.Index, int.MaxValue));
                }


                //GenArtId
                if (options.GenArtId > 0)
                {
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.GenArtId, options.GenArtId);
                }

                #endregion

                qDesc.Query = qBuilder.Create();
                qDesc.FilterQuery = fqBuilder.Create();

                qDesc.StartIndex = 0;
                qDesc.RowCount = int.MaxValue;

                var qResult = _sortIndex.QueryEx(qDesc);
                var idList = qResult.Documents.Select(x => int.Parse(x.Id)).ToList();

                if (options.AktionenOnTop != null
                    && options.AktionenOnTop.Count() > 0
                    && (qResult.Documents.Any(x => x.AktionsnummerAbsatzgruppe != null)
                        || qResult.Documents.Any(x => x.AktionsnummerKundengruppe != null)))
                {
                    var aktionsList = new List<int>();
                    var otherList = new List<int>();
                    foreach (var doc in qResult.Documents)
                    {

                        foreach (var aktionsfilter in options.AktionenOnTop)
                        {

                            if (doc.AktionsnummerAbsatzgruppe != null &&
                                doc.AktionsnummerAbsatzgruppe.Any(x => x == aktionsfilter.Aktionsnummer)
                                ||
                                doc.AktionsnummerKundengruppe != null &&
                                doc.AktionsnummerKundengruppe.Any(x => x == aktionsfilter.Aktionsnummer))
                            {
                                aktionsList.Add(int.Parse(doc.Id));
                            }
                            else
                            {
                                otherList.Add(int.Parse(doc.Id));
                            }

                        }
                    }
                    idList = new List<int>();
                    idList.AddRange(aktionsList);
                    idList.AddRange(otherList);
                }

                var result = new ArtikelSearchResult(qResult.NumFound, startIndex, rowCount);

                if (breadCrumbFacetField != null)
                {
                    var facetResult = qResult.Facets.SingleOrDefault(x => x.FieldName == breadCrumbFacetField);
                    if (facetResult != null)
                    {
                        result.Suchbaumknoten = SuchbaumknotenMapper.Map(facetResult.Counts.Select(x => x.Key));
                        result.BreadCrumbs =
                            SuchbaumknotenMapper.MapBreadCrumbs(facetResult.Counts)
                                .OrderBy(x => x.Value)
                                .ToDictionary(x => x.Key, x => x.Value);
                    }
                }

                if (genArtFacetField != null)
                {
                    var facetResult = qResult.Facets.SingleOrDefault(x => x.FieldName == genArtFacetField);
                    if (facetResult != null)
                    {
                        result.GenerischeArtikel = GenArtMapper.MapFacet(facetResult.Counts);
                    }
                }

                result.Artikel = GetArtikelList(context, idList.Skip(startIndex).Distinct().Take(rowCount), true);

                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);
                if (OnNetworkError(context, ex))
                    return FindArtikelByHlkAndArtikelnummer(context, suchtext, options, startIndex, rowCount);

                return new ArtikelSearchResult(0, 0, 0);
            }
        }

        public ArtikelSearchResult FindArtikelByNummer(ServiceContext context, List<int> artikelIds)
        {
            try
            {
                var result = new ArtikelSearchResult(0, 0, 0);

                return result;
            }
            catch
            {
                return new ArtikelSearchResult(0, 0, 0);
            }
        }

        public ArtikelSearchResult FindSFPArtikelByHlkAndArtikelnummer(ServiceContext context,
            ArtikelSuchoptionen options, int startIndex, int rowCount)
        {
            try
            {
                var qDesc = _sortIndex.NewQueryDescription();
                var qBuilder = _sortIndex.NewQueryBuilder();
                var fqBuilder = _sortIndex.NewQueryBuilder();
                var fqSubBuilder = _sortIndex.NewQueryBuilder();

                string genArtFacetField = null;


                qBuilder.AllExpression();

                //FilterQuery 
                // HLK/ATNR Kombination

                #region HLK/ATNR Kombination

                var subQuery = _sortIndex.NewQueryBuilder();
                foreach (var item in options.HlkArtNr.Keys)
                {
                    var hersteller = item;
                    var herstellerSubQuery = _sortIndex.NewQueryBuilder()
                        .Operator(SolrQueryOperator.Or)
                        .Expression(x => x.VdbHerstellerkuerzel, hersteller);
                    var ArtikelnummerSubQuery = _sortIndex.NewQueryBuilder();
                    foreach (var nr in options.HlkArtNr[hersteller])
                    {
                        ArtikelnummerSubQuery
                            .Operator(SolrQueryOperator.Or)
                            .Expression(x => x.VdbArtikelnummer, nr);
                    }

                    herstellerSubQuery
                        .Operator(SolrQueryOperator.And)
                        .SubQuery(ArtikelnummerSubQuery);

                    subQuery
                        .Operator(SolrQueryOperator.Or)
                        .SubQuery(herstellerSubQuery);

                }

                fqBuilder
                    .Operator(SolrQueryOperator.And)
                    .SubQuery(subQuery);

                #endregion


                // GenArtFacets
                if (options.ShowGenArtFacets)
                {
                    genArtFacetField = _index.GetFieldName(x => x.GenerischerArtikel);
                    qDesc.FacetQueries.Add(new SolrFacetQuery(genArtFacetField, null, FacetSort.Index, int.MaxValue));
                }


                //GenArtId
                if (options.GenArtId > 0)
                {
                    fqBuilder
                        .Operator(SolrQueryOperator.And)
                        .Expression(x => x.GenArtId, options.GenArtId);
                }

                qDesc.Query = qBuilder.Create();
                qDesc.FilterQuery = fqBuilder.Create();

                qDesc.StartIndex = 0;
                qDesc.RowCount = int.MaxValue;

                var qResult = _sortIndex.QueryEx(qDesc);
                var idList = qResult.Documents.Select(x => int.Parse(x.Id)).ToList();

                var result = new ArtikelSearchResult(qResult.NumFound, startIndex, rowCount);

                if (genArtFacetField != null)
                {
                    var facetResult = qResult.Facets.SingleOrDefault(x => x.FieldName == genArtFacetField);
                    if (facetResult != null)
                    {
                        result.GenerischeArtikel = GenArtMapper.MapFacet(facetResult.Counts);
                    }
                }

                result.Artikel = GetArtikelList(context, idList.Distinct(), true);

                return result;
            }
            catch (System.Net.WebException ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);
                if (OnNetworkError(context, ex))
                    return FindSFPArtikelByHlkAndArtikelnummer(context, options, startIndex, rowCount);

                return new ArtikelSearchResult(0, 0, 0);
            }
        }

        public ArtikelSearchResult GetArtikelByMeinSortiment(ServiceContext context, List<int> artikelIds)
        {
            return new ArtikelSearchResult(0, 0, 0);
        }

        private SolrQueryBuilder<ArtikelSortDoc> CreateSearchPhraseNumberQuery(string suchText)
        {
            SolrQueryBuilder<ArtikelSortDoc> queryBuilder = _sortIndex.NewQueryBuilder();

            string _suchTextForNumberSearch = string.Format("{0}*",
                QuoteString(Regex.Replace(suchText.ToLower(), "([^a-z0-9])", "")));
            string _suchTextForSearch = QuoteString(suchText.ToLower());

            queryBuilder.DefaultExpression(string.Format("{0}", _suchTextForSearch)).Operator(SolrQueryOperator.Or);
            queryBuilder.DefaultExpression(string.Format("{0}*", _suchTextForSearch)).Operator(SolrQueryOperator.Or);
            queryBuilder.DefaultExpression(string.Format("*{0}", _suchTextForSearch)).Operator(SolrQueryOperator.Or);
            queryBuilder.DefaultExpression(string.Format("\"{0}\"", _suchTextForSearch)).Operator(SolrQueryOperator.Or);
            queryBuilder.DefaultExpression(string.Format("\"{0}*\"", _suchTextForSearch)).Operator(SolrQueryOperator.Or);
            queryBuilder.DefaultExpression(string.Format("\"*{0}\"", _suchTextForSearch)).Operator(SolrQueryOperator.Or);
            queryBuilder.Expression(x => x.ArtikelnummerSuche, _suchTextForNumberSearch).Operator(SolrQueryOperator.Or);
            queryBuilder.Expression(x => x.GebrauchsnummerSuche, _suchTextForNumberSearch)
                .Operator(SolrQueryOperator.Or);
            queryBuilder.Expression(x => x.EaNummer, _suchTextForNumberSearch).Operator(SolrQueryOperator.Or);
            queryBuilder.Expression(x => x.ReferenznummerSuche, _suchTextForNumberSearch).Operator(SolrQueryOperator.Or);
            queryBuilder.Expression(x => x.Vergleichsnummer, _suchTextForNumberSearch);
            return queryBuilder;
        }

        private ServiceContext _timerContext = null;

        private bool HealthTimerCallback(object state)
        {
            try
            {

                if (!_index_prim.Initialized)
                {
                    _index_prim.Initialize();

                    if (_index_prim.Initialized)
                        TryInitialize();
                }

                if (_index_prim.Initialized)
                {
                    if (_timerContext != null)
                    {
                        UebergabeFuerSolr search = new UebergabeFuerSolr();
                        search.FzgArt = Fahrzeugart.Pkw;
                        search.SbTyp = Suchbaumtyp.Pkw;
                        search.FzgId = 68193;
                        search.GenArtId = 874;
                        var result = this.GetArtikelByGenerischerArtikel_Servertest(_timerContext, search);

                        return true;

                    }
                }
                else
                {
                    return false;
                }
            }
            catch (System.Net.WebException)
            {
                // Noch Fehler...
            }
            catch (Exception ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);
            }

            return false;
        }

        private bool OnNetworkError(ServiceContext context, Exception ex)
        {

            if (context != null)
                _timerContext = context;

            return false; //_fallbackHandler.OnError(ex);

        }

        private void TryInitialize()
        {
            _stuecklistenIndex_prim.Initialize();
            _tauschartikelIndex_prim.Initialize();
            _dokumentIndex_prim.Initialize();
            _verwandteartikelIndex_prim.Initialize();
            _logistikInfosIndex_prim.Initialize();
            _nummernIndex_prim.Initialize();
            _gefahrgutIndex_prim.Initialize();
            _fahrzeugIdsIndex_prim.Initialize();
            _dokumentUndLinksIndex_prim.Initialize();
        }

    }
}
