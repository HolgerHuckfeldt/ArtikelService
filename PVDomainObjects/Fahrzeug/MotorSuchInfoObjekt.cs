/*******************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:   Fahrzeugsuche    
 * Funktionen:  Kapselt die Suchinformationen zu einer Achse
 *****************************************************************/
using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Fahrzeug
{
    /// <summary>
    /// Kapselt die Suchinformationen zu einer Achse
    /// </summary>
    [Serializable]
    [DataContract]
    public class MotorSuchInfoObjekt
    {
        /// <summary>
        /// Der Name des gesuchte Hersteller
        /// </summary>
        [DataMember]
        public string Hersteller
        {
            get;
            set;
        }

        /// <summary>
        /// Das gesuchte Baujahr
        /// </summary>
        [DataMember]
        public string Baujahr
        {
            get;
            set;
        }

        /// <summary>
        /// Der gesuchte Hubraum
        /// </summary>
        [DataMember]
        public string Hubraum
        {
            get;
            set;
        }

        /// <summary>
        /// Die gesuchte Leistung in KW
        /// </summary>
        [DataMember]
        public string LeistungKW
        {
            get;
            set;
        }

        /// <summary>
        /// Die gesuchte Leistung in PS
        /// </summary>
        [DataMember]
        public string LeistungPS
        {
            get;
            set;
        }

        /// <summary>
        /// Der gesuchte Motorcode
        /// </summary>
        [DataMember]
        public string Motorcode
        {
            get;
            set;
        }

        /// <summary>
        /// Der gesuchte Kraftstoff
        /// </summary>
        [DataMember]
        public string Kraftstoff
        {
            get;
            set;
        }

        /// <summary>
        /// Die gesuchte Motorart
        /// </summary>
        [DataMember]
        public string Motorart
        {
            get;
            set;
        }
    }
}