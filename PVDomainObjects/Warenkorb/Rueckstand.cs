using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    [Serializable] 
    public class Rueckstand
    {
        [DataMember]
        public string Bezeichnung { get; set; }

        [DataMember]
        public string Hersteller { get; set; }

        [DataMember]
        public string BestellID { get; set; }

        [DataMember]
        public DateTime Bestellzeitpunkt { get; set; }

        [DataMember]
        public long Menge { get; set; }

        [DataMember]
        public long Auftrag { get; set; }

        [DataMember]
        public int Position { get; set; }

        [DataMember]
        public int Positionssuffix { get; set; }

        [DataMember]
        public int Unterposition { get; set; }

        [DataMember]
        public string Artikelnummer { get; set; }

        [DataMember]
        public string HLK { get; set; }

        [DataMember]
        public int Auftragsfirma { get; set; }

        [DataMember]
        public int Auftragsabteilung { get; set; }

        [DataMember]
        public int Auftragsstandort { get; set; }

        [DataMember]
        public double EKPreis { get; set; }

        [DataMember]
        public double EKSumme { get; set; }

        [DataMember]
        public Artikel.Artikel ArtikelRef { get; set; }
    }
}
