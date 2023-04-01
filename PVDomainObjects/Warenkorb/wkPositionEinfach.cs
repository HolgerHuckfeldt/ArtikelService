using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    [Serializable]
    public class wkPositionEinfach
    {
        [DataMember]
        public float BestellMenge { get; set; }

        [DataMember]
        public String Artikelnummer
        {
            get;
            set;
        }

        public String Hersteller
        {
            get;
            set;
        }

        public bool Wurdegefunden
        {
            get;
            set;
        }
        
        [DataMember]
        public Artikel.Artikel ArtikelRef
        {
            get;
            set;
        }
    }
}
