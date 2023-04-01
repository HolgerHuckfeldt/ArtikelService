using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.Warenkorb;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Plus
{
    [DataContract]
    [Serializable]
    public class PraemienWarenkorbPosition : INotifyPropertyChanged
    {

        private PraemienArtikel _artikel;
        [DataMember]
        public PraemienArtikel Artikel
        {
            get { return _artikel; }
        }

        private decimal _menge;
        [DataMember]
        public decimal Menge
        {
            get { return _menge; }
            set
            {
                _menge = value;
                OnPropertyChanged("Menge");
            }
        }

        [DataMember]
        public int AnzahlGesamtPunkte
        {
            get 
            {
                return Convert.ToInt32(Artikel.AnzahlPunkte * Menge);
            }
        }

        public PraemienWarenkorbPosition(PraemienArtikel artikel)
        {
            _artikel = artikel;
        }

        #region INotifyPropertyChanged Member

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

    }
}
