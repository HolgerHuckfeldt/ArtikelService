using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    public enum SmartFixSubjectType
    {
        None = 0,
        [EnumMember]
        SF_ADVICE_RECOMMAND = 1,
        [EnumMember]
        SF_AIR_CONDITIONING,
        [EnumMember]
        SF_ALL_BULLETINS,
        [EnumMember]
        SF_BODY_INTERIOR,
        [EnumMember]
        SF_ELECTRONICS,
        [EnumMember]
        SF_ENGINE,
        [EnumMember]
        SF_SAFETY_PROTECTION,
        [EnumMember]
        SF_TRANS_STEERING_SUSP_BRAKES
    }

    [DataContract]
    public class SmartFixSubject
    {
        [DataMember]
        public List<SmartFixElement> Elements { get; set; }
        [DataMember]
        public SmartFixSubjectType Type { get; set; }

    }
}
