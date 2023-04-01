using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PV.DomainObjects.Artikel;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    [Serializable]
    public class wkPosition : IWarenkorbPosition
    {

        private Decimal _bestellMenge;

        public static wkPosition GetCopy( wkPosition _position )
        {
            return new wkPosition( _position );
        }

        private wkWarenkorb _Warenkorb;

        public wkWarenkorb Warenkorb
        {
            get
            {
                return _Warenkorb;
            }
            set
            {
                _Warenkorb = value;
            }
        }

        [DataMember] private Guid _repdocGuid;
        
        public Guid RepdocGuid
        {
            get { return _repdocGuid; }
            set { _repdocGuid = value; }
        }

        private wkPosition( wkPosition _position )
        {
            _Warenkorb = _position._Warenkorb;
            ArtikelRef = _position.ArtikelRef;
            PositionNr = _position.PositionNr;
            VdbArtikelnummer = _position.VdbArtikelnummer;

            AktionBonus = _position.AktionBonus;
            UmsatzBonus = _position.UmsatzBonus;
            AktionBonus = _position.AktionBonus;
            KonzeptBonus = _position.KonzeptBonus;
            TauschBonus = _position.TauschBonus;
            KompassBestellBonus = _position.KompassBestellBonus;
            LieferBonus = _position.LieferBonus;
            SummeBonus = _position.SummeBonus;
            OnlineBonus = _position.OnlineBonus;

            EkPreis = _position.EkPreis;
            EkPreisSumme = _position.EkPreisSumme;
            BestellMenge = _position.BestellMenge;
            Unterpositionen = new List<wkUnterPosition>();
            PosGuid = _position.PosGuid;
            UserText1 = _position.UserText1;
            UserText2 = _position.UserText2;
            RepdocGuid = _position.RepdocGuid;
            Anlieferungsart = _position.Anlieferungsart;
            Nachtexpressmoeglich = _position.Nachtexpressmoeglich;
            IsTecCom = _position.IsTecCom;

            foreach ( wkUnterPosition unterPosition in _position.Unterpositionen )
            {
                Unterpositionen.Add( new wkUnterPosition()
                                        {
                                            Liefertour = unterPosition.Liefertour,
                                            Menge = unterPosition.Menge,
                                            Selbstabholung = unterPosition.Selbstabholung,
                                            Verfuegbarkeit = unterPosition.Verfuegbarkeit,
                                        } );
            }
        }

        public wkPosition( wkWarenkorb warenkorb )
        {
            //Standard Constructor
            _Warenkorb = warenkorb;
        }

        public wkPosition( wkWarenkorb warenkorb, Artikel.Artikel artikel, decimal menge )
            : this( warenkorb )
        {
            ArtikelRef = artikel;
            Menge = menge;
        }

        [DataMember]
        public Guid PosGuid
        {
            get;
            set;
        }

        [DataMember]
        public Artikel.Artikel ArtikelRef
        {
            get;
            set;
        }


        [DataMember]
        public Int32 PositionNr
        {
            get;
            set;
        }

        [DataMember]
        public List<wkUnterPosition> Unterpositionen
        {
            get;
            set;
        }

        public String HLK
        {
            get
            {
                return ArtikelRef.HLK;
            }
        }

        public wkArtikelArt ArtikelArt
        {
            get;
            set;
        }

        public String Pfandwert
        {
            get
            {
                string retValue = string.Empty;

                if (ArtikelRef.HatPfandwert)
                {
                    string strHelp = ArtikelRef.AltteilKennzeichen.Equals("U") ? "Erstattungsfähiger Umweltbeitrag" : "Altteil-Pfand";
                    retValue = string.Format("{0}: {1:n} €", strHelp, ArtikelRef.Pfandwert);
                }

                return retValue;
            }
        }

        [DataMember]
        public String VdbArtikelnummer
        {
            get;
            set;
        }

        [DataMember]
        public Anlieferungsarten Anlieferungsart
        {
            get;
            set;
        }

        [DataMember]
        public bool Nachtexpressmoeglich
        {
            get;
            set;
        }

        [DataMember]
        public wkPositionStatus VdbStatus { get; set; }

        
        public Int64 DatenlieferantenNummer
        {
            get
            {
                Debug.Assert( ArtikelRef != null, "ArtikelRef is null when trying to access DatenlieferantenNummer" );
                return ArtikelRef.DatenlieferantenNummer;
            }
        }

        
        public String Artikelnummer
        {
            get
            {
                Debug.Assert( ArtikelRef != null, "ArtikelRef is null when trying to access ArtikelNummer" );
                return ArtikelRef.ArtikelNummer;
            }
        }

        [DataMember]
        public Decimal BestellMenge
        {
            get { return _bestellMenge; }
            set
            {
                if (ArtikelRef != null && ArtikelRef.IsTecComDeleveryArtikel)
                {
                    _bestellMenge = 1;
                }
                else
                    _bestellMenge = value;
            }
        }

        [DataMember]
        public long UmsatzBonus { get; set; }

        [DataMember]
        public long AktionBonus { get; set; }

        [DataMember]
        public long KonzeptBonus { get; set; }

        [DataMember]
        public long TauschBonus { get; set; }

        [DataMember]
        public long KompassBestellBonus { get; set; }

        [DataMember]
        public long LieferBonus { get; set; }

        [DataMember]
        public long SummeBonus { get; set; }

        [DataMember]
        public long OnlineBonus { get; set; }

        [DataMember]
        public Decimal EkPreis
        {
            get;
            set;
        }

        public Decimal VkPreis
        {
            get
            {
                return ArtikelRef.VKPreis;
            }
        }

        [DataMember]
        public Decimal EkPreisSumme
        {
            get;
            set;
        }

        [DataMember]
        public Boolean Alternativen
        {
            get;
            set;
        }

        [DataMember]
        private string _userText1;

        
        public String UserText1
        {
            get
            {
                return _userText1;
            }
            set
            {
                _userText1 = value;

                if (!string.IsNullOrEmpty(_userText1) && _userText1.Length > 40)
                    _userText1 = _userText1.Substring(0, 40);

                //_Warenkorb.IstWarenkorbReserviert = false;
                OnPropertyChanged( "UserText2" );
            }
        }

        [DataMember]
        private string _userText2;

        public String UserText2
        {
            get
            {
                return _userText2;
            }
            set
            {
                _userText2 = value;

                if (!string.IsNullOrEmpty(_userText2) && _userText2.Length > 40)
                    _userText2 = _userText2.Substring(0, 40);
                //_Warenkorb.IstWarenkorbReserviert = false;
                OnPropertyChanged( "UserText2" );
            }
        }

        #region IWarenkorbPosition Member

        public string Bezeichnung
        {
            get
            {
                Debug.Assert( ArtikelRef != null, "ArtikelRef is null when trying to access Bezeichnung" );
                string genArtBezeichnung = String.IsNullOrEmpty( ArtikelRef.GenArtBezeichnung ) ? String.Empty : String.Format( "{0} ", ArtikelRef.GenArtBezeichnung );
                return String.Format( "{0}{1}", genArtBezeichnung, ArtikelRef.Bezeichnung );
            }
        }

        public string Hersteller
        {
            get
            {
                Debug.Assert( ArtikelRef != null, "ArtikelRef is null when trying to access HerstellerName" );
                return ArtikelRef.HerstellerName;
            }
        }

        public decimal Menge
        {
            get
            {
                // Spezielle Position, TecCom-Transportkosten. Menge ist immer 1.
                if (ArtikelArt == wkArtikelArt.TecComDelivery)
                    return 1;

                return BestellMenge;
            }
            set
            {
                //if( IsTecCom)
                //    return;

                if ( BestellMenge != value )
                {
                    BestellMenge = value;
                    OnPropertyChanged( "Menge" );
                }
            }
        }

        public String Steuerkennzeichen
        {
            get
            {
                Debug.Assert( ArtikelRef != null, "ArtikelRef is null when trying to access Steuerkennzeichen" );
                return ArtikelRef.UStTag;
            }
        }

        public Artikel.Artikel TecComTransportArtikelRef { get; set; }

        private bool _isTecCom = false;
        public bool IsTecCom {
            get
            {
                return _isTecCom;
            }
            set
            {
                _isTecCom = value;
            }
        }

        #endregion

        #region INotifyPropertyChanged Member

        private void OnPropertyChanged( String property )
        {
            if ( PropertyChanged != null )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( property ) );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

    [DataContract]
    [Serializable]
    public enum Anlieferungsarten
    {
        [EnumMember]
        Anlieferung,
        [EnumMember]
        Selbstabholung,
        [EnumMember]
        Nachtexpress,
        [EnumMember]
        Heimatstandort
    }
}
