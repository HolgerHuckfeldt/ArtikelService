/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen eines Einstelldatums
 ***********************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Einstelldatums
    /// </summary>
    [DataContract]
    [Serializable] 
    public class Einstelldatum
    {
        #region Fields

        private int _EinstelldatumId;
        private EnumHauptgruppe.Hauptgruppe _Hauptgruppe;
        private string _Gruppe;
        private string _Bezeichnung;
        private string _ZusatzNotiz;
        private string _Wert;
        private string _Einheit;
        private int _ReparaturhandbuchId;
        private bool _IstAuWert;
        private int _BlobId;
        private bool _isSubSentence;

        #endregion

        // --------------------------------------------------------------------------

        #region Einstelldatum-Member

        /// <summary>
        /// Liefert Id des Einstelldatums
        /// </summary>
        [DataMember]
        public int EinstelldatumId
        {
            get
            {
                return _EinstelldatumId;
            }
            set
            {
                _EinstelldatumId = value;
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
        /// Liefert den Namen des Einstelldatums
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
        /// Liefert eine Zusatznotiz zum Einstelldatums
        /// </summary>
        [DataMember]
        public string ZusatzNotiz
        {
            get
            {
                return _ZusatzNotiz;
            }
            set
            {
                _ZusatzNotiz = value;
            }
        }

        /// <summary>
        /// Liefert den Wert
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
        /// Liefert die Einheit
        /// </summary>
        [DataMember]
        public string Einheit
        {
            get
            {
                return _Einheit;
            }
            set
            {
                _Einheit = value;
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

        /// <summary>
        /// Gibt an, ob das Einstelldatum ein AU-Wert ist
        /// </summary>
        [DataMember]
        public bool IstAuWert
        {
            get
            {
                return _IstAuWert;
            }
            set
            {
                _IstAuWert = value;
            }
        }

        /// <summary>
        /// Liefert Id für das Image
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
        /// Liefert das SubSentence
        /// </summary>
        [DataMember]
        public bool SubSentence
        {
            get
            {
                return _isSubSentence;
            }
            set
            {
                _isSubSentence = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------
    }
}
