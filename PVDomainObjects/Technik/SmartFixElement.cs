using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    public class SmartFixElement
    {
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Id { get; set; }
    }
}

