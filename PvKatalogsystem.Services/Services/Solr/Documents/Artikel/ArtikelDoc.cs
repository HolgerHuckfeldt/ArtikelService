using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Absolute.SolrClient0900;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.XPath;
using Newtonsoft.Json.Linq;
using PvKatalogsystem.Types.Interfaces;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Services.Services.Solr.Documents.Artikel
{
    [DataContract]
    public class ArtikelDoc : ISolrDocument
    {
        [SolrField(Name = "Id", Stored = true, Indexed = true)]
        public string Id { get; set; }

        [SolrField(Name = "Aktionsinfo", Stored = true, Indexed = false)]
        public List<string> Aktionsinfo { get; set; }

        [SolrField(Name = "Aktionsnummer", Stored = true, Indexed = true)]
        public string Aktionsnummer_Thomas { get; set; }

        public List<int?> Aktionsnummer { get; set; }

        [SolrField(Name = "AktionsnummerAbsatzgruppe_*", Stored = true, Indexed = true)]
        public List<long> AktionsnummerAbsatzgruppe { get; set; }

        [SolrField(Name = "AktionsnummerKundengruppe_*", Stored = true, Indexed = true)]
        public List<long> AktionsnummerKundengruppe { get; set; }

        [SolrField(Name = "AktionsnummerPreisgruppe_*", Stored = true, Indexed = true)]
        public List<long> AktionsnummerPreisgruppe { get; set; }

        [SolrField(Name = "Artikelnummer", Stored = true, Indexed = true)]
        public string Artikelnummer { get; set; }

        [SolrField(Name = "ArtikelnummerSuche", Stored = true, Indexed = true)]
        public string ArtikelnummerSuche { get; set; }

        [SolrField(Name = "Attribut", Stored = true, Indexed = false)]
        public List<string> Attribut { get; set; }

        [SolrField(Name = "Attributblock_*", Stored = true, Indexed = false)]
        public List<string> Attributblock { get; set; }

        [SolrField(Name = "Artikelsortiernummer_*", Stored = true, Indexed = false)]
        public string Artikelsortiernummer { get; set; }

        [SolrField(Name = "Bezeichnung", Stored = true, Indexed = false)]
        public string Bezeichnung { get; set; }

        [SolrField(Name = "Breadcrumb_*", Stored = true, Indexed = true)]
        public List<string> Breadcrumb { get; set; }

        private string csoCode;

        [SolrField(Name = "CsoCode", Stored = true, Indexed = true)]
        public List<string> CsoCode { get; set; }

        public string CsoCode_Thomas
        {
            get
            {
                string back = String.Empty;
                foreach (var i in CsoCode)
                {
                    back += string.Format("D3", i);
                }
                return back;
            }

        }

        [SolrField(Name = "Dokument", Stored = true, Indexed = false)]
        public List<string> Dokument { get; set; }

        [SolrField(Name = "EaNummerEindeutig", Stored = true, Indexed = true)]
        public List<string> EaNummerEindeutig { get; set; }

        [SolrField(Name = "EaNummer", Stored = true, Indexed = true)]
        public List<string> EaNummer { get; set; }

        [SolrField(Name = "Einheit", Stored = true, Indexed = false)]
        public string Einheit { get; set; }

        [SolrField(Name = "EinheitenProVerpackung", Stored = true, Indexed = false)]
        public int? EinheitenProVerpackung { get; set; }

        [SolrField(Name = "Ersatzartikelnummer", Stored = true, Indexed = false)]
        public List<string> Ersatzartikelnummer { get; set; }

        [SolrField(Name = "FahrzeugId", Stored = true, Indexed = true)]
        public List<string> FahrzeugId { get; set; }

        [SolrField(Name = "Gebrauchsnummer", Stored = true, Indexed = false)]
        public List<string> Gebrauchsnummer { get; set; }

        [SolrField(Name = "GebrauchsnummerEindeutig", Stored = true, Indexed = true)]
        public List<string> GebrauchsnummerEindeutig { get; set; }

        [SolrField(Name = "GebrauchsnummerSuche", Stored = true, Indexed = true)]
        public List<string> GebrauchsnummerSuche { get; set; }

        [SolrField(Name = "Gefahrgutinformation", Stored = true, Indexed = false)]
        public List<string> Gefahrgutinformation { get; set; }

        [SolrField(Name = "GenerischerArtikel", Stored = true, Indexed = false)]
        public List<string> GenerischerArtikel { get; set; }

        [SolrField(Name = "GenArtId", Stored = true, Indexed = true)]
        public List<int> GenArtId { get; set; }

        [SolrField(Name = "GenArtNummer", Stored = true, Indexed = true)]
        public List<int> GenArtNummer { get; set; }

        [SolrField(Name = "HasSensitiveAreas", Stored = false, Indexed = true)]
        public bool HasSensitiveAreas { get; set; }

        [SolrField(Name = "Hersteller", Stored = true, Indexed = true)]
        public string Hersteller { get; set; }

        [SolrField(Name = "HerstellerHLK", Stored = true, Indexed = true)]
        public string HerstellerHLK { get; set; }

        [SolrField(Name = "HerstellerHLKSuche", Stored = true, Indexed = true)]
        public string HerstellerHLKSuche { get; set; }

        [SolrField(Name = "Herstellername", Stored = false, Indexed = true)]
        public string Herstellername { get; set; }

        [SolrField(Name = "Herstellernummer", Stored = true, Indexed = true)]
        public Int64 Herstellernummer { get; set; }

        [SolrField(Name = "DLNr", Stored = true, Indexed = true)]
        public int DLNr { get; set; }

        [SolrField(Name = "GenArtMasterbezeichnung_*", Stored = true, Indexed = true)]
        public string GenArtMasterbezeichnung { get; set; }

        [SolrField(Name = "Information", Stored = true, Indexed = false)]
        public List<string> Information { get; set; }

        [SolrField(Name = "InformationByFahrzeug_*", Stored = true, Indexed = false)]
        public List<string> InformationByFahrzeug { get; set; }

        [SolrField(Name = "IsAltteil", Stored = true, Indexed = false)]
        public bool IsAltteil { get; set; }

        [SolrField(Name = "IsIncentiveBundle", Stored = true, Indexed = true)]
        public bool IsIncentiveBundle { get; set; }

        [SolrField(Name = "IsLieferbar", Stored = true, Indexed = true)]
        public bool IsLieferbar { get; set; }

        [SolrField(Name = "IsStahlgruberArtikel", Stored = true, Indexed = true)]
        public bool IsStahlgruberArtikel { get; set; }

        [SolrField(Name = "IsPseudoartikel", Stored = true, Indexed = true)]
        public bool IsPseudoartikel { get; set; }

        [SolrField(Name = "IsVerpackungseinheitGanzzahl", Stored = true, Indexed = false)]
        public bool IsVerpackungseinheitGanzzahl { get; set; }

        [SolrField(Name = "Katalognummer", Stored = true, Indexed = false)]
        public string Katalognummer { get; set; }

        [SolrField(Name = "Link", Stored = true, Indexed = false)]
        public List<string> Link { get; set; }

        [SolrField(Name = "Logistikinfo_*", Stored = true, Indexed = false)]
        public List<string> Logistikinfo { get; set; }

        [SolrField(Name = "Marketingbezeichnung", Stored = true, Indexed = true)]
        public string Marketingbezeichnung { get; set; }

        [SolrField(Name = "Matchcode", Stored = true, Indexed = true)]
        public List<string> Matchcode { get; set; }

        [SolrField(Name = "MengeProEinheit", Stored = true, Indexed = false)]
        public decimal? MengeProEinheit { get; set; }

        [SolrField(Name = "MwstSchluessel", Stored = true, Indexed = false)]
        public int MwstSchluessel { get; set; }

        [SolrField(Name = "PitstopVorschaubild", Stored = true, Indexed = false)]
        public String PitstopVorschaubild { get; set; }

        [SolrField(Name = "PreiseinheitBezeichnung", Stored = true, Indexed = false)]
        public string PreiseinheitBezeichnung { get; set; }

        [SolrField(Name = "PreiseinheitMenge", Stored = true, Indexed = false)]
        public decimal PreiseinheitMenge { get; set; }

        [SolrField(Name = "PreisEinheitUmrechnungsFaktor", Stored = true, Indexed = false)]
        public decimal PreisEinheitUmrechnungsFaktor { get; set; }

        [SolrField(Name = "MengenEinheitsFaktor", Stored = true, Indexed = false)]
        public decimal MengenEinheitsFaktor { get; set; }

        [SolrField(Name = "TechnischeMengeneinheitBezeichnung", Stored = true, Indexed = false)]
        public string TechnischeMengeneinheitBezeichnung { get; set; }

        [SolrField(Name = "Referenznummer", Stored = true, Indexed = false)]
        public List<string> Referenznummer { get; set; }

        [SolrField(Name = "ReferenznummerEindeutig", Stored = true, Indexed = true)]
        public List<string> ReferenznummerEindeutig { get; set; }

        [SolrField(Name = "ReferenznummerSuche", Stored = true, Indexed = true)]
        public List<string> ReferenznummerSuche { get; set; }

        [SolrField(Name = "SpellCheckfield")]
        public List<string> SpellCheckfield { get; set; }

        [SolrField(Name = "Suchbaumtyp", Stored = false, Indexed = true)]
        public string Suchbaumtyp { get; set; }

        [SolrField(Name = "Suchbaumknoten_*", Stored = false, Indexed = true)]
        public List<string> Suchbaumknoten { get; set; }

        [SolrField(Name = "TeaserTyp", Stored = true, Indexed = true)]
        public List<string> TeaserTyp { get; set; }

        [SolrField(Name = "TeaserInfo", Stored = true, Indexed = false)]
        public List<string> TeaserInfo { get; set; }

        [SolrField(Name = "TeaserName", Stored = true, Indexed = false)]
        public List<string> TeaserName { get; set; }

        [SolrField(Name = "TeaserId", Stored = true, Indexed = true)]
        public string TeaserId { get; set; }

        [SolrField(Name = "SensitiveAreas", Stored = true, Indexed = false)]
        public List<string> SensitiveAreas { get; set; }

        [SolrField(Name = "Stueckliste", Stored = true, Indexed = false)]
        public List<string> Stueckliste { get; set; }

        [SolrField(Name = "Tauschartikel_*", Stored = true, Indexed = false)]
        public List<string> Tauschartikel { get; set; }

        public List<string> Tauschartikel_001 { get; set; }

        [SolrField(Name = "VdbArtikelnummer", Stored = true, Indexed = true)]
        public string VdbArtikelnummer { get; set; }

        [SolrField(Name = "VdbHerstellerkuerzel", Stored = true, Indexed = true)]
        public string VdbHerstellerkuerzel { get; set; }

        [SolrField(Name = "Vergleichsnummer", Stored = true, Indexed = true)]
        public List<string> Vergleichsnummer { get; set; }

        [SolrField(Name = "VergleichsnummerEindeutig", Stored = true, Indexed = true)]
        public List<string> VergleichsnummerEindeutig { get; set; }

        [SolrField(Name = "Verkaufspreis_*", Stored = true, Indexed = true)]
        public decimal Verkaufspreis { get; set; }
        public decimal Verkaufspreis_0 { get; set; }

        [SolrField(Name = "Verkaufspreis_Kompass", Stored = true, Indexed = true)]
        public decimal Verkaufspreis_Kompass { get; set; }

        [SolrField(Name = "Verkaufspreis_KompassPitstop", Stored = true, Indexed = true)]
        public decimal Verkaufspreis_KompassPitstop { get; set; }

        [SolrField(Name = "Verkaufspreis_KompassStahlgruber", Stored = true, Indexed = true)]
        public decimal Verkaufspreis_KompassStahlgruber { get; set; }

        [SolrField(Name = "VerpackungseinheitBezeichnung", Stored = true, Indexed = false)]
        public string VerpackungseinheitBezeichnung { get; set; }

        [SolrField(Name = "Verpackungsart", Stored = true, Indexed = false)]
        public string Verpackungsart { get; set; }

        [SolrField(Name = "VerwandteArtikel", Stored = true, Indexed = false)]
        public List<string> VerwandteArtikel { get; set; }

        [SolrField(Name = "VerwandteGenArtikel", Stored = true, Indexed = false)]
        public List<string> VerwandteGenArtikel { get; set; }

        [SolrField(Name = "Vorschaubild", Stored = true, Indexed = false)]
        public string Vorschaubild { get; set; }

        [SolrField(Name = "Zusatzbezeichnung", Stored = true, Indexed = false)]
        public List<string> Zusatzbezeichnung { get; set; }

        [SolrField(Name = "PvManagerGruppe", Stored = true, Indexed = false)]
        public int PvManagerGruppe { get; set; }

        [SolrField(Name = "HasMaterialCertification", Stored = true, Indexed = false)]
        public bool HasMaterialCertification { get; set; }

        [SolrField(Name = "IsRemanufacturedPart", Stored = true, Indexed = false)]
        public bool IsRemanufacturedPart { get; set; }

        [SolrField(Name = "IsSelfServicePackage", Stored = true, Indexed = false)]
        public bool IsSelfServicePackage { get; set; }

        [SolrField(Name = "Topprodukt", Stored = true, Indexed = false)]
        public string Topprodukt { get; set; }
        //Neu!!
        [SolrField(Name = "ZusatzbezeichnungB2C", Stored = true, Indexed = false)]
        public List<string> ZusatzbezeichnungB2C { get; set; }

        [SolrField(Name = "PitstopWarengruppe", Stored = true, Indexed = false)]
        public string PitstopWarengruppe { get; set; }

        [SolrField(Name = "Warengruppe", Stored = true, Indexed = false)]
        public string Warengruppe { get; set; }

        [SolrField(Name = "Herstellersortiernummer", Stored = true, Indexed = false)]
        public List<string> Herstellersortiernummer { get; set; }

        [SolrField(Name = "IsNfzUniversalArtikel", Stored = false, Indexed = true)]
        public bool IsNfzUniversalArtikel { get; set; }

        [SolrField(Name = "GenArtIdFzg", Stored = false, Indexed = true)]
        public List<string> GenArtIdFahrzeug { get; set; }

        [SolrField(Name = "FzgGenArtId", Stored = false, Indexed = true)]
        public List<string> FzgGenArtId { get; set; }

        [SolrField(Name = "VdbArtikelzustand", Stored = true, Indexed = true)]
        public int VdbArtikelzustand { get; set; }

        [SolrField(Name = "Pfandwert", Stored = true, Indexed = false)]
        public double Pfandwert { get; set; }

        [SolrField(Name = "AltteilKennzeichen", Stored = true, Indexed = false)]
        public string AltteilKennzeichen { get; set; }

        [SolrField(Name = "Synonym", Stored = true, Indexed = true)]
        public List<string> Synonym { get; set; }

        public List<string> Attributblock_PC68193 { get; set; }

        public List<int?> AktionsnummerKundengruppe_80003 { get; set; }

    }



}
