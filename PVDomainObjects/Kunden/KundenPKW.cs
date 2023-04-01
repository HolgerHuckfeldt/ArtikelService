/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Kundenverwaltung   
 * Funktionen:  Kapselt die Informationen und Funktionen eines PKW welcher einem Kunden zugeordnet ist
 ************************************************************************************/

using System;
using PV.DomainObjects.Fahrzeug;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace PV.DomainObjects.Kunden
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines PKW welcher einem Kunden zugeordnet ist
    /// </summary>
    [Serializable]
    [DataContract]
    public class KundenPKW : KundenFahrzeug
    {
        private PKWTyp _PKW;

        /// <summary>
        /// Der referenzierte PKW
        /// </summary>
        [DataMember]
        public PKWTyp Pkw
        {
            get 
            {
                return _PKW; 
            }
            set 
            {
                _PKW = value; 
            }
        }
    }
}