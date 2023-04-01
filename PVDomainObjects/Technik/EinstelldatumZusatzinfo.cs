/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen einer EinstelldatumZusatzinfo
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen einer EinstelldatumZusatzinfo
    /// </summary>
    [DataContract]
    [Serializable] 
    public class EinstelldatumZusatzinfo
    {
        #region Fields

        private int _EinstelldatumZusatzinfoId;
        private int _ReparaturhandbuchId;
        private string _Gruppe;
        private string _Beschreibung;
        private string _Anmerkung;
        private int _BlobIdMain;
        private int _BlobIdDetail;

        #endregion

        // --------------------------------------------------------------------------

        #region EinstelldatumZusatzinfo-Member

        /// <summary>
        /// Liefert Id der EinstelldatumZusatzinfo
        /// </summary>
        [DataMember]
        public int EinstelldatumZusatzinfoId
        {
            get
            {
                return _EinstelldatumZusatzinfoId;
            }
            set
            {
                _EinstelldatumZusatzinfoId = value;
            }
        }

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

        [DataMember]
        public List<TableData> TableData { get; set; }

        [DataMember]
        public string TableName { get; set; }

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
        public int BlobIdMain
        {
            get
            {
                return _BlobIdMain;
            }
            set
            {
                _BlobIdMain = value;
            }
        }

        /// <summary>
        /// Liefert die Id des zugehörigen Blobs
        /// </summary>
        [DataMember]
        public int BlobIdDetail
        {
            get
            {
                return _BlobIdDetail;
            }
            set
            {
                _BlobIdDetail = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------
    }
}
