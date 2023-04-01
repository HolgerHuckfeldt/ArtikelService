/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Stammdatenverwaltung   
 * Funktionen:  Kapselt die Informationen und Funktionen einer Werkstatt
 ************************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using PV.DomainObjects.Common;

namespace PV.DomainObjects.Stammdaten
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen einer Werkstatt
    /// </summary>
    [DataContract]
    [Serializable]
    public class Werkstatt
    {
        #region fields
        [DataMember]
        private IList<Fahrzeug.Hersteller> _AusschlussHerstellerListe;
        
        private IList<Warenkorb.Warenkorb> _WarenkorbListe;
        
        private IList<KVA.KVA> _KVAListe;
        [DataMember]
        private List<ArbeitswertArt> _ArbeitswertArtListe;
        [DataMember]
        private IList<DokumentDruckOption> _Druckoptionen;
        
        private List<Profil> _WerkstattProfile;
        
        private bool _UseAW;
        
        private int _EigenerAWTeiler;
        
        private bool _EigeneAWTeilerNutzen;

        private bool _UseAWOld;
        private int _EigenerAWTeilerOld;
        private bool _EigeneAWTeilerNutzenOld;
        private double _InspektionsOel;

        #endregion

        /// <summary>
        /// Liefert ein Objekt der Klasse Werkstatt
        /// </summary>

        public Werkstatt()
        {
            Id = Guid.NewGuid();
            InspektionsOel = 2;
        }

        #region Props

        /// <summary>
        /// Liefert und setzt die ID der in der Datenbasis
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert eine Liste von auszuschließenden Herstellern
        /// </summary>
        public IList<Fahrzeug.Hersteller> AusschlussHerstellerListe
        {
            get
            {
                if( _AusschlussHerstellerListe == null )
                    _AusschlussHerstellerListe = new ObservableCollection<Fahrzeug.Hersteller>();
                return _AusschlussHerstellerListe;
            }

        }

        /// <summary>
        /// Liefert und setzt die Information ob Arbeitswerte oder Stunden genutzt werden sollen
        /// true wenn AW genutzt werden sollen
        /// </summary>
        [DataMember]
        public bool UseAW
        {
            get
            {
                return _UseAW;
            }
            set
            {
                UseAWOld = _UseAW;
                _UseAW = value;
            }
        }

        /// <summary>
        /// Speichert bei Änderungen den alten Wert um die 
        /// </summary>
        public bool UseAWOld
        {
            get
            {
                return _UseAWOld;
            }
            set
            {
                _UseAWOld = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Information ob in den Arbeitswerten eigene Teiler genutzt werden sollen
        /// </summary>
        [DataMember]
        public bool EigeneAWTeilerNutzen
        {
            get
            {
                return _EigeneAWTeilerNutzen;
            }
            set
            {
                EigeneAWTeilerNutzenOld = _EigeneAWTeilerNutzen;
                _EigeneAWTeilerNutzen = value;
            }
        }

        /// <summary>
        /// Speichert bei Änderungen den alten Wert um die 
        /// </summary>
        public bool EigeneAWTeilerNutzenOld
        {
            get
            {
                return _EigeneAWTeilerNutzenOld;
            }
            set
            {
                _EigeneAWTeilerNutzenOld = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Information ob automatisches Update aktiviert ist
        /// </summary>
        [DataMember]
        public bool AutoUpdate
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den eigenen AW-Teiler
        /// </summary>
        [DataMember]
        public int EigenerAWTeiler
        {
            get
            {
                return _EigenerAWTeiler;
            }
            set
            {
                EigenerAWTeilerOld = _EigenerAWTeiler;
                _EigenerAWTeiler = value;

            }
        }

        /// <summary>
        /// Speichert bei Änderungen den alten Wert um die 
        /// </summary>
        public int EigenerAWTeilerOld
        {
            get
            {
                return _EigenerAWTeilerOld;
            }
            set
            {
                _EigenerAWTeilerOld = value;
            }
        }

        /// <summary>
        /// Liefert die Liste der Profile der Werkstatt
        /// </summary>
        [DataMember]
        public List<Profil> WerkstattProfile
        {
            get
            {
                if( _WerkstattProfile == null )
                    _WerkstattProfile = new List<Profil>();
                return _WerkstattProfile;
            }
            set
            {
                _WerkstattProfile = value;
            }
        }

        /// <summary>
        /// Liefert die Liste der aktiven Profile
        /// </summary>
        public List<Profil> ActiveProfiles
        {
            get
            {
                if( _WerkstattProfile == null )
                    _WerkstattProfile = new List<Profil>();
                List<Profil> back = ( from profil in _WerkstattProfile
                                      where profil.IsActive
                                      select profil ).ToList();
                return back;
            }
        }

        /// <summary>
        /// Liefert die Info ob die Werkstatt Profile hat
        /// </summary>
        public bool HasProfiles
        {
            get
            {
                if (_WerkstattProfile == null)
                    return false;
                return _WerkstattProfile.Count != 0;
            }
        }

        /// <summary>
        /// PitStop Kunde der bei Stahlgruber bestellt
        /// </summary>
        [DataMember]
        public bool IsStahlgruberPitStop
        {
            get;
            set;
        }
        
        /// <summary>
        /// Liefert die Liste der ArbeitswertArten der Werkstatt
        /// </summary>
        public List<ArbeitswertArt> ArbeitswertArtListe
        {
            get
            {
                if( _ArbeitswertArtListe == null )
                    _ArbeitswertArtListe = new List<ArbeitswertArt>();
                return _ArbeitswertArtListe;
            }
        }

        /// <summary>
        /// Liefert die Liste der Warenkörbe der Werkstatt
        /// </summary>
        public IList<Warenkorb.Warenkorb> WarenkorbListe
        {
            get
            {
                if( _WarenkorbListe == null )
                    _WarenkorbListe = new List<Warenkorb.Warenkorb>();
                return _WarenkorbListe;
            }

        }

        /// <summary>
        /// Liefert die Liste der Kostenvoranschäge der Werkstatt
        /// </summary>
        public IList<KVA.KVA> KVAListe
        {
            get
            {
                if( _KVAListe == null )
                    _KVAListe = new List<KVA.KVA>();
                return _KVAListe;
            }
        }

        /// <summary>
        /// Liefert die Liste der Druckoptionen
        /// </summary>
        public IList<DokumentDruckOption> Druckoptionen
        {
            get
            {
                if( _Druckoptionen == null )
                {
                    _Druckoptionen = new List<DokumentDruckOption>();
                }
                return _Druckoptionen;
            }
        }

        [DataMember]
        public double InspektionsOel
        {
            get
            {
                return _InspektionsOel;
            }
            set
            {
                _InspektionsOel = value;
            }
        }
        #endregion

    }
}
