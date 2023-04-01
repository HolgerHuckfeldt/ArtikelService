/*********************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:      
 * Modul:       
 * Funktionen:  
 *********************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    /// <summary>
    /// Kapselt ein Suchergebniss einer Volltextsuche für die Technik
    /// </summary>
    [DataContract]
    [Serializable]
    public class TechnikSuchErgebnis
    {
        /// <summary>
        /// Die Id des Suchergebnisses, abhängig von der Quelle
        /// </summary>
        [DataMember]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Die Quelle des Suchergebnisses. Der Name der View, die den String geliefert hat.
        /// </summary>
        [DataMember]
        public string Quelle
        {
            get;
            set;
        }

        /// <summary>
        /// Der Freitext, in dem der Suchstring gefunden wurde.
        /// </summary>
        [DataMember]
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Die MainGroup, zu der der Suchstring gefunden wurde.
        /// </summary>
        [DataMember]
        public string MainGroup
        {
            get;
            set;
        }

        /// <summary>
        /// Die Id, der übergeordneten Gruppe.
        /// </summary>
        [DataMember]
        public string GroupId
        {
            get;
            set;
        }
    }
}
