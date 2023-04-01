using System;
using System.Runtime.Serialization;
using System.Text;
using System.Collections.Generic;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable] 
    public class VdbArtikelId
    {
        [DataMember]
        public string VdbArtikelnummer { get; set; }

        [DataMember]
        public string Hlk { get; set; }

        [DataMember]
        public Decimal Menge { get; set; }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("VdbArtikelnummer: " + VdbArtikelnummer);
            sb.AppendLine("Hlk: " + Hlk);
            return sb.ToString();
        }
    }

    [DataContract]
    [Serializable]
    public class ArtikelID
    {
        [DataMember]
        public string Artikelnummer { get; set; }

        [DataMember]
        public Int64 DLNr { get; set; }

        [DataMember]
        public int ArtikelId { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Artikelnummer: " + Artikelnummer);
            sb.AppendLine("DLNr: " + DLNr);
            sb.AppendLine("ArtikelId: " + ArtikelId);
            return sb.ToString();
        }
    }

    [DataContract]
    [Serializable]
    public class MobileArtikelDetailsRequest
    {
        [DataMember]
        public int ArtikelId { get; set; }

        [DataMember]
        public int FahrzeugId { get; set; }
    }
}
