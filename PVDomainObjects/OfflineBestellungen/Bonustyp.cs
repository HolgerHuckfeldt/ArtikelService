using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Pv.Services.Shared.Dtos
{
    /// <summary>
    /// Wichtig, für Persistierung immer zu Zehelenwerten zuordnen
    /// </summary>
    [DataContract]
    public enum Bonustyp
    {
        /// <remarks/>
        [EnumMember] 
        Summe = 0,

        /// <remarks/>
        [EnumMember]
        Umsatz = 1,

        /// <remarks/>
        [EnumMember]
        Umsatzposition = 2,

        /// <remarks/>
        [EnumMember]
        Aktion = 3,

        /// <remarks/>
        [EnumMember]
        Aktionposition = 4,

        /// <remarks/>
        [EnumMember]
        Online = 5,

        /// <remarks/>
        [EnumMember]
        Konzept = 6,

         /// <remarks/>
        [EnumMember]
        Konzeptposition = 7,

        /// <remarks/>
        [EnumMember]
        Tausch = 8,

        /// <remarks/>
        [EnumMember]
        Tauschposition = 9,

        [EnumMember]
        KompassBestellBonus = 10,

        [EnumMember]
        KompassBestellBonusposition = 11,

        [EnumMember]
        Liefer = 12,

        [EnumMember]
        Lieferposition = 13,

        /// <remarks/>
        [EnumMember]
        Sonderbonus = 14,

        [EnumMember]
        Undefined = 99
    }
}
