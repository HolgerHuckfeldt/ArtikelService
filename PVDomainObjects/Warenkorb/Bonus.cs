using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Warenkorb
{
    [Serializable]
    [DataContract]
    public enum Status
    {
        [EnumMember]
        Bestellt,
        [EnumMember]
        Storniert
    }

    [Serializable]
    [DataContract]
    public class Bonus
    {
        [DataMember]
        public long Punkte { get; set; }
        [DataMember]
        public Bonustyp Bonustyp { get; set; }
    }

    [Serializable]
    [DataContract]
    public enum Bonustyp
    {
        [EnumMember]
        Summe,
        [EnumMember]
        Sonderbonus,
        [EnumMember]
        Umsatz,
        [EnumMember]
        Umsatzposition,
        [EnumMember]
        Aktion,
        [EnumMember]
        Aktionposition,
        [EnumMember]
        Online,
        [EnumMember]
        Konzept,
        [EnumMember]
        Konzeptposition,
        [EnumMember]
        Tausch,
        [EnumMember]
        Tauschposition,
        [EnumMember]
        KompassBestellBonus,
        [EnumMember]
        KompassBestellBonusposition,
        [EnumMember]
        Liefer,
        [EnumMember]
        Lieferposition,
    }
}
