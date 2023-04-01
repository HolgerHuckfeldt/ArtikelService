/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Kundenverwaltung   
 * Funktionen:  Kapselt die Informationen und Funktionen eines Motors welcher einem Kunden zugeordnet ist
 ************************************************************************************/

using System;
using PV.DomainObjects.Fahrzeug;
using System.ComponentModel;
using System.Runtime.Serialization;
namespace PV.DomainObjects.Kunden
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Motors welcher einem Kunden zugeordnet ist
    /// </summary>
    [Serializable]
    [DataContract]
    public class KundenMotor : KundenRessourceBase
    {
        /// <summary>
        /// Der referenzierte Motor
        /// </summary>
        [DataMember]
        public Motor Motor
        {
            get;
            set;
        }
    }
}