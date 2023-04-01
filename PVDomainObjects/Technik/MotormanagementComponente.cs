/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen einer MotormanagementComponente
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen einer MotormanagementComponente
    /// </summary>
    [DataContract]
    [Serializable]
    public class MotormanagementComponente
    {
        #region Fields

        private int _MotormanagementComponenteId;
        private EnumHauptgruppe.Hauptgruppe _Hauptgruppe;
        private int _MotormanagementSystemId;
        private int _CompNummer;
        private string _CompBezeichnung;
        private string _CompFunktion;
        private string _CompSpezifikation;
        private string _CompOszilloskop1;
        private string _CompOszilloskop2;
        private string _CompDiagnose;
        private bool _BeschreibungVorhanden;
        private string _ZusatzInfoHtml;
        private int _SchaltplanPosX;
        private int _SchaltplanPosY;
        private int _Hoehe;
        private int _Breite;
        private int _EinbaulagePosX;
        private int _EinbaulagePosY;
        private string _EinbaulagePfeilRichtung;
        private string _EinbaulagePfeilText;
        private int _BlobIdFunktion;
        private int _BlobIdOszilloskop1;
        private int _BlobIdOszilloskop2;

        #endregion

        // --------------------------------------------------------------------------

        #region MotormanagementComponente-Member

        /// <summary>
        /// Liefert Id der Componente
        /// </summary>
        [DataMember]
        public int MotormanagementComponenteId
        {
            get
            {
                return _MotormanagementComponenteId;
            }
            set
            {
                _MotormanagementComponenteId = value;
            }
        }

        /// <summary>
        /// Liefert die Hauptgruppe
        /// </summary>
        [DataMember]
        public EnumHauptgruppe.Hauptgruppe Hauptgruppe
        {
            get
            {
                return _Hauptgruppe;
            }
            set
            {
                _Hauptgruppe = value;
            }
        }

        /// <summary>
        /// Liefert die Id des MotormanagementSystems
        /// </summary>
        [DataMember]
        public int MotormanagementSystemId
        {
            get
            {
                return _MotormanagementSystemId;
            }
            set
            {
                _MotormanagementSystemId = value;
            }
        }

        /// <summary>
        /// Liefert die Componentennummer
        /// </summary>
        [DataMember]
        public int CompNummer
        {
            get
            {
                return _CompNummer;
            }
            set
            {
                _CompNummer = value;
            }
        }

        /// <summary>
        /// Liefert die Bezeichnung der Componente
        /// </summary>
        [DataMember]
        public string CompBezeichnung
        {
            get
            {
                return _CompBezeichnung;
            }
            set
            {
                _CompBezeichnung = value;
            }
        }

        /// <summary>
        /// Liefert die Beschreibung der Componente
        /// </summary>
        [DataMember]
        public string CompFunktion
        {
            get
            {
                return _CompFunktion;
            }
            set
            {
                _CompFunktion = value;
            }
        }

        /// <summary>
        /// Liefert die Spezifikation zur Componente
        /// </summary>
        [DataMember]
        public string CompSpezifikation
        {
            get
            {
                return _CompSpezifikation;
            }
            set
            {
                _CompSpezifikation = value;
            }
        }

        /// <summary>
        /// Liefert die Beschreibung für Oszilloskop1
        /// </summary>
        [DataMember]
        public string CompOszilloskop1
        {
            get
            {
                return _CompOszilloskop1;
            }
            set
            {
                _CompOszilloskop1 = value;
            }
        }


        /// <summary>
        /// Liefert die Beschreibung für Oszilloskop2
        /// </summary>
        [DataMember]
        public string CompOszilloskop2
        {
            get
            {
                return _CompOszilloskop2;
            }
            set
            {
                _CompOszilloskop2 = value;
            }
        }

        /// <summary>
        /// Liefert die Diagnose zur Componente
        /// </summary>
        [DataMember]
        public string CompDiagnose
        {
            get
            {
                return _CompDiagnose;
            }
            set
            {
                _CompDiagnose = value;
            }
        }

        /// <summary>
        /// Gibt an, ob eine Beschreibung vorhanden sind
        /// </summary>
        [DataMember]
        public bool BeschreibungVorhanden
        {
            get
            {
                return _BeschreibungVorhanden;
            }
            set
            {
                _BeschreibungVorhanden = value;
            }
        }

        /// <summary>
        /// Gibt an, ob zusätzliche Informationen als XML vorhanden sind
        /// </summary>
        public bool ZusatzInfoVorhanden
        {
            get
            {
                return !string.IsNullOrEmpty(ZusatzInfoHtml);
            }
        }

        /// <summary>
        /// Gibt den Dateinamen für die HTML der Zusatzinfo an
        /// </summary>
        [DataMember]
        public string ZusatzInfoHtml
        {
            get
            {
                return _ZusatzInfoHtml;
            }
            set
            {
                _ZusatzInfoHtml = value;
            }
        }

        /// <summary>
        /// Liefert die x-Position im Image "Schaltplan"
        /// </summary>
        [DataMember]
        public int SchaltplanPosX
        {
            get
            {
                return _SchaltplanPosX;
            }
            set
            {
                _SchaltplanPosX = value;
            }
        }

        /// <summary>
        /// Liefert die y-Position im Image "Schaltplan"
        /// </summary>
        [DataMember]
        public int SchaltplanPosY
        {
            get
            {
                return _SchaltplanPosY;
            }
            set
            {
                _SchaltplanPosY = value;
            }
        }

        /// <summary>
        /// Liefert die Höhe im Image
        /// </summary>
        [DataMember]
        public int Hoehe
        {
            get
            {
                return _Hoehe;
            }
            set
            {
                _Hoehe = value;
            }
        }

        /// <summary>
        /// Liefert die Breite im Image
        /// </summary>
        [DataMember]
        public int Breite
        {
            get
            {
                return _Breite;
            }
            set
            {
                _Breite = value;
            }
        }

        /// <summary>
        /// Liefert die x-Position im Image "Einbaulage"
        /// </summary>
        [DataMember]
        public int EinbaulagePosX
        {
            get
            {
                return _EinbaulagePosX;
            }
            set
            {
                _EinbaulagePosX = value;
            }
        }

        /// <summary>
        /// Liefert die y-Position im Image "Einbaulage"
        /// </summary>
        [DataMember]
        public int EinbaulagePosY
        {
            get
            {
                return _EinbaulagePosY;
            }
            set
            {
                _EinbaulagePosY = value;
            }
        }

        /// <summary>
        /// Liefert die Pfeilrichtung im Image "Einbaulage"
        /// </summary>
        [DataMember]
        public string EinbaulagePfeilRichtung
        {
            get
            {
                return _EinbaulagePfeilRichtung;
            }
            set
            {
                _EinbaulagePfeilRichtung = value;
            }
        }

        /// <summary>
        /// Liefert den Text für eine Pfeilposition im Image "Einbaulage"
        /// </summary>
        [DataMember]
        public string EinbaulagePfeilText
        {
            get
            {
                return _EinbaulagePfeilText;
            }
            set
            {
                _EinbaulagePfeilText = value;
            }
        }

        /// <summary>
        /// Liefert die Id des Image für die Beschreibung der Funktion
        /// </summary>
        [DataMember]
        public int BlobIdFunktion
        {
            get
            {
                return _BlobIdFunktion;
            }
            set
            {
                _BlobIdFunktion = value;
            }
        }

        /// <summary>
        /// Liefert die Id des Image für dei Beschreibung des Oszilloskop 1
        /// </summary>
        [DataMember]
        public int BlobIdOszilloskop1
        {
            get
            {
                return _BlobIdOszilloskop1;
            }
            set
            {
                _BlobIdOszilloskop1 = value;
            }
        }

        /// <summary>
        /// Liefert die Id des Image für dei Beschreibung des Oszilloskop 2
        /// </summary>
        [DataMember]
        public int BlobIdOszilloskop2
        {
            get
            {
                return _BlobIdOszilloskop2;
            }
            set
            {
                _BlobIdOszilloskop2 = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------
    }
}