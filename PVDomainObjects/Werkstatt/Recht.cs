/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Stammdatenverwaltung   
 * Funktionen:  Kapselt die Informationen und Funktionen eines Rechts
 ************************************************************************************/

using System;

namespace PV.DomainObjects.Stammdaten
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Rechts
    /// </summary>
    [Serializable]
    public class Recht
    {
        #region Fields

        private bool _Vererbbar;
        private string _Description;
        private string _ToCheck;
        private string _Name;
        
        #endregion

        #region Recht Member

        /// <summary>
        /// Liefert und setzt die Information ob ein Recht vererbbar ist
        /// </summary>
        public bool Vererbbar
        {
            get
            {
                return _Vererbbar;
            }
            set
            {
                _Vererbbar = value;
            }
        }


        /// <summary>
        /// Liefert eine Beschreibung des Rechts
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }


        /// <summary>
        /// Liefert und setzt den Namen des Rechts
        /// </summary>
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
        /// Liefert und setzt den String, welcher auch in der Oberfläche für ein benötigtes Recht bekannt ist
        /// </summary>
        public string ToCheck
        {
            get
            {
                return _ToCheck;
            }
            set
            {
                _ToCheck = value;
            }
        }

        #endregion
    }
}
