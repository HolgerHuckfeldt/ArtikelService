/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen eines KomfortelektronikComponente
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines KomfortelektronikComponente
    /// </summary>
    [DataContract]
    [Serializable]
    public class KomfortelektronikComponente
    {
        #region Fields

        private string _komfortelektronikComponenteId;
        private EnumHauptgruppe.Hauptgruppe _hauptgruppe;
        private int _komfortelektronikSystemId;
        private int _symbolId;
        private string _seitenZahl;
        private string _bezeichnung;

        #endregion

        // --------------------------------------------------------------------------

        #region KomfortelektronikComponente-Member

        /// <summary>
        /// Liefert Id der Componente
        /// </summary>
        [DataMember]
        public string KomfortelektronikComponenteId
        {
            get
            {
                return _komfortelektronikComponenteId;
            }
            set
            {
                _komfortelektronikComponenteId = value;
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
                return _hauptgruppe;
            }
            set
            {
                _hauptgruppe = value;
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
                return _komfortelektronikSystemId;
            }
            set
            {
                _komfortelektronikSystemId = value;
            }
        }

        /// <summary>
        /// Liefert die Id es Symbols
        /// </summary>
        [DataMember]
        public int SymbolId
        {
            get
            {
                return _symbolId;
            }
            set
            {
                _symbolId = value;
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
                return _seitenZahl;
            }
            set
            {
                _seitenZahl = value;
            }
        }

        /// <summary>
        /// Liefert die Bezeichnung der Componenete
        /// </summary>
        [DataMember]
        public string Bezeichnung
        {
            get
            {
                return _bezeichnung;
            }
            set
            {
                _bezeichnung = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------
    }
}
