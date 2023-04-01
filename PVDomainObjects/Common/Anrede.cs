/**************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz
 * Modul:    DomainObjects   
 * Funktionen: Kapselt die Informationen und Funktionen der Anrede
 *************************************************************************/

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Common
{
    [Serializable]
    [DataContract]
    public class Anrede : IEquatable<Anrede>
    {

        private Guid _guid;
         /// <summary>
        /// Liefert und setzt die Id in der DB
        /// </summary>        
        [DataMember]
        public Guid ID
        {
            get { return _guid; }
            set { _guid = value; }
        }

        /// <summary>
        /// Liefert und setzt den Anredetext
        /// </summary>
        [DataMember]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Priorisierung der Anrede in einer Liste von Anreden
        /// </summary>
        [DataMember]
        public int Priorisierung
        {
            get;
            set;
        }

        #region IEquatable Member


        public bool Equals( Anrede other )
        {
            return ID == other.ID;
        }

        public override bool Equals( object obj )
        {
            Anrede toCompare = obj as Anrede;
            if ( toCompare != null )
                return toCompare.ID == ID;

            return base.Equals( obj );
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        #endregion
    }
}
