/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Kapselt die Informationen und Funktionen einer Sicherung
 ***********************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen einer Sicherung
    /// </summary>
    [DataContract]
    [Serializable] 
    public class Sicherung
    {
        #region Fields

        private int _SicherungId;
        private EnumHauptgruppe.Hauptgruppe _Hauptgruppe;
        private int _SicherungskastenId;
        private string _Position;
        private string _CompBezeichnung;
        private string _Anmerkung;
        private string _Wert;
        private int _BlobIdLage;
        private int _BlobIdDetail;

        #endregion

        // --------------------------------------------------------------------------

        #region Sicherung-Member

        /// <summary>
        /// Liefert Id der Componente
        /// </summary>
        [DataMember]
        public int SicherungId
        {
            get
            {
                return _SicherungId;
            }
            set
            {
                _SicherungId = value;
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
        /// Liefert die Id des Sicherungskastens
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
        /// Liefert die Position
        /// </summary>
        [DataMember]
        public string Position
        {
            get
            {
                return _Position;
            }
            set
            {
                _Position = value;
            }
        }

        /// <summary>
        /// Liefert die ComponentenBezeichnung
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
        /// Liefert die Anmerkung zur ComponentenBezeichnung
        /// </summary>
        [DataMember]
        public string Anmerkung
        {
            get
            {
                return _Anmerkung;
            }
            set
            {
                _Anmerkung = value;
            }
        }

        /// <summary>
        /// Liefert den Wert
        /// </summary>
        [DataMember]
        public string Wert
        {
            get
            {
                return _Wert;
            }
            set
            {
                _Wert = value;
            }
        }

        /// <summary>
        /// Liefert die ID des Image für die Lage des Sicherungskastens
        /// </summary>
        [DataMember]
        public int BlobIdLage
        {
            get
            {
                return _BlobIdLage;
            }
            set
            {
                _BlobIdLage = value;
            }
        }

        /// <summary>
        /// Liefert die ID des Image für die Lage der Sicherung
        /// </summary>
        [DataMember]
        public int BlobIdDetail
        {
            get
            {
                return _BlobIdDetail;
            }
            set
            {
                _BlobIdDetail = value;
            }
        }

        #endregion

        // --------------------------------------------------------------------------
    }
}
