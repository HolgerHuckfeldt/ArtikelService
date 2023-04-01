using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Stammdaten
{
    [DataContract]
    public class ManagerVersion
    {
        [DataMember]
        public int ProfilId { get; set; }
        [DataMember]
        public string Version { get; set; }
        [DataMember]
        public string InternalVersion { get; set; }
        [DataMember]
        public string Lizenz { get; set; }
    }
}
