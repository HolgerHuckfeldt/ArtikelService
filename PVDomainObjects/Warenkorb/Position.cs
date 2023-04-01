using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.Artikel;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Warenkorb
{

    [Serializable]
    public enum ActionStatus
    {
        Keine,
        MengeAendern,
        Loeschen,
        Neu,
        ArtikelChanged,
        UsrTextChanged
    }

    [Serializable]
    public enum VDBStatus
    {
        Reserviert,
        BestellLimit,
        StueckLimit,
        KreditLimit,
        NotFound,
        Ungeprueft
    }

    [DataContract]
    [Serializable] 
    public class Position
    {
        [DataMember]
        public int PosNummer { get; set; }

        /// <summary>
        /// VDB ArtikelNummer
        /// </summary>
        /// 
        [DataMember]
        public string BaugruppenBezeichnung { get; set; }

        [DataMember]
        public int? BaugruppenNummer { get; set; }

        [DataMember]
        public string ArtikelNummer { get; set; }

        [DataMember]
        public Warengruppe WarenGruppe { get; set; }

        [DataMember]
        public String TecDocArtikelnummer { get; set; }

        [DataMember]
        public bool IstGanzzahlArtikel { get; set; }

        [DataMember]
        public bool IstPaarArtikel { get; set; }

        [DataMember]
        public String BezeichnungMengeneinheit { get; set; }

        [DataMember]
        public double EKPreis { get; set; }

        [DataMember]
        public double EKPreisSumme { get; set; }

        /// <summary>
        /// Bezeichnung aus der Pimms Distribution, falls vorhanden
        /// </summary>
        [DataMember]
        public string ArtikelBezeichnung { get; set; }

        [DataMember]
        public string HerstellerBezeichnung { get; set; }

        [DataMember]
        public string HLK { get; set; }
        [DataMember]
        public int Menge { get; set; }
        [DataMember]
        public VDBStatus VDBStatusFlag { get; set; }
        [DataMember]
        public ActionStatus ActionStatusFlag { get; set; }
        [DataMember]
        public List<VerfuegbarkeitEigenschaften> Verfuegbarkeit { get; set; }
        [DataMember]
        public DateTime Lieferzeitpunkt { get; set; }
        [DataMember]
        public bool Alternativen { get; set; }

        [DataMember]
        public string txt1 { get; set; }
        [DataMember]
        public string txt2 { get; set; }

        public override string ToString()
        {
            /*
            E
            Type=ART
            Artikelbezeichnung=ELEKTROSATZ, ANHÄNGEVORRICHTUNG
            Artikelnummer=335304300113
            Verkaufspreis=    122.90
            Mengen=       1.0
            Hersteller=WESTFALIA
            Baugruppen-Nr=82
            Baugruppen-Name=ZUGVORRICHTUNGEN
             */
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("E");
            sb.AppendLine("Type=ART");
            sb.AppendLine(string.Concat("Artikelbezeichnung=", ArtikelBezeichnung));
            sb.AppendLine(string.Concat("Artikelnummer=", TecDocArtikelnummer));
            sb.AppendLine(string.Concat("Verkaufspreis=", "19.99"));//m_Preis.ToString("######0.00", CultureInfo.InvariantCulture)));
            sb.AppendLine(string.Concat("Mengen=", Menge.ToString("#######0.0", System.Globalization.CultureInfo.InvariantCulture)));
            sb.AppendLine(string.Concat("Hersteller=", HerstellerBezeichnung));
            sb.AppendLine(string.Concat("Baugruppen-Nr=", BaugruppenNummer));
            sb.AppendLine(string.Concat("Baugruppen-Name=", BaugruppenBezeichnung));
            return sb.ToString();
        }
    }

}