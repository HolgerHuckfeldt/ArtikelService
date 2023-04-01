/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Stammdatenverwaltung   
 * Funktionen:  Kapselt die Informationen was in welchem Dokument gedruckt werden soll
 ************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Stammdaten
{
    [DataContract]
    [Serializable]
    public enum Dokumentart
    {
        [EnumMember]
        Kva,
        [EnumMember]
        Rechnung
    }

    /// <summary>
    /// Kapselt die Informationen was in welchem Dokument gedruckt werden soll
    /// </summary>
    [DataContract]
    [Serializable]
    public class DokumentDruckOption
    {
        private string _InhaltFreitext = string.Empty;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public DokumentDruckOption()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Liefert und setzt die Id
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Dokumentart
        /// </summary>
        [DataMember]
        public Dokumentart Dokumentart
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information ob der Firmenname bei dieser Dokumentart gedruckt werden soll
        /// </summary>
        [DataMember]
        public bool Firmenname
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information ob der Firmenzusatz bei dieser Dokumentart gedruckt werden soll
        /// </summary>
        [DataMember]
        public bool Firmenzusatz
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information ob das Firmenlogo bei dieser Dokumentart gedruckt werden soll
        /// </summary>
        [DataMember]
        public bool Firmenlogo
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information ob die Firmenanschrift bei dieser Dokumentart gedruckt werden soll
        /// </summary>
        [DataMember]
        public bool Firmenanschrift
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information ob bei dieser Dokumentart daer Absender ins Adressfeld gedruckt werden soll
        /// </summary>
        [DataMember]
        public bool AbsenderInAdressfeld
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information ob die Kontaktdaten bei dieser Dokumentart gedruckt werden sollen
        /// </summary>
        [DataMember]
        public bool Kontaktdaten
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information ob die Steuernummer bei dieser Dokumentart gedruckt werden soll
        /// </summary>
        [DataMember]
        public bool Steuernummer
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information ob der Geschaeftsfuerer oder Inhaber bei dieser Dokumentart gedruckt werden soll
        /// </summary>
        [DataMember]
        public bool GeschaeftsfuererInhaber
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information ob der Firmensitz bei dieser Dokumentart gedruckt werden soll
        /// </summary>
        [DataMember]
        public bool Sitz
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information ob das Registergericht und die Registernummer bei dieser Dokumentart gedruckt werden soll
        /// </summary>
        [DataMember]
        public bool RegistergerichtUndNummer
        {
            get;
            set;
        }

        /// <summary>
		/// Liefert und setzt die Information ob das neue Format der Bankverbindung (IBAN/BIC) bei dieser Dokumentart gedruckt werden soll
        /// </summary>
        [DataMember]
        public bool Bankverbindung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information ob das alte Format der Bankverbindung (Konto/BLZ) bei dieser Dokumentart gedruckt werden soll
        /// </summary>
        [DataMember]
        public bool BankverbindungAlt
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information ob Freitext bei dieser Dokumentart gedruckt werden soll
        /// </summary>
        [DataMember]
        public bool Freitext
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Inhalt des Freitexest bei dieser Dokumentart
        /// </summary>
        [DataMember]
        public string InhaltFreitext
        {
            get
            {
                return _InhaltFreitext;
            }
            set
            {
                _InhaltFreitext = value;
            }
        }


        /// <summary>
        /// Liefert und setzt den oberen Rand
        /// </summary>
        [DataMember]
        public double RandOben
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den unteren Rand
        /// </summary>
        [DataMember]
        public double RandUnten
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den rechten Rand
        /// </summary>
        [DataMember]
        public double RandRechts
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den linken Rand
        /// </summary>
        [DataMember]
        public double RandLinks
        {
            get;
            set;
        }

        [DataMember]
        public string RechnungVorSilbe
        {
            get; set;
        }

        [DataMember]
        public string RechnungNachSilbe
        {
            get;
            set;
        }

        [DataMember]
        public long RechnungsNummernkreisStart
        {
            get; set;
        }

    }
}
