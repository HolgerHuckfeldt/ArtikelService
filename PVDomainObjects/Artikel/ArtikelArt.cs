using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public enum ArtikelArt
    {
        [EnumMember]
        PKW,
        [EnumMember]
        NKW,
        [EnumMember]
        Motor,
        [EnumMember]
        Achse,
        [EnumMember]
        Universal,
    }
}
