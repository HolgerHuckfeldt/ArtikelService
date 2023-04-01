/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Wartung
 * Funktionen:  Kapselt die Informationen und Funktionen einer WartungsCheckliste
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Wartung
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen einer WartungsCheckliste
    /// </summary>
    [DataContract]
    [Serializable]
    public class TechnikLink
    {
        #region Fields

        private int _TechnikLinkId;
        private WartungsChecklisteItem.TechnikLinkTyp _TechnikLinkTyp;
        private int _ReferenzId;
        private string _MainGroup;

        #endregion

        // --------------------------------------------------------------------------

        #region WartungsCheckliste-Member

        /// <summary>
        /// Liefert Id der TechnikLink
        /// </summary>
        [DataMember]
        public int TechnikLinkId
        {
            get
            {
                return _TechnikLinkId;
            }
            set
            {
                _TechnikLinkId = value;
            }
        }

        /// <summary>
        /// Liefert den TechnikLinkTyp
        /// </summary>
        [DataMember]
        public WartungsChecklisteItem.TechnikLinkTyp TechnikLinkTyp
        {
            get
            {
                return _TechnikLinkTyp;
            }
            set
            {
                _TechnikLinkTyp = value;
            }
        }

        /// <summary>
        /// Liefert Id des Referenzobjekts
        /// </summary>
        [DataMember]
        public int ReferenzId
        {
            get
            {
                return _ReferenzId;
            }
            set
            {
                _ReferenzId = value;
            }
        }

        /// <summary>
        /// Liefert die Hauptgruppe
        /// </summary>
        [DataMember]
        public string MainGroup
        {
            get
            {
                return _MainGroup;
            }
            set
            {
                _MainGroup = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------
    }
}
