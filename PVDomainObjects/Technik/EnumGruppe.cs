using System;

namespace PV.DomainObjects.Technik
{
    [Serializable]
    public class EnumGruppe
    {
        /// <summary>
        /// Stellt den Enum-Wert als String dar.
        /// </summary>
        public static string ToString(Enum _enum)
        {
            if (_enum is EnumHauptgruppe.Hauptgruppe)
            {
                switch ((EnumHauptgruppe.Hauptgruppe)_enum)
                {
                    case EnumHauptgruppe.Hauptgruppe.NICHT_GESETZT:
                        return "n.a.";
                    case EnumHauptgruppe.Hauptgruppe.MOTOR:
                        return "Motor";
                    case EnumHauptgruppe.Hauptgruppe.BREMSEN:
                        return "Bremsen";
                    case EnumHauptgruppe.Hauptgruppe.LENKUNG_UND_RADAUFHÄNGUNG:
                        return "Lenkung und Radaufhängung";
                    case EnumHauptgruppe.Hauptgruppe.GETRIEBE:
                        return "Getriebe";
                    case EnumHauptgruppe.Hauptgruppe.AUßENSEITE_UND_INNENRAUM:
                        return "Außenseite und Innenraum";
                    case EnumHauptgruppe.Hauptgruppe.ELEKTRONIK:
                        return "Elektronik";
                    case EnumHauptgruppe.Hauptgruppe.ZUSAMMENFASSUNG:
                        return "Zusammenfassung aller Daten";
                    case EnumHauptgruppe.Hauptgruppe.SMARTFIX:
                        return "Bekannte Probleme";
                    default:
                        return "";
                }
            }
            else if (_enum is EnumUntergruppe.Untergruppe)
            {
                switch ((EnumUntergruppe.Untergruppe)_enum)
                {
                    case EnumUntergruppe.Untergruppe.NICHT_RELEVANT:
                        return "n.a.";
                    case EnumUntergruppe.Untergruppe.EINSTELLDATEN_MOTOR:
                    case EnumUntergruppe.Untergruppe.EINSTELLDATEN_BREMSEN:
                    case EnumUntergruppe.Untergruppe.EINSTELLDATEN_LENKUNG_RAD:
                    case EnumUntergruppe.Untergruppe.EINSTELLDATEN_GETRIEBE:
                    case EnumUntergruppe.Untergruppe.EINSTELLDATEN_AUßEN_INNEN:
                    case EnumUntergruppe.Untergruppe.ALLE_EINSTELLDATEN:
                        return "Einstelldaten";
                    case EnumUntergruppe.Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_MOTOR:
                    case EnumUntergruppe.Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_BREMSEN:
                    case EnumUntergruppe.Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_LENKUNG_RAD:
                    case EnumUntergruppe.Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_GETRIEBE:
                    case EnumUntergruppe.Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_AUßEN_INNEN:
                    case EnumUntergruppe.Untergruppe.ALLE_SCHMIERMITTEL:
                        return "Schmiermittel und Flüssigkeiten";
                    case EnumUntergruppe.Untergruppe.REPARATURHANDBÜCHER_MOTOR:
                    case EnumUntergruppe.Untergruppe.REPARATURHANDBÜCHER_BREMSEN:
                    case EnumUntergruppe.Untergruppe.REPARATURHANDBÜCHER_LENKUNG_RAD:
                    case EnumUntergruppe.Untergruppe.REPARATURHANDBÜCHER_GETRIEBE:
                    case EnumUntergruppe.Untergruppe.REPARATURHANDBÜCHER_AUßEN_INNEN:
                    case EnumUntergruppe.Untergruppe.REPARATURHANDBÜCHER_ELEKTRONIK:
                    case EnumUntergruppe.Untergruppe.ALLE_REPARATURHANDBÜCHER:
                        return "Reparaturhandbücher";
                    case EnumUntergruppe.Untergruppe.TECHNISCHE_ZEICHNUNGEN_MOTOR:
                    case EnumUntergruppe.Untergruppe.TECHNISCHE_ZEICHNUNGEN_BREMSEN:
                    case EnumUntergruppe.Untergruppe.TECHNISCHE_ZEICHNUNGEN_LENKUNG_RAD:
                    case EnumUntergruppe.Untergruppe.TECHNISCHE_ZEICHNUNGEN_GETRIEBE:
                    case EnumUntergruppe.Untergruppe.TECHNISCHE_ZEICHNUNGEN_AUßEN_INNEN:
                    case EnumUntergruppe.Untergruppe.ALLE_TECHNISCHE_ZEICHNUNGEN:
                        return "Technische Zeichnungen";
                    case EnumUntergruppe.Untergruppe.ALLGEMEINE_INFORMATIONEN_MOTOR:
                    case EnumUntergruppe.Untergruppe.ALLGEMEINE_INFORMATIONEN_LENKUNG_RAD:
                    case EnumUntergruppe.Untergruppe.ALLGEMEINE_INFORMATIONEN_GETRIEBE:
                    case EnumUntergruppe.Untergruppe.ALLGEMEINE_INFORMATIONEN_AUßEN_INNEN:
                    case EnumUntergruppe.Untergruppe.ALLE_ALLGEMEINE_INFORMATIONEN:
                        return "Allgemeine Informationen";
                    case EnumUntergruppe.Untergruppe.ABS_ELEKTRONISCH_BREMSEN:
                    case EnumUntergruppe.Untergruppe.ABS_ELEKTRONISCH_ELEKTRONIK:
                        return "ABS elektronisch";
                    case EnumUntergruppe.Untergruppe.AUTOMATIKGETRIEBE_GETRIEBE:
                    case EnumUntergruppe.Untergruppe.AUTOMATIKGETRIEBE_ELEKTRONIK:
                        return "Automatikgetriebe";
                    case EnumUntergruppe.Untergruppe.KLIMAANLAGE_SCHALTPLÄNE_AUßEN_INNEN:
                        return "Klimaanlage Schaltpläne";
                    case EnumUntergruppe.Untergruppe.MOTORMANAGEMENT_MOTOR:
                    case EnumUntergruppe.Untergruppe.MOTORMANAGEMENT_ELEKTRONIK:
                        return "Motormanagement";
                    case EnumUntergruppe.Untergruppe.SICHERUNGEN_UND_RELAIS_ELEKTRONIK:
                        return "Sicherungen und Relais";
                    case EnumUntergruppe.Untergruppe.DIAGNOSE_ELEKTRONIK:
                        return "Diagnose";
                    case EnumUntergruppe.Untergruppe.DIAGNOSE_ELEKTRONIK_FLASH:
                        return "Diagnoseassistent";
                    case EnumUntergruppe.Untergruppe.KOMFORTELEKTRONIK_ELEKTRONIK:
                        return "Komfortelektronik";
                    case EnumUntergruppe.Untergruppe.SMARTFIX_NONE:
                        return "SMARTFIX_NONE";
                    case EnumUntergruppe.Untergruppe.SMARTFIX_ADVICE_RECOMMAND:
                        return "Ratschläge und Empfehlungen";
                    case EnumUntergruppe.Untergruppe.SMARTFIX_AIR_CONDITIONING:
                        return "Klimaanlage";
                    case EnumUntergruppe.Untergruppe.SMARTFIX_ALL_BULLETINS:
                        return "SMARTFIX_ALL_BULLETINS";
                    case EnumUntergruppe.Untergruppe.SMARTFIX_BODY_INTERIOR:
                        return "Karosserie und Innenraum";
                    case EnumUntergruppe.Untergruppe.SMARTFIX_ELECTRONICS:
                        return "Elektronik";
                    case EnumUntergruppe.Untergruppe.SMARTFIX_ENGINE:
                        return "Motor";
                    case EnumUntergruppe.Untergruppe.SMARTFIX_SAFETY_PROTECTION:
                        return "Sicherheit";
                    case EnumUntergruppe.Untergruppe.SMARTFIX_TRANS_STEERING_SUSP_BRAKES:
                        return "Getriebe, Lenkung, Radaufhängung und Bremsen";
                    default:
                        return "";
                }
            }
            else
            {
                return "";
            }

        }
        public static EnumUntergruppe.Untergruppe GetUntergruppeTechnischeZeichnungen(EnumHauptgruppe.Hauptgruppe hg)
        {
            switch (hg)
            {
                case EnumHauptgruppe.Hauptgruppe.MOTOR:
                    return EnumUntergruppe.Untergruppe.TECHNISCHE_ZEICHNUNGEN_MOTOR;
                case EnumHauptgruppe.Hauptgruppe.BREMSEN:
                    return EnumUntergruppe.Untergruppe.TECHNISCHE_ZEICHNUNGEN_BREMSEN;
                case EnumHauptgruppe.Hauptgruppe.GETRIEBE:
                    return EnumUntergruppe.Untergruppe.TECHNISCHE_ZEICHNUNGEN_GETRIEBE;
                case EnumHauptgruppe.Hauptgruppe.LENKUNG_UND_RADAUFHÄNGUNG:
                    return EnumUntergruppe.Untergruppe.TECHNISCHE_ZEICHNUNGEN_LENKUNG_RAD;
                case EnumHauptgruppe.Hauptgruppe.AUßENSEITE_UND_INNENRAUM:
                    return EnumUntergruppe.Untergruppe.TECHNISCHE_ZEICHNUNGEN_AUßEN_INNEN;

                default:
                    return EnumUntergruppe.Untergruppe.NICHT_RELEVANT;
            }

        }
        public static EnumUntergruppe.Untergruppe GetUntergruppeManagement(EnumHauptgruppe.Hauptgruppe hg)
        {
            switch (hg)
            {
                case EnumHauptgruppe.Hauptgruppe.MOTOR:
                    return EnumUntergruppe.Untergruppe.MOTORMANAGEMENT_MOTOR;
                case EnumHauptgruppe.Hauptgruppe.BREMSEN:
                    return EnumUntergruppe.Untergruppe.ABS_ELEKTRONISCH_BREMSEN;
                case EnumHauptgruppe.Hauptgruppe.GETRIEBE:
                    return EnumUntergruppe.Untergruppe.AUTOMATIKGETRIEBE_GETRIEBE;

                default:
                    return EnumUntergruppe.Untergruppe.NICHT_RELEVANT;
            }

        }
        public static EnumUntergruppe.Untergruppe GetUntergruppeReparaturhandbücher(EnumHauptgruppe.Hauptgruppe hg)
        {
            switch (hg)
            {
                case EnumHauptgruppe.Hauptgruppe.MOTOR:
                    return EnumUntergruppe.Untergruppe.REPARATURHANDBÜCHER_MOTOR;
                case EnumHauptgruppe.Hauptgruppe.BREMSEN:
                    return EnumUntergruppe.Untergruppe.REPARATURHANDBÜCHER_BREMSEN;
                case EnumHauptgruppe.Hauptgruppe.GETRIEBE:
                    return EnumUntergruppe.Untergruppe.REPARATURHANDBÜCHER_GETRIEBE;
                case EnumHauptgruppe.Hauptgruppe.LENKUNG_UND_RADAUFHÄNGUNG:
                    return EnumUntergruppe.Untergruppe.REPARATURHANDBÜCHER_LENKUNG_RAD;
                case EnumHauptgruppe.Hauptgruppe.AUßENSEITE_UND_INNENRAUM:
                    return EnumUntergruppe.Untergruppe.REPARATURHANDBÜCHER_AUßEN_INNEN;
                case EnumHauptgruppe.Hauptgruppe.ELEKTRONIK:
                    return EnumUntergruppe.Untergruppe.REPARATURHANDBÜCHER_ELEKTRONIK;

                default:
                    return EnumUntergruppe.Untergruppe.NICHT_RELEVANT;
            }

        }
        public static EnumUntergruppe.Untergruppe GetUntergruppeEinstelldaten(EnumHauptgruppe.Hauptgruppe hg)
        {
            switch (hg)
            {
                case EnumHauptgruppe.Hauptgruppe.MOTOR:
                    return EnumUntergruppe.Untergruppe.EINSTELLDATEN_MOTOR;
                case EnumHauptgruppe.Hauptgruppe.BREMSEN:
                    return EnumUntergruppe.Untergruppe.EINSTELLDATEN_BREMSEN;
                case EnumHauptgruppe.Hauptgruppe.GETRIEBE:
                    return EnumUntergruppe.Untergruppe.EINSTELLDATEN_GETRIEBE;
                case EnumHauptgruppe.Hauptgruppe.LENKUNG_UND_RADAUFHÄNGUNG:
                    return EnumUntergruppe.Untergruppe.EINSTELLDATEN_LENKUNG_RAD;
                case EnumHauptgruppe.Hauptgruppe.AUßENSEITE_UND_INNENRAUM:
                    return EnumUntergruppe.Untergruppe.EINSTELLDATEN_AUßEN_INNEN;
                case EnumHauptgruppe.Hauptgruppe.ZUSAMMENFASSUNG:
                    return EnumUntergruppe.Untergruppe.ALLE_EINSTELLDATEN;

                default:
                    return EnumUntergruppe.Untergruppe.NICHT_RELEVANT;
            }

        }
        public static EnumUntergruppe.Untergruppe GetUntergruppeSchmiermittel(EnumHauptgruppe.Hauptgruppe hg)
        {
            switch (hg)
            {
                case EnumHauptgruppe.Hauptgruppe.MOTOR:
                    return EnumUntergruppe.Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_MOTOR;
                case EnumHauptgruppe.Hauptgruppe.BREMSEN:
                    return EnumUntergruppe.Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_BREMSEN;
                case EnumHauptgruppe.Hauptgruppe.GETRIEBE:
                    return EnumUntergruppe.Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_GETRIEBE;
                case EnumHauptgruppe.Hauptgruppe.LENKUNG_UND_RADAUFHÄNGUNG:
                    return EnumUntergruppe.Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_LENKUNG_RAD;
                case EnumHauptgruppe.Hauptgruppe.AUßENSEITE_UND_INNENRAUM:
                    return EnumUntergruppe.Untergruppe.SCHMIERMITTEL_UND_FLÜSSIGKEITEN_AUßEN_INNEN;

                default:
                    return EnumUntergruppe.Untergruppe.NICHT_RELEVANT;
            }

        }
    }
}
