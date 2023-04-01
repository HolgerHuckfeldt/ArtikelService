using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class ZubehoerArtikel : Artikel
    {
        [DataMember]
        public Int32 BenoetigteMenge { get; set; }

        [DataMember]
        public int LfdNr2 { get; set; }

        [DataMember]
        public List<ArtikelKriterium> ZubehoerKriterien { get; set; }
    }
}