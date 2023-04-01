using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Common;
using PV.DomainObjects.Fahrzeug;
using PV.DomainObjects.Plus;
using PvKatalogsystem.Services.SqlQueries.Mapper;
using PvKatalogsystem.Types.DTOs;
using PvKatalogsystem.Types.Enums;
using Artikel = PV.DomainObjects.Artikel.Artikel;


namespace ArtikelService.PVSolrServices.Mapper
{
    public class ArtikelMapper
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static bool vkPreiseFromDb = false;

        //static System.Windows.Forms.RichTextBox _rtBox;
        //static System.Windows.Forms.RichTextBox rtBox
        //{
        //    get
        //    {
        //        if (_rtBox == null)
        //        {
        //            _rtBox = new System.Windows.Forms.RichTextBox();
        //        }
        //        return _rtBox;
        //    }
        //}

        public static PV.DomainObjects.Artikel.Artikel Map(PvKatalogsystem.Types.DTOs.Artikel dto, ArtikelTypen artikelTyp, int genArtNr = 0, bool mitHerstellerpriorisierung = false, bool isPitstop = false, bool isStahlgruber = false)
        {
            var back = new PV.DomainObjects.Artikel.Artikel();
            switch (artikelTyp)
            {
                case ArtikelTypen.Stueckliste:
                    back = new PV.DomainObjects.Artikel.StuecklistenArtikel();
                    break;
                case ArtikelTypen.VerwandterArtikel:
                    back = new PV.DomainObjects.Artikel.VerwandterArtikel();
                    break;
                case ArtikelTypen.ZubehoerArtikel:
                    back = new PV.DomainObjects.Artikel.ZubehoerArtikel();
                    break;
                case ArtikelTypen.TopProdukt:
                    back = new PV.DomainObjects.Artikel.TopProdukt();
                    break;
                case ArtikelTypen.PraemienArtikel:
                    back = new PraemienArtikel();
                    break;
                case ArtikelTypen.Incentive:
                    back = new IncentiveArtikel();
                    break;
            }

            back.HerstellerName = string.IsNullOrEmpty(dto.Hersteller.Name) ? string.Empty : dto.Hersteller.Name;
            back.ArtikelNummer = dto.Artikelnummer;
            back.TiRepArtikelNummer = dto.Katalognummer;
            back.HerstellerKurzName = string.IsNullOrEmpty(dto.Hersteller.Name) ? string.Empty : dto.Hersteller.Name;

            //DLNr wird zur Identifzierung des Artikels benötigt
            back.DatenlieferantenNummer = dto.Hersteller.DLNr;
            back.HerstellerNummer = dto.Hersteller.Nummer;

            if ((dto.Suchergebnisfelder & PvKatalogsystem.Types.Enums.Suchergebnisfelder.Artikelnummer) != 0)
            {
                back.GefundenUeberListe.Add(PV.DomainObjects.Artikel.Artikel_Nummernsuche.FoundBy.Artikelnummer);
                back.GefundenUeberNummer = "Artikelnummer";
            }
            else if ((dto.Suchergebnisfelder & PvKatalogsystem.Types.Enums.Suchergebnisfelder.Ean) != 0)
            {
                back.GefundenUeberListe.Add(PV.DomainObjects.Artikel.Artikel_Nummernsuche.FoundBy.EANummer);
                back.GefundenUeberNummer = "EAN-Nummer";
            }
            else if ((dto.Suchergebnisfelder & PvKatalogsystem.Types.Enums.Suchergebnisfelder.Gebrauchsnummer) != 0)
            {
                back.GefundenUeberListe.Add(PV.DomainObjects.Artikel.Artikel_Nummernsuche.FoundBy.Gebrauchsnummer);
                back.GefundenUeberNummer = "Gebrauchsnummer";
            }
            else if ((dto.Suchergebnisfelder & PvKatalogsystem.Types.Enums.Suchergebnisfelder.Referenznummer) != 0)
            {
                back.GefundenUeberNummer = "Referenznummer/OE-Nummer";
                back.GefundenUeberListe.Add(PV.DomainObjects.Artikel.Artikel_Nummernsuche.FoundBy.Referenznummer);
            }
            else if ((dto.Suchergebnisfelder & PvKatalogsystem.Types.Enums.Suchergebnisfelder.Vergleichsnummer) != 0)
            {
                back.GefundenUeberListe.Add(PV.DomainObjects.Artikel.Artikel_Nummernsuche.FoundBy.Vergleichsnummer);
                back.GefundenUeberNummer = "Vergleichsnummer";
            }
            else if ((dto.Suchergebnisfelder & PvKatalogsystem.Types.Enums.Suchergebnisfelder.Matchcode) != 0)
            {
                back.GefundenUeberListe.Add(PV.DomainObjects.Artikel.Artikel_Nummernsuche.FoundBy.Matchcode);
                back.GefundenUeberNummer = "Matchcode";
            }

            back.HatStuecklistePV = dto.HasStuecklistePV;
            back.HatStuecklisteTecDoc = dto.HasStuecklisteTecDoc;

            back.Pfandwert = dto.Pfandwert;
            back.AltteilKennzeichen = dto.AltteilKennzeichen;

            back.HatAlternativArtikelPV = dto.HasTauschartikelPV;
            back.HatAlternativArtikelTecDoc = dto.HasTauschartikelTecDoc;
            back.HatVerwandteArtikel = dto.HasVerwandteArtikel;
            back.KZMat = dto.HasMaterialCertification;
            back.KZSB = dto.IsSelfServicePackage;
            back.KZAT = dto.IsRemanufacturedPart;

            back.Verpackungsart = dto.Verpackungsart;
            back.Einheit = dto.Einheit;
            back.MengeProEinheit = dto.MengeProEinheit;
            back.EinheitenProVerpackung = dto.EinheitenProVerpackung;
            back.TeaserAnzeigedatumMax = dto.TeaserAnzeigedatumMax;
            back.TeaserAnzeigedatumMin = dto.TeaserAnzeigedatumMin;
            back.TeaserName = dto.TeaserName;

            back.MengeneinheitFaktor = dto.MengenEinheitsFaktor;
            back.MengeneinheitBezeichnung = dto.Mengeneinheitsbezeichnung;
            back.TechMengeneinheitBezeichnung = dto.TechnischeMengeneinheitBezeichnung;
            back.MengeneinheitBezeichnung = dto.Mengeneinheitsbezeichnung;
            back.TechMengeneinheitFaktor = dto.TechnischeMengeneinheitFaktor;
            back.PreiseinheitBezeichnung = dto.Preiseinheit.PreiseinheitBezeichnung;
            back.PreiseinheitFaktor = dto.Preiseinheit.PreisEinheitUmrechnungsFaktor;
            back.MarketingBezeichnung = dto.Marketingbezeichnung;
            back.TiRepBaugruppenNummer = dto.PvManagerGruppe;
            back.IstPseudoArtikel = dto.IsPseudoartikel;
            back.PitstopWarengruppe = dto.Warengruppen.PitstopWAGR;
            back.VdbWarengruppe = dto.Warengruppen.VdbWAGR;
            back.VdbArtikelzustand = dto.VdbArtikelzustand;

            MapVKPreis(dto, back, isPitstop, isStahlgruber);

            if (dto.IsAltteil)
                back.UStTag = "AT";
            else
            {
                switch (dto.MwstSchluessel)
                {
                    case 1:
                        back.UStTag = "E";
                        break;
                    case 2:
                        back.UStTag = "V";
                        break;
                    default:
                        back.UStTag = "V";      // solange es noch keine OutPri.csv Datei gibt, setzen wir das auf volle Steuer, da alle Artikel "V" sind
                        break;
                }
            }

            // Ist in Pims2 eindeutig.
            //todo: LinkageId
            //back.LinkageId = o.LinkageId;
            back.ArtikelId = dto.Id;

            //Artikelbild
            if (dto.SensitiveAreas.Count > 0)
            {
                MapSensitiveAreas(dto.SensitiveAreas, back);
                back.Bilder = new List<PvImage>();
                if (string.IsNullOrEmpty(dto.Vorschaubild) && dto.SensitiveAreas.Count > 0)
                {
                    back.Bilder.Add(PvImage.FromTecDocSensitiveBild(dto.SensitiveAreas.First().BackgroundPictureFileName));
                    //artikel.Vorschaubild = artikel.SensitiveAreas.First().BackgroundPictureFileName;
                }
                else if (null != dto.Vorschaubild)
                {
                    back.Bilder.Add(PvImage.FromTecDocSensitiveBild(dto.Vorschaubild));
                }
            }
            else if (null != dto.Vorschaubild)
            {
                if (back is PraemienArtikel)
                {
                    back.Bilder = new List<PvImage>();
                    back.Bilder.Add(PvImage.FromTecDocPraemienArtikelBild((Int64)dto.Hersteller.Nummer, dto.Vorschaubild, string.Empty, string.Empty));
                }
                else
                {
                    back.Bilder = new List<PvImage>();
                    back.Bilder.Add(PvImage.FromTecDocArtikelBild((Int64)dto.Hersteller.Nummer, dto.Vorschaubild, string.Empty, string.Empty));
                }
            }

            back.HerstellerLogo = PvImage.FromPims2HerstellerLogo(dto.Hersteller.Logo);

            if (dto.GenerischeArtikel != null && dto.GenerischeArtikel.Any())
            {
                if (genArtNr == 0 || dto.GenerischeArtikel.Count == 1)
                {
                    back.GenArtBezeichnung = dto.GenerischeArtikel[0].Bezeichnung;
                    back.GenArtNr = dto.GenerischeArtikel[0].Id;
                    back.GenArtNrTecDoc = dto.GenerischeArtikel[0].GenArtNummerTecDoc;
                }
                else if (dto.GenerischeArtikel.Count(x => x.GenArtNummerTecDoc == genArtNr) > 0)
                {
                    var genArt = dto.GenerischeArtikel.First(x => x.GenArtNummerTecDoc == genArtNr);
                    back.GenArtBezeichnung = genArt.Bezeichnung;
                    back.GenArtNr = genArt.Id;
                    back.GenArtNrTecDoc = genArt.GenArtNummerTecDoc;
                }
                else if (dto.GenerischeArtikel.Count(x => x.Id == genArtNr) > 0)
                {
                    //Für Herstellerstücklisten ist dies notwendig
                    var genArt = dto.GenerischeArtikel.First(x => x.Id == genArtNr);
                    back.GenArtBezeichnung = genArt.Bezeichnung;
                    back.GenArtNr = genArt.Id;
                    back.GenArtNrTecDoc = genArt.GenArtNummerTecDoc;
                }
                else
                {
                    back.GenArtBezeichnung = dto.GenerischeArtikel.First().Bezeichnung;
                    back.GenArtNr = dto.GenerischeArtikel.First().Id;
                    back.GenArtNrTecDoc = dto.GenerischeArtikel.First().GenArtNummerTecDoc;
                }
            }
            else
                back.GenArtBezeichnung = string.Empty;

            if (dto.Zusatzbezeichnungen != null && dto.Zusatzbezeichnungen.Count > 0)
            {
                back.Bezeichnung = string.Join(" ", dto.Zusatzbezeichnungen).Trim();
            }
            else if (string.IsNullOrEmpty(back.GenArtBezeichnung) && dto.VdbInformationen != null)
            {
                back.Bezeichnung = dto.VdbInformationen.Bezeichnung;
            }
            else if (string.IsNullOrEmpty(back.GenArtBezeichnung))
            {
                back.Bezeichnung = dto.Bezeichnung;
            }

            if (dto.VdbInformationen != null && dto.VdbInformationen.Identifikator != null &&
                !string.IsNullOrEmpty(dto.VdbInformationen.Identifikator.Artikelnummer)
                && !string.IsNullOrEmpty(dto.VdbInformationen.Identifikator.Herstellerkuerzel))
            {
                back.VDBArtikelNummer = dto.VdbInformationen.Identifikator.Artikelnummer;
                back.HLK = dto.VdbInformationen.Identifikator.Herstellerkuerzel;
                back.HerstellerKurzName = GetKurzName(back.HLK);
                //back.AbholVerfuegbarkeit = VerfuegbarkeitsMapper.Map(dto.VdbInformationen.Abholverfuegbarkeit);
                //todo: Warengruppe fehlt
                //back.Warengruppe = (uint)(o.VdbInfo.Warengruppe);
                //back.Warengruppenbezeichnung = o.VdbInfo.WarengruppenBezeichnung;
            }
            else
            {
                back.AbholVerfuegbarkeit = PV.DomainObjects.Warenkorb.wkVerfuegbarkeit.NichtBestellbar;
                back.Verfuegbarkeit = PV.DomainObjects.Warenkorb.wkVerfuegbarkeit.NichtBestellbar;
            }

            //back.DatenlieferantenNummer = 3;
            //back.IsVDBArtikel = true;

            back.VDBStatus = PV.DomainObjects.Warenkorb.wkPositionStatus.Neu;
            back.IsVDBArtikel = false;
            back.VDBArtikelInfoLoaded = false;
            back.Gebrauchsnummern = dto.GebrauchsnummernSofortanzeige;
            back.ErsetzendeArtikelnummern = dto.ErsetzendeArtikelnummernSofortanzeige;
            back.ErsetzteArtikelnummern = dto.ErsetzteArtikelnummernSofortanzeige;

            back.Kriterien = new List<ArtikelKriterium>();
            MapAttibute(dto.Attribute, back, false);

            MapAttributbloecke(dto.Attributbloecke, back);

            MapArtikelInformationen(dto.Informationen, back);

            MapArtikelInformationenLinkageId(dto.Attributbloecke, back);

            MapArtikelDokumente(dto.DokUndLinks.Dokumente, back);
            MapArtikelLinks(dto.DokUndLinks.Links, back);

            if (dto.Aktionsinformationen.Count > 0)
            {
                DateTime aktuellesDatum = DateTime.Now.Date;
                foreach (var aktion in dto.Aktionsinformationen)
                {
                    if (aktion.AnzeigedatumMax.Date >= aktuellesDatum &&
                        ((aktion.AnzeigedatumMin.HasValue && aktion.AnzeigedatumMin.Value.Date <= aktuellesDatum) ||
                        !aktion.AnzeigedatumMin.HasValue))
                    {
                        //back.Aktion = AktionsMapper.Map(aktion, dto);
                        break;
                    }
                }
            }

            //NodeIds
            MapArtikelNodeIDs(dto.NodeIDs, back);
            //Dokumente
            //MapArtikelDokumente(dto.Dokumente, back);
            //Links
            //MapArtikelLinks(dto.Links, back);

            if (mitHerstellerpriorisierung)
            {
                if (dto.Herstellersortiernummer.FirstOrDefault() != null)
                    back.HerstellerSortiernummer = dto.Herstellersortiernummer.First().Sortiernummer;
                else
                    back.HerstellerSortiernummer = 99999;
            }

            //back.UStTag = dto.VdbInformationen

            //var tecComSuppliers = PVEntity2Provider.ExterneArtikeldaten.ExterneArtikeldatenProvider.GetTecComDlNr();
            //if (tecComSuppliers != null && tecComSuppliers.Contains((int)back.DatenlieferantenNummer))
            //{
            //    back.TecCom = true;
            //}

            return back;
        }

        private static Dictionary<string, string> _hlk_kurzname = null;

        private static string GetKurzName(string hlk)
        {
            string back = string.Empty;

            if (_hlk_kurzname == null)
            {
                //string fname = ConfigurationManager.AppSettings["hlk-kb"];
                //if (System.IO.File.Exists(fname))
                //{
                //    var content = System.IO.File.ReadAllLines(fname);

                //    _hlk_kurzname = new Dictionary<string, string>();

                //    foreach (var item in content)
                //    {
                //        var parts = item.Split('=');

                //        if (parts.Length == 2)
                //            if (!_hlk_kurzname.ContainsKey(parts[0]))
                //                _hlk_kurzname.Add(parts[0], parts[1]);
                //    }


                //}

            }

            //_hlk_kurzname.TryGetValue(hlk, out back);

            return back;
        }

        private static void MapVKPreis(PvKatalogsystem.Types.DTOs.Artikel dto, PV.DomainObjects.Artikel.Artikel back, bool isPitstop, bool isStahlgruber)
        {
            //if (vkPreiseFromDb)
            //{
            //    decimal pitPreis = 0;
            //    decimal stahlgruberPreis = 0;
            //    //var preisInfo = ExterneArtikeldatenProvider.GetVkPreis(
            //    //    dto.Id);

            //    decimal pitPreisK = 0;

            //    if (preisInfo != null)
            //        pitPreisK = preisInfo.Value.Key;


            //    if (preisInfo.HasValue)
            //        pitPreisK = preisInfo.Value.Value;


            //    if (isPitstop && (pitPreis = ExterneArtikeldatenProvider.GetVkPreisPitstop(dto.Id, pitPreisK)) > 0)
            //    {
            //        if (preisInfo != null)
            //            back.VKPreis = pitPreis;
            //    }
            //    else if (isStahlgruber && ((stahlgruberPreis = ExterneArtikeldatenProvider.GetVkPreisStahlgruber(dto.Artikelnummer, dto.Hersteller.DLNr)) > 0 && !isPitstop))
            //    {
            //        back.VKPreis = stahlgruberPreis;
            //    }
            //    else if (dto.VerkaufspreisKompass > 0)
            //    {
            //        if (preisInfo != null)
            //        {
            //            back.VKPreis = preisInfo.Value.Key;
            //        }
            //    }
            //    else
            //    {
            //        if (preisInfo != null)
            //        {
            //            back.VKPreis = preisInfo.Value.Key;
            //        }
            //    }
            //}
            //else
            {
                if (isPitstop && dto.VerkaufspreisPitstop > 0)
                {
                    back.VKPreis = dto.VerkaufspreisPitstop;
                }
                else if (isStahlgruber && dto.VerkaufspreisStahlgruber > 0 && !isPitstop)
                {
                    back.VKPreis = dto.VerkaufspreisStahlgruber;
                }
                else if (dto.VerkaufspreisKompass > 0)
                {
                    back.VKPreis = dto.VerkaufspreisKompass;
                }
                else
                {
                    back.VKPreis = dto.Verkaufspreis;
                }
            }
        }

        private static void MapArtikelInformationen(List<Artikelinfo> artikelinfo, PV.DomainObjects.Artikel.Artikel artikel)
        {
            if (artikelinfo != null && artikelinfo.Count > 0)
            {
                string hinweistext, hinweisart, hinweistextOhneRTF;
                foreach (var infos in artikelinfo.Where
                    (x => !(x.Name.Contains("Artikelliste (Shop)")
                        || x.Name.Contains("Artikeldetailseite (Shop)"))))
                {
                    //RTF konvertieren
                    try
                    {
                        hinweistext = infos.WertRTF;
                        hinweistextOhneRTF = infos.Wert;

                        //FontSize darf maximal zweistellig sein
                        hinweistext = ueberpruefeRTFText(hinweistext);
                        //rtBox.Rtf = hinweistext;
                        //hinweistext = rtBox.Text;//.Replace("\n", " ");

                        hinweisart = infos.Name;
                    }
                    catch
                    {
                        hinweistext = "Fehler beim Auslesen der ArtikelInformationen";
                        hinweisart = "Fehler";
                        hinweistextOhneRTF = "Fehler beim Auslesen der ArtikelInformationen";
                    }

                    if (infos.IsSofortanzeige)
                    {
                        if (artikel.SofortArtikelInformationenOhneRTF.Count(x => x.Key == hinweisart + ":") == 0)
                        {
                            var artikelinfotemp = artikelinfo.Where(x => !(x.Name.Contains("Artikelliste (Shop)")
                                || x.Name.Contains("Artikeldetailseite (Shop)")) && x.Name == hinweisart && x.IsSofortanzeige
                                && x.LinkageId == 0);

                            if (artikelinfotemp != null && artikelinfotemp.Count() > 0)
                            {
                                var hinweistextOhneRTF2 = string.Empty;

                                foreach (var infos2 in artikelinfotemp)
                                {
                                    if (!string.IsNullOrEmpty(hinweistextOhneRTF2))
                                    {
                                        hinweistextOhneRTF2 += "\n";
                                    }

                                    hinweistextOhneRTF2 += infos2.Wert;
                                }
                                if (!string.IsNullOrEmpty(hinweistextOhneRTF2))
                                {
                                    artikel.SofortArtikelInformationenOhneRTF.Add(new KeyValuePair<string, string>(hinweisart + ":", hinweistextOhneRTF2));
                                }
                            }
                        }

                        if (artikel.SofortArtikelInformationenFahrzeugbezogenOhneRTF
                            .Select(x => x.SofortArtikelInformationenOhneRTF).Count(x => x.Key == hinweisart + ":") == 0)
                        {
                            var artikelinfotempFahrzeugBezogen = artikelinfo.Where(x => !(x.Name.Contains("Artikelliste (Shop)")
                                || x.Name.Contains("Artikeldetailseite (Shop)")) && x.Name == hinweisart && x.IsSofortanzeige
                                && x.LinkageId > 0);

                            if (artikelinfotempFahrzeugBezogen != null && artikelinfotempFahrzeugBezogen.Count() > 0)
                            {
                                var artikelinfoGroup = artikelinfotempFahrzeugBezogen.GroupBy(x => x.LinkageId);

                                foreach (var infos2 in artikelinfoGroup)
                                {
                                    var hinweistextOhneRTF2 = string.Empty;

                                    foreach (var info3 in infos2)
                                    {
                                        if (!string.IsNullOrEmpty(hinweistextOhneRTF2))
                                        {
                                            hinweistextOhneRTF2 += "\n";
                                        }

                                        hinweistextOhneRTF2 += info3.Wert;
                                    }

                                    if (!string.IsNullOrEmpty(hinweistextOhneRTF2))
                                    {
                                        var infosF = new ArtikelInformationenFahrzeugbezogen();
                                        infosF.SofortArtikelInformationenOhneRTF = new KeyValuePair<string, string>(hinweisart + ":", hinweistextOhneRTF2);
                                        infosF.LinkageId = infos2.Key;
                                        artikel.SofortArtikelInformationenFahrzeugbezogenOhneRTF.Add(infosF);
                                    }
                                }
                            }
                        }

                        artikel.SofortArtikelInformationen.Add(new KeyValuePair<string, string>(hinweisart, hinweistext));
                    }

                    string hinweistextHTML = ConvertRtf(hinweistext);

                    if (!string.IsNullOrEmpty(hinweistextHTML))
                        artikel.ArtikelInformationenMitHTML.Add(new KeyValuePair<string, string>(hinweisart, hinweistextHTML));
                    else
                        artikel.ArtikelInformationenMitHTML.Add(new KeyValuePair<string, string>(hinweisart, hinweistextOhneRTF));

                    artikel.ArtikelInformationen.Add(new KeyValuePair<string, string>(hinweisart, hinweistext));
                    artikel.ArtikelInformationenOhneRTF.Add(new KeyValuePair<string, string>(hinweisart, hinweistextOhneRTF));
                }
            }
        }

        private static void MapArtikelInformationenLinkageId(List<Attributblock> attributbloecke, PV.DomainObjects.Artikel.Artikel artikel)
        {
            if (artikel.SofortArtikelInformationenFahrzeugbezogenOhneRTF != null
                && artikel.SofortArtikelInformationenFahrzeugbezogenOhneRTF.Count > 0 && attributbloecke.Count > 0
                && artikel.TypKriterien != null && artikel.TypKriterien.Count > 0)
            {
                foreach (var infos in artikel.SofortArtikelInformationenFahrzeugbezogenOhneRTF)
                {
                    if (artikel.TypKriterien.Count(x => x.LinkageId == infos.LinkageId) == 0)
                    {
                        if (attributbloecke.Count(x => x.ListLinkageId.Contains(infos.LinkageId)) > 0)
                        {
                            infos.LinkageId = attributbloecke.First(x => x.ListLinkageId.Contains(infos.LinkageId)).Attribute.First().LinkageId;
                        }
                    }
                }
            }
        }

        private static string ConvertRtf(string rtfText)
        {
            if (!rtfText.StartsWith("{\\rtf1"))
            {
                return "";
            }
            var result = "";
            try
            {
                //result = new Converter().ConvertToHtml(rtfText, true);
                //result = Regex.Replace(result, "font.*?[;\"]{1}", "");
            }
            catch
            {

            }
            return result;
        }
        private static string ueberpruefeRTFText(string rtfText)
        {
            //FontSize darf maximal zweistellig sein
            int firstPosition = rtfText.IndexOf("fs");
            firstPosition += 2;

            int count = 0;
            int temp = 0;
            if (firstPosition < (rtfText.Length - 3))
            {
                while (true)
                {
                    if (int.TryParse(rtfText[firstPosition].ToString(), out temp))
                    {
                        if (count == 2)
                        {
                            rtfText = rtfText.Insert(firstPosition, " ");
                            return rtfText;
                        }

                        count++;
                        firstPosition++;
                    }
                    else
                        return rtfText;
                }
            }
            return rtfText;
        }

        private static void MapArtikelNodeIDs(List<PvKatalogsystem.Types.DTOs.NodeIdGenArt> nodeIds, Artikel artikel)
        {
            artikel.NodeIDs = new List<PV.DomainObjects.Artikel.NodeIdGenArt>();
            foreach (var node in nodeIds)
            {
                if (artikel.NodeIDs.Count(x => x.GenArtId == node.GenArtId) == 0)
                {
                    artikel.NodeIDs.Add(new PV.DomainObjects.Artikel.NodeIdGenArt
                    {
                        GenArtId = node.GenArtId,
                        ParentNodeId = node.ParentNodeId
                    });
                }
            }
        }

        public static void MapArtikelDokumente(List<Dokument> dokumente, Artikel artikel)
        {
            artikel.Dokumente = new List<ArtikelDokument>();
            foreach (var dok in dokumente)
            {
                var artDok = new ArtikelDokument();
                artDok.Beschreibung = dok.Bezeichnung;

                if (dok.Fileformat != null)
                {
                    artDok.Bezeichnung = !dok.Fileformat.Contains("Bitmap (BMP)") && !dok.Fileformat.Contains("Bildformat JPEG")
                    ? dok.Bezeichnung : dok.Dokumenttyp;
                }
                else
                {
                    //alt, muss bei neuen Index raus
                    artDok.Bezeichnung = !dok.Dateityp.Contains("PIMS_") ? dok.Bezeichnung : dok.Dokumenttyp;
                }

                artDok.Target = dok.Dateiname;
                switch (dok.Bezeichnung)
                {
                    case "Einbauanleitung":
                        artDok.Typ = DokumentenTyp.Einbauanleitung;
                        break;
                    case "Sicherheitsdatenblatt":
                        artDok.Typ = DokumentenTyp.Sicherheitsdatenblatt;
                        break;
                    default:
                        artDok.Typ = DokumentenTyp.Sonstiges;
                        break;
                }

                artikel.Dokumente.Add(artDok);
            }
        }

        public static void MapArtikelLinks(List<Link> links, Artikel artikel)
        {
            artikel.Links = new List<ArtikelLink>();
            foreach (var link in links)
            {
                var artLink = new ArtikelLink();
                artLink.Bezeichnung = link.Bezeichnung;
                artLink.Uri = link.Uri;

                if (link.Bezeichnung.Contains("Einbauanleitung"))
                    artLink.Typ = DokumentenTyp.Einbauanleitung;
                else if (link.Bezeichnung.Contains("Sicherheitsdatenblatt"))
                    artLink.Typ = DokumentenTyp.Sicherheitsdatenblatt;
                else
                    artLink.Typ = DokumentenTyp.Sonstiges;

                artikel.Links.Add(artLink);
            }
        }

        public static List<AutoSuggestItem> MapAutoSuggest(IEnumerable<PvKatalogsystem.Types.Results.AutoSuggestItem> autoSuggestItems)
        {
            var result = new List<AutoSuggestItem>();

            foreach (var item in autoSuggestItems)
            {
                var autoSuggestItem = new AutoSuggestItem
                {
                    DisplayName = item.DisplayName,
                    DisplayNameSort = item.DisplayNameSort,
                    ResultCount = item.ResultCount,
                    GenArtId = item.GenArtId
                };
                switch (item.Type)
                {
                    case PvKatalogsystem.Types.Enums.AutoSuggestItemTypes.HerstellerUni:
                        autoSuggestItem.Type = PV.DomainObjects.Artikel.AutoSuggestItemTypes.HerstellerUni;

                        break;
                    case PvKatalogsystem.Types.Enums.AutoSuggestItemTypes.HerstellerFahrzeug:
                        autoSuggestItem.Type = PV.DomainObjects.Artikel.AutoSuggestItemTypes.HerstellerFahrzeug;

                        break;
                    case PvKatalogsystem.Types.Enums.AutoSuggestItemTypes.Kategorie:
                        autoSuggestItem.Type = PV.DomainObjects.Artikel.AutoSuggestItemTypes.Kategorie;
                        break;
                    case PvKatalogsystem.Types.Enums.AutoSuggestItemTypes.Kategorie_Uni:
                        autoSuggestItem.Type = PV.DomainObjects.Artikel.AutoSuggestItemTypes.Kategorie_Uni;
                        break;
                    case PvKatalogsystem.Types.Enums.AutoSuggestItemTypes.HerstellerHLKArtikel:
                        autoSuggestItem.Type = PV.DomainObjects.Artikel.AutoSuggestItemTypes.HerstellerHLKArtikel;
                        break;
                };

                result.Add(autoSuggestItem);
            }

            return result;
        }

        private static void MapAttributbloecke(List<Attributblock> attributbloecke, Artikel artikel)
        {
            artikel.TypKriterien = new List<ArtikelKriterium>();
            int i = 0;
            foreach (var attribut in attributbloecke)
            {
                ++i;
                MapAttibute(attribut.Attribute, artikel, true);

                if (i < attributbloecke.Count)
                {
                    artikel.TypKriterien.Add(new ArtikelKriterium()
                    {
                        BezeichnungLang = "oder",
                        SofortAnzeige = artikel.TypKriterien.Last().SofortAnzeige
                    });
                }
            }
        }

        private static void MapAttibute(List<Attribut> attribute, Artikel artikel, bool isAttributblock)
        {
            foreach (var attribut in attribute)
            {
                ArtikelKriterium kriterium = new ArtikelKriterium();
                kriterium.BezeichnungAbk = attribut.Kurzname;
                kriterium.BezeichnungEinheit = attribut.Einheit;
                kriterium.BezeichnungLang = attribut.Name;
                kriterium.KritWert = attribut.Wert;
                // In Pims2 gibt es keine laufende Nummer, daher wird die Sortiernummer verwendet
                kriterium.LfdNr = attribut.Sortiernummer.ToString();
                //todo: Pflichtkriterium fehlt
                kriterium.Pflichtkriterium = false;
                kriterium.SofortAnzeige = attribut.IsSofortanzeige;
                kriterium.HideName = attribut.HideName;
                kriterium.SortNr = attribut.Sortiernummer.ToString();
                //todo: Typ fehlt
                kriterium.Typ = string.Empty;

                kriterium.LinkageId = attribut.LinkageId;

                //kriterium.IsNameFettdruck = AttributeFettdruck.GetAttributeNameFuerFettdruck().Contains(attribut.Kurzname);

                if (isAttributblock)
                {
                    artikel.TypKriterien.Add(kriterium);
                }
                else
                    artikel.Kriterien.Add(kriterium);
            }

        }

        public static List<PV.DomainObjects.Artikel.Artikel> Map(IEnumerable<PvKatalogsystem.Types.DTOs.Artikel> dtoList, bool isPitStop, bool isStahlgruber)
        {
            var result = new List<PV.DomainObjects.Artikel.Artikel>();

            foreach (var dto in dtoList)
            {
                result.Add(Map(dto, ArtikelTypen.Normal, 0, false, isPitStop, isStahlgruber));
            }

            return result;
        }

        private static void MapSensitiveAreas(List<PvKatalogsystem.Types.DTOs.SensitiveArea> sensitiveAreas, Artikel artikel)
        {
            foreach (PvKatalogsystem.Types.DTOs.SensitiveArea item in sensitiveAreas)
            {

                PV.DomainObjects.Artikel.SensitiveArea sensitiveArea = new PV.DomainObjects.Artikel.SensitiveArea();

                sensitiveArea.Coords = item.Coords;
                sensitiveArea.BackgroundPictureFileName = item.BackgroundPictureFileName;

                foreach (int id in item.ArtikelIds)
                {
                    sensitiveArea.ArtikelIds.Add(id);
                }

                artikel.SensitiveAreas.Add(sensitiveArea);
            }
        }

        public static NummernTransport MapNummern(ArtikelSonstigeNummern nummern)
        {
            NummernTransport nummernTransport = new NummernTransport();

            nummernTransport.EANummern = nummern.EaNummern.Count > 0 ? nummern.EaNummern : null;
            nummernTransport.ErsetztVon = nummern.ErsetzteArtikelnummern.Count > 0 ? nummern.ErsetzteArtikelnummern : null;
            nummernTransport.ErsetztDurch = nummern.ErsetzendeArtikelnummern.Count > 0 ? nummern.ErsetzendeArtikelnummern : null;
            nummernTransport.GebrauchsNummern = nummern.Gebrauchsnummern.Count > 0 ? nummern.Gebrauchsnummern : null;
            nummernTransport.OENummern = nummern.OeReferenznummern.Count > 0 ? new List<OEHersteller>() : null;

            foreach (Referenznummer oenummer in nummern.OeReferenznummern)
            {
                var tmp = nummernTransport.OENummern.Where(x => x.Hersteller == oenummer.Hersteller).FirstOrDefault();

                if (tmp == null)
                {
                    OEHersteller oeHersteller = new OEHersteller()
                    {
                        Nummern = new List<string>()
                    };

                    oeHersteller.Hersteller = oenummer.Hersteller;
                    oeHersteller.Nummern.Add(oenummer.Nummer);
                    nummernTransport.OENummern.Add(oeHersteller);
                }
                else
                {
                    tmp.Nummern.Add(oenummer.Nummer);
                }
            }
            return nummernTransport;
        }
    }
}
