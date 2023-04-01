/*********************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:       Warenkorb
 * Funktionen:  Kapselt die Informationen und Funktionen eines WarenkorbEntry
 *              Ein Warenkorbentry ist eine Hilfsklasse welche eine Itemart im Warenkorb beschreibt
 *********************************************************************************************************************/

namespace PV.DomainObjects.Warenkorb
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines WarenkorbEntry
    /// </summary>
    public class WarenkorbEntry
    {
        #region Fields

        private PV.DomainObjects.Artikel.Artikel _Ware;
        private int _Anzahl; 
	    private double _Summe;

        private string _Artikelnummer;
        private string _VdbArtikelnummer;
        private string _VdbBezeichnung;
        private string _TecDocBezeichnung;
        private string _HerstellerBezeichnung;
        private int _Menge;
        private string _Notiz1;
        private string _Notiz2;
        private string _CustInfo;
        #endregion

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="_ware">Die Ware welche das Entry enthält</param>
        /// <param name="_anzahl">Initiale Anzahl der Wareneinheiten</param>
        public WarenkorbEntry( PV.DomainObjects.Artikel.Artikel _ware, int _anzahl )
        {
            _Anzahl = _anzahl;
            _Ware = _ware;
            CalculateSumme();
        }

        #region WarenkorbEntry-Member

        #region Properties

        /// <summary>
        /// Liefert die Anzahl der Wareneinheiten
        /// </summary>
        public int Anzahl
        {
            get
            {
                return _Anzahl;
            }
            set
            {
                _Anzahl = value;
            }

        }

        public double Summe
        {
            get
            {
                return _Summe;
            }
        }

        /// <summary>
        /// Liefert die Ware welche das Entry enthält
        /// </summary>
        public PV.DomainObjects.Artikel.Artikel Ware
        {
            get
            {
                return _Ware;
            }
        }

        public string Artikelnummer
        {
            get { return _Artikelnummer; }
            set { _Artikelnummer = value; }
        }

        public string VdbArtikelnummer
        {
            get { return _VdbArtikelnummer; }
            set { _VdbArtikelnummer = value; }
        }

        public string VdbBezeichnung
        {
            get { return _VdbBezeichnung; }
            set { _VdbBezeichnung = value; }
        }

        public string TecDocBezeichnung
        {
            get { return _TecDocBezeichnung; }
            set { _TecDocBezeichnung = value; }
        }

        public string HerstellerBezeichnung
        {
            get { return _HerstellerBezeichnung; }
            set { _HerstellerBezeichnung = value; }
        }

        public int Menge
        {
            get { return _Menge; }
            set { _Menge = value; }
        }

        public string Notiz1
        {
            get { return _Notiz1; }
            set { _Notiz1 = value; }
        }

        public string Notiz2
        {
            get { return _Notiz2; }
            set { _Notiz2 = value; }
        }

        public string CustInfo
        {
            get { return _CustInfo; }
            set { _CustInfo = value; }
        }

        #endregion

        #region Methoden

        /// <summary>
        /// Fügt Wareneinheiten hinzu
        /// </summary>
        /// <param name="_count">Anzahl der hinzuzufügenden Einheiten</param>
        public void Add( int _count )
        {
            _Anzahl += _count;
            CalculateSumme();
        }

        /// <summary>
        /// Entfernt Wareneinheiten 
        /// </summary>
        /// <param name="_count">Anzahl der zu entfernenden Einheiten</param>
        public void Remove( int _count )
        {
            _Anzahl -= _count;
            CalculateSumme();
        }

        private void CalculateSumme()
        {
            //_Summe = _Ware.EKPreis * Anzahl; 
        }

        #endregion

        #endregion
    }
}
