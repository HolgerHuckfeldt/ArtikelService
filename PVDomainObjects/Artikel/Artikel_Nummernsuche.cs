using System;
using System.Collections.Generic;
using System.ComponentModel;
using PV.DomainObjects.Arbeitswerte;
using PV.DomainObjects.Common;
using PV.DomainObjects.Fahrzeug;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Artikel
{
    [Serializable]
    public class Artikel_Nummernsuche
    {
        public enum FoundBy
        {
            [EnumMember]
            Artikelnummer,
            [EnumMember]
            Referenznummer,
            [EnumMember]
            Matchcode,
            [EnumMember]
            Vergleichsnummer,
            [EnumMember]
            Gebrauchsnummer,
            [EnumMember]
            EANummer,
            [EnumMember]
            Eindeutignummer,
            [EnumMember]
            WeitereHersteller
        }

        public FoundBy IsFoundBy
        {
            get; set;
        }


    }
}