/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen einer MotormanagementSystem
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen einer MotormanagementSystem
    /// </summary>
    [DataContract]
    [Serializable] 
    public class MotormanagementSystem
    {
        #region Fields

        private int _MotormanagementSystemId;
        private EnumHauptgruppe.Hauptgruppe _Hauptgruppe;
        private EnumUntergruppe.Untergruppe _Untergruppe;
        private string _Bezeichnung;
        private string _BezeichnungEinbaulage;
        private int _BlobIdSchaltplan;
        private int _BlobIdEinbaulage;
        private int _ErrorcodeId;

        #endregion

        // --------------------------------------------------------------------------

        #region MotormanagementSystem-Member

        /// <summary>
        /// Liefert Id des Systems
        /// </summary>
        [DataMember]
        public int MotormanagementSystemId
        {
            get
            {
                return _MotormanagementSystemId;
            }
            set
            {
                _MotormanagementSystemId = value;
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
        /// Liefert die Bezeichnung für die Einbaulage
        /// </summary>
        [DataMember]
        public string BezeichnungEinbaulage
        {
            get
            {
                return _BezeichnungEinbaulage;
            }
            set
            {
                _BezeichnungEinbaulage = value;
            }
        }

        /// <summary>
        /// Liefert die Id des Images für den Schaltplan
        /// </summary>
        [DataMember]
        public int BlobIdSchaltplan
        {
            get
            {
                return _BlobIdSchaltplan;
            }
            set
            {
                _BlobIdSchaltplan = value;
            }
        }

        /// <summary>
        /// Liefert die Id des Images für die Einbaulage
        /// </summary>
        [DataMember]
        public int BlobIdEinbaulage
        {
            get
            {
                return _BlobIdEinbaulage;
            }
            set
            {
                _BlobIdEinbaulage = value;
            }
        }

        /// <summary>
        /// Liefert die Id der Standard-Diagnose-Anzeige
        /// </summary>
        [DataMember]
        public int ErrorcodeId
        {
            get
            {
                return _ErrorcodeId;
            }
            set
            {
                _ErrorcodeId = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------
    }
}
