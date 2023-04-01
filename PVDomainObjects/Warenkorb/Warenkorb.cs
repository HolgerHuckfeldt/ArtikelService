/**************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz  
 * Modul:    Warenkorb   
 * Funktionen:  Kapselt die Informationen und Funktionen eines Warenkorbes
 *************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using PV.DomainObjects.Stammdaten;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Warenkorb
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Warenkorbes
    /// </summary>
    [DataContract]
    [Serializable]
    public class Warenkorb : INotifyPropertyChanged
    {
        #region Fields

        private Guid _Id;
        private DateTime _Created;
        private DateTime _LastUsed;
        private string _Title;
        private Mitarbeiter _Mitarbeiter;
        private bool _Integrietaet;
        private int _PositionsAnzahl;
        #endregion

        /// <summary>
        /// Konstruktor
        /// </summary>
        public Warenkorb()
        {
            ID = Guid.NewGuid();
            Title = string.Format( "Neu" );//_{0}", DateTime.Now.ToLongTimeString());
        }

        #region Warenkorb-Member

        #region Properties

        /// <summary>
        /// Eindeutige ID eines Warenkorbs
        /// </summary>
        [DataMember]
        public int BelegID
        {
            get;
            set;
        }



        /// <summary>
        /// Kann der Warenkorb in seinem Aktuellen Zustand bestellt werden?
        /// </summary>
        [DataMember]
        public bool Integrietaet
        {
            get
            {
                return _Integrietaet;
            }
            set
            {
                _Integrietaet = value;
                OnPropertyChanged( "Integrietaet" );
            }
        }

        /// <summary>
        /// Achtung: BestellID nicht zur Persistierung nutzen
        /// </summary>
        [DataMember]
        public long BestellID
        {
            get;
            set;
        }

        [DataMember]
        public List<Position> WarenListe
        {
            get;
            set;
        }

        [DataMember]
        public decimal SummeEK
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt das Erstellatum
        /// </summary>
        [DataMember]
        public DateTime Created
        {
            get
            {
                return _Created;
            }
            set
            {
                _Created = value;
            }
        }

        /// <summary>
        /// Liefert und setzt das Datum, wann der Warenkorb das letzte mal gespeichert wurde
        /// </summary>
        [DataMember]
        public DateTime LastUsed
        {
            get
            {
                return _LastUsed;
            }
            set
            {
                _LastUsed = value;
            }
        }



        /// <summary>
        /// Liefert und setzt den Titel des Warenkorbes
        /// </summary>
        [DataMember]
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }

        [DataMember]
        public Mitarbeiter Mitarbeiter
        {
            get
            {
                return _Mitarbeiter;
            }
            set
            {
                _Mitarbeiter = value;
            }
        }

        /// <summary>
        /// Die Id in der DB
        /// </summary>
        [DataMember]
        public Guid ID
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

        /// <summary>
        /// Liefert und setzt die Anzahl der Positionen
        /// </summary>
        public int PositionsAnzahl
        {
            get
            {
                return _PositionsAnzahl;
            }
            set
            {
                _PositionsAnzahl = value;
            }
        }

        #endregion

        #region Methoden

        #endregion

        #endregion

        private void OnPropertyChanged( String _name )
        {
            if ( PropertyChanged != null )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( _name ) );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
