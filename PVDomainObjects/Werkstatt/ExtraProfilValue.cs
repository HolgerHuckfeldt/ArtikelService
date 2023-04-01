using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Stammdaten
{
    [Serializable]
    [DataContract]
    public class ExtraProfilValue
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public string TheValue { get; set; }
    }
}
