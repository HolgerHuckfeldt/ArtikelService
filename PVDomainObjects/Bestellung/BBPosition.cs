/*********************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Walter Licht / Dirk Lannatewitz   
 * Modul:    Bestellung   
 * Funktionen:  Domainobjekt für eine Position innerhalb einer Bestellbestätigung
 ********************************************************************************************/

using System;
using PV.DomainObjects.Warenkorb;

namespace PV.DomainObjects.Bestellung
{
    /// <summary>
    /// Domainobjekt für eine Position innerhalb einer Bestellbestätigung
    /// </summary>
    [Serializable]
    public class BBPosition
    {
        public BBPosition(bool _split,bool _rueckstand, DateTime _lieferdatum, String _artikelnummer, String _bezeichnung,
            string _hersteller, Decimal _menge, Int32 _pvplus, Int32 _pvplusSumme, Decimal _ekEinzel,string _steuer, Decimal _ekSumme, string _notiz1,
            string _notiz2, Anlieferungsarten _Anlieferungsart, wkVerfuegbarkeit _Verfuegbarkeit)
        {
            Splitartikel = _split;
            Rueckstand = _rueckstand;
            Lieferdatum = _lieferdatum;
            Artikelnummer = _artikelnummer;
            Bezeichnung = _bezeichnung;
            Hersteller = _hersteller;
            Menge = _menge;
            PVPlus1 = _pvplus;
            PVPlus2 = _pvplusSumme;
            EKEinzel = _ekEinzel;
            EKSumme = _ekSumme;
            Notiz1 = _notiz1;
            Notiz2 = _notiz2;
            Steuer = _steuer;
            Anlieferungsart = _Anlieferungsart;
            Verfuegbarkeit = _Verfuegbarkeit;
        }

        #region Properties

        public Anlieferungsarten Anlieferungsart
        {
            get;
            set;
        }

        public wkVerfuegbarkeit Verfuegbarkeit
        {
            get;
            set;
        }

        public bool Splitartikel
        {
            get;
            set;
        }
        public bool Rueckstand
        {
            get;
            set;
        }

        //Datum 2. Uhrzeit
        public DateTime Lieferdatum
        {
            get;
            set;
        }

        //Next
        public String Artikelnummer
        {
            get;
            set;
        }

        public String Bezeichnung
        {
            get;
            set;
        }

        public String Hersteller
        {
            get;
            set;
        }

        public String Steuer
        {
            get;
            set;
        }

        public Decimal Menge
        {
            get;
            set;
        }

        public Int32 PVPlus1
        {
            get;
            set;
        }

        public Int32 PVPlus2
        {
            get;
            set;
        }

        public Decimal EKEinzel
        {
            get;
            set;
        }

        public Decimal EKSumme
        {
            get;
            set;
        }

        public string Notiz1
        {
            get;
            set;
        }
        public string Notiz2
        {
            get;
            set;
        }

        #endregion
    }
}
