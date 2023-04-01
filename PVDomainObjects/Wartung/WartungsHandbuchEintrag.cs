/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Wartung
 * Funktionen:  Kapselt die Informationen und Funktionen eines WartungshandbuchEintrags
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Wartung
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines WartungshandbuchEintrags
    /// </summary>
    [DataContract]
    [Serializable]
    public class WartungsHandbuchEintrag
    {
        #region Fields

        private int _WartungsHandbuchEintragId;
        private int _WartungsHandbuchId;
        private string _Gruppe;
        private string _Beschreibung;
        private string _Anmerkung;
        private int _BlobId;

        #endregion

        // --------------------------------------------------------------------------

        #region WartungsHandbuchEintrag-Member

        /// <summary>
        /// Liefert Id des WartungshandbuchEintrags
        /// </summary>
        [DataMember]
        public int WartungsHandbuchEintragId
        {
            get
            {
                return _WartungsHandbuchEintragId;
            }
            set
            {
                _WartungsHandbuchEintragId = value;
            }
        }

        /// <summary>
        /// Liefert die Id des Wartungshandbuchs
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

        #endregion

        // --------------------------------------------------------------------------
    }
}
