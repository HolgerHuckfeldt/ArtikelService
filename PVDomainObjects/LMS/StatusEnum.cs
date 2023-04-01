using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.LMS
{
    [Serializable]
    public class StatusEnum
    {
        [DataContract]
        public enum AnmeldeStatus
        {
            [EnumMember]
            Angemeldet = 1,
            [EnumMember]
            Storniert = 2,
            [EnumMember]
            Teilgenommen = 3,
            [EnumMember]
            Bedarf_Gemeldet = 4,
            [EnumMember]
            Nicht_Erschienen = 5,
            [EnumMember]
            Abgesagt = 6
        };

        [DataContract]
        public enum TerminStatus
        {
            [EnumMember]
            NICHT_GESETZT = 0,
            [EnumMember]
            Frei_Zur_Anmeldung = 1,
            [EnumMember]
            Anmeldung_Gesperrt = 2,
            [EnumMember]
            Abgeschlossen = 3,
            [EnumMember]
            Abgesagt = 4,
        };

        [DataContract]
        public enum ZahlungsArt
        {
            [EnumMember]
            Rechnung_Preis = 1,
            [EnumMember]
            Rechnung_Bonuspunkte = 2,
            [EnumMember]
            Gutschrift_Preis = 3,
            [EnumMember]
            Gutschrift_Bonuspunkte = 4,
            [EnumMember]
            Freie_Trainingstage = 5,
            [EnumMember]
            TrainingsCard =6
        };

        [DataContract]
        public enum TrainingsCard
        {
            [EnumMember]
            Keine = 0,
            [EnumMember]
            TrainingsCard25 = 1,
            [EnumMember]
            TrainingsCard50 = 2,
            [EnumMember]
            TrainingsCard100 = 3,
        };
    }
}
