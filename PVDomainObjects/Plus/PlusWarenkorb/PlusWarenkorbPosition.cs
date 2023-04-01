using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.Warenkorb;
using System.ComponentModel;
using System.Windows;

namespace PV.DomainObjects.Plus.PlusWarenkorb
{
    public class PlusWarenkorbPosition
    {
        private PraemienArtikel _artikel;
        private Decimal _menge;
        private Int32 _plusPunkte;
        private Int32 _plusPunkteSumme;
        private Int32 _positionsNummer;
        private wkPositionStatus _vdbStatus;
        private PlusWarenkorb _warenkorb;

        public PlusWarenkorbPosition(PraemienArtikel artikel, Decimal menge, Int32 plusPunkte, Int32 plusPunkteSumme, wkPositionStatus vdbStatus, Int32 positionsNummer, PlusWarenkorb warenkorb)
        {
            _artikel = artikel;
            _menge = menge > 0.0m ? menge : 1.0m;
            _plusPunkteSumme = plusPunkteSumme;
            _plusPunkte = plusPunkte;
            _positionsNummer = positionsNummer;
            _vdbStatus = vdbStatus;
            _warenkorb = warenkorb;
        }

        public PraemienArtikel Artikel
        {
            get
            {
                return _artikel;
            }
        }

        public Decimal Menge
        {
            get
            {
                return _menge;
            }
            set
            {
                if(_menge == value)
                    return;

                if (value > 0.0m)
                    _menge = value;
                OnChanged();
            }
        }

        public String Artikelnummer
        {
            get
            {
                return _artikel.ArtikelNummer;
            }
        }

        public String Beschreibung
        {
            get
            {
                return string.Format("{0} {1}", _artikel.HerstellerKurzName, _artikel.MarketingBezeichnung);
            }
        }

        public Int32 PlusPunkte
        {
            get
            {
                return _plusPunkte;
            }
        }

        public Int32 PlusPunkteSumme
        {
            get
            {
                return _plusPunkteSumme;
            }
            set
            {
                _plusPunkteSumme = value;
                OnChanged();
            }
        }

        public wkPositionStatus VdbStatus
        {
            get
            {
                return _vdbStatus;
            }
            set
            {
                _vdbStatus = value;
            }
        }


        private string _artikelHinweisCaption;

        public string ArtikelHinweisCaption
        {
            get { return _artikelHinweisCaption; }
            set
            {
                _artikelHinweisCaption = value;
            }
        }

        private string _artikelHinweisText;

        public string ArtikelHinweisText
        {
            get { return _artikelHinweisText; }
            set
            {
                _artikelHinweisText = value;
            }
        }

        public Int32 PositionsNummer
        {
            get
            {
                return _positionsNummer;
            }
        }

        private void OnChanged()
        {
            if (Changed != null)
            {
                Changed(this, new EventArgs());
            }
            _warenkorb.OnChanged();
        }

        public event EventHandler Changed;
    }
}
