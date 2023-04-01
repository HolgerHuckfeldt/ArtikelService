using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PVInterfaces.Enums
{
    [Serializable]
    [DataContract]
    public enum EinlogDeviceTyp
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        Hybrid = 1,
        [EnumMember]
        OnlineKompakt = 2,
        [EnumMember]
        OnlineKompaktMobile = 3,
        [EnumMember]
        IPhone = 4,
        [EnumMember]
        WinPhone = 5,
        [EnumMember]
        Android = 6
    }
}
