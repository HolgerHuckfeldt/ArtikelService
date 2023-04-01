using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    public class TSBGroup
    {
        [DataMember]
        public string groupDescription { get; set; }

        [DataMember]
        public List<TSBDataElement> bulletin { get; set; }

        [DataMember]
        public int systemId { get; set; }

    }
}
