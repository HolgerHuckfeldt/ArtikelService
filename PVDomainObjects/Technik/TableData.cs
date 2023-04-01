using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    public class TableData
    {
        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public bool IsHeader { get; set; }

        [DataMember]
        public int Col { get; set; }

        [DataMember]
        public int Row { get; set; }

    }
}
