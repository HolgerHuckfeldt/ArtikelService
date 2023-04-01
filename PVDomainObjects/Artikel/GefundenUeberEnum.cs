using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [Serializable]
    public enum GefundenUeberEnum
    {
        [EnumMember]
        Eindeutig,
        [EnumMember]
        Artikelnummer,
        [EnumMember]
        Gebrauchsnummer,
        [EnumMember]
        EANNummer,
        [EnumMember]
        Referenznummer,
        [EnumMember]
        Vergleichsnummer,
        [EnumMember]
        Matchcode
    }
}
