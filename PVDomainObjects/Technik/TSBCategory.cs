using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    public enum TSBCat
    {
        [EnumMember]
        NOTHING = 0,
        [EnumMember]
        ENGINE,
        [EnumMember]
        TRANSMISSION,
        [EnumMember]
        STEERING,
        [EnumMember]
        BRAKES,
        [EnumMember]
        EXTERIOR,
        [EnumMember]
        ELECTRONICS,
        [EnumMember]
        QUICKGUIDES
    }

    [DataContract]
    public class TSBCategory
    {

        [DataMember]
        public string extraInfo { get; set; }

        [DataMember]
        public string categoryDescription { get; set; }

        [DataMember]
        public TSBCat category { get; set; }

        [DataMember]
        public List<TSBSystem> systems { get; set; }
    }
}
