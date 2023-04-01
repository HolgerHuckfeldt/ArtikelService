/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Kundenverwaltung   
 * Funktionen:  Kapselt die Informationen und Funktionen eines NKW welcher einem Kunden zugeordnet ist
 ************************************************************************************/

using System;
using PV.DomainObjects.Fahrzeug;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Kunden
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines NKW welcher einem Kunden zugeordnet ist
    /// </summary>
    [Serializable]
    [DataContract]
    public class KundenNKW : KundenFahrzeug
    {
        /// <summary>
        /// Der referenzierte NKW
        /// </summary>
        [DataMember]
        public NKWTyp Nkw
        {
            get;
            set;
        }
    }
}