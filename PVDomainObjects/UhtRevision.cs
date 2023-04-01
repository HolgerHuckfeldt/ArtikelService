/********************************************************
 * Copyright    Absolute Software GmbH 2008-2009
 * Projekt:     PV-Kompass 
 * Author:      Dirk Lannatewitz
 * Modul:       UhtRevision 
 * Funktionen:  Kapselt die Informationen der UhtRevision
 ********************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects
{
    /// <summary>
    /// Kapselt die Informationen der UhtRevision
    /// </summary>
    [DataContract]
    [Serializable]
    public class UhtRevision
    {
        /// <summary>
        /// Liefert und setzt die Id in der Datenquelle
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Version
        /// </summary>
        [DataMember]
        public long Version
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt das Lieferdatum
        /// </summary>
        [DataMember]
        public DateTime Lodet
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Info ob an Repdoc commited wurde
        /// </summary>
        [DataMember]
        public bool Commited
        {
            get;
            set;
        }
    }
}
