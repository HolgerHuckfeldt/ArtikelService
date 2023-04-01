using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    public enum TSBItemKey
    {
        [EnumMember]
        BODY_STYLE,
        [EnumMember]
        DAM_FROM,
        [EnumMember]
        DAM_TO,
        [EnumMember]
        DATE_FROM,
        [EnumMember]
        DATE_TO,
        [EnumMember]
        ENGINE_CODE,
        [EnumMember]
        ENGINE_FROM,
        [EnumMember]
        ENGINE_TO,
        [EnumMember]
        VIN_FROM,
        [EnumMember]
        VIN_TO,
        [EnumMember]
        REMARK,
        [EnumMember]
        TRANSMISSION_TYPE,
        [EnumMember]
        TRANSMISSION_CODE,
        [EnumMember]
        TRANSMISSION_FROM,
        [EnumMember]
        TRANSMISSION_TO

    }

    [DataContract]
    public class TSBItem
    {
        [DataMember]
        public string key{ get; set;}

        [DataMember]
        public string value { get; set; }
    }
}
