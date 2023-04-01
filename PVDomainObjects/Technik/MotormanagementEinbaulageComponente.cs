/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen einer MotormanagementEinbaulageComponente
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen einer MotormanagementEinbaulageComponente
    /// </summary>
    [DataContract]
    [Serializable] 
    public class MotormanagementEinbaulageComponente
    {
        #region Fields

        private int _MotormanagementEinbaulageComponenteId;
        private int _MotormanagementSystemId;
        private string _CompNummer;
        private string _CompBezeichnung;
        private int _BlobIdEinbaulage;
        private string _BezeichnungEinbaulage;

        #endregion

        // --------------------------------------------------------------------------

        #region MotormanagementEinbaulageComponente-Member

        /// <summary>
        /// Liefert Id der Componente
        /// </summary>
        [DataMember]
        public int MotormanagementEinbaulageComponenteId
        {
            get
            {
                return _MotormanagementEinbaulageComponenteId;
            }
            set
            {
                _MotormanagementEinbaulageComponenteId = value;
            }
        }

        /// <summary>
        /// Liefert die Id des MotormanagementSystems
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
        /// Liefert die Componentennummer
        /// </summary>
        [DataMember]
        public string CompNummer
        {
            get
            {
                return _CompNummer;
            }
            set
            {
                _CompNummer = value;
            }
        }

        /// <summary>
        /// Liefert die Bezeichnung der Componente
        /// </summary>
        [DataMember]
        public string CompBezeichnung
        {
            get
            {
                return _CompBezeichnung;
            }
            set
            {
                _CompBezeichnung = value;
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

        #endregion

        // --------------------------------------------------------------------------
    }
}
