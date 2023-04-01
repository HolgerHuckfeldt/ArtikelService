/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Stammdatenverwaltung   
 * Funktionen:  Kapselt die Informationen und Funktionen eines Mitarbeiters
 ************************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using PV.DomainObjects.History;
using PV.DomainObjects.LMS;

namespace PV.DomainObjects.Stammdaten
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Mitarbeiters
    /// </summary>
    [Serializable]
    [DataContract]
    public class Mitarbeiter
    {
        #region Fields

        [DataMember]
        private int _lmsID;
        [DataMember]
        private StatusEnum.TrainingsCard _trainingsCard;
        [DataMember]
        private int _index;
        [DataMember]
        private Personendaten _Personendaten;
        [DataMember]
        private string _Username = string.Empty;
        [DataMember]
        private string _Passwort = string.Empty;
        [DataMember]
        private string _Email = string.Empty;
        [DataMember]
        private string _Profilstring = string.Empty;
        [DataMember]
        private List<Profil> _Profile;
        [DataMember]
        private Profil _CurrentProfil;
        [DataMember]
        private IList<HistoryEntry> _IdentHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _PKWFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _NKWFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _MotorenFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _AchsenFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _PKWArtikelFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _NKWArtikelFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _AchsArtikelFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _MotorenArtikelFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _UniversalArtikelFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _NummernArtikelFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _ArbeitswerteFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _KundenFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _EigeneArtikelFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _EigeneAWFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _KVAFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _TechnikFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _WartungFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _WartungArbeitswertFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _TrainingOrteFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _TrainingKategorieFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _PlusAuszugFreitextSuchHistory;
        [DataMember]
        private IList<FreitextSuchHistory> _BestellungFreitextSuchHistory;

        #endregion

        /// <summary>
        /// empty Konstruktor fürs EntityFramework
        /// </summary>
        public Mitarbeiter()
        {
            Guid = Guid.NewGuid();
            _Personendaten = new Personendaten();
            RechtWartungsAssistent = true;
        }

        /// <summary>
        /// Wird ausgelöst, wenn sich das CurrentProfile ändert
        /// </summary>
        [NonSerialized]
        private EventHandler _CurrentProfileChangedEvent;
        public event EventHandler CurrentProfileChangedEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                _CurrentProfileChangedEvent = (EventHandler)Delegate.Combine(_CurrentProfileChangedEvent, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                _CurrentProfileChangedEvent = (EventHandler)Delegate.Remove(_CurrentProfileChangedEvent, value);
            }
        }

        protected void OnCurrentProfileChangedEvent(Profil _old, Profil _new)
        {
            if (_CurrentProfileChangedEvent != null)
            {
                _CurrentProfileChangedEvent(this, new ProfileChangedEventArgs(_old, _new));
            }
        }

        #region Properties

        /// <summary>
        /// Liefert und setzt den Index eines Mitarbeiters in einer Liste
        /// </summary>
        [DataMember]
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }

        public bool IsAutomaticLogedIn
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die LMS_ID
        /// </summary>
        [DataMember]
        public int LmsID
        {
            get
            {
                return _lmsID;
            }
            set
            {
                _lmsID = value;
            }
        }

        [DataMember]
        public StatusEnum.TrainingsCard TrainingsCard
        {
            get { return _trainingsCard; }
            set { _trainingsCard = value; }
        }

        public string UITrainingsCardAnzeige
        {
            get
            {
                if (TrainingsCard != StatusEnum.TrainingsCard.Keine)
                    return " (TC)";
                else
                    return "";
            }
        }

        /// <summary>
        /// Liefert und setzt die ID der Organisationseinheit
        /// </summary>
        [DataMember]
        public Guid Guid
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert das Personendaten-Object
        /// </summary>
        [DataMember]
        public Personendaten Personendaten
        {
            get
            {
                return _Personendaten;
            }
            set
            {
                _Personendaten = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Anrede
        /// </summary>
        [DataMember]
        public string Anrede
        {
            get
            {
                return _Personendaten.Anrede;
            }
            set
            {
                if (_Personendaten == null)
                    _Personendaten = new Personendaten();

                _Personendaten.Anrede = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Vornamen
        /// </summary>
        [DataMember]
        public string Vorname
        {
            get
            {
                return _Personendaten.Vorname;
            }
            set
            {
                if (_Personendaten == null)
                    _Personendaten = new Personendaten();

                _Personendaten.Vorname = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Familiennamen
        /// </summary>
        [DataMember]
        public string Nachname
        {
            get
            {
                return _Personendaten.Name;
            }
            set
            {
                if (_Personendaten == null)
                    _Personendaten = new Personendaten();

                _Personendaten.Name = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Position
        /// </summary>
        [DataMember]
        public string Position
        {
            get
            {
                return _Personendaten.Position;
            }
            set
            {
                if (_Personendaten == null)
                    _Personendaten = new Personendaten();

                _Personendaten.Position = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Usernamen
        /// </summary>
        [DataMember]
        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
            }
        }

        /// <summary>
        /// Liefert und setzt das Passwort
        /// </summary>
        [DataMember]
        public string Passwort
        {
            get
            {
                return _Passwort;
            }
            set
            {
                _Passwort = value;
            }
        }

        /// <summary>
        /// Gibt an ob das Passwort geändert wurde und beim Speichern gehasht werden muss
        /// </summary>
        [DataMember]
        public bool PasswortDirty
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Info ob sich ein Benutzer das erste mal anmeldet 
        /// </summary>
        [DataMember]
        public bool FirstLogin
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Mailadresse des Mitarbeiters
        /// </summary>
        [DataMember]
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        /// <summary>
        /// Liefert einen Pipeseparierten String der Profilids des Users
        /// </summary>
        [DataMember]
        public string Profilstring
        {
            get
            {
                return _Profilstring;
            }
            set
            {
                _Profilstring = value;
            }
        }

        /// <summary>
        /// Liefert die Liste der zugeteilten Profile
        /// </summary>
        public IList<Profil> Profile
        {
            get
            {
                if (_Profile == null)
                {
                    _Profile = new List<Profil>();
                }
                return _Profile;
            }
        }

        /// <summary>
        /// Liefert das aktuell gewählte Profil
        /// </summary>
        [DataMember]
        public Profil CurrentProfil
        {
            get
            {
                return _CurrentProfil;
            }
            set
            {
                if (_CurrentProfil != value)
                {
                    Profil old = _CurrentProfil;
                    _CurrentProfil = value;
                    OnCurrentProfileChangedEvent(old, _CurrentProfil);
                }
            }
        }

        /// <summary>
        /// Liefert und setzt die ID des als bevorzugt gespeicherten Profils
        /// </summary>
        [DataMember]
        public Guid PreferedProfilID
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat die Firmendaten zu sehen und zu ändern
        /// </summary>
        [DataMember]
        public bool RechtFirmendaten
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat die Benutzerdaten zu sehen und zu ändern
        /// </summary>
        [DataMember]
        public bool RechtBenutzer
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat die Lizenzdaten zu sehen und zu ändern
        /// </summary>
        [DataMember]
        public bool RechtLizenzen
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat die Druckvorlagen zu sehen und zu ändern
        /// </summary>
        [DataMember]
        public bool RechtDruckvorlagen
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat die EK-Preise zu sehen
        /// </summary>
        [DataMember]
        public bool RechtEKPreise
        {
            get;
            set;
        }

        public bool ShowEKPreiseArtikelliste
        {
            get;
            set;
        }


        public bool ShowEKPreiseWkPrint
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat die Bestellungen zu machen
        /// </summary>
        [DataMember]
        public bool RechtBestellung
        {
            get;
            set;
        }

		/// <summary>
		/// Liefert die Info ob der Benutzer das Recht hat den Entsorgungs-Tab zu sehen
		/// </summary>
		[DataMember]
		public bool RechtEntsorgung
		{
			get;
			set;
		}
		
		/// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat KVAs zu ändern
        /// </summary>
        [DataMember]
        public bool RechtKVAErweitert
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat Einstellungen im Assistenten zu machen
        /// </summary>
        [DataMember]
        public bool RechtAssistent
        {
            get;
            set;
        }

        [DataMember]
        public bool RechtQualitaetscheck
        {
            get;
            set;
        }

        private bool _rechtWartungsAssistent;

        [DataMember]
        public bool RechtWartungsAssistent
        {
            get { 
                
                return _rechtWartungsAssistent; 
            }
            set 
            { 
                _rechtWartungsAssistent = value; 
            }
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat VkPreise in der Auftragsbestätigung anzuzeigen
        /// </summary>
        [DataMember]
        public bool RechtVkPreis
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht nur Barzahlung hat
        /// </summary>
        [DataMember]
        public bool NurBarZahlung
        {
            get;
            set;
        }

        [DataMember]
        public bool NurBarZahlungAlt
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob beim Benutzer der Zahlungsmodus über die Einstellungen aktiv ist
        /// </summary>
        [DataMember]
        public bool ZahlungsModusAktiv
        {
            get;
            set;
        }

        [DataMember]
        public bool ZahlungsModusAktivAlt
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer beim Absenden einer Bestellung eine Bestellnotiz angeben muss
        /// </summary>
        [DataMember]
        public bool BestellnotizErforderlich
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat MeineWerkstatt zu benutzen
        /// </summary>
        [DataMember]
        public bool RechtMeineWerkstatt
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat MediaMarkter zu benutzen
        /// </summary>
        [DataMember]
        public bool RechtMediaMaster
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat Plus-Punkte zu Artikeln zu sehen
        /// </summary>
        [DataMember]
        public bool RechtPlusPunkteEinsehen
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat Plus-Punkte einzulösen
        /// </summary>
        [DataMember]
        public bool RechtPlusPunkteEinloesen
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat andere Benutzer zu TRainings anzumelden
        /// </summary>
        [DataMember]
        public bool RechtLMSAnmeldenAndere
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat sich für Trainings anzumelden
        /// </summary>
        [DataMember]
        public bool RechtLMSAnmeldenSelbst
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer das Recht hat sich für Trainings anzumelden
        /// </summary>
        [DataMember]
        public bool RechtClubPv
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob der Benutzer den WarenkorbSchnellmodus expantiert hat oder nicht
        /// </summary>
        [DataMember]
        public bool IsWarenkorbSchnellmodusIsExpanded
        {
            get;
            set;
        }

        public bool IsWarenkorbImportTabSelected
        {
            get;
            set;
        }

        #region Histories

        /// <summary>
        /// Liefert die History für die PKW-, NKW, Motoren- und Achsensuche des angemeldeten Users
        /// </summary>
        public IList<HistoryEntry> IdentHistory
        {
            get
            {
                if (_IdentHistory == null)
                {
                    _IdentHistory = new ObservableCollection<HistoryEntry>();
                }


                // Okok, echt blöd. Objekte diesewr Klasse kommen aus dem WCF-Service.
                // Der serialisiert arrays in die _IdentHistory, wir brauchen aber,
                // und das ist ein design-Bug, ObservableCollection. Also umkopieren.
                if (_IdentHistory as ObservableCollection<HistoryEntry> == null)
                {
                    IList<HistoryEntry> tmp = new List<HistoryEntry>();
                    foreach (var item in _IdentHistory)
                    {
                        tmp.Add(item);
                    }
                    _IdentHistory = new ObservableCollection<HistoryEntry>();
                    foreach (var item1 in tmp)
                    {
                        _IdentHistory.Add(item1);
                    }
                }

                return _IdentHistory;
            }
        }

        /// <summary>
        /// Liefert die History der Freitextsuchen des angemeldeten Users für die PKWFreitextsuche
        /// </summary>
        public IList<FreitextSuchHistory> PKWFreitextSuchHistory
        {
            get
            {
                if (_PKWFreitextSuchHistory == null)
                {
                    _PKWFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_PKWFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _PKWFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _PKWFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _PKWFreitextSuchHistory.Add(item1);
                    }
                }

                return _PKWFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert  die History der Freitextsuchen des angemeldeten Users für die NKWFreitextsuche
        /// </summary>
        public IList<FreitextSuchHistory> NKWFreitextSuchHistory
        {
            get
            {
                if (_NKWFreitextSuchHistory == null)
                {
                    _NKWFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_NKWFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _NKWFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _NKWFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _NKWFreitextSuchHistory.Add(item1);
                    }
                }

                return _NKWFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert die History der Freitextsuchen des angemeldeten Users für die MotorenFreitextsuche
        /// </summary>
        public IList<FreitextSuchHistory> MotorenFreitextSuchHistory
        {
            get
            {
                if (_MotorenFreitextSuchHistory == null)
                {
                    _MotorenFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_MotorenFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _MotorenFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _MotorenFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _MotorenFreitextSuchHistory.Add(item1);
                    }
                }

                return _MotorenFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert die History der Freitextsuchen des angemeldeten Users für die AchsenFreitextsuche
        /// </summary>
        public IList<FreitextSuchHistory> AchsenFreitextSuchHistory
        {
            get
            {
                if (_AchsenFreitextSuchHistory == null)
                {
                    _AchsenFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_AchsenFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _AchsenFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _AchsenFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _AchsenFreitextSuchHistory.Add(item1);
                    }
                }

                return _AchsenFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert die History der Freitextsuchen des angemeldeten Users für die KundenFreitextsuche
        /// </summary>
        public IList<FreitextSuchHistory> KundenFreitextSuchHistory
        {
            get
            {
                if (_KundenFreitextSuchHistory == null)
                {
                    _KundenFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_KundenFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _KundenFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _KundenFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _KundenFreitextSuchHistory.Add(item1);
                    }
                }

                return _KundenFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert die History der Freitextsuchen des angemeldeten Users für die EigeneArtikelFreitextsuche
        /// </summary>
        public IList<FreitextSuchHistory> EigeneArtikelFreitextSuchHistory
        {
            get
            {
                if (_EigeneArtikelFreitextSuchHistory == null)
                {
                    _EigeneArtikelFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_EigeneArtikelFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _EigeneArtikelFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _EigeneArtikelFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _EigeneArtikelFreitextSuchHistory.Add(item1);
                    }
                }

                return _EigeneArtikelFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert die History der Freitextsuchen des angemeldeten Users für die EigeneArtikelFreitextsuche
        /// </summary>
        public IList<FreitextSuchHistory> EigeneAWFreitextSuchHistory
        {
            get
            {
                if (_EigeneAWFreitextSuchHistory == null)
                {
                    _EigeneAWFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_EigeneAWFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _EigeneAWFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _EigeneAWFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _EigeneAWFreitextSuchHistory.Add(item1);
                    }
                }

                return _EigeneAWFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert die History der Freitextsuchen des angemeldeten Users für die EigeneArtikelFreitextsuche
        /// </summary>
        public IList<FreitextSuchHistory> KVAFreitextSuchHistory
        {
            get
            {
                if (_KVAFreitextSuchHistory == null)
                {
                    _KVAFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_KVAFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _KVAFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _KVAFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _KVAFreitextSuchHistory.Add(item1);
                    }
                }

                return _KVAFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert für den eingeloggten User die History der Freitextsuche in den PKWArtikeln
        /// </summary>
        public IList<FreitextSuchHistory> PkwArtikelFreitextSuchHistory
        {
            get
            {
                if (_PKWArtikelFreitextSuchHistory == null)
                {
                    _PKWArtikelFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_PKWArtikelFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _PKWArtikelFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _PKWArtikelFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _PKWArtikelFreitextSuchHistory.Add(item1);
                    }
                }

                return _PKWArtikelFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert für den eingeloggten User die History der Freitextsuche in den NKWArtikeln
        /// </summary>
        public IList<FreitextSuchHistory> NkwArtikelFreitextSuchHistory
        {
            get
            {
                if (_NKWArtikelFreitextSuchHistory == null)
                {
                    _NKWArtikelFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_NKWArtikelFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _NKWArtikelFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _NKWArtikelFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _NKWArtikelFreitextSuchHistory.Add(item1);
                    }
                }

                return _NKWArtikelFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert für den eingeloggten User die History der Freitextsuche in den AchsArtikeln
        /// </summary>
        public IList<FreitextSuchHistory> AchsenArtikelFreitextSuchHistory
        {
            get
            {
                if (_AchsArtikelFreitextSuchHistory == null)
                {
                    _AchsArtikelFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_AchsArtikelFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _AchsArtikelFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _AchsArtikelFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _AchsArtikelFreitextSuchHistory.Add(item1);
                    }
                }

                return _AchsArtikelFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert für den eingeloggten User die History der Freitextsuche in den MotorenArtikeln
        /// </summary>
        public IList<FreitextSuchHistory> MotorenArtikelFreitextSuchHistory
        {
            get
            {
                if (_MotorenArtikelFreitextSuchHistory == null)
                {
                    _MotorenArtikelFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_MotorenArtikelFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _MotorenArtikelFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _MotorenArtikelFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _MotorenArtikelFreitextSuchHistory.Add(item1);
                    }
                }

                return _MotorenArtikelFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert für den eingeloggten User die History der Freitextsuche in den UniversalArtikeln
        /// </summary>
        public IList<FreitextSuchHistory> UniversalArtikelFreitextSuchHistory
        {
            get
            {
                if (_UniversalArtikelFreitextSuchHistory == null)
                {
                    _UniversalArtikelFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_UniversalArtikelFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _UniversalArtikelFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _UniversalArtikelFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _UniversalArtikelFreitextSuchHistory.Add(item1);
                    }
                }

                return _UniversalArtikelFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert für den eingeloggten User die History der Freitextsuche in den NummernArtikelsuche
        /// </summary>
        public IList<FreitextSuchHistory> NummernArtikelFreitextSuchHistory
        {
            get
            {
                if (_NummernArtikelFreitextSuchHistory == null)
                {
                    _NummernArtikelFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_NummernArtikelFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _NummernArtikelFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _NummernArtikelFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _NummernArtikelFreitextSuchHistory.Add(item1);
                    }
                }

                return _NummernArtikelFreitextSuchHistory;
            }
        }


        /// <summary>
        /// Liefert für den eingeloggten User die History der Freitextsuche in den Arbeitswerten
        /// </summary>
        public IList<FreitextSuchHistory> ArbeitswerteFreitextSuchHistory
        {
            get
            {
                if (_ArbeitswerteFreitextSuchHistory == null)
                {
                    _ArbeitswerteFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_ArbeitswerteFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _ArbeitswerteFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _ArbeitswerteFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _ArbeitswerteFreitextSuchHistory.Add(item1);
                    }
                }

                return _ArbeitswerteFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert für den eingeloggten User die History der Freitextsuche in Technik
        /// </summary>
        public IList<FreitextSuchHistory> TechnikFreitextSuchHistory
        {
            get
            {
                if (_TechnikFreitextSuchHistory == null)
                {
                    _TechnikFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_TechnikFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _TechnikFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _TechnikFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _TechnikFreitextSuchHistory.Add(item1);
                    }
                }

                return _TechnikFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert für den eingeloggten User die History der Freitextsuche in der Wartung
        /// </summary>
        public IList<FreitextSuchHistory> WartungFreitextSuchHistory
        {
            get
            {
                if (_WartungFreitextSuchHistory == null)
                {
                    _WartungFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_WartungFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _WartungFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _WartungFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _WartungFreitextSuchHistory.Add(item1);
                    }
                }

                return _WartungFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert für den eingeloggten User die History der Freitextsuche in Wartungsarbeitswerte
        /// </summary>
        public IList<FreitextSuchHistory> WartungArbeitswertFreitextSuchHistory
        {
            get
            {
                if (_WartungArbeitswertFreitextSuchHistory == null)
                {
                    _WartungArbeitswertFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_WartungArbeitswertFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _WartungArbeitswertFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _WartungArbeitswertFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _WartungArbeitswertFreitextSuchHistory.Add(item1);
                    }
                }

                return _WartungArbeitswertFreitextSuchHistory;
            }
        }


        /// <summary>
        /// Liefert für den eingeloggten User die History der Freitextsuche in Trainings-Orten
        /// </summary>
        public IList<FreitextSuchHistory> TrainingOrteFreitextSuchHistory
        {
            get
            {
                if (_TrainingOrteFreitextSuchHistory == null)
                {
                    _TrainingOrteFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_TrainingOrteFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _TrainingOrteFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _TrainingOrteFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _TrainingOrteFreitextSuchHistory.Add(item1);
                    }
                }

                return _TrainingOrteFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert für den eingeloggten User die History der Freitextsuche in Trainings-Kategorien
        /// </summary>
        public IList<FreitextSuchHistory> TrainingKategorieFreitextSuchHistory
        {
            get
            {
                if (_TrainingKategorieFreitextSuchHistory == null)
                {
                    _TrainingKategorieFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_TrainingKategorieFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _TrainingKategorieFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _TrainingKategorieFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _TrainingKategorieFreitextSuchHistory.Add(item1);
                    }
                }

                return _TrainingKategorieFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert für den eingeloggten User die History der Freitextsuche in PlusKontoauszügen
        /// </summary>
        public IList<FreitextSuchHistory> PlusAuszugFreitextSuchHistory
        {
            get
            {
                if (_PlusAuszugFreitextSuchHistory == null)
                {
                    _PlusAuszugFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_PlusAuszugFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _PlusAuszugFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _PlusAuszugFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _PlusAuszugFreitextSuchHistory.Add(item1);
                    }
                }

                return _PlusAuszugFreitextSuchHistory;
            }
        }

        /// <summary>
        /// Liefert für den eingeloggten User die History der Freitextsuche in Bestellungen
        /// </summary>
        public IList<FreitextSuchHistory> BestellungFreitextSuchHistory
        {
            get
            {
                if (_BestellungFreitextSuchHistory == null)
                {
                    _BestellungFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                }

                if (_BestellungFreitextSuchHistory as ObservableCollection<FreitextSuchHistory> == null)
                {
                    IList<FreitextSuchHistory> tmp = new List<FreitextSuchHistory>();
                    foreach (var item in _BestellungFreitextSuchHistory)
                    {
                        tmp.Add(item);
                    }
                    _BestellungFreitextSuchHistory = new ObservableCollection<FreitextSuchHistory>();
                    foreach (var item1 in tmp)
                    {
                        _BestellungFreitextSuchHistory.Add(item1);
                    }
                }

                return _BestellungFreitextSuchHistory;
            }
        }

        #endregion

        #endregion

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(Mitarbeiter))
                return false;
            return Equals((Mitarbeiter)obj);
        }

        public bool Equals(Mitarbeiter other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return other.Guid.Equals(Guid);
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }
    }
}
