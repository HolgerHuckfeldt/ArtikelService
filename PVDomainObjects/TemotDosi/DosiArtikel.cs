using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.TemotDosi
{
    [DataContract]
    public class DosiArtikel
    {
        [DataMember]
        public string Hersteller { get; set; }
        [DataMember]
        public string ArtikelNummer { get; set; }
        [DataMember]
        public string GenArtNummer { get; set; }
        [DataMember]
        public string ArticleIndicator { get; set; }
        [DataMember]
        public string HaynesCompRef { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public string Quantity { get; set; }
        [DataMember]
        public string Hlk
        {
            get; set;
        }
    }
}
