/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Gibt Informationen über die Hauptgruppen (Ebene1) im Suchbaum "Technik"
 ************************************************************************************/
using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [Serializable]
    public class EnumHauptgruppe : EnumGruppe
    {
        [DataContract]
        public enum Hauptgruppe
        {
            [EnumMember]
            NICHT_GESETZT = 0,
            [EnumMember]
            MOTOR = 1,
            [EnumMember]
            BREMSEN = 2,
            [EnumMember]
            LENKUNG_UND_RADAUFHÄNGUNG = 3,
            [EnumMember]
            GETRIEBE = 4,
            [EnumMember]
            AUßENSEITE_UND_INNENRAUM = 5,
            [EnumMember]
            ELEKTRONIK = 6,
            [EnumMember]
            ZUSAMMENFASSUNG = 7,
            [EnumMember]
            SMARTFIX = 8,
        }

        /// <summary>
        /// Gibt den Enum-Wert der Hauptgruppe zur angegebenen Position zurück.
        /// </summary>
        public static Hauptgruppe GetHauptgruppeZuPosition(int position)
        {
            switch (position)
            {
                case 1:
                    return Hauptgruppe.MOTOR;
                case 2:
                    return Hauptgruppe.BREMSEN;
                case 3:
                    return Hauptgruppe.LENKUNG_UND_RADAUFHÄNGUNG;
                case 4:
                    return Hauptgruppe.GETRIEBE;
                case 5:
                    return Hauptgruppe.AUßENSEITE_UND_INNENRAUM;
                case 6:
                    return Hauptgruppe.ELEKTRONIK;
                case 7:
                    return Hauptgruppe.ZUSAMMENFASSUNG;
                case 8:
                    return Hauptgruppe.SMARTFIX;
                default:
                    return Hauptgruppe.NICHT_GESETZT;
            }
        }

        /// <summary>
        /// Mappt die DB-Maingroup in Persistance-Hauptgruppe.
        /// </summary>
        public static Hauptgruppe MappeMainGroupInHauptgruppe(string mainGroup)
        {
            switch (mainGroup)
            {
                case "engine":
                    return Hauptgruppe.MOTOR;
                case "brakes":
                    return Hauptgruppe.BREMSEN;
                case "steer_susp":
                    return Hauptgruppe.LENKUNG_UND_RADAUFHÄNGUNG;
                case "transm":
                    return Hauptgruppe.GETRIEBE;
                case "ext_int":
                    return Hauptgruppe.AUßENSEITE_UND_INNENRAUM;
                case "electronic":
                    return Hauptgruppe.ELEKTRONIK;
                default:
                    return Hauptgruppe.NICHT_GESETZT;
            }
        }
    }
}
