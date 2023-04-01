using PV.DomainObjects.Warenkorb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class OelInfo
    {
        [DataMember]
        public Artikel ArtikelInfos
        {
            get;
            set;
        }
        
        [DataMember]
        public decimal EKPreis
        {
            get;
            set;
        }
        
        [DataMember]
        public virtual wkVerfuegbarkeit Verfuegbarkeit
        {
            get;
            set;
        }
        
        [DataMember]
        public string ArtikelNummer
        {
            get;
            set;
        }
        
        [DataMember]
        public string AlternativeArtikelNummern
        {
            get;
            set;
        }
    }
}
