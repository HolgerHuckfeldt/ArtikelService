using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;
using System.Text.RegularExpressions;
using System.Diagnostics;
using PvKatalogsystem.Types.Enums;
using System.Globalization;
using System.Drawing;
using PvKatalogsystem.Services.Services.Solr.Documents.Artikel;

//using PV.Utilities.SystemConfiguration;

namespace PvKatalogsystem.Services.Services.Solr.Mapper
{
	public class ArtikelMapper
	{
		private readonly static CultureInfo _culture = new CultureInfo("en-US");
		private readonly static Regex _regexHersteller = new Regex(@"^(.+)\{(\d+)\}¦(.*)$", RegexOptions.Compiled);
		private readonly static Regex _regexAttribut = new Regex(@"^(\d+)¦([01]{1})¦([01]{1})¦(.*)¦(.*)¦(.*)¦(.*)$", RegexOptions.Compiled);
        private readonly static Regex _regexAttributblock = new Regex(@"^(\d+)¦(\d+)¦(\d+)¦([01]{1})¦([01]{1})¦(.*)¦(.*)¦(.*)¦(.*)¦(.*)$", RegexOptions.Compiled);
		private readonly static Regex _regexInformation = new Regex(@"^(\d+)¦([01]{1})¦(.*)¦(.*)¦(.*)$", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly static Regex _regexInformationByFahrzeug = new Regex(@"^(\d+)¦(\d+)¦([01]{1})¦(.*)¦(.*)¦(.*)¦(.*)$", RegexOptions.Compiled | RegexOptions.Singleline);
        private readonly static Regex _regexVerpackungsmenge = new Regex(@"^Verpackungsmenge¦(.*)$", RegexOptions.Compiled);
		private readonly static Regex _regexGebrauchsnummer = new Regex(@"^([01]+)¦(.*)$", RegexOptions.Compiled);
		private readonly static Regex _regexGenArt = new Regex(@"^(.+)\{(\d+)\}¦(\d+)$", RegexOptions.Compiled);
		private readonly static Regex _regexGenArtSortiernummer = new Regex(@"^(\d+)¦(\d+)$", RegexOptions.Compiled);
		private readonly static Regex _regexLogistikinformation = new Regex(@"^(.*)¦(.*)$", RegexOptions.Compiled);
		private readonly static Regex _regexReferenznummer = new Regex(@"^(.+)¦(.+)$", RegexOptions.Compiled);
		private readonly static Regex _regexErsatzartikelnummer = new Regex(@"^(OLD|NEW)¦(.*)$", RegexOptions.Compiled);
		private readonly static Regex _regexAktion = new Regex(@"^(\d+)¦(V|P)¦([^¦]*)¦([^¦]*)¦([^¦]*)¦([^¦]*)¦([^¦]*)¦([^¦]*)¦([^¦]*)¦([^¦]*)¦([\d\:\-ZT]*)¦([\d\:\-ZT]*)¦([\d\.]*)¦([\d\.]*)¦([01]{1})¦([01]{1})¦([\d\.]*)¦(\d*)¦([\d\.]*)$", RegexOptions.Compiled);
		private readonly static Regex _regexGefahrgutinformation = new Regex(@"^(.*)¦(.*)$", RegexOptions.Compiled);
		private readonly static Regex _regexFahrzeugId = new Regex(@"^([A-Z]+)(\d+)$");
        private readonly static Regex _regexDokument = new Regex(@"^(\d+)¦(.*)¦(.*)¦(.*)¦(.*)¦(.*)$", RegexOptions.Compiled);
		private readonly static Regex _regexLink = new Regex(@"^(\d*)¦(.*)¦(.*)¦(.*)$", RegexOptions.Compiled);
		private readonly static Regex _regexTopProdukt = new Regex(@"^(P|V|F)¦([^¦]*)¦([^¦]*)¦([^¦]*)¦([01]{1})¦(.*)¦(.*)¦(\d+)", RegexOptions.Compiled);
        private readonly static Regex _regexTeaserInfos = new Regex(@"^(PLUSPAGE1|PLUSPAGE2|PLUSTOP|PVA)¦(\d+)¦([01]{1})¦([\d\:\-ZT]*)¦([\d\:\-ZT]*)", RegexOptions.Compiled);
		private readonly static Random rand = new Random(DateTime.Now.Millisecond);
        private readonly static Regex _regexTeaserName = new Regex(@"^(\d+)¦(PLUSPAGE1|PLUSPAGE2|PLUSTOP|PVA|PVN)¦(.*)$", RegexOptions.Compiled);
        private readonly static CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

        private const char DELIMITER = '¦';

        //TopProduktTypen: "P" PreisVorteil, "V": FesterPunktewert, "F": TopProduktType.PunkeFaktor

        public static Artikel  Map(ArtikelDoc doc, int genArtId = 0, bool mitTopProdukt = false, TeaserTyp teaserTyp = TeaserTyp.NICHTS, bool isPitstop = false, bool mobileArtikeldetails = false)
		{

			var artikel = new Artikel();

			if (mitTopProdukt)
			{
				MapTopProdukt(doc, artikel);

				if (artikel.TopProdukt == null)
					return null;

				return artikel;
			}

			artikel.Id = int.Parse(doc.Id);
			artikel.Artikelnummer = doc.Artikelnummer;
			artikel.Katalognummer = doc.Katalognummer;
			artikel.Verkaufspreis = doc.Verkaufspreis;
			artikel.VerkaufspreisKompass = doc.Verkaufspreis_Kompass;
			artikel.VerkaufspreisPitstop = doc.Verkaufspreis_KompassPitstop;
            artikel.VerkaufspreisStahlgruber = doc.Verkaufspreis_KompassStahlgruber;
            
			artikel.Marketingbezeichnung = doc.Marketingbezeichnung;

			if (isPitstop)
				artikel.Vorschaubild = doc.PitstopVorschaubild;
			else
				artikel.Vorschaubild = doc.Vorschaubild;

			artikel.IsLieferbar = doc.IsLieferbar;
			artikel.HasMaterialCertification = doc.HasMaterialCertification;
			artikel.IsRemanufacturedPart = doc.IsRemanufacturedPart;
			artikel.IsSelfServicePackage = doc.IsSelfServicePackage;

			artikel.Verpackungsart = doc.Verpackungsart;
			artikel.Einheit = doc.Einheit;
			artikel.MengeProEinheit = doc.MengeProEinheit.HasValue ? (decimal)doc.MengeProEinheit : 0;
			artikel.EinheitenProVerpackung = doc.EinheitenProVerpackung.HasValue ? (int)doc.EinheitenProVerpackung : 0;

			artikel.MengenEinheitsFaktor = doc.MengenEinheitsFaktor > 0 ? doc.MengenEinheitsFaktor : 1;
            artikel.TechnischeMengeneinheitFaktor = artikel.MengenEinheitsFaktor;
			artikel.Mengeneinheitsbezeichnung = string.IsNullOrEmpty(doc.VerpackungseinheitBezeichnung) ? "Stück" : doc.VerpackungseinheitBezeichnung;
			artikel.IsGanzzahlMengeneingabe = doc.IsVerpackungseinheitGanzzahl;
			artikel.TechnischeMengeneinheitBezeichnung = string.IsNullOrEmpty(doc.TechnischeMengeneinheitBezeichnung) ? "Stück" : doc.VerpackungseinheitBezeichnung;
			//Neu!!
			artikel.ZusatzbezeichnungenB2C = doc.ZusatzbezeichnungB2C != null ? doc.ZusatzbezeichnungB2C.ToList() : null;
			artikel.Warengruppen.VdbWAGR = doc.Warengruppe;
			artikel.Warengruppen.PitstopWAGR = doc.PitstopWarengruppe;

			artikel.PvManagerGruppe = doc.PvManagerGruppe;
			artikel.IsAltteil = doc.IsAltteil;
			artikel.MwstSchluessel = doc.MwstSchluessel;
            artikel.VdbArtikelzustand = doc.VdbArtikelzustand;
            artikel.AltteilKennzeichen = (doc.AltteilKennzeichen != null && (doc.AltteilKennzeichen.Equals("T")
                || doc.AltteilKennzeichen.Equals("P") || doc.AltteilKennzeichen.Equals("U"))
                ? doc.AltteilKennzeichen : null);
            
            //double pfandwert = 0;
            //double.TryParse(doc.Pfandwert, style, culture, out pfandwert);
            artikel.Pfandwert = doc.Pfandwert; //pfandwert;

			artikel.IsPseudoartikel = doc.IsPseudoartikel;

			MapTechnischeMengenheitAusLogistikinfo(doc, artikel);

			MapGenArt(doc, artikel);

            changeAltteilKennzeichen(artikel);

			MapZusatzbezeichnung(doc, artikel);
			MapBezeichnung(doc, genArtId, artikel);
			MapPreiseinheit(doc, artikel);
			MapGebrauchsnummer(doc, artikel);
			MapErsatzartikelnummer(doc, artikel);
			MapHersteller(doc, artikel);
			MapVdbInformationen(doc, artikel);
			MapAttribut(doc, artikel);
			MapAttributblock(doc, artikel);
			MapInformation(doc, artikel);
            MapInformationByFahrzeug(doc, artikel);
			MapHasTauschartikel(doc, artikel);
			MapHasStueckliste(doc, artikel);
			MapHasVerwandteArtikel(doc, artikel);
			MapAktionsinfo(doc, artikel);
			MapHerstellersortiernummer(doc, artikel);
			MapArtikelsortiernummer(doc, artikel);
			MapSensitiveAreas(doc, artikel);
            MapArtikelDokumente(doc, artikel);

            if (mobileArtikeldetails)
            {
                if (doc.Logistikinfo != null && doc.Logistikinfo.Count > 0)
                {
                    LogistikinfosDoc docL = new LogistikinfosDoc()
                    {
                        Logistikinfo = doc.Logistikinfo
                    };
                    artikel.Logistik = MapLogistikinfos(docL);
                }

                NummernDoc docN = new NummernDoc()
                {
                    EaNummer = doc.EaNummer,
                    Ersatzartikelnummer = doc.Ersatzartikelnummer,
                    Gebrauchsnummer = doc.Gebrauchsnummer,
                    Referenznummer = doc.Referenznummer
                };

                artikel.Nummern = MapNummern(docN);
            }

            if (teaserTyp != TeaserTyp.NICHTS)
            {
                MapTeaserInfos(doc, artikel, teaserTyp);
            }

			return artikel;
		}

		public static List<Artikel> Map(IEnumerable<ArtikelDoc> docs, int genArtId = 0, List<Suchbaumknoten> resultBreadcrumbs = null,
			bool mitTopProdukt = false, TeaserTyp teaserTyp = TeaserTyp.NICHTS, List<KeyValuePair<int, int>> artIdZuGenArtId = null, 
            bool mobileArtikeldetails = false)
		{
			var result = new List<Artikel>();
			foreach (var doc in docs)
			{
				if (artIdZuGenArtId != null)
				{
					int id = int.Parse(doc.Id);
					if (!artIdZuGenArtId.Any(x => x.Value == genArtId && x.Key == id) && artIdZuGenArtId.Any(x => x.Key == id))
					{
						genArtId = artIdZuGenArtId.Where(x => x.Key == id).FirstOrDefault().Value;
					}
				}

                result.Add(Map(doc, genArtId, mitTopProdukt, teaserTyp, false, mobileArtikeldetails));
			}

			if (resultBreadcrumbs != null && resultBreadcrumbs.Count > 0 && result.Count > 0)
			{
				MapNodeIdsZuArtikel(result, resultBreadcrumbs);
			}

			return result;
		}

		public static List<KeyValuePair<String, String>> MapLogistikinfos(LogistikinfosDoc logistik)
		{
			var back = new List<KeyValuePair<String, String>>();

			foreach (var item in logistik.Logistikinfo)
			{
				var match = _regexLogistikinformation.Match(item);
				if (!match.Success)
				{
					continue;
				}
				var key = match.Groups[1].Value;
				var value = match.Groups[2].Value;
				if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value) || (back.Count(x => x.Key == key) > 0 && back.Count(x => x.Value == value) > 0))
				{
					continue;
				}
				back.Add(new KeyValuePair<string, string>(key, value));
			}

			return back;
		}

		public static ArtikelSonstigeNummern MapNummern(NummernDoc doc)
		{
			var nummern = new ArtikelSonstigeNummern();

			if (doc.Gebrauchsnummer != null)
			{
				foreach (var item in doc.Gebrauchsnummer)
				{
					var match = _regexGebrauchsnummer.Match(item);
					if (!match.Success)
					{
						continue;
					}
					var nummer = match.Groups[2].Value;
					nummern.Gebrauchsnummern.Add(nummer);
				}
			}

			if (doc.EaNummer != null)
			{
				nummern.EaNummern = doc.EaNummer.ToList();
			}

			if (doc.Referenznummer != null)
			{
				foreach (var item in doc.Referenznummer)
				{
					var match = _regexReferenznummer.Match(item);
					if (!match.Success)
					{
						continue;
					}
					var nummer = new Referenznummer();
					nummer.Hersteller = match.Groups[1].Value;
					nummer.Nummer = match.Groups[2].Value;
					nummern.OeReferenznummern.Add(nummer);
				}
			}

			if (doc.Ersatzartikelnummer != null)
			{
				foreach (var item in doc.Ersatzartikelnummer)
				{
					var match = _regexErsatzartikelnummer.Match(item);
					if (!match.Success)
					{
						continue;
					}
					var typ = match.Groups[1].Value;
					var nummer = match.Groups[2].Value;
					switch (typ)
					{
						case "OLD":
							nummern.ErsetzteArtikelnummern.Add(nummer);
							break;
						case "NEW":
							nummern.ErsetzendeArtikelnummern.Add(nummer);
							break;
					}
				}
			}
			return nummern;
		}

		private static void MapHerstellersortiernummer(ArtikelDoc doc, Artikel artikel)
		{
			if (doc.Herstellersortiernummer != null && doc.Herstellersortiernummer.Count > 0)
			{
				foreach (var item in doc.Herstellersortiernummer)
				{
					var match = _regexGenArtSortiernummer.Match(item);
					if (!match.Success)
					{
						continue;
					}

					artikel.Herstellersortiernummer.Add(new GenArtSortiernummer()
					{
						GenArtId = int.Parse(match.Groups[1].Value),
						Sortiernummer = int.Parse(match.Groups[2].Value)
					});
				}
			}
		}

		private static void MapArtikelsortiernummer(ArtikelDoc doc, Artikel artikel)
		{
			if (!string.IsNullOrEmpty(doc.Artikelsortiernummer))
			{
				var match = _regexGenArtSortiernummer.Match(doc.Artikelsortiernummer);
				if (!match.Success)
				{
					return;
				}

				artikel.Artikelsortiernummer.Add(new GenArtSortiernummer()
				{
					GenArtId = int.Parse(match.Groups[1].Value),
					Sortiernummer = int.Parse(match.Groups[2].Value)
				});
			}
		}

		private static void MapTopProdukt(ArtikelDoc doc, Artikel artikel)
		{
			//TopProduktTypen: "P" PreisVorteil, "V": FesterPunktewert, "F": TopProduktType.PunkeFaktor
			if (doc.Topprodukt != null)
			{
				var match = _regexTopProdukt.Match(doc.Topprodukt);
				if (!match.Success || (!string.IsNullOrEmpty(match.Groups[2].Value) && (Convert.ToDateTime(match.Groups[2].Value) > DateTime.Now))
					|| (!string.IsNullOrEmpty(match.Groups[3].Value) && (Convert.ToDateTime(match.Groups[3].Value) < DateTime.Now)))
				{
					return;
				}

				var tpProdukt = new TopProdukt();
				switch (match.Groups[1].Value)
				{
					case "P":
						tpProdukt.Typ = TopProduktType.PreisVorteil;
						break;
					case "V":
						tpProdukt.Typ = TopProduktType.FesterPunktewert;
						break;
					case "F":
						tpProdukt.Typ = TopProduktType.PunkeFaktor;
						break;
				}

				tpProdukt.Notiz = match.Groups[4].Value;
				tpProdukt.SameKTypeOnly = match.Groups[5].Value == "1";

				//ToDo: TopProduktFaktor und TopProduktWert noch nicht im aktuellen Index
                tpProdukt.TopProduktWert = decimal.Parse(match.Groups[6].Value);
				tpProdukt.TopProduktFaktor = decimal.Parse(match.Groups[7].Value);

				tpProdukt.UrsprungsArtikelId = int.Parse(match.Groups[8].Value); // wenn TopProduktFaktor und Wert im Index dann gilt match.Groups[8].Value,
				//regex muss auch erweitert werden

				artikel.TopProdukt = tpProdukt;
			}
		}

		private static void MapHasVerwandteArtikel(ArtikelDoc doc, Artikel artikel)
		{
			if (doc.VerwandteArtikel != null && doc.VerwandteArtikel.Count > 0)
			{
				artikel.HasVerwandteArtikel = true;
			}
		}

		private static void MapHasStueckliste(ArtikelDoc doc, Artikel artikel)
		{
			if (doc.Stueckliste != null)
			{
				artikel.HasStuecklisteTecDoc = doc.Stueckliste.Count(x => x.Contains("TECDOC")) > 0;
                var listHelper = doc.Stueckliste.Where(x => x.Contains("PV"));
                if (listHelper != null && listHelper.Any())
                {
                    artikel.HasStuecklistePV = listHelper.Any(x => x.Contains("¦J"));
                }
			}
		}

		private static void MapHasTauschartikel(ArtikelDoc doc, Artikel artikel)
		{
			if (doc.Tauschartikel != null)
			{
				artikel.HasTauschartikelTecDoc = doc.Tauschartikel.Count(x => x.Contains("TECDOC")) > 0;
				artikel.HasTauschartikelPV = doc.Tauschartikel.Count(x => x.Contains("PV")) > 0;
			}
		}

		private static void MapZusatzbezeichnung(ArtikelDoc doc, Artikel artikel)
		{
			if (doc.Zusatzbezeichnung != null)
			{
				artikel.Zusatzbezeichnungen = doc.Zusatzbezeichnung.ToList();
			}
		}

		private static void MapGebrauchsnummer(ArtikelDoc doc, Artikel artikel)
		{
			if (doc.Gebrauchsnummer != null)
			{
				foreach (var item in doc.Gebrauchsnummer)
				{
					var match = _regexGebrauchsnummer.Match(item);
					if (!match.Success)
					{
						continue;
					}
					var isSofortanzeige = match.Groups[1].Value == "1";
					var nummer = match.Groups[2].Value;
					if (isSofortanzeige)
					{
						artikel.GebrauchsnummernSofortanzeige.Add(nummer);
					}
				}
			}
		}

		private static void MapErsatzartikelnummer(ArtikelDoc doc, Artikel artikel)
		{
			if (doc.Ersatzartikelnummer != null)
			{
				foreach (var item in doc.Ersatzartikelnummer)
				{
					var match = _regexErsatzartikelnummer.Match(item);
					if (!match.Success)
					{
						continue;
					}
					var typ = match.Groups[1].Value;
					var nummer = match.Groups[2].Value;
					switch (typ)
					{
						case "OLD":
							artikel.ErsetzteArtikelnummernSofortanzeige.Add(nummer);
							break;
						case "NEW":
							artikel.ErsetzendeArtikelnummernSofortanzeige.Add(nummer);
							break;
					}
				}
			}
		}

		private static void MapGenArt(ArtikelDoc doc, Artikel artikel)
		{
			if (doc.GenerischerArtikel != null)
			{
				foreach (var item in doc.GenerischerArtikel)
				{
                    var genArt = Regex.Replace(item, @"(\r\n|\r|\n)", "");
                    var match = _regexGenArt.Match(genArt); //item.Replace("\n", ""):https://absolutehh.atlassian.net/browse/PV-1319
					if (!match.Success)
					{
						continue;
					}
					var ga = new GenerischerArtikel();
					ga.Bezeichnung = match.Groups[1].Value;
					ga.Id = int.Parse(match.Groups[2].Value);
					ga.GenArtNummerTecDoc = int.Parse(match.Groups[3].Value);

					artikel.GenerischeArtikel.Add(ga);
				}
			}

		}

		private static void MapBezeichnung(ArtikelDoc doc, int genArtId, Artikel artikel)
		{
			// Bezeichnung setzen
			GenerischerArtikel genArt = null;
			if (genArtId > 0)
			{
				genArt = artikel.GenerischeArtikel.SingleOrDefault(x => x.Id == genArtId);
				artikel.ArtIdZuGenArtId = genArtId;
			}
			else if (artikel.GenerischeArtikel.Count > 0)
			{
				genArt = artikel.GenerischeArtikel.First();
			}

			if (genArt != null)
			{
                //artikel.Bezeichnung = string.Format("{0} {1}", genArt.Bezeichnung,
                //    doc.Zusatzbezeichnung != null ? string.Join(" ", doc.Zusatzbezeichnung.Any()? doc.Zusatzbezeichnung: new List<string>()) : "").Trim();

                artikel.Bezeichnung = string.Format("{0} {1}", genArt.Bezeichnung,
                    doc.Zusatzbezeichnung != null ? string.Join(" ", doc.Zusatzbezeichnung ?? new List<string>()) : "").Trim();

                artikel.GenArtForSortierung = genArt.Bezeichnung;
			}
			else
			{
				artikel.Bezeichnung = doc.Bezeichnung;
			}
		}

		private static void MapPreiseinheit(ArtikelDoc doc, Artikel artikel)
		{
			var pe = new Preiseinheit();

			pe.PreiseinheitBezeichnung = string.IsNullOrEmpty(doc.PreiseinheitBezeichnung) ? "Stück" : doc.PreiseinheitBezeichnung;
			pe.PreiseinheitMenge = doc.PreiseinheitMenge > 0 ? doc.PreiseinheitMenge : 1;
			pe.PreisEinheitUmrechnungsFaktor = doc.PreisEinheitUmrechnungsFaktor > 0 ? doc.PreisEinheitUmrechnungsFaktor : 1;

			artikel.Preiseinheit = pe;
		}

		private static void MapHersteller(ArtikelDoc doc, Artikel artikel)
		{
			if (!string.IsNullOrEmpty(doc.Hersteller))
			{
				var match = _regexHersteller.Match(doc.Hersteller);
				if (match.Success)
				{
					var hersteller = new Artikelhersteller();
					hersteller.Id = int.Parse(match.Groups[2].Value);
					hersteller.Name = match.Groups[1].Value;
					hersteller.Logo = match.Groups[3].Value;
					hersteller.Nummer = doc.Herstellernummer;
					hersteller.DLNr = doc.DLNr;
					artikel.Hersteller = hersteller;
				}
			}
		}

		private static void MapVdbInformationen(ArtikelDoc doc, Artikel artikel)
		{
			var vdbInfo = new VdbArtikelinformationen();
			vdbInfo.Bezeichnung = doc.Bezeichnung;
			if (!(string.IsNullOrEmpty(doc.VdbArtikelnummer) && string.IsNullOrEmpty(doc.VdbHerstellerkuerzel)))
			{
				var vdbIdent = new VdbArtikelidentifikator();
				vdbIdent.Herstellerkuerzel = doc.VdbHerstellerkuerzel;
				vdbIdent.Artikelnummer = doc.VdbArtikelnummer;
				vdbInfo.Identifikator = vdbIdent;
				artikel.VdbInformationen = vdbInfo;
			}
		}

		private static void MapAttribut(ArtikelDoc doc, Artikel artikel)
		{
			if (doc.Attribut != null)
			{
				foreach (var docAttr in doc.Attribut)
				{
					var match = _regexAttribut.Match(docAttr);
					if (!match.Success)
					{
                        match = _regexAttribut.Match(docAttr.Replace("\n", ""));
                        if (!match.Success)
                        {
                            continue;
                        }
					}
					var attr = new Attribut();
					attr.Sortiernummer = long.Parse(match.Groups[1].Value);
					attr.IsSofortanzeige = match.Groups[2].Value == "1";
					attr.HideName = match.Groups[3].Value == "1";
					attr.Name = match.Groups[4].Value;
					attr.Kurzname = match.Groups[5].Value;
					attr.Wert = match.Groups[6].Value;
					attr.Einheit = match.Groups[7].Value;
					artikel.Attribute.Add(attr);
				}
			}
		}

		private static void MapAttributblock(ArtikelDoc doc, Artikel artikel)
		{
			if (doc.Attributblock != null)
			{
				var attrBloecke = new Dictionary<long, Attributblock>();
                foreach (var docAttrBlock in doc.Attributblock)
                {
                    var match = _regexAttributblock.Match(docAttrBlock);
                    if (!match.Success)
                    {
                        continue;
                    }
                    if (match.Groups[7].Value.Contains("TECDOC-"))
                    {
                        //attr.Kurzname
                        continue;
                    }

                    var blockSortiernummer = long.Parse(match.Groups[2].Value);
                    if (!attrBloecke.ContainsKey(blockSortiernummer))
                    {
                        var ab = new Attributblock();
                        ab.Attribute = new List<Attribut>();

                        ab.SortierNummer = blockSortiernummer;
                        ab.GenArtId = int.Parse(match.Groups[2].Value);

                        ab.ListLinkageId = new List<int>();

                        attrBloecke.Add(blockSortiernummer, ab);
                    }
                    var attrBlock = attrBloecke[blockSortiernummer];
                    var attr = new Attribut();
                    attr.Sortiernummer = long.Parse(match.Groups[3].Value);
                    attr.IsSofortanzeige = match.Groups[4].Value == "1";
                    attr.HideName = match.Groups[5].Value == "1";
                    attr.Name = match.Groups[6].Value;
                    attr.Kurzname = match.Groups[7].Value;
                    attr.Wert = match.Groups[8].Value;
                    attr.Einheit = match.Groups[9].Value;
                    int linkageId = 0;
                    int.TryParse(match.Groups[10].Value, out linkageId);
                    attr.LinkageId = linkageId;
                    if (attrBlock.ListLinkageId.Count == 0)
                    {
                        attrBlock.ListLinkageId.Add(linkageId);
                    }

                    attrBlock.Attribute.Add(attr);
                }

                foreach (var block in attrBloecke)
                {
                    if (artikel.Attributbloecke.Count(x => x.ToString() == block.Value.ToString()) > 0)
                    {
                        artikel.Attributbloecke.First(x => x.ToString() == block.Value.ToString()).ListLinkageId.Add(block.Value.ListLinkageId.First());
                    }
                    else
                    {
                        artikel.Attributbloecke.Add(block.Value);
                    }
                }

                //artikel.Attributbloecke = attrBloecke.GroupBy(x => x.Value.ToString()).Select(x => x.First().Value).ToList();
			}
		}

		private static void MapAktionsinfo(ArtikelDoc doc, Artikel artikel)
		{
			if (doc.Aktionsinfo == null)
			{
				return;
			}
			var aktNrList = new List<long>();
			if (doc.AktionsnummerAbsatzgruppe != null)
			{
				aktNrList.AddRange(doc.AktionsnummerAbsatzgruppe);
			}
			if (doc.AktionsnummerKundengruppe != null)
			{
				aktNrList.AddRange(doc.AktionsnummerKundengruppe);
			}
			if (doc.AktionsnummerPreisgruppe != null)
			{
				aktNrList.AddRange(doc.AktionsnummerPreisgruppe);
			}
			foreach (var aktNr in aktNrList.Distinct())
			{
				foreach (var item in doc.Aktionsinfo.Where(x => x.StartsWith(aktNr + "¦")))
				{
					if (item == null)
					{
						continue;
					}
					var match = _regexAktion.Match(item);
					if (!match.Success)
					{
						continue;
					}
					var aktion = new ArtikelAktionsinformation();
					aktion.Aktionsnummer = aktNr;
					aktion.AnzeigedatumMin = !string.IsNullOrEmpty(match.Groups[11].Value) ? DateTime.Parse(match.Groups[11].Value) : (DateTime?)null;
					aktion.AnzeigedatumMax = !string.IsNullOrEmpty(match.Groups[12].Value) ? DateTime.Parse(match.Groups[12].Value) : DateTime.Today.AddDays(1);
					if (aktion.AnzeigedatumMin.HasValue && aktion.AnzeigedatumMin.Value > DateTime.Now || aktion.AnzeigedatumMax < DateTime.Now)
					{
						//continue;
					}

					aktion.AktionsTyp = match.Groups[2].Value == "V" ? Aktionstyp.Verkaufsaktion : Aktionstyp.Bonusaktion;
					aktion.Aktionsbezeichnung = match.Groups[3].Value;
					aktion.Aktionsanzeigename = match.Groups[4].Value;
					aktion.Aktionsclaim = match.Groups[5].Value;
					aktion.Aktionslogo = match.Groups[6].Value;
					aktion.Aktionsnotiz = match.Groups[7].Value;
					aktion.Artikelanzeigename = match.Groups[8].Value;
					aktion.Artikelbeschreibung = match.Groups[9].Value;
					aktion.Artikelvorschaubild = match.Groups[10].Value;
					aktion.MengeMin = !string.IsNullOrEmpty(match.Groups[13].Value) ? decimal.Parse(match.Groups[13].Value, _culture) : (decimal?)null;
					aktion.MengeMax = !string.IsNullOrEmpty(match.Groups[14].Value) ? decimal.Parse(match.Groups[14].Value, _culture) : decimal.MaxValue;
					aktion.ShowVerfuegbarkeit = match.Groups[15].Value == "1";
					aktion.ShowStreichpreis = match.Groups[16].Value == "1";
					aktion.Bonusfaktor = !string.IsNullOrEmpty(match.Groups[17].Value) ? decimal.Parse(match.Groups[17].Value, _culture) : (decimal?)null;
					aktion.Bonuspunkte = !string.IsNullOrEmpty(match.Groups[18].Value) ? int.Parse(match.Groups[18].Value) : (int?)null;
					aktion.Verkaufsaktionspreis = !string.IsNullOrEmpty(match.Groups[19].Value) ? decimal.Parse(match.Groups[19].Value, _culture) : (decimal?)null;

					if (artikel.Aktionsinformationen == null)
					{
						artikel.Aktionsinformationen = new List<ArtikelAktionsinformation>();
					}
					artikel.Aktionsinformationen.Add(aktion);
				}
			}
		}

		private static void MapInformation(ArtikelDoc doc, Artikel artikel)
		{
			if (doc.Information != null)
			{
				foreach (var docInfo in doc.Information)
				{
					var match = _regexInformation.Match(docInfo);
					var info = new Artikelinfo();
					if (match.Success)
					{
						info.Sortiernummer = long.Parse(match.Groups[1].Value);
						info.IsSofortanzeige = match.Groups[2].Value == "1";
						info.Name = match.Groups[3].Value;
						info.WertRTF = match.Groups[4].Value;
						info.Wert = match.Groups[5].Value;
					}
					else
					{
						info.Name = "Fehler";
						info.Wert = "Fehler beim Konvertieren eines InfoAssignments in Artikel";
					}
					artikel.Informationen.Add(info);
				}
			}
		}

        private static void MapInformationByFahrzeug(ArtikelDoc doc, Artikel artikel)
        {
            if (doc.InformationByFahrzeug != null)
            {
                foreach (var docInfo in doc.InformationByFahrzeug)
                {
                    var match = _regexInformationByFahrzeug.Match(docInfo);
                    var info = new Artikelinfo();
                    if (match.Success)
                    {
                        info.Sortiernummer = long.Parse(match.Groups[2].Value);
                        info.IsSofortanzeige = match.Groups[3].Value == "1";
                        info.Name = match.Groups[4].Value;
                        info.WertRTF = match.Groups[5].Value;
                        info.Wert = match.Groups[6].Value;

                        int linkageId = 0;
                        int.TryParse(match.Groups[7].Value, out linkageId);
                        info.LinkageId = linkageId;
                    }
                    else
                    {
                        info.Name = "Fehler";
                        info.Wert = "Fehler beim Konvertieren eines InfoAssignments in Artikel";
                    }
                    artikel.Informationen.Add(info);
                }
            }
        }

		private static void MapTechnischeMengenheitAusLogistikinfo(ArtikelDoc doc, Artikel artikel)
		{

			if (doc.Logistikinfo != null)
			{
				foreach (var docLog in doc.Logistikinfo)
				{
					var match = _regexLogistikinformation.Match(docLog);
					if (!match.Success)
					{
						continue;
					}
					if (match.Groups[1].Value == "Mindestabnahmemenge")
					{
						artikel.TechnischeMengeneinheitFaktor = decimal.Parse(match.Groups[2].Value);
						return;
					}
				}
			}

            if (artikel.TechnischeMengeneinheitFaktor == 0)
            {
                artikel.TechnischeMengeneinheitFaktor = 1;
            }
		}

        public static void MapArtikelDokumente(ArtikelDoc doc, Artikel artikel)
        {

            if (doc.Dokument != null && doc.Dokument.Count > 0)
            {
                foreach (var dokumentstring in doc.Dokument)
                {
                    var match = _regexDokument.Match(dokumentstring);
                    if (!match.Success)
                    {
                        continue;
                    }
                    else
                    {
                        var dokument = new Dokument();
                        dokument.Sortiernummer = long.Parse(match.Groups[1].Value);
                        dokument.Dokumenttyp = match.Groups[2].Value;
                        dokument.Bezeichnung = match.Groups[3].Value;
                        dokument.Dateityp = match.Groups[4].Value;
                        dokument.Dateiname = match.Groups[5].Value;
                        dokument.Fileformat = match.Groups[6].Value;
                        artikel.DokUndLinks.Dokumente.Add(dokument);
                    }
                }
            }

            if (doc.Link != null && doc.Link.Count > 0)
            {
                foreach (var item in doc.Link)
                {
                    var match = _regexLink.Match(item);
                    if (!match.Success)
                    {
                        continue;
                    }
                    var link = new Link();
                    link.Sortiernummer = long.Parse(match.Groups[1].Value);
                    link.Bezeichnung = match.Groups[2].Value;
                    link.Uri = match.Groups[3].Value;
                    link.Beschreibung = match.Groups[4].Value;
                    artikel.DokUndLinks.Links.Add(link);
                }
            }
        }

		public static void MapArtikelDokumente(DokumentUndLinksDoc doc, ArtikelDokumenteUndLinks dokUndLinks)
		{

			if (doc.Dokument != null && doc.Dokument.Count > 0)
			{
				foreach (var dokumentstring in doc.Dokument)
				{
					var match = _regexDokument.Match(dokumentstring);
                    if (!match.Success)
                    {
                        continue;
                    }
                    else
                    {
                        var dokument = new Dokument();
                        dokument.Sortiernummer = long.Parse(match.Groups[1].Value);
                        dokument.Dokumenttyp = match.Groups[2].Value;
                        dokument.Bezeichnung = match.Groups[3].Value;
                        dokument.Dateityp = match.Groups[4].Value;
                        dokument.Dateiname = match.Groups[5].Value;
                        dokument.Fileformat = match.Groups[6].Value;
                        dokUndLinks.Dokumente.Add(dokument);
                    }
				}
			}

			if (doc.Link != null && doc.Link.Count > 0)
			{
				foreach (var item in doc.Link)
				{
					var match = _regexLink.Match(item);
					if (!match.Success)
					{
						continue;
					}
					var link = new Link();
					link.Sortiernummer = long.Parse(match.Groups[1].Value);
					link.Bezeichnung = match.Groups[2].Value;
					link.Uri = match.Groups[3].Value;
					link.Beschreibung = match.Groups[4].Value;
					dokUndLinks.Links.Add(link);
				}
			}
		}

		public static Dictionary<string, string> MapGefahrgutinfos(GefahrgutInfosDoc doc)
		{
			var back = new Dictionary<string, string>();
			var key = string.Empty;
			var value = string.Empty;

			foreach (var item in doc.Gefahrgutinformation)
			{
				var match = _regexGefahrgutinformation.Match(item);
				if (!match.Success)
				{
					if (item.Contains("IsGefahrstoffKlasse"))
					{
						key = item;
						value = string.Empty;
						back.Add(key, value);
					}
					continue;
				}
				key = match.Groups[1].Value;
				value = match.Groups[2].Value;
				if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value) || back.ContainsKey(key))
				{
					continue;
				}
				back.Add(key, value);
			}

			return back;
		}

		public static List<int> MapFahrzeugIdForArtikel(FahrzeugIdsDoc doc, string typ, int fahrzeugTyp)
		{
			int verwendetInList = 60;

			//int.TryParse(ConfigManager.Instance.GetSetting("VerwendetInList"), out verwendetInList);

			var temp = doc.FahrzeugId.Where(x => x.Contains(typ)).Take(verwendetInList);

			if (temp.Count() == 0)
				return null;

			var back = new List<int>();

			//z.Z. nur für PKW: dies stellt sicher, dass das ausgewählte Fahzeug in der VerwendetIn-Liste ist
			if (fahrzeugTyp > 0 && temp.Count(x => x.Contains(typ + fahrzeugTyp.ToString())) == 0 && doc.FahrzeugId.Count(x => x.Contains(typ + fahrzeugTyp.ToString())) > 0)
				back.Add(fahrzeugTyp);

			foreach (var fahrzeugId in temp)
			{
				var match = _regexFahrzeugId.Match(fahrzeugId);
				if (!match.Success)
				{
					continue;
				}
				back.Add(int.Parse(match.Groups[2].Value));
			}

			return back;
		}

		private static void MapNodeIdsZuArtikel(List<Artikel> artikel, List<Suchbaumknoten> resultBreadcrumbs)
		{
			foreach (var art in artikel.Where(x => x.GenerischeArtikel != null))
			{               

				foreach (var gen in art.GenerischeArtikel)
				{
					var parentId = resultBreadcrumbs.Where(x => x.Id == gen.Id).Select(x => x.ParentId);

					if (parentId != null && parentId.Count() > 0)
					{
						foreach (int pId in parentId.Where(x => x != null))
						{
							art.NodeIDs.Add(new NodeIdGenArt
							{
								GenArtId = gen.Id,
								ParentNodeId = pId
							});
						}
					}
				}
			}
		}

		private static void MapTeaserInfos(ArtikelDoc doc, Artikel artikel, TeaserTyp teaserTyp)
		{
            if (doc.TeaserInfo != null && doc.TeaserInfo.Count > 0)
            {

                var teaser = doc.TeaserInfo.Where(x => x.Contains(teaserTyp.ToString())).FirstOrDefault();

                var match = _regexTeaserInfos.Match(teaser);
                if (!match.Success)
                {
                    return;
                }
                
                artikel.Sortiernummer = int.Parse(match.Groups[2].Value);
                artikel.IsZufallsanzeige = match.Groups[3].Value == "1";
                artikel.TeaserAnzeigedatumMin = !string.IsNullOrEmpty(match.Groups[4].Value) ? Convert.ToDateTime(match.Groups[4].Value) : (DateTime?)null;
                artikel.TeaserAnzeigedatumMax = !string.IsNullOrEmpty(match.Groups[5].Value) ? Convert.ToDateTime(match.Groups[5].Value) : (DateTime?)null;

                //TeaserName
                var teaserName = string.Empty;
                if (doc.TeaserName != null)
                {
                    var teaserN = doc.TeaserName.Where(x => x.Contains(teaserTyp.ToString())).FirstOrDefault();
                    var matchTeaserName = _regexTeaserName.Match(teaserN);
                    if (matchTeaserName.Success)
                    {
                        artikel.TeaserName = matchTeaserName.Groups[3].Value;
                    }
                }
            }
		}

		private static void MapSensitiveAreas(ArtikelDoc doc, Artikel artikel)
		{
			if (null == doc.SensitiveAreas)
				return;
            
            foreach (var item in doc.SensitiveAreas)
			{
                var result = item.Split(DELIMITER);

                if (result.Length > 2)
                {
                    var artikelId = int.Parse(result[0]);

                    var intValueMatches = Regex.Matches(result[2], @"(\d+),(\d+),(\d+),(\d+)");

                    foreach (Match intValueMatch in intValueMatches)
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.X = int.Parse(intValueMatch.Groups[1].Value);
                        rectangle.Y = int.Parse(intValueMatch.Groups[2].Value);
                        rectangle.Width = int.Parse(intValueMatch.Groups[3].Value) - rectangle.X;
                        rectangle.Height = int.Parse(intValueMatch.Groups[4].Value) - rectangle.Y;
                        var area = artikel.SensitiveAreas.SingleOrDefault(x => x.Coords.X == rectangle.X && x.Coords.Y == rectangle.Y && x.Coords.Width == rectangle.Width && x.Coords.Height == rectangle.Height);
                        if (area == null)
                        {
                            area = new SensitiveArea();
                            area.Coords = rectangle;
                            area.BackgroundPictureFileName = result[1];
                            artikel.SensitiveAreas.Add(area);
                        }
                        area.ArtikelIds.Add(artikelId);
                    }

                    if (result.Length > 3)
                    {
                        var intValueMatches2 = Regex.Matches(result[3], @"(\d+),(\d+),(\d+),(\d+)");

                        foreach (Match intValueMatch in intValueMatches2)
                        {
                            Rectangle rectangle = new Rectangle();
                            rectangle.X = int.Parse(intValueMatch.Groups[1].Value);
                            rectangle.Y = int.Parse(intValueMatch.Groups[2].Value);
                            rectangle.Width = int.Parse(intValueMatch.Groups[3].Value) - rectangle.X;
                            rectangle.Height = int.Parse(intValueMatch.Groups[4].Value) - rectangle.Y;
                            var area = artikel.SensitiveAreas.SingleOrDefault(x => x.Coords.X == rectangle.X && x.Coords.Y == rectangle.Y && x.Coords.Width == rectangle.Width && x.Coords.Height == rectangle.Height);
                            if (area == null)
                            {
                                area = new SensitiveArea();
                                area.Coords = rectangle;
                                area.BackgroundPictureFileName = result[1];
                                artikel.SensitiveAreas.Add(area);
                            }
                            area.ArtikelIds.Add(artikelId);
                        }
                    }
                }
			}

			if (artikel.SensitiveAreas.Count > 0)
			{
				artikel.Vorschaubild = artikel.SensitiveAreas.First().BackgroundPictureFileName;
			}
		}

        private static void changeAltteilKennzeichen(Artikel artikel)
        {
            if (!string.IsNullOrEmpty(artikel.AltteilKennzeichen) && artikel.GenerischeArtikel.Count(x => x.Bezeichnung == "Starterbatterie") > 0)
            {
                artikel.AltteilKennzeichen = "U";
            }
        }
	}
}
