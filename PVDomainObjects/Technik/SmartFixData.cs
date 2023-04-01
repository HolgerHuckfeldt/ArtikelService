using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    public class SmartFixData
    {
        [DataMember]
        public string Data
        { get; set; }

        [DataMember]
        public SmartFixElement Element
        { get; set; }
    }
    ;
}
