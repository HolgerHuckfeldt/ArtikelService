using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;
using PV.DomainObjects.Arbeitswerte;
using PV.DomainObjects.Common;
using PV.DomainObjects.Fahrzeug;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public enum ArtikelVerwandtschaft
    {
        [EnumMember]
        Muss,
        [EnumMember]
        Kann,
        [EnumMember]
        Soll,
        [EnumMember]
        Zubehoer
    }
}
