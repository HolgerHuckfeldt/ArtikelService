using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Artikel
{
    [Serializable]
    [DataContract]
    public class PreisStaffel
    {
        [DataMember]
        public decimal MengeVon { get; set; }
        [DataMember]
        public decimal MengeBis { get; set; }
        [DataMember]
        public decimal EKPreis { get; set; }
        [DataMember]
        public int WaehrungsSchluessel { get; set; }
    }
}
