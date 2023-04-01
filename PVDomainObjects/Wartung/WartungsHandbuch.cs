/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Wartung
 * Funktionen:  Kapselt die Informationen und Funktionen eines Wartungshandbuchs
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Wartung
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Wartungshandbuchs
    /// </summary>
    [DataContract]
    [Serializable]
    public class WartungsHandbuch
    {
        #region Fields

        private int _WartungsHandbuchId;
        private string _Bezeichnung;
        private string _ZusatzBezeichnung;
        private int _BlobId;

        #endregion

        // --------------------------------------------------------------------------

        #region WartungsHandbuch-Member

        /// <summary>
        /// Liefert Id des WartungsHandbuch
        /// </summary>
        [DataMember]
        public int WartungsHandbuchId
        {
            get
            {
                return _WartungsHandbuchId;
            }
            set
            {
                _WartungsHandbuchId = value;
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
        /// Liefert die ZusatzBezeichnung
        /// </summary>
        [DataMember]
        public string ZusatzBezeichnung
        {
            get
            {
                return _ZusatzBezeichnung;
            }
            set
            {
                _ZusatzBezeichnung = value;
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
