using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public enum AutoSuggestItemTypes
    {
		[EnumMember]
		Kein = 0,
		[EnumMember]
        Kategorie = 1,
        [EnumMember]
        Kategorie_Uni = 2,
        [EnumMember]
        HerstellerUni = 3,
        [EnumMember]
        HerstellerFahrzeug = 4,
        [EnumMember]
        HerstellerHLKArtikel = 5,
    }
}
