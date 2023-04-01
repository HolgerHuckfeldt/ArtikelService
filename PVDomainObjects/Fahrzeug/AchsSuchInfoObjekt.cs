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
    public class AchsSuchInfoObjekt
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
        /// Das Name des gesuchte Modell
        /// </summary>
        [DataMember]
        public string Modell
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
        /// Der gesuchte Achstyp
        /// </summary>
        [DataMember]
        public string Achstyp
        {
            get;
            set;
        }

        /// <summary>
        /// Die gesuchte Achsart
        /// </summary>
        [DataMember]
        public string Achsart
        {
            get;
            set;
        }

        /// <summary>
        /// Die gesuchte Achsausführung
        /// </summary>
        [DataMember]
        public string Achsausfuerung
        {
            get;
            set;
        }

        /// <summary>
        /// Die gesuchte Bremsgröße
        /// </summary>
        [DataMember]
        public string Bremsgroesse
        {
            get;
            set;
        }
    }
}
