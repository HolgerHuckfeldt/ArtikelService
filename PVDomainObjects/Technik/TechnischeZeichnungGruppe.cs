/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen einer tech. Zeichnunggruppe
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen einer tech. Zeichnunggruppe
    /// </summary>
    [DataContract]
    [Serializable] 
    public class TechnischeZeichnungGruppe
    {
        #region Fields

        private int _TechnischeZeichnungGruppeId;
        private EnumHauptgruppe.Hauptgruppe _Hauptgruppe;
        private EnumUntergruppe.Untergruppe _Untergruppe;
        private string _Bezeichnung;
        private int _BlobId;

        #endregion

        // --------------------------------------------------------------------------

        #region TechnischeZeichnungGruppe-Member

        /// <summary>
        /// Liefert Id der tech. Zeichnunggruppe
        /// </summary>
        [DataMember]
        public int TechnischeZeichnungGruppeId
        {
            get
            {
                return _TechnischeZeichnungGruppeId;
            }
            set
            {
                _TechnischeZeichnungGruppeId = value;
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
        /// Liefert die Bezeichnung für die tech. Zeichnung
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
        /// Liefert die Id des Images für die tech. Zeichnung
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
