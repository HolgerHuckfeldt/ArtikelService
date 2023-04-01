/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Stammdatenverwaltung   
 * Funktionen:  Kapselt die Informationen von Personendaten
 ************************************************************************************/

using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace PV.DomainObjects.Stammdaten
{
    /// <summary>
    /// Kapselt die Informationen von Personendaten
    /// </summary>
    [Serializable]
    [DataContract]
    public class Personendaten
    {
        #region Fields

        private string _Anrede = string.Empty;
        private string _Vorname = string.Empty;
        private string _Name = string.Empty;
        private string _Position = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Liefert und setzt die Anrede
        /// </summary>
        [DataMember]
        public string Anrede
        {
            get
            {
                return _Anrede;
            }
            set
            {
                _Anrede = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Vornamen
        /// </summary>
        [DataMember]
        public string Vorname
        {
            get
            {
                return _Vorname;
            }
            set
            {
                _Vorname = value;
            }
        }

        /// <summary>
        /// Setzt und liefert den Namen
        /// </summary>
        [DataMember]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// Setzt und liefert die Position
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

        #endregion

        #region UI-Properties

        /// <summary>
        /// Dies wird benutzt im TrainingsCard-Tab der Einstellung
        /// </summary>

        public List<string> AnredeList
        {
            get;
            set;
        }

        public List<string> PositionList
        {
            get;
            set;
        }

        #endregion
    }
}
