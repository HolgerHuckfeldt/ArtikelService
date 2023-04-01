using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.Enums;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class Artikel : DtoBase
    {
        public Artikel()
        {
            Attribute = new List<Attribut>();
            Attributbloecke = new List<Attributblock>();            
            Informationen = new List<Artikelinfo>();
            Hersteller = new Artikelhersteller();
            Preiseinheit = new Preiseinheit();
            GebrauchsnummernSofortanzeige = new List<string>();
            GenerischeArtikel = new List<GenerischerArtikel>();
            Aktionsinformationen = new List<ArtikelAktionsinformation>();
            NodeIDs = new List<NodeIdGenArt>();
            Herstellersortiernummer = new List<GenArtSortiernummer>();
            Artikelsortiernummer = new List<GenArtSortiernummer>();
            Logistik = new List<KeyValuePair<string, string>>();
            DokUndLinks = new ArtikelDokumenteUndLinks();
            ErsetzteArtikelnummernSofortanzeige = new List<string>();
            ErsetzendeArtikelnummernSofortanzeige = new List<string>();
            SensitiveAreas = new List<SensitiveArea>();

            Warengruppen = new Warengruppen();
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Id, Artikelnummer, Bezeichnung);
        }


        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Artikelnummer { get; set; }
        [DataMember]
        public String Vorschaubild { get; set; }
        [DataMember]
        public List<SensitiveArea> SensitiveAreas { get; set; }
        [DataMember]
        public String Bezeichnung { get; set; }
        [DataMember]
        public String GenArtForSortierung { get; set; }
        [DataMember]
        public int ArtIdZuGenArtId { get; set; }   
        [DataMember]
        public String Marketingbezeichnung { get; set; }
        [DataMember]
        public decimal Verkaufspreis { get; set; }
        [DataMember]
        public decimal VerkaufspreisKompass { get; set; }
        [DataMember]
        public decimal VerkaufspreisPitstop { get; set; }
        [DataMember]
        public decimal VerkaufspreisStahlgruber { get; set; }
        [DataMember]
        public List<string> GebrauchsnummernSofortanzeige { get; set; }
        [DataMember]
        public ArtikelDokumenteUndLinks DokUndLinks { get; set; }
        [DataMember]
        public List<string> ErsetzendeArtikelnummernSofortanzeige { get; set; }
        [DataMember]
        public List<string> ErsetzteArtikelnummernSofortanzeige { get; set; }
        [DataMember]
        public Artikelhersteller Hersteller { get; set; }
        [DataMember]
        public List<Attribut> Attribute { get; set; }
        [DataMember]
        public List<string> Zusatzbezeichnungen { get; set; }
        //Neu!!
        [DataMember]
        public List<string> ZusatzbezeichnungenB2C { get; set; }
        [DataMember]
        public VdbArtikelinformationen VdbInformationen { get; set; }
        [DataMember]
        public bool HasMaterialCertification { get; set; }
        [DataMember]
        public bool IsRemanufacturedPart { get; set; }
        [DataMember]
        public bool IsSelfServicePackage { get; set; }
        [DataMember]
        public double Pfandwert { get; set; }
        [DataMember]
        public string AltteilKennzeichen { get; set; }
        [DataMember]
        public string Verpackungsart { get; set; }
        [DataMember]
        public int EinheitenProVerpackung { get; set; }
        [DataMember]
        public string Einheit { get; set; }
        [DataMember]
        public string GefundenUeberNummer { get; set; }
        [DataMember]
        public decimal MengeProEinheit { get; set; }
        [DataMember]
        public Decimal MengenEinheitsFaktor { get; set; }
        [DataMember]
        public Decimal TechnischeMengeneinheitFaktor { get; set; }
        [DataMember]
        public String Mengeneinheitsbezeichnung { get; set; }
        [DataMember]
        public bool IsAltteil { get; set; }
        [DataMember]
        public bool IsPseudoartikel { get; set; }
        [DataMember]
        public int MwstSchluessel { get; set; }
        [DataMember]
        public bool IsGanzzahlMengeneingabe { get; set; }
        [DataMember]
        public String TechnischeMengeneinheitBezeichnung { get; set; }
        [DataMember]
        public bool IstLoseWare { get; set; }
        [DataMember]
        public virtual decimal InhaltPreisfuerWarenkorblogikDecimal
        {
            get;
            set;
        }
        
        [DataMember]
        public int VdbArtikelzustand { get; set; }

        [DataMember]
        /// <summary>
        /// nur relevant für Tanke
        /// </summary>
        public String Katalognummer { get; set; }

        [DataMember]
        /// <summary>
        /// Preis per ... Stück
        /// </summary>
        public Preiseinheit Preiseinheit { get; set; }

        [DataMember]
        /// <summary>
        /// Nur bei Linkages befüllt
        /// </summary>
        public List<Attributblock> Attributbloecke { get; set; }

        [DataMember]
        /// <summary>
        /// Tabelle InfoAssignments
        /// </summary>
        public List<Artikelinfo> Informationen { get; set; }

        [DataMember]
        public List<ArtikelAktionsinformation> Aktionsinformationen { get; set; }
        [DataMember]
        public List<GenerischerArtikel> GenerischeArtikel { get; set; }

        [DataMember]
        public int PvManagerGruppe { get; set; }

        [DataMember]
        public List<NodeIdGenArt> NodeIDs { get; set; }
        
        [DataMember]
        public TopProdukt TopProdukt { get; set; }

        [DataMember]
        /// <summary>
        /// Information über welche Felder der Artikel gefunden wurde
        /// </summary>
        public Suchergebnisfelder Suchergebnisfelder { get; set; }

        [DataMember]
        public bool HasTauschartikelPV { get; set; }
        [DataMember]
        public bool HasStuecklistePV { get; set; }
        [DataMember]
        public bool HasTauschartikelTecDoc { get; set; }
        [DataMember]
        public bool HasStuecklisteTecDoc { get; set; }
        [DataMember]
        public bool HasVerwandteArtikel { get; set; }
        [DataMember]
        public bool IsLieferbar { get; set; }
        [DataMember]
        public long Sortiernummer { get; set; }
        [DataMember]
        public long HerstellerSortiernummer { get; set; }
        [DataMember]
        public long ArtikelSortiernummer { get; set; }
        [DataMember]
        public bool IsZufallsanzeige { get; set; }
        [DataMember]
        public List<int> GenerischerArtikelNummer { get; set; }
        [DataMember]
        public Warengruppen Warengruppen { get; set; }
        [DataMember]
        public Decimal BenoetigteMenge { get; set; }
        [DataMember]
        public List<GenArtSortiernummer> Herstellersortiernummer { get; set; }
        [DataMember]
        public List<GenArtSortiernummer> Artikelsortiernummer { get; set; }

        [DataMember]
        public String SuperflexInfo { get; set; }

        [DataMember]
        public String TeaserName { get; set; }

        [DataMember]
        public List<KeyValuePair<String, String>> Logistik { get; set; }
        [DataMember]
        public ArtikelSonstigeNummern Nummern { get; set; }
        [DataMember]
        public DateTime? TeaserAnzeigedatumMin { get; set; }
        [DataMember]
        public DateTime? TeaserAnzeigedatumMax { get; set; }

    }
}
