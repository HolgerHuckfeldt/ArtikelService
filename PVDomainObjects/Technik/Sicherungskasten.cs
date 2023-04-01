/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen eines Sicherungskastens
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Sicherungskastens
    /// </summary>
    [DataContract]
    [Serializable] 
    public class Sicherungskasten
    {
        #region Fields

        private int _SicherungskastenId;
        private EnumHauptgruppe.Hauptgruppe _Hauptgruppe;
        private EnumUntergruppe.Untergruppe _Untergruppe;
        private string _Bezeichnung;
        private string _Lenkposition;

        #endregion

        // --------------------------------------------------------------------------

        #region Sicherungskasten-Member

        /// <summary>
        /// Liefert Id des Sicherungskastens
        /// </summary>
        [DataMember]
        public int SicherungskastenId
        {
            get
            {
                return _SicherungskastenId;
            }
            set
            {
                _SicherungskastenId = value;
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
        /// Liefert die Untergruppe
        /// </summary>
        [DataMember]
        public EnumUntergruppe.Untergruppe Untergruppe
        {
            get
            {
                return _Untergruppe;
            }
            set
            {
                _Untergruppe = value;
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
        /// Liefert die Lenkposition
        /// </summary>
        [DataMember]
        public string Lenkposition
        {
            get
            {
                return _Lenkposition;
            }
            set
            {
                _Lenkposition = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------
    }
}
