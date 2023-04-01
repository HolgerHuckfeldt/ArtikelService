using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.Enums
{
    [Serializable]
    [DataContract]
    public enum BestellungPublikation
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
        Android = 6,
        [EnumMember]
        PvLive = 7
    }
}
