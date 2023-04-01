/*******************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:   Fahrzeugsuche    
 * Funktionen:  Kapselt die Suchinformationen zu einem Fahrzeug
 *****************************************************************/
using System;
using System.Runtime.Serialization;
using PV.DomainObjects.Common;

namespace PV.DomainObjects.Fahrzeug
{
    /// <summary>
    /// Kapselt die Suchinformationen zu einem Fahrzeug
    /// </summary>
    [Serializable]
    [DataContract]
    public class FahrzeugSuchInfoObject
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
        /// Die gesuchte Bauart
        /// </summary>
        [DataMember]
        public string Bauart
        {
            get;
            set;
        }

        /// <summary>
        /// Die gesuchte Tonnage
        /// </summary>
        [DataMember]
        public string Tonnage
        {
            get;
            set;
        }

        /// <summary>
        /// Die gesuchten Achsen
        /// </summary>
        [DataMember]
        public string Achsen
        {
            get;
            set;
        }

        /// <summary>
        /// Der gesuchte Mandant
        /// </summary>
        [DataMember]
        public Mandant Mandant
        {
            get;
            set;
        }

        /// <summary>
        /// Die gesuchte Sprache
        /// </summary>
        [DataMember]
        public int Language
        {
            get;
            set;
        }

        /// <summary>
        /// Die gesuchte Sprache
        /// </summary>
        [DataMember]
        public int ProfileId
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Concat(this.Achsen, this.Bauart, this.Baujahr, this.Hersteller, this.Hubraum,
                                 this.Kraftstoff, this.Language, this.LeistungKW, this.Mandant, this.Modell,
                                 this.Motorcode);
        }
    }
}
