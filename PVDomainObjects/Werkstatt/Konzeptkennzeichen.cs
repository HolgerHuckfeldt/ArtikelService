/***************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Stammdatenverwaltung
 * Funktionen:  Kapselt die Informationen, welche PV im Konzeptkennzeichen zusammenfasst.
 **************************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Stammdaten
{
    /// <summary>
    /// Kapselt die Informationen, welche PV im Konzeptkennzeichen zusammenfasst.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Konzeptkennzeichen
    {
        #region Fields

        private string _KonzeptKzBezeichnung = string.Empty;
        private string _StatusKundenkonzept = string.Empty;

        #endregion

        private int _konzeptKzID;

        /// <summary>
        /// Liefert und setzt die ID des Konzeptkennzeichens
        /// </summary>
        [DataMember]
        public int KonzeptKzID
        {
            get { return _konzeptKzID; }
            set { _konzeptKzID = value; }
        }

        /// <summary>
        /// Liefert und setzt die Bezeichnung des Konzeptkennzeichens
        /// </summary>
        [DataMember]
        public string KonzeptKzBezeichnung
        {
            get
            {
                return _KonzeptKzBezeichnung;
            }
            set
            {
                _KonzeptKzBezeichnung = value;
            }
        }

        /// <summary>
        /// Liefert und setzt das Datum der Vereinbarung des Konzeptkennzeichens
        /// </summary>
        [DataMember]
        public int DatumVereinbarung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt Datum des Endes der Vereinbarung des Konzeptkennzeichens
        /// </summary>
        [DataMember]
        public int DatumVertragsende
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Status des Konzeptkennzeichens
        /// </summary>
        [DataMember]
        public string StatusKundenkonzept
        {
            get
            {
                return _StatusKundenkonzept;
            }
            set
            {
                _StatusKundenkonzept = value;
            }
        }

        /// <summary>
        /// Wird beim Server gesetzt und gibt an ob das Konzeptkennzeichen beim Laden gültig war
        /// </summary>
        [DataMember]
        public bool IsValid
        {
            get;
            set;
        }

        [DataMember]
        public bool IstSichtbar
        {
            get;
            set;
        }
    }
}
