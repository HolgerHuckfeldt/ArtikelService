/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Wartung
 * Funktionen:  Kapselt die Informationen und Funktionen einer WartungsChecklistePeriode
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Wartung
{
    [DataContract]
    [Serializable]
    public enum PeriodenTyp
    {
        [EnumMember]
        NICHT_RELEVANT = 0,
        [EnumMember]
        CHECKLISTE = 1,
        [EnumMember]
        SPEZIAL_ANBEBOT = 2,
        [EnumMember]
        STEUERRIEMENINTERVALL = 3,
    }

    /// <summary>
    /// Kapselt die Informationen und Funktionen einer WartungsChecklistePeriode
    /// </summary>
    [DataContract]
    [Serializable] 
    public class WartungsChecklistePeriode
    {
        #region Fields

        private int _WartungsChecklistePeriodeId;
        private int _WartungsChecklisteId;
        private PeriodenTyp _PeriodenTyp;
        private string _Bezeichnung;

        #endregion

        // --------------------------------------------------------------------------

        #region WartungsChecklistePeriode-Member

        /// <summary>
        /// Liefert Id der WartungsChecklistePeriode
        /// </summary>
        [DataMember]
        public int WartungsChecklistePeriodeId
        {
            get
            {
                return _WartungsChecklistePeriodeId;
            }
            set
            {
                _WartungsChecklistePeriodeId = value;
            }
        }

        /// <summary>
        /// Liefert die Id der WartungsCheckliste
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
        /// Liefert den PeriodenTypen
        /// </summary>
        [DataMember]
        public PeriodenTyp PeriodenTyp
        {
            get
            {
                return _PeriodenTyp;
            }
            set
            {
                _PeriodenTyp = value;
            }
        }

        /// <summary>
        /// Liefert die Bezeichnung für dei Periode
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
