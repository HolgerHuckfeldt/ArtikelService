/**************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz
 * Modul:    Modulübergreifend   
 * Funktionen: Stellt die Informationen und Funktionen der UStArt bereit
 *************************************************************************/

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Common
{
    /// <summary>
    /// Stellt die Informationen und Funktionen der UStArt bereit
    /// </summary>
    [Serializable]
    [DataContract]
    public class UStArt : IEquatable<UStArt>
    {
        #region fields
        [DataMember]
        private string _Bezeichnung = string.Empty;
        [DataMember]
        private string _Anzeige = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Liefert und setzt die ID in der DB
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die vollständige Bezeichnung
        /// </summary>
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
        /// Liefert und setzt den String, welcher in der Oberfläche angezeigt werden soll
        /// </summary>
        /// 
        
        public string Anzeige
        {
            get
            {
                return _Anzeige;
            }
            set
            {
                _Anzeige = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Satz mit dem gerechnet werden soll
        /// </summary>
        [DataMember]
        public double Satz
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Priorisierung dieser Umsatzsteuerart in der Anzeige
        /// </summary>
        [DataMember]
        public int Prioisierung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Tag für die Suche.
        /// Bezeichnungen können sich ändern, der Tag sollte gleich bleiben
        /// </summary>
        [DataMember]
        public string Tag
        {
            get; set;
        }

        #endregion

        #region IEquatable<UStArt> Member

        public bool Equals( UStArt other )
        {
            return this.Id == other.Id;
        }

        public override bool Equals( object obj )
        {
            UStArt toCompare = obj as UStArt;
            if ( toCompare != null )
                return toCompare.Id == this.Id;

            return base.Equals( obj );
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion
    }
}
