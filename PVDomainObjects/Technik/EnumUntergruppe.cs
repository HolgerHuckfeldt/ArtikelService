/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Gibt Informationen über die Untergruppen (Ebene2) im Suchbaum "Technik"
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    [Serializable]
    public class EnumUntergruppe : EnumGruppe
    {
        #region Enum

        [DataContract]
        public enum Untergruppe
        {
            [EnumMember]
            NICHT_RELEVANT = 10,

            // Motor
            [EnumMember]
            EINSTELLDATEN_MOTOR = 11,
            [EnumMember]
            SCHMIERMITTEL_UND_FLÜSSIGKEITEN_MOTOR = 12,
            [EnumMember]
            REPARATURHANDBÜCHER_MOTOR = 13,
            [EnumMember]
            TECHNISCHE_ZEICHNUNGEN_MOTOR = 14,
            [EnumMember]
            MOTORMANAGEMENT_MOTOR = 15,
            [EnumMember]
            ALLGEMEINE_INFORMATIONEN_MOTOR = 19,

            // Bremsen
            [EnumMember]
            EINSTELLDATEN_BREMSEN = 21,
            [EnumMember]
            SCHMIERMITTEL_UND_FLÜSSIGKEITEN_BREMSEN = 22,
            [EnumMember]
            REPARATURHANDBÜCHER_BREMSEN = 23,
            [EnumMember]
            TECHNISCHE_ZEICHNUNGEN_BREMSEN = 24,
            [EnumMember]
            ABS_ELEKTRONISCH_BREMSEN = 25,

            // Lenkung und Radaufhängung
            [EnumMember]
            EINSTELLDATEN_LENKUNG_RAD = 31,
            [EnumMember]
            SCHMIERMITTEL_UND_FLÜSSIGKEITEN_LENKUNG_RAD = 32,
            [EnumMember]
            REPARATURHANDBÜCHER_LENKUNG_RAD = 33,
            [EnumMember]
            TECHNISCHE_ZEICHNUNGEN_LENKUNG_RAD = 34,
            [EnumMember]
            ALLGEMEINE_INFORMATIONEN_LENKUNG_RAD = 39,

            // Getriebe
            [EnumMember]
            EINSTELLDATEN_GETRIEBE = 41,
            [EnumMember]
            SCHMIERMITTEL_UND_FLÜSSIGKEITEN_GETRIEBE = 42,
            [EnumMember]
            REPARATURHANDBÜCHER_GETRIEBE = 43,
            [EnumMember]
            TECHNISCHE_ZEICHNUNGEN_GETRIEBE = 44,
            [EnumMember]
            AUTOMATIKGETRIEBE_GETRIEBE = 45,
            [EnumMember]
            ALLGEMEINE_INFORMATIONEN_GETRIEBE = 49,

            // Aussenseite und Innenraum
            [EnumMember]
            EINSTELLDATEN_AUßEN_INNEN = 51,
            [EnumMember]
            SCHMIERMITTEL_UND_FLÜSSIGKEITEN_AUßEN_INNEN = 52,
            [EnumMember]
            REPARATURHANDBÜCHER_AUßEN_INNEN = 53,
            [EnumMember]
            TECHNISCHE_ZEICHNUNGEN_AUßEN_INNEN = 54,
            [EnumMember]
            KLIMAANLAGE_SCHALTPLÄNE_AUßEN_INNEN = 55,
            [EnumMember]
            ALLGEMEINE_INFORMATIONEN_AUßEN_INNEN = 59,

            // Elektronik
            [EnumMember]
            REPARATURHANDBÜCHER_ELEKTRONIK = 61,
            [EnumMember]
            MOTORMANAGEMENT_ELEKTRONIK = 62,
            [EnumMember]
            ABS_ELEKTRONISCH_ELEKTRONIK = 63,
            [EnumMember]
            SICHERUNGEN_UND_RELAIS_ELEKTRONIK = 64,
            [EnumMember]
            DIAGNOSE_ELEKTRONIK = 65,
            [EnumMember]
            DIAGNOSE_ELEKTRONIK_FLASH = 1000,
            [EnumMember]
            KOMFORTELEKTRONIK_ELEKTRONIK = 66,
            [EnumMember]
            AUTOMATIKGETRIEBE_ELEKTRONIK = 67,

            // Zusammenfassung
            [EnumMember]
            ALLE_EINSTELLDATEN = 71,
            [EnumMember]
            ALLE_SCHMIERMITTEL = 72,
            [EnumMember]
            ALLE_REPARATURHANDBÜCHER = 73,
            [EnumMember]
            ALLE_TECHNISCHE_ZEICHNUNGEN = 74,
            [EnumMember]
            ALLE_ALLGEMEINE_INFORMATIONEN = 75,

            // Smartfix
            [EnumMember]
            SMARTFIX_NONE = 80,
            [EnumMember]
            SMARTFIX_ADVICE_RECOMMAND = 81,
            [EnumMember]
            SMARTFIX_AIR_CONDITIONING = 82,
            [EnumMember]
            SMARTFIX_ALL_BULLETINS = 83,
            [EnumMember]
            SMARTFIX_BODY_INTERIOR = 84,
            [EnumMember]
            SMARTFIX_ELECTRONICS = 85,
            [EnumMember]
            SMARTFIX_ENGINE = 86,
            [EnumMember]
            SMARTFIX_SAFETY_PROTECTION = 87,
            [EnumMember]
            SMARTFIX_TRANS_STEERING_SUSP_BRAKES = 88

        }

        #endregion

        // --------------------------------------------------------------------------

        #region Getter

        public static Untergruppe GetEnumUntergruppeSmartfixZuPosition(int position)
        {
            switch (position)
            {
                case 1:
                    return Untergruppe.SMARTFIX_ADVICE_RECOMMAND;
                case 2:
                    return Untergruppe.SMARTFIX_AIR_CONDITIONING ;
                case 3:
                    return Untergruppe.SMARTFIX_ALL_BULLETINS ;
                case 4:
                    return Untergruppe.SMARTFIX_BODY_INTERIOR;
                case 5:
                    return Untergruppe.SMARTFIX_ELECTRONICS ;
                case 6:
                    return Untergruppe.SMARTFIX_ENGINE ;
                case 7:
                    return Untergruppe.SMARTFIX_NONE ;
                case 8:
                    return Untergruppe.SMARTFIX_SAFETY_PROTECTION ;
                case 9:
                    return Untergruppe.SMARTFIX_TRANS_STEERING_SUSP_BRAKES ;
                default:
                    return Untergruppe.NICHT_RELEVANT;
            }
        }
        /// <summary>
        /// Gibt den Enum-Wert für die Hauptgruppe "Motor" und zur angegebenen Position zurück.
        /// </summary>
        public static Untergruppe GetEnumUntergruppeMotorZuPosition(int position)
        {
            switch (position)
            {
                case 1:
                    return Untergruppe.EINSTELLDATEN_MOTOR;
                case 2:
                    return Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_MOTOR;
                case 3:
                    return Untergruppe.REPARATURHANDBÜCHER_MOTOR;
                case 4:
                    return Untergruppe.TECHNISCHE_ZEICHNUNGEN_MOTOR;
                case 5:
                    return Untergruppe.MOTORMANAGEMENT_MOTOR;
                default:
                    return Untergruppe.NICHT_RELEVANT;
            }
        }

        /// <summary>
        /// Gibt den Enum-Wert für die Hauptgruppe "Bremsen" und zur angegebenen Position zurück.
        /// </summary>
        public static Untergruppe GetEnumUntergruppeBremsenZuPosition(int position)
        {
            switch (position)
            {
                case 1:
                    return Untergruppe.EINSTELLDATEN_BREMSEN;
                case 2:
                    return Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_BREMSEN;
                case 3:
                    return Untergruppe.REPARATURHANDBÜCHER_BREMSEN;
                case 4:
                    return Untergruppe.TECHNISCHE_ZEICHNUNGEN_BREMSEN;
                case 5:
                    return Untergruppe.ABS_ELEKTRONISCH_BREMSEN;
                default:
                    return Untergruppe.NICHT_RELEVANT;
            }
        }

        /// <summary>
        /// Gibt den Enum-Wert für die Hauptgruppe "Lenkung und Radaufhängung" und zur angegebenen Position zurück.
        /// </summary>
        public static Untergruppe GetEnumUntergruppeLenkungUndRadaufhaengungZuPosition(int position)
        {
            switch (position)
            {
                case 1:
                    return Untergruppe.EINSTELLDATEN_LENKUNG_RAD;
                case 2:
                    return Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_LENKUNG_RAD;
                case 3:
                    return Untergruppe.REPARATURHANDBÜCHER_LENKUNG_RAD;
                case 4:
                    return Untergruppe.TECHNISCHE_ZEICHNUNGEN_LENKUNG_RAD;
                default:
                    return Untergruppe.NICHT_RELEVANT;
            }
        }

        /// <summary>
        /// Gibt den Enum-Wert für die Hauptgruppe "Lenkung und Radaufhängung" und zur angegebenen Position zurück.
        /// </summary>
        public static Untergruppe GetEnumUntergruppeGetriebeZuPosition(int position)
        {
            switch (position)
            {
                case 1:
                    return Untergruppe.EINSTELLDATEN_GETRIEBE;
                case 2:
                    return Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_GETRIEBE;
                case 3:
                    return Untergruppe.REPARATURHANDBÜCHER_GETRIEBE;
                case 4:
                    return Untergruppe.TECHNISCHE_ZEICHNUNGEN_GETRIEBE;
                case 5:
                    return Untergruppe.AUTOMATIKGETRIEBE_GETRIEBE;
                default:
                    return Untergruppe.NICHT_RELEVANT;
            }
        }

        /// <summary>
        /// Gibt den Enum-Wert für die Hauptgruppe "Aussenseite und Innenraum" und zur angegebenen Position zurück.
        /// </summary>
        public static Untergruppe GetEnumUntergruppeAussenseiteUndInnenraumZuPosition(int position)
        {
            switch (position)
            {
                case 1:
                    return Untergruppe.EINSTELLDATEN_AUßEN_INNEN;
                case 2:
                    return Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_AUßEN_INNEN;
                case 3:
                    return Untergruppe.REPARATURHANDBÜCHER_AUßEN_INNEN;
                case 4:
                    return Untergruppe.TECHNISCHE_ZEICHNUNGEN_AUßEN_INNEN;
                case 5:
                    return Untergruppe.KLIMAANLAGE_SCHALTPLÄNE_AUßEN_INNEN;
                default:
                    return Untergruppe.NICHT_RELEVANT;
            }
        }

        #endregion

        // --------------------------------------------------------------------------

        #region Getter für Freitextsuche

        public static Untergruppe GetEnumUntergruppeZuHauptgruppeUndContent(EnumHauptgruppe.Hauptgruppe hauptgruppe, string content)
        {
            switch (hauptgruppe)
            {
                case EnumHauptgruppe.Hauptgruppe.MOTOR:
                    switch (content)
                    {
                        case "v_Einstelldatum":
                            return Untergruppe.EINSTELLDATEN_MOTOR;
                        case "v_Schmiermittel":
                        case "v_SchmiermittelFuellmenge":
                            return Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_MOTOR;
                        case "v_ReparaturhandbuchEintrag":
                            return Untergruppe.REPARATURHANDBÜCHER_MOTOR;
                        case "v_MotormanagementComponente":
                            return Untergruppe.MOTORMANAGEMENT_MOTOR;
                        case "v_TechnischeZeichnungGruppeItem":
                            return Untergruppe.TECHNISCHE_ZEICHNUNGEN_MOTOR;
                    }
                    break;
                case EnumHauptgruppe.Hauptgruppe.BREMSEN:
                    switch (content)
                    {
                        case "v_Einstelldatum":
                            return Untergruppe.EINSTELLDATEN_BREMSEN;
                        case "v_Schmiermittel":
                        case "v_SchmiermittelFuellmenge":
                            return Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_BREMSEN;
                        case "v_ReparaturhandbuchEintrag":
                            return Untergruppe.REPARATURHANDBÜCHER_BREMSEN;
                        case "v_MotormanagementComponente":
                            return Untergruppe.ABS_ELEKTRONISCH_BREMSEN;
                        case "v_TechnischeZeichnungGruppeItem":
                            return Untergruppe.TECHNISCHE_ZEICHNUNGEN_BREMSEN;
                    }
                    break;
                case EnumHauptgruppe.Hauptgruppe.LENKUNG_UND_RADAUFHÄNGUNG:
                    switch (content)
                    {
                        case "v_Einstelldatum":
                            return Untergruppe.EINSTELLDATEN_LENKUNG_RAD;
                        case "v_Schmiermittel":
                        case "v_SchmiermittelFuellmenge":
                            return Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_LENKUNG_RAD;
                        case "v_ReparaturhandbuchEintrag":
                            return Untergruppe.REPARATURHANDBÜCHER_LENKUNG_RAD;
                        case "v_TechnischeZeichnungGruppeItem":
                            return Untergruppe.TECHNISCHE_ZEICHNUNGEN_LENKUNG_RAD;
                    }
                    break;
                case EnumHauptgruppe.Hauptgruppe.GETRIEBE:
                    switch (content)
                    {
                        case "v_Einstelldatum":
                            return Untergruppe.EINSTELLDATEN_GETRIEBE;
                        case "v_Schmiermittel":
                        case "v_SchmiermittelFuellmenge":
                            return Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_GETRIEBE;
                        case "v_ReparaturhandbuchEintrag":
                            return Untergruppe.REPARATURHANDBÜCHER_GETRIEBE;
                        case "v_MotormanagementComponente":
                            return Untergruppe.AUTOMATIKGETRIEBE_GETRIEBE;
                        case "v_TechnischeZeichnungGruppeItem":
                            return Untergruppe.TECHNISCHE_ZEICHNUNGEN_GETRIEBE;
                    }
                    break;
                case EnumHauptgruppe.Hauptgruppe.AUßENSEITE_UND_INNENRAUM:
                    switch (content)
                    {
                        case "v_Einstelldatum":
                            return Untergruppe.EINSTELLDATEN_AUßEN_INNEN;
                        case "v_Schmiermittel":
                        case "v_SchmiermittelFuellmenge":
                            return Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_AUßEN_INNEN;
                        case "v_ReparaturhandbuchEintrag":
                            return Untergruppe.REPARATURHANDBÜCHER_AUßEN_INNEN;
                        case "v_TechnischeZeichnungGruppeItem":
                            return Untergruppe.TECHNISCHE_ZEICHNUNGEN_AUßEN_INNEN;
                    }
                    break;
                case EnumHauptgruppe.Hauptgruppe.ELEKTRONIK:
                    switch (content)
                    {
                        case "v_ReparaturhandbuchEintrag":
                            return Untergruppe.REPARATURHANDBÜCHER_ELEKTRONIK;
                        case "v_DiagnoseCode":
                            return Untergruppe.DIAGNOSE_ELEKTRONIK;
                        case "v_Sicherung":
                            return Untergruppe.SICHERUNGEN_UND_RELAIS_ELEKTRONIK;
                    }
                    break;
            }

            return Untergruppe.NICHT_RELEVANT;
        }

        #endregion

        // --------------------------------------------------------------------------

    }
}
