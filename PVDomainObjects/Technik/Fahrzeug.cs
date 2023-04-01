/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen eines Fahrzeugs
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    [Serializable]
    public enum TreibstofTyp
    {
        [EnumMember]
        NICHT_GESETZT = 0,
        [EnumMember]
        P = 1,
        [EnumMember]
        D = 2,
        [EnumMember]
        NG = 3,
        [EnumMember]
        NA = 4,
    }

    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Fahrzeugs
    /// </summary>
    [DataContract]
    [Serializable]
    public class Fahrzeug
    {
        #region Fields

        private int _HerstellerId;
        private int _ModellId;
        private int _TypId;
        private string _HerstellerBezeichnung;
        private string _ModellBezeichnung;
        private string _ModellZusatzInfo;
        private string _TypBezeichnung;
        private string _Motorcode;
        private int _MotorNummer = -1;
        private decimal _Hubraum;
        private decimal _LeistungKw;
        private decimal _LeistungPs;
        private string _GebautVon;
        private string _GebautBis;
        private int _KTypNummer;
        private TreibstofTyp _TreibstoffTyp;
        private string _Subjects;
        private bool _HatEobd;
        private string _Hauptgruppen;
        private string _UntergruppenMotor;
        private string _UntergruppenBremsen;
        private string _UntergruppenLenkungUndRadaufhaengung;
        private string _UntergruppenGetriebe;
        private string _UntergruppenAussenseiteUndInnenraum;
        private int _TechnischeZeichnungSystemId;

        #endregion

        // --------------------------------------------------------------------------

        #region Fahrzeug-Member

        /// <summary>
        /// Liefert Id des Herstellers
        /// </summary>
        [DataMember]
        public int HerstellerId
        {
            get
            {
                return _HerstellerId;
            }
            set
            {
                _HerstellerId = value;
            }
        }

        /// <summary>
        /// Liefert Id des Modells
        /// </summary>
        [DataMember]
        public int ModellId
        {
            get
            {
                return _ModellId;
            }
            set
            {
                _ModellId = value;
            }
        }

        /// <summary>
        /// Liefert Id des Typs
        /// </summary>
        [DataMember]
        public int TypId
        {
            get
            {
                return _TypId;
            }
            set
            {
                _TypId = value;
            }
        }

        /// <summary>
        /// Liefert den Namen des Herstellers
        /// </summary>
        [DataMember]
        public string HerstellerBezeichnung
        {
            get
            {
                return _HerstellerBezeichnung;
            }
            set
            {
                _HerstellerBezeichnung = value;
            }
        }

        /// <summary>
        /// Liefert den Namen des Modells
        /// </summary>
        [DataMember]
        public string ModellBezeichnung
        {
            get
            {
                return _ModellBezeichnung;
            }
            set
            {
                _ModellBezeichnung = value;
            }
        }

        /// <summary>
        /// Liefert Zusatzinfos des Modells
        /// </summary>
        [DataMember]
        public string ModellZusatzInfo
        {
            get
            {
                return _ModellZusatzInfo;
            }
            set
            {
                _ModellZusatzInfo = value;
            }
        }

        /// <summary>
        /// Liefert den Namen des Typs
        /// </summary>
        [DataMember]
        public string TypBezeichnung
        {
            get
            {
                return _TypBezeichnung;
            }
            set
            {
                _TypBezeichnung = value;
            }
        }

        /// <summary>
        /// Liefert die Gesamt Bezeichnung des Fahrzeugs
        /// </summary>
        public string GesamtBezeichnung
        {
            get
            {
                return ModellBezeichnung + " " + (!string.IsNullOrEmpty(ModellZusatzInfo) ? ModellZusatzInfo + " " : "") + TypBezeichnung;
            }
        }

        /// <summary>
        /// Liefert den Motorcode
        /// </summary>
        [DataMember]
        public string Motorcode
        {
            get
            {
                return _Motorcode;
            }
            set
            {
                _Motorcode = value;
            }
        }

        /// <summary>
        /// Liefert die Motornummer
        /// </summary>
        [DataMember]
        public int Motornummer
        {
            get
            {
                return _MotorNummer;
            }
            set
            {
                _MotorNummer = value;
            }
        }

        /// <summary>
        /// Liefert die Größe des Hubraums in ccm
        /// </summary>
        [DataMember]
        public decimal Hubraum
        {
            get
            {
                return _Hubraum;
            }
            set
            {
                _Hubraum = value;
            }
        }

        /// <summary>
        /// Liefert die Leistung in kW
        /// </summary>
        [DataMember]
        public decimal LeistungKw
        {
            get
            {
                return _LeistungKw;
            }
            set
            {
                _LeistungKw = value;
            }
        }

        /// <summary>
        /// Liefert die Leistung in PS
        /// </summary>
        [DataMember]
        public decimal LeistungPs
        {
            get
            {
                return _LeistungPs;
            }
            set
            {
                _LeistungPs = value;
            }
        }

        /// <summary>
        /// Datum ab wann das Fahrzeug gebaut wurde
        /// </summary>
        [DataMember]
        public string GebautVon
        {
            get
            {
                return _GebautVon;
            }
            set
            {
                _GebautVon = value;
            }
        }

        /// <summary>
        /// Datum bis wann das Fahrzeug gebaut wurde
        /// </summary>
        [DataMember]
        public string GebautBis
        {
            get
            {
                return _GebautBis;
            }
            set
            {
                _GebautBis = value;
            }
        }

        /// <summary>
        /// Liefert Referenznummer des selektieren Fahzeug-Typs aus der TecDoc-DB
        /// </summary>
        [DataMember]
        public int KTypNummer
        {
            get
            {
                return _KTypNummer;
            }
            set
            {
                _KTypNummer = value;
            }
        }

        /// <summary>
        /// Liefert den Treibstofftyp
        /// </summary>
        [DataMember]
        public TreibstofTyp TreibstoffTyp
        {
            get
            {
                return _TreibstoffTyp;
            }
            set
            {
                _TreibstoffTyp = value;
            }
        }

        /// <summary>
        /// Liefert eine 36-stellige bit-Liste. Jede Position steht für eine Kategorie/Gruppen.
        /// z.B.: '11111110000010111100011000010110 000'
        /// </summary>
        [DataMember]
        public string Subjects
        {
            get
            {
                return _Subjects;
            }
            set
            {
                _Subjects = value;
            }
        }

        /// <summary>
        /// Gibt an, ob das Fahrzeug über einen EODB-Stecker verfügt.
        /// </summary>
        [DataMember]
        public bool HatEobd
        {
            get
            {
                return _HatEobd;
            }
            set
            {
                _HatEobd = value;
            }
        }

        /// <summary>
        /// Liefert die Hauptgruppen als 5-stellige bit-Liste. Jede Position steht für eine definierte Gruppe.
        /// z.B.: '11111'
        /// </summary>
        [DataMember]
        public string Hauptgruppen
        {
            get
            {
                return _Hauptgruppen;
            }
            set
            {
                _Hauptgruppen = value;
            }
        }

        /// <summary>
        /// Liefert die Untergruppen für die Hauptgruppe "Motor" als 10-stellige bit-Liste. Jede Position steht für eine definierte Gruppe.
        /// z.B.: '0010001111'
        /// </summary>
        [DataMember]
        public string UntergruppenMotor
        {
            get
            {
                return _UntergruppenMotor;
            }
            set
            {
                _UntergruppenMotor = value;
            }
        }

        /// <summary>
        /// Liefert die Untergruppen für die Hauptgruppe "Bremsen" als 10-stellige bit-Liste. Jede Position steht für eine definierte Gruppe.
        /// z.B.: '0010001111'
        /// </summary>
        [DataMember]
        public string UntergruppenBremsen
        {
            get
            {
                return _UntergruppenBremsen;
            }
            set
            {
                _UntergruppenBremsen = value;
            }
        }

        /// <summary>
        /// Liefert die Untergruppen für die Hauptgruppe "LenkungUndRadaufhaengung" als 10-stellige bit-Liste. Jede Position steht für eine definierte Gruppe.
        /// z.B.: '0010001111'
        /// </summary>
        [DataMember]
        public string UntergruppenLenkungUndRadaufhaengung
        {
            get
            {
                return _UntergruppenLenkungUndRadaufhaengung;
            }
            set
            {
                _UntergruppenLenkungUndRadaufhaengung = value;
            }
        }

        /// <summary>
        /// Liefert die Untergruppen für die Hauptgruppe "Getriebe" als 10-stellige bit-Liste. Jede Position steht für eine definierte Gruppe.
        /// z.B.: '0010001111'
        /// </summary>
        [DataMember]
        public string UntergruppenGetriebe
        {
            get
            {
                return _UntergruppenGetriebe;
            }
            set
            {
                _UntergruppenGetriebe = value;
            }
        }

        /// <summary>
        /// Liefert die Untergruppen für die Hauptgruppe "AussenseiteUndInnenraum" als 10-stellige bit-Liste. Jede Position steht für eine definierte Gruppe.
        /// z.B.: '0010001111'
        /// </summary>
        [DataMember]
        public string UntergruppenAussenseiteUndInnenraum
        {
            get
            {
                return _UntergruppenAussenseiteUndInnenraum;
            }
            set
            {
                _UntergruppenAussenseiteUndInnenraum = value;
            }
        }

        /// <summary>
        /// Liefert die Id für das System der techn. Zeichnungen
        /// </summary>
        [DataMember]
        public int TechnischeZeichnungSystemId
        {
            get
            {
                return _TechnischeZeichnungSystemId;
            }
            set
            {
                _TechnischeZeichnungSystemId = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------

        #region Property

        /// <summary>
        /// Gibt an, ob das Fahrzeug die neue Ansicht der Motoreinbaulage hat.
        /// Die 36. Position gibt den Wert an.
        /// </summary>
        public bool HatMotoreinbaulageNewStyle
        {
            get
            {
                if (Subjects.Length >= 36)
                {
                    string hatDiagnose = Subjects.Substring(35, 1);

                    if (hatDiagnose == "1")
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Gibt an, ob das Fahrzeug Diagnose hat.
        /// Die 9. oder 37. Position gibt den Wert an.
        /// </summary>
        public bool HatDiagnose
        {
            get
            {
                if (Subjects.Length >= 9)
                {
                    string hatDiagnose1 = Subjects.Substring(8, 1);
                    string hatDiagnose2 = Subjects.Substring(36, 1);

                    if (hatDiagnose1 == "1" || 
                        hatDiagnose2 == "1" )
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Gibt an, ob das Fahrzeug Infos über Sicherungen hat.
        /// Die 30. Position gibt den Wert an.
        /// </summary>
        public bool HatSicherungen
        {
            get
            {
                if (Subjects.Length >= 30)
                {
                    string hatSicherungen = Subjects.Substring(29, 1);

                    if (hatSicherungen == "1")
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Gibt an, ob das Fahrzeug Infos über Komfortelektronik hat.
        /// Die 14. Position gibt den Wert an.
        /// </summary>
        public bool HatKomfortElektronik
        {
            get
            {
                if (Subjects.Length >= 14)
                {
                    string hatKomfortElektronik = Subjects.Substring(13, 1);

                    if (hatKomfortElektronik == "1")
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Gibt an, ob das Fahrzeug Informationen über die Wartungsanzeige-Rückstellung hat.
        /// Die 26. Position gibt den Wert an.
        /// </summary>
        public bool HatWartungsanzeigeRueckstellung
        {
            get
            {
                if (Subjects.Length >= 26)
                {
                    string hatWartungsanzeigeRueckstellung = Subjects.Substring(25, 1);

                    if (hatWartungsanzeigeRueckstellung == "1")
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Gibt an, ob das Fahrzeug Wartungs-Zusatzinformationen hat.
        /// Die 32. Position gibt den Wert an.
        /// </summary>
        public bool HatWartungsZusatzinformationen
        {
            get
            {
                if (Subjects.Length >= 32)
                {
                    string hatWartungsZusatzinformationen = Subjects.Substring(31, 1);

                    if (hatWartungsZusatzinformationen == "1")
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        #endregion

        // --------------------------------------------------------------------------
    }
}