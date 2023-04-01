using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    [Serializable]
    public enum  wkPositionStatus
    {
        [EnumMember]
        Neu,
        [EnumMember]
        Reserviert,
        [EnumMember]
        StuecklimitErreicht,
        [EnumMember]
        BestelllimitErreicht,
        [EnumMember]
        ArtikelNotFound,
        [EnumMember]
        Kreditlimit,
        [EnumMember]
        NichtLieferbar,
        [EnumMember]
        NachtexpressNichtmoeglich,
        [EnumMember]
        UnterpositionNichtLieferbar,
    }
}
