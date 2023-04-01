/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen eines DiagnoseCodes
 ***********************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [Serializable] 
    public class DiagnoseCode
    {
        #region Fields

        private int _DiagnoseCodeId;
        private int _HerstellerId;
        private string _Code;
        private string _Beschreibung;

        #endregion

        // --------------------------------------------------------------------------

        #region DiagnoseCode-Member

        /// <summary>
        /// Liefert Id des DiagnoseCodes
        /// </summary>
        [DataMember]
        public int DiagnoseCodeId
        {
            get
            {
                return _DiagnoseCodeId;
            }
            set
            {
                _DiagnoseCodeId = value;
            }
        }

        /// <summary>
        /// Liefert die ID des Herstellers
        /// </summary>
        [DataMember]
        public int HerstellerId
        {
            get
            {
                return _HerstellerId;
            }
            set
            {
                _HerstellerId = value;
            }
        }

        /// <summary>
        /// Liefert den DiagnoseCode
        /// </summary>
        [DataMember]
        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
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

        #endregion

        // --------------------------------------------------------------------------
    }
}
