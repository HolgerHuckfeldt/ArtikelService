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
    public class WartungsCheckliste
    {
        #region Fields

        private int _WartungsChecklisteId;
        private string _Bezeichnung;

        #endregion

        // --------------------------------------------------------------------------

        #region WartungsCheckliste-Member

        /// <summary>
        /// Liefert Id der WartungsCheckliste
        /// </summary>
        [DataMember]
        public int WartungsChecklisteId
        {
            get
            {
                return _WartungsChecklisteId;
            }
            set
            {
                _WartungsChecklisteId = value;
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

        #endregion

        // --------------------------------------------------------------------------
    }
}
