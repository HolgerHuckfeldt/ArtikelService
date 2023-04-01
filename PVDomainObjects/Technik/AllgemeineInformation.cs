/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen einer Allgemeinen Information
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen einer Allgemeinen Information
    /// </summary>
    [DataContract]
    [Serializable]
    public class AllgemeineInformation
    {
        #region Fields

        private EnumHauptgruppe.Hauptgruppe _Hauptgruppe;
        private string _Bezeichnung;
        private string _Html;

        #endregion

        // --------------------------------------------------------------------------

        #region AllgemeineInformation-Member

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
        /// Liefert die Bezichnung
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
        /// Liefert den Dateinamen für das anzuzeigende Html
        /// </summary>
        [DataMember]
        public string Html
        {
            get
            {
                return _Html;
            }
            set
            {
                _Html = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------
    }
}
