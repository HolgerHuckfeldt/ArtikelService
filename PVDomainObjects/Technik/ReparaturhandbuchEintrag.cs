/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen eines ReparaturhandbuchEintrags
 ************************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines ReparaturhandbuchEintrags
    /// </summary>
    [DataContract]
    [Serializable] 
    public class ReparaturhandbuchEintrag
    {
        #region Fields

        private int _ReparaturhandbuchEintragId;
        private EnumHauptgruppe.Hauptgruppe _Hauptgruppe;
        private int _ReparaturhandbuchId;
        private string _Gruppe;
        private string _Beschreibung;
        private string _Anmerkung;
        private int _BlobId;

        #endregion

        // --------------------------------------------------------------------------

        #region ReparaturhandbuchEintrag-Member

        /// <summary>
        /// Liefert Id des ReparaturhandbuchEintrags
        /// </summary>
        [DataMember]
        public int ReparaturhandbuchEintragId
        {
            get
            {
                return _ReparaturhandbuchEintragId;
            }
            set
            {
                _ReparaturhandbuchEintragId = value;
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
        /// Liefert die Id des Reparaturhandbuches
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
        /// Liefert den Namen der Grupppe
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
        /// Liefert die Anmerkung
        /// </summary>
        [DataMember]
        public string Anmerkung
        {
            get
            {
                return _Anmerkung;
            }
            set
            {
                _Anmerkung = value;
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

        [DataMember]
        public List<TableData> TableData { get; set; }

        [DataMember]
        public string TableName { get; set; }

        #endregion

        // --------------------------------------------------------------------------
    }
}
