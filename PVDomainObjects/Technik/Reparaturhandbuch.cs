/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen eines Reparaturhandbuchs
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Reparaturhandbuchs
    /// </summary>
    [DataContract]
    [Serializable] 
    public class Reparaturhandbuch
    {
        #region Fields

        private int _ReparaturhandbuchId;
        private EnumHauptgruppe.Hauptgruppe _Hauptgruppe;
        private EnumUntergruppe.Untergruppe _Untergruppe;
        private string _Bezeichnung;
        private int _BlobId;

        #endregion

        // --------------------------------------------------------------------------

        #region Reparaturhandbuch-Member

        /// <summary>
        /// Liefert Id des Reparaturhandbuches
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
        /// Liefert die Untergruppe
        /// </summary>
        [DataMember]
        public EnumUntergruppe.Untergruppe Untergruppe
        {
            get
            {
                return _Untergruppe;
            }
            set
            {
                _Untergruppe = value;
            }
        }

        /// <summary>
        /// Liefert die Bezeichnung
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

        #endregion

        // --------------------------------------------------------------------------
    }
}
