using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    [Serializable]
    public enum wkVerfuegbarkeit
    {
        [EnumMember]
        NaechsteTour,
        [EnumMember]
        Heute,
        [EnumMember]
        NaechsterWerktag,
        [EnumMember]
        UebernaechsterTag,
        [EnumMember]
        GroesserUebernaechsterTag,
        [EnumMember]
        Rueckstand,
        [EnumMember]
        NichtBestellbar,
        [EnumMember]
        OfflineVDB,
        TecCom
    }
}
