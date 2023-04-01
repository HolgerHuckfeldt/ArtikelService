using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Wartung
{
    [DataContract]
    public class WartungSystemIntervalleInfo
    {
        [DataMember]
        public int SystemId;
        [DataMember]
        public string SystemText;
        [DataMember]
        public List<WartungsChecklisteItem> Items = new List<WartungsChecklisteItem>();
    }
}
