using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Plus
{
    [Serializable]
    public class PlusBuchung : INotifyPropertyChanged
    {
        /// <summary>
        /// Das Buchungsdatum
        /// </summary>
        public DateTime Datum { get; set; }

        /// <summary>
        /// Buchungsdatum als String
        /// </summary>
        public string DatumString { get { return Datum.ToShortDateString(); } }

        /// <summary>
        /// Hauptbeschreibung
        /// </summary>
        public string BeschreibungTitel { get; set; }

        /// <summary>
        /// Untertitel der Beschreibung
        /// </summary>
        public string BeschreibungSub { get; set; }

        /// <summary>
        /// Zweckgebundene Prämienbestellung
        /// </summary>
        public string Zweckgebunden { get; set; }

        /// <summary>
        /// Verfügbarkeit
        /// </summary>
        public string VerfuegbarAb { get; set; }

        /// <summary>
        /// Soll-Buchungswert
        /// </summary>
        public int Soll { get; set; }

        /// <summary>
        /// Haben-Buchungswert
        /// </summary>
        public int Haben { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="_datum">Datum der Buchung</param>
        /// <param name="_bschTitel">Hauptbeschreibung</param>
        /// <param name="_bschSub">Untertitel der Beschreibung</param>
        /// <param name="_zweckGeb">Zweckgebunden?</param>
        /// <param name="_verfAb">Verfügbarkeit der Buchung</param>
        /// <param name="_soll">Soll-Buchungswert</param>
        /// <param name="_haben">Haben-Buchungswert</param>
        public PlusBuchung
            (
                DateTime _datum,
                string _bschTitel,
                string _bschSub,
                string _zweckGeb,
                string _verfAb,
                int _soll,
                int _haben
            )
        {
            Datum = _datum;
            BeschreibungTitel = _bschTitel;
            BeschreibungSub = _bschSub;
            Zweckgebunden = _zweckGeb;
            VerfuegbarAb = _verfAb;
            Soll = _soll;
            Haben = _haben;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged == null)
            {
                return;
            }

            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }


        #endregion
    }
}
