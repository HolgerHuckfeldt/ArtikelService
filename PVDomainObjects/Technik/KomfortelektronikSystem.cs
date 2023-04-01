/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen eines KomfortelektronikSystems
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines KomfortelektronikSystems
    /// </summary>
    [DataContract]
    [Serializable] 
    public class KomfortelektronikSystem
    {
        #region Fields

        private int _KomfortelektronikSystemId;
        private int _OptionId;
        private int _SystemTypeId;
        private EnumHauptgruppe.Hauptgruppe _Hauptgruppe;
        private string _Bezeichnung;
        private string _SubBezeichnung;

        #endregion

        // --------------------------------------------------------------------------

        #region KomfortelektronikFahrzeug-Member

        /// <summary>
        /// Liefert Id des Systems
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
        /// Liefert Id des Systems
        /// </summary>
        [DataMember]
        public int SystemTypeId
        {
            get
            {
                return _SystemTypeId;
            }
            set
            {
                _SystemTypeId = value;
            }
        }

        /// <summary>
        /// Liefert Id der Systemoption
        /// </summary>
        [DataMember]
        public int OptionId
        {
            get
            {
                return _OptionId;
            }
            set
            {
                _OptionId = value;
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
        /// Liefert die SubBezeichnung
        /// </summary>
        [DataMember]
        public string SubBezeichnung
        {
            get
            {
                return _SubBezeichnung;
            }
            set
            {
                _SubBezeichnung = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (string.IsNullOrEmpty(SubBezeichnung.Trim()))
            {
                return Bezeichnung.Trim();
            }else
            {
                return Bezeichnung.Trim() + ", " + SubBezeichnung.Trim();
            }

        }//end function
    }
}
