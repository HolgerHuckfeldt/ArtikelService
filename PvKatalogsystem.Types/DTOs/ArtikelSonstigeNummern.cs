using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class ArtikelSonstigeNummern : DtoBase
    {
        public ArtikelSonstigeNummern()
        {
            OeReferenznummern = new List<Referenznummer>();
            Gebrauchsnummern = new List<string>();
            EaNummern = new List<string>();
            ErsetzteArtikelnummern = new List<string>();
            ErsetzendeArtikelnummern = new List<string>();
            Vergleichsnummern = new List<string>();
        }

        [DataMember]
        public List<Referenznummer> OeReferenznummern { get; set; }
        [DataMember]
        public List<string> Gebrauchsnummern { get; set; }
        [DataMember]
        public List<string> EaNummern { get; set; }
        [DataMember]
        public List<string> Vergleichsnummern { get; set; }
        [DataMember]
        public List<string> ErsetzteArtikelnummern { get; set; }
        [DataMember]
        public List<string> ErsetzendeArtikelnummern { get; set; }

        public override string ToString()
        {
            return string.Format("OeRef: {0}, Gebr: {1}, Ean: {2}, Vergl: {3}, Ersetzte: {4}, Ersetzende: {5}", OeReferenznummern.Count, Gebrauchsnummern.Count, EaNummern.Count, Vergleichsnummern.Count, ErsetzteArtikelnummern.Count, ErsetzendeArtikelnummern.Count);
        }
    }
}
