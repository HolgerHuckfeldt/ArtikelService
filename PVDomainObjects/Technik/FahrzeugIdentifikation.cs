/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen einer FahrzeugIdentifikation
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen einer FahrzeugIdentifikation
    /// </summary>
    [DataContract]
    [Serializable] public class FahrzeugIdentifikation
    {
        #region Fields

        private int _FahrzeugIdentifikationId;
        private int _KTypNr;
        private string _Praefix;
        private string _Beschreibung;
        private string _Wert;
        private int _BlobIdAllgemein;
        private int _BlobIdMotor;
        private int _BlobIdGetriebe;

        #endregion

        // --------------------------------------------------------------------------

        #region FahrzeugIdentifikation-Member

        /// <summary>
        /// Liefert die Id der FahrzeugIdentifikation
        /// </summary>
        [DataMember]
        public int FahrzeugIdentifikationId
        {
            get
            {
                return _FahrzeugIdentifikationId;
            }
            set
            {
                _FahrzeugIdentifikationId = value;
            }
        }

        /// <summary>
        /// Liefert die Id der Fahrzeugtyps aus der TecDoc-Datenbank
        /// </summary>
        [DataMember]
        public int KTypNr
        {
            get
            {
                return _KTypNr;
            }
            set
            {
                _KTypNr = value;
            }
        }

        /// <summary>
        /// Liefert den Präfix für die Beschreibung
        /// </summary>
        [DataMember]
        public string Praefix
        {
            get
            {
                return _Praefix;
            }
            set
            {
                _Praefix = value;
            }
        }

        /// <summary>
        /// Liefert die Beschreibung
        /// </summary>
        [DataMember]
        public string Beschreibung
        {
            get
            {
                return _Beschreibung;
            }
            set
            {
                _Beschreibung = value;
            }
        }

        /// <summary>
        /// Liefert den Wert für die Beschreibung
        /// </summary>
        [DataMember]
        public string Wert
        {
            get
            {
                return _Wert;
            }
            set
            {
                _Wert = value;
            }
        }

        /// <summary>
        /// Liefert die Id der Image-Infos für Allgemeines
        /// </summary>
        [DataMember]
        public int BlobIdAllgemein
        {
            get
            {
                return _BlobIdAllgemein;
            }
            set
            {
                _BlobIdAllgemein = value;
            }
        }

        /// <summary>
        /// Liefert die Id der Image-Infos für den Motor
        /// </summary>
        [DataMember]
        public int BlobIdMotor
        {
            get
            {
                return _BlobIdMotor;
            }
            set
            {
                _BlobIdMotor = value;
            }
        }

        /// <summary>
        /// Liefert die Id der Image-Infos für das Getriebe
        /// </summary>
        [DataMember]
        public int BlobIdGetriebe
        {
            get
            {
                return _BlobIdGetriebe;
            }
            set
            {
                _BlobIdGetriebe = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------
    }
}
