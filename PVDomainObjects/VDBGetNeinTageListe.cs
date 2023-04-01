using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects
{   
    [DataContract]
    [Serializable]
    public class VDBGetNeinTageListe
    {
        [DataMember]
        public List<DateTime> GetNeinTageListe = new List<DateTime>();
    }
}
