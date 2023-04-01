using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class StuecklistenArtikel : Artikel
    {
        [DataMember]
        public Int32 StueckMenge { get; set; }

        [DataMember]
        public List<ArtikelKriterium> StueckKriterien { get; set; }
    }
}