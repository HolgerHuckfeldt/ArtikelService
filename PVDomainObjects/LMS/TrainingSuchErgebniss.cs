/*********************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:      
 * Modul:       
 * Funktionen:  
 *********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.LMS
{
    /// <summary>
    /// Kapselt ein Suchergebniss einer Volltextsuche für die Technik
    /// </summary>
    [DataContract]
    [Serializable]
    public class TrainingSuchErgebniss
    {
        /// <summary>
        /// Die Id des Suchergebnisses, abhängig von der Quelle
        /// </summary>
        [DataMember]
        public string Id
        {
            get; set;
        }

        /// <summary>
        /// Die Quelle des Suchergebnisses. Der Name der View, die den String geliefert hat.
        /// </summary>
        [DataMember]
        public string Quelle
        {
            get; set;
        }

        /// <summary>
        /// Der Freitext, in dem der Suchstring gefunden wurde.
        /// </summary>
        [DataMember]
        public string Content
        {
            get; set;
        }

    }
}
