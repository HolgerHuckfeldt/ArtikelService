/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen eines Blobs
 ************************************************************************************/

using System;
using System.IO;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Blobs
    /// </summary>
    [DataContract]
    [Serializable] 
    public class Blob
    {
        #region Fields

        private int _BlobId;
        private int _Breite;
        private int _Hoehe;
        private int _Seite;
        private string _DateiErweiterung;
        private string _DateiName;

        #endregion

        // --------------------------------------------------------------------------

        #region Blob-Member

        /// <summary>
        /// Liefert Id des Blobs
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
        /// Liefert die Breite
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
        /// Liefert die Höhe
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
        /// Liefert die Seite
        /// </summary>
        [DataMember]
        public int Seite
        {
            get
            {
                return _Seite;
            }
            set
            {
                _Seite = value;
            }
        }

        /// <summary>
        /// Liefert die Dateierweiterung
        /// </summary>
        [DataMember]
        public string DateiErweiterung
        {
            get
            {
                return _DateiErweiterung;
            }
            set
            {
                _DateiErweiterung = value;
            }
        }

        /// <summary>
        /// Liefert den Dateinamen
        /// </summary>
        [DataMember]
        public string DateiName
        {
            get
            {
                return _DateiName;
            }
            set
            {
                _DateiName = value;
            }
        }

        /// <summary>
        /// Die Uri für das Laden des Images im Frontend durch den ImageProvider.
        /// </summary>
        public string Uri
        {
            get
            {
                return "Technik/" + DateiName;
            }
        }

        #endregion

        // --------------------------------------------------------------------------
    }
}
