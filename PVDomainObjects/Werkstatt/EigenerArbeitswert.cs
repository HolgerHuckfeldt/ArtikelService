/**************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Torsten Gaul
 * Modul:    DomainObjects   
 * Funktionen: Kapselt die Informationen und Funktionen der Eigenen Arbeitswerte
 *************************************************************************/


using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using PV.DomainObjectInterfaces;
using PV.DomainObjects.Common;

namespace PV.DomainObjects.Stammdaten
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen der Eigenen Arbeitswerte
    /// </summary>
    [Serializable]
    [DataContract]
    public class EigenerArbeitswert : ICloneable, INotifyPropertyChanged, IKVAItem
    {
        #region fields
        [DataMember]
        private Guid _Id;
        [DataMember]
        private int _AWNummer;
        [DataMember]
        private string _Beschreibung;
        [DataMember]
        private double _Stunden;
        [DataMember]
        private Werkstatt _Werkstatt;
        [DataMember]
        private ArbeitswertArt _ArbeitswertArt;
        [DataMember]
        private bool _IsKvaAw;

        #endregion

        /// <summary>
        /// Konstruktor
        /// </summary>
        public EigenerArbeitswert()
        {
            Id = Guid.NewGuid();
            Beschreibung = string.Empty;
        }

        #region Props
        /// <summary>
        /// ID des Eigenen Arbeitswertes
        /// </summary>
        /// 
        public Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }


        public bool IsKvaAW
        {
            get
            {
                return _IsKvaAw;
            }
            set
            {
                _IsKvaAw = value;
            }
        }

        /// <summary>
        /// Nummer des Eigenen Arbeitswertes
        /// </summary>        
        public int AWNummer
        {
            get
            {
                return _AWNummer;
            }
            set
            {
                _AWNummer = value;
            }
        }

        public string CLNumber { get; set; }

        /// <summary>
        /// Beschreibung des Eigenen Arbeitswertes
        /// </summary>
        public string Beschreibung
        {
            get
            {
                return _Beschreibung;
            }
            set
            {
                _Beschreibung = value;
            }
        }

        /// <summary>
        /// Der Stundenlohn des Eigenen Arbeitswertes
        /// </summary>
       
        public double Stunden
        {
            get
            {
                return Math.Round(_Stunden, 2);
            }
            set
            {
                _Stunden = value;
                OnPropertyChanged( "VKNetto" );
                OnPropertyChanged( "Wert" );
            }
        }

        /// <summary>
        /// Die Werkstatt des Eigenen Arbeitswertes
        /// </summary>
       
        public Werkstatt Werkstatt
        {
            get
            {
                return _Werkstatt;
            }
            set
            {
                _Werkstatt = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Arbeitswertpreis
        /// </summary>
      
        public ArbeitswertArt ArbeitswertArt
        {
            get
            {
                return _ArbeitswertArt;
            }
            set
            {
                _ArbeitswertArt = value;
                OnPropertyChanged( "VKNetto" );
                OnPropertyChanged( "Wert" );
            }
        }

        /// <summary>
        ///Liefert den berechneten Wert des AW
        /// </summary>
  
        public double Wert
        {
            get
            {
                return Stunden * Werkstatt.EigenerAWTeiler;
            }
        }

        /// <summary>
        /// Liefert den NettoVK
        /// </summary>
       
        public double VKNetto
        {
            get
            {
                return ArbeitswertArt.VKStundenlohn * Stunden;
            }
        }

        private void OnPropertyChanged( String _name )
        {
            if ( PropertyChanged != null )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( _name ) );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public object Clone()
        {
            EigenerArbeitswert result = new EigenerArbeitswert
                                            {
                                                ArbeitswertArt = ArbeitswertArt,
                                                AWNummer = AWNummer,
                                                Beschreibung = Beschreibung,
                                                Id = Id,
                                                Stunden = Stunden,
                                                Werkstatt = Werkstatt,
                                                CLNumber = CLNumber,
                                                IsKvaAW = IsKvaAW
                                            };
            return result;
        }
    }
}
