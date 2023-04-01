/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen eines KomfortelektronikSchaltplans
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines KomfortelektronikSchaltplans
    /// </summary>
    [DataContract]
    [Serializable] 
    public class KomfortelektronikSchaltplan
    {
        #region Fields

        private int _KomfortelektronikSchaltplanId;
        private EnumHauptgruppe.Hauptgruppe _Hauptgruppe;
        private int _KomfortelektronikSystemId;
        private string _SeitenZahl;
        private string _Blob;

        #endregion

        // --------------------------------------------------------------------------

        #region KomfortelektronikSchaltplan-Member

        /// <summary>
        /// Liefert Id des Schaltplans
        /// </summary>
        [DataMember]
        public int KomfortelektronikSchaltplanId
        {
            get
            {
                return _KomfortelektronikSchaltplanId;
            }
            set
            {
                _KomfortelektronikSchaltplanId = value;
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
        /// Liefert die Id es Komfortelektronik-Systems
        /// </summary>
        [DataMember]
        public int KomfortelektronikSystemId
        {
            get
            {
                return _KomfortelektronikSystemId;
            }
            set
            {
                _KomfortelektronikSystemId = value;
            }
        }

        /// <summary>
        /// Liefert die Seitenzahl
        /// </summary>
        [DataMember]
        public string SeitenZahl
        {
            get
            {
                return _SeitenZahl;
            }
            set
            {
                _SeitenZahl = value;
            }
        }

        /// <summary>
        /// Liefert das Blob
        /// </summary>
        [DataMember]
        public string Blob
        {
            get
            {
                return _Blob;
            }
            set
            {
                _Blob = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------
    }
}
