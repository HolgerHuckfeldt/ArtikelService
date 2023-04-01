/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen eines Schmiermittels
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Schmiermittels
    /// </summary>
    [DataContract]
    [Serializable] 
    public class Schmiermittel
    {

        #region Fields

        private int _SchmiermittelId;
        private EnumHauptgruppe.Hauptgruppe _Hauptgruppe;
        private string _Gruppe;
        private string _Bezeichnung;
        private string _Qualitaet;
        private string _Temperatur;
        private string _Viskositaet;
        private int _BlobId;
        private int _ReparaturhandbuchId;

        #endregion

        // --------------------------------------------------------------------------

        #region Schmiermittel-Member

        /// <summary>
        /// Liefert Id des Schmiermittels
        /// </summary>
        [DataMember]
        public int SchmiermittelId
        {
            get
            {
                return _SchmiermittelId;
            }
            set
            {
                _SchmiermittelId = value;
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
        /// Liefert den Namen der Gruppe
        /// </summary>
        [DataMember]
        public string Gruppe
        {
            get
            {
                return _Gruppe;
            }
            set
            {
                _Gruppe = value;
            }
        }

        /// <summary>
        /// Liefert den Namen des Schmiermittels
        /// </summary>
        [DataMember]
        public string Bezeichnung
        {
            get
            {
                return _Bezeichnung;
            }
            set
            {
                _Bezeichnung = value;
            }
        }

        /// <summary>
        /// Liefert die Qualität
        /// </summary>
        [DataMember]
        public string Qualitaet
        {
            get
            {
                return _Qualitaet;
            }
            set
            {
                _Qualitaet = value;
            }
        }

        /// <summary>
        /// Liefert die Temperatur
        /// </summary>
        [DataMember]
        public string Temperatur
        {
            get
            {
                return _Temperatur;
            }
            set
            {
                _Temperatur = value;
            }
        }

        /// <summary>
        /// Liefert die Viskosität
        /// </summary>
        [DataMember]
        public string Viskositaet
        {
            get
            {
                return _Viskositaet;
            }
            set
            {
                _Viskositaet = value;
            }
        }

        /// <summary>
        /// Liefert die Id des zugehörigen Blobs
        /// </summary>
        [DataMember]
        public int BlobId
        {
            get
            {
                return _BlobId;
            }
            set
            {
                _BlobId = value;
            }
        }

        /// <summary>
        /// Liefert Id zum Reparaturhandbuch für eine ZusatzInfo
        /// </summary>
        [DataMember]
        public int ReparaturhandbuchId
        {
            get
            {
                return _ReparaturhandbuchId;
            }
            set
            {
                _ReparaturhandbuchId = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------
    }
}
