using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class ForKbaSelectProviderRequest
    {
        [DataMember]
        public string Kba {get; set;}
        [DataMember]
        public int VehicleId { get; set; }
        [DataMember]
        public bool LoadArtList {get; set;}
        [DataMember]
        public bool LoadAWList { get; set; }
        [DataMember]
        public bool LoadPkwModells { get; set; }
        [DataMember]
        public bool LoadPkwTypes { get; set; }
        [DataMember]
        public bool LoadVividMap { get; set; }
        [DataMember]
        public bool LoadTechnikPkws { get; set; }
        [DataMember]
        public int FirmaId { get; set; }
        [DataMember]
        public string AlternativeCSO { get; set; }
    }
}
