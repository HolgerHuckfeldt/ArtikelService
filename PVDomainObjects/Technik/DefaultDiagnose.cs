/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen der DefaultDiagnose
 ***********************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Einstelldatums
    /// </summary>
    [DataContract]
    [Serializable]
    public class DefaultDiagnose
    {
        #region Fields

        private int _DefaultDiagnoseId;
        private EnumHauptgruppe.Hauptgruppe _Hauptgruppe;
        private string _GruppeAuslesen;
        private string _GruppeZuruecksetzten;
        private string _GruppeSignal;
        private int _BlobId;

        #endregion

        // --------------------------------------------------------------------------

        #region Einstelldatum-Member

        /// <summary>
        /// Liefert Id der DefaultDiagnose
        /// </summary>
        [DataMember]
        public int DefaultDiagnoseId
        {
            get
            {
                return _DefaultDiagnoseId;
            }
            set
            {
                _DefaultDiagnoseId = value;
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
        /// Liefert Daten für die Gruppe "Auslesen"
        /// </summary>
        [DataMember]
        public string GruppeAuslesen
        {
            get
            {
                return _GruppeAuslesen;
            }
            set
            {
                _GruppeAuslesen = value;
            }
        }

        /// <summary>
        /// Liefert Daten für die Gruppe "Zuruecksetzten"
        /// </summary>
        [DataMember]
        public string GruppeZuruecksetzten
        {
            get
            {
                return _GruppeZuruecksetzten;
            }
            set
            {
                _GruppeZuruecksetzten = value;
            }
        }

        /// <summary>
        /// Liefert Daten für die Gruppe "Signal"
        /// </summary>
        [DataMember]
        public string GruppeSignal
        {
            get
            {
                return _GruppeSignal;
            }
            set
            {
                _GruppeSignal = value;
            }
        }

        /// <summary>
        /// Liefert Id für das Image
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
