/*********************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Artikel   
 * Funktionen: Kapselt die Informationen und die Funktionen einer ArtikelLieferantenInfo
 ********************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Artikel
{
    /// <summary>
    /// Kapselt die Informationen und die Funktionen einer ArtikelLieferantenInfo
    /// </summary>
    [DataContract]
    [Serializable] 
    public class ArtikelLieferantenInfo
    {
        /// <summary>
        /// Liefert und setzt die Nummer des DL
        /// </summary>
        [DataMember]
        public int DLNr
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt ???
        /// </summary>
        [DataMember]
        public int? SA
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die erste Bezeichnung
        /// </summary>
        [DataMember]
        public string Bezeichnung
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die zweite Bezeichnung
        /// </summary>
        [DataMember]
        public string Bezeichnung2
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die erste Straße
        /// </summary>
        [DataMember]
        public string Straße
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die zweite Strasse
        /// </summary>
        [DataMember]
        public string Strasse2
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt das Postfach
        /// </summary>
        [DataMember]
        public string Postfach
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt das LandesKennzeichen des Postfachs
        /// </summary>
        [DataMember]
        public string PLZLKZ
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt den Ort des Postfachs
        /// </summary>
        [DataMember]
        public string PLZOrt
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die PLZ des Postfachs
        /// </summary>
        [DataMember]
        public string PLZPf
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die ???
        /// </summary>
        [DataMember]
        public string PLZGr
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt den ersten Ort
        /// </summary>
        [DataMember]
        public string Ort
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt den zweiten Ort
        /// </summary>
        [DataMember]
        public string Ort2
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die Telefonnummer
        /// </summary>
        [DataMember]
        public string Telefon
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die Faxnummer
        /// </summary>
        [DataMember]
        public string Fax
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die EMailadresse
        /// </summary>
        [DataMember]
        public string Email
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die WebAdresse
        /// </summary>
        [DataMember]
        public string WebAdresse
        {
            get;
            set;
        }
    }
}
