/**************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz  
 * Modul:    Modulübergreifend   
 * Funktionen: Kapselt die Informationen und die Funktionen eines Bildes
 *************************************************************************/

using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace PV.DomainObjects.Common
{
    /// <summary>
    /// Kapselt die Informationen und die Funktionen eines Bildes
    /// </summary>
    [DataContract]
    [Serializable]
    public class PVBildInfoObject :INotifyPropertyChanged
    {


        public bool LargeImageLoaded { get; set; }


        /// <summary>
        /// Liefert und setzt den Datenlieferanten
        /// </summary>
        [DataMember]
        public string Datenlieferant
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Datenlieferanten
        /// </summary>
        [DataMember]
        public string Bildnummer
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Datenlieferanten
        /// </summary>
        [DataMember]
        public string Bildnamen
        {
            get;
            set;
        }

        /// <summary>
        /// BMP,JPG
        /// </summary>
        [DataMember]
        public string Dateityp
        { get; set; }


        /// <summary>
        /// Liefert den BildURI-String
        /// </summary>
        [DataMember]
        public string BildURI
        {
            get
            {
                return string.Format( "pv://katalog/{0}/{1}?type={2}", Datenlieferant, Bildnamen,Dateityp );
            }
            set
            {
            }
        }

        #region INotifyPropertyChanged Member

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string _name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(_name));
            }
        }

        #endregion
    }
}
