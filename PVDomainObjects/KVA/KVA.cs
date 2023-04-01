/***************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz
 * Modul:    KVA
 * Funktionen: KVA Domian Object
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Kunden;
using PV.DomainObjects.Stammdaten;
using System.Runtime.Serialization;
using PV.DomainObjects.Wartung;
using PV.DomainObjects.Arbeitswerte;

namespace PV.DomainObjects.KVA
{
    [Serializable]
    [DataContract]
    [KnownType(typeof(Mitarbeiter))]
    [KnownType(typeof(Profil))]
    [KnownType(typeof(KVAPosition))]
    [KnownType(typeof(ShallowInnerItem))]
    [KnownType(typeof(ShallowInnerItem.ShallowArbeitsprozess))]
    [KnownType(typeof(ArtikelKatalogIdent))]
    [KnownType(typeof(List<int>))]
    [KnownType(typeof(List<WartungsChecklisteItem>))]
    [KnownType(typeof(EigenerArtikel))]
    [KnownType(typeof(EigenerArbeitswert))]

    public class KVA : IEquatable<KVA>, INotifyPropertyChanged
    {
        #region fields

        [DataMember]
        private string _Titel = string.Empty;
        [DataMember]
        private DateTime _LastUseTime;
        [DataMember]
        private Mitarbeiter _LastUser;
        [DataMember]
        private Profil _LastUseProfil;
        //Kundendaten sollen ein Snapshot vom Istzustand der Zuweisung sein und werden deshalb kopiert
        [DataMember]
        private string _KundenAnrede = string.Empty;
        [DataMember]
        private string _KundenVorname = string.Empty;
        [DataMember]
        private string _KundenName = string.Empty;
        [DataMember]
        private string _KundenRessource = string.Empty;
        [DataMember]
        private string _KundenFirma = string.Empty;
        [DataMember]
        private string _KundenStrasse = string.Empty;
        [DataMember]
        private string _KundenPLZ = string.Empty;
        [DataMember]
        private string _KundenOrt = string.Empty;
        [DataMember]
        private string _KundenNummer = string.Empty;
        [DataMember]
        private string _KundenTelefonnummer = string.Empty;
        [DataMember]
        private string _KundenMobilnummer = string.Empty;
        [DataMember]
        private string _KundenEMail = string.Empty;
        [DataMember]
        private string _KundenFahrzeugtyp = string.Empty;
        [DataMember]
        private string _KundenFahrzeugkennzeichen = string.Empty;
        [DataMember]
        private string _KundenFahrzeugErstzulassung = string.Empty;
        [DataMember]
        private string _KundenFahrzeugKilometerstand = string.Empty;
        [DataMember]
        private decimal? _VKMaterialienEinzelNetto;
        [DataMember]
        private decimal? _VKLeistungenEinzelNetto;
        [DataMember]
        private IList<KVAPosition> _KVAPositionen;
        [DataMember]
        private KVAPosition _SelectedKVAPositionen;
        [DataMember]
        private decimal _BelegRabattProzent;
        [DataMember]
        private decimal _BelegRabattTotal;
        [DataMember]
        private bool _UseAW;
        [NonSerialized]
        private string _KTypNr;

        #endregion

        public KVA()
        {
            Id = Guid.NewGuid();
            IsLoaded = false;
            LastUser = new Mitarbeiter();
            LastUseProfil = new Profil();
        }

        /// <summary>
        /// Wird ausgelöst, wenn sich der selektierte Kunde ändert
        /// </summary>
        public event EventHandler SelectedKundeChangedEvent;

        private void OnSelectedKundeChangedEvent()
        {
            if (SelectedKundeChangedEvent != null)
                SelectedKundeChangedEvent(this, null);
        }

        /// <summary>
        /// Wird geworfen wenn eine neue Position ausgewählt wird
        /// </summary>
        public event EventHandler SelectedKVAPositionChangedEvent;

        /// <summary>
        /// Löst das SelectedKVAPositionChangedEvent aus
        /// </summary>
        private void OnSelectedKVAPositionChangedEvent()
        {
            if (SelectedKVAPositionChangedEvent != null)
                SelectedKVAPositionChangedEvent(this, null);
        }

        #region KVAInfos

        [NonSerialized]
        private bool _isSaved;

        private bool _isReadOnly;
      
        /// <summary>
        /// Gibt die KtypNr des Fahrzeugs vom Kunden an, der dem KVA zugeordnet ist
        /// </summary>
        [DataMember]
        public string KTypeId
        {
            get
            {
                return _KTypNr;
            }
            set
            {
                _KTypNr = value;
            }
        }

        /// <summary>
        /// Gibt an ob der KVA Readonly geöffnet wurde
        /// </summary>
        [DataMember]
        public bool IsReadOnly
        {
            get
            {
                return _isReadOnly;
            }
            set
            {
                if (_isReadOnly != value)
                {
                    _isReadOnly = value;
                    OnPropertyChanged("IsReadOnly");
                }
            }
        }

        /// <summary>
        /// Gibt an ob der KVA schon gespeichert wurde oder nicht
        /// </summary>
        public bool IsSaved
        {
            get
            {
                return _isSaved;
            }
            set
            {
                _isSaved = value;
            }
        }

        public bool IsLoaded
        {
            get; set;
        }

        /// <summary>
        /// Gibt an ob der KVA komplett geladen wurde
        /// </summary>
        [DataMember]
        public bool IsCompleteInitialized
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Id des KVA
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Belegnummer des Kva
        /// </summary>
        [DataMember]
        public int Belegnummer
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Rechnungsnummer, falls vorhanden, des Kva
        /// </summary>
        [DataMember]
        public int? Rechnungsnummer
        {
            get;
            set;
        }


        public bool IsPims2Kva
        {
            get
            {
                return _Titel.EndsWith("@P2");
            }
        }

        /// <summary>
        /// Liefert und setzt den Titel 
        /// </summary>
        public string Titel
        {
            get
            {
                if (_Titel.EndsWith("@P2")) return _Titel.Substring(0, _Titel.Length - 3);
                return _Titel;
            }
            set
            {
                _Titel = value;
                OnPropertyChanged("Titel");
            }
        }

        /// <summary>
        /// Liefert und setzt den Titel 
        /// </summary>
        public string TitelIntern
        {
            get
            {
                return _Titel;
            }
        }

        /// <summary>
        /// Liefert und setzt die Info ob der KVA sich im Calcmode befindet
        /// </summary>
        [DataMember]
        public bool CalcMode
        {
            get;
            set;
        }


        #endregion

        #region UserInfos

        /// <summary>
        /// Liefert und setzt den Mitarbeiter welcher den KVA erzeugt hat
        /// </summary>
        [DataMember]
        public Mitarbeiter CreationUser
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt das Profil mit welcher den KVA erzeugt hat
        /// </summary>
        [DataMember]
        public Profil CreationProfil
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Zeit, wann ein KVA erzeugt wurde
        /// </summary>
        [DataMember]
        public DateTime CreationTime
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den letzten Mitarbeiter, welcher den KVA zuletzt bearbeitet hat
        /// </summary>
        public Mitarbeiter LastUser
        {
            get
            {
                return _LastUser;

            }
            set
            {
                _LastUser = value;
                OnPropertyChanged("LastUser");
            }
        }

        /// <summary>
        /// Liefert und setzt das Profil mit welchem der KVA zuletzt bearbeitet wurde
        /// </summary>
        public Profil LastUseProfil
        {
            get
            {
                return _LastUseProfil;
            }
            set
            {
                _LastUseProfil = value;
                OnPropertyChanged("LastUseProfil");
            }
        }

        /// <summary>
        /// Liefert und setzt die Zeit, wann ein KVA das letzte Mal bearbeitet wurde
        /// </summary>
        ///
        public DateTime LastUseTime
        {
            get
            {
                return _LastUseTime;
            }
            set
            {
                _LastUseTime = value;
                OnPropertyChanged("LastUseTime");
            }
        }

        #endregion

        /// <summary>
        /// Liefert und setzt die Liste der KVA Positionen
        /// </summary>
        [DataMember]
        public IList<KVAPosition> KVAPositionen
        {
            get
            {
                if (_KVAPositionen == null)
                    _KVAPositionen = new ObservableCollection<KVAPosition>();
                return _KVAPositionen;
            }
            set
            {
                _KVAPositionen = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die selektierte KVA Positionen
        /// </summary>
        [DataMember]
        public KVAPosition SelectedKVAPositionen
        {
            get
            {
                return _SelectedKVAPositionen;
            }
            set
            {
                _SelectedKVAPositionen = value;
                OnSelectedKVAPositionChangedEvent();
                OnPropertyChanged("SelectedKVAPositionen");
            }
        }


        #region Kundendaten

        public string KundenAnzeigeName
        {
            get
            {
                return KundenAnrede + " " + KundenVorname + " " + KundenName;
            }
        }

        /// <summary>
        /// Liefert und setzt die Kundenanrede
        /// </summary>
        [DataMember]
        public string KundenAnrede
        {
            get
            {
                return _KundenAnrede;
            }
            set
            {
                _KundenAnrede = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Kundenvornamen
        /// </summary>
        [DataMember]
        public string KundenVorname
        {
            get
            {
                return _KundenVorname;
            }
            set
            {
                _KundenVorname = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Kundennamen
        /// </summary>
        [DataMember]
        public string KundenName
        {
            get
            {
                return _KundenName;
            }
            set
            {
                _KundenName = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Hersteller des Kundenfahrzeuges
        /// </summary>
        [DataMember]
        public string KundenRessource
        {
            get
            {
                return _KundenRessource;
            }
            set
            {
                _KundenRessource = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Firma des Kunden
        /// </summary>
        [DataMember]
        public string KundenFirma
        {
            get
            {
                return _KundenFirma;
            }
            set
            {
                _KundenFirma = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Strasse des Kunden
        /// </summary>
        [DataMember]
        public string KundenStrasse
        {
            get
            {
                return _KundenStrasse;
            }
            set
            {
                _KundenStrasse = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die PLZ des Kunden
        /// </summary>
        [DataMember]
        public string KundenPLZ
        {
            get
            {
                return _KundenPLZ;
            }
            set
            {
                _KundenPLZ = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Ort des Kunden
        /// </summary>
        [DataMember]
        public string KundenOrt
        {
            get
            {
                return _KundenOrt;
            }
            set
            {
                _KundenOrt = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Kundennummer
        /// </summary>
        [DataMember]
        public string KundenNummer
        {
            get
            {
                return _KundenNummer;
            }
            set
            {
                _KundenNummer = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Telefonnummer
        /// </summary>
        [DataMember]
        public string KundenTelefonnummer
        {
            get
            {
                return _KundenTelefonnummer;
            }
            set
            {
                _KundenTelefonnummer = value;
            }
        }
        /// <summary>
        /// Liefert und setzt die Mobilnummer
        /// </summary>
        [DataMember]
        public string KundenMobilnummer
        {
            get
            {
                return _KundenMobilnummer;
            }
            set
            {
                _KundenMobilnummer = value;
            }
        }
        /// <summary>
        /// Liefert und setzt die EMail-Adresse
        /// </summary>
        [DataMember]
        public string KundenEMail
        {
            get
            {
                return _KundenEMail;
            }
            set
            {
                _KundenEMail = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Typ des Kundenfahrzeuges
        /// </summary>
        [DataMember]
        public string KundenFahrzeugtyp
        {
            get
            {
                return _KundenFahrzeugtyp;
            }
            set
            {
                _KundenFahrzeugtyp = value;
            }
        }

        /// <summary>
        /// Liefert und setzt das Kennzeichen des Kundenfahrzeuges
        /// </summary>
        [DataMember]
        public string KundenFahrzeugkennzeichen
        {
            get
            {
                return _KundenFahrzeugkennzeichen;
            }
            set
            {
                _KundenFahrzeugkennzeichen = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Erstzulassung des Kundenfahrzeuges
        /// </summary>
        [DataMember]
        public string KundenFahrzeugErstzulassung
        {
            get
            {
                return _KundenFahrzeugErstzulassung;
            }
            set
            {
                _KundenFahrzeugErstzulassung = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den Kilometerstand des Kundenfahrzeuges
        /// </summary>
        [DataMember]
        public string KundenFahrzeugKilometerstand
        {
            get
            {
                return _KundenFahrzeugKilometerstand;
            }
            set
            {
                _KundenFahrzeugKilometerstand = value;
            }
        }

        #endregion

        #region Brutto/Netto/Steuer-Summen




        /// <summary>
        /// Liefert BEI EINEM AUS DER DB GELADENEN KVA die Summe der Nettobeträge aller Positionen
        /// </summary>
        /// <remarks>
        /// Dieses Feld ist NUR bei einem aus der DB geladenen KVA gefüllt!!!
        /// </remarks>
        [DataMember]
        public decimal SaveNetto
        {
            get;
            set;
        }

 



        /// <summary>
        /// Liefert und setzt den Belegrabatttotal
        /// </summary>
        public decimal BelegRabattTotal
        {
            get
            {
                return _BelegRabattTotal;
            }
            set
            {
                _BelegRabattTotal = value;
            }
        }

        /// <summary>
        /// Liefert BEI EINEM AUS DER DB GELADENEN KVA die Summer der Bruttobeträge aller Positionen
        /// </summary>
        /// <remarks>
        /// Dieses Feld ist NUR bei einem aus der DB geladenen KVA gefüllt!!!
        /// </remarks>
        [DataMember]
        public decimal SaveBrutto
        {
            get;
            set;
        }




        #endregion

        #region Set Methoden

     

        /// <summary>
        /// Setzt die Daten des Users der letzten Bearbeitung
        /// </summary>
        /// <param name="_user">Der zu setzende User</param>
        public void SetLastUser(Mitarbeiter _user)
        {
            LastUser = _user;
            LastUseProfil = _user.CurrentProfil;
            //LastUseTime erst beim Speichern
        }

        /// <summary>
        /// Ordnet dem KVA einen Kunden zu
        /// </summary>
        /// <param name="_kunde">der zuzuordnende Kunde</param>
        public void KundeZuordnen(Kunde _kunde)
        {
            KundenAnrede = _kunde.Anrede.Name;
            KundenVorname = _kunde.Vorname;
            KundenName = _kunde.Name;
            KundenRessource = _kunde.SelectedRessource != null ? _kunde.SelectedRessource.RessourceDisplayString : string.Empty;
            KundenFirma = _kunde.Firma;
            KundenStrasse = _kunde.Adresse.Strasse;
            KundenPLZ = _kunde.Adresse.PLZ;
            KundenOrt = _kunde.Adresse.Ort;
            KundenNummer = _kunde.Kundennummer.ToString();
            KundenTelefonnummer = string.Format("{0} {1}", _kunde.Adresse.Vorwahl1, _kunde.Adresse.Telefon1);
            KundenMobilnummer = string.Format("{0} {1}", _kunde.Adresse.Vorwahl2, _kunde.Adresse.Telefon2);
            KundenEMail = _kunde.Adresse.Email;
            if (_kunde.SelectedRessource != null)
            {
                //Thomas: da bei den abgespeicherten KVAs noch nicht die TecDocID für eine eindeutige Identifizierung des Fahrzeugs
                //abgespeichert wird, wurde beim String KundenFahrzeugtyp die "#TecDocID" hinzugefügt
                //dies ist eine vorubergehende Lösung
                //in Zukunft muss die DB für die KVAs erweitert werden, damit auch die TecDocID abgespeichert werden kann
                //dann ist "#TecDocID" nicht mehr notwendig
                if (_kunde.SelectedRessource.RessourcenArt == KundenRessourcenArt.Pkw)
                {
                    KundenFahrzeugtyp = string.Format("{0} {1} {2}", ((KundenPKW)_kunde.SelectedRessource).Pkw.HerstellerBezeichnung,
                                                      ((KundenPKW)_kunde.SelectedRessource).Pkw.ModellBezeichnung,
                                                      ((KundenPKW)_kunde.SelectedRessource).Pkw.Bezeichnung);

                    KTypeId = "#TecDocID" + ((KundenPKW)_kunde.SelectedRessource).Pkw.Id.ToString();
                }
                else if (_kunde.SelectedRessource.RessourcenArt == KundenRessourcenArt.Nkw)
                {
                    KundenFahrzeugtyp = string.Format("{0} {1} {2}", ((KundenNKW)_kunde.SelectedRessource).Nkw.HerstellerBezeichnung,
                                                      ((KundenNKW)_kunde.SelectedRessource).Nkw.ModellBezeichnung,
                                                      ((KundenNKW)_kunde.SelectedRessource).Nkw.Bezeichnung);

                    KTypeId = "#TecDocNKWID" + ((KundenNKW)_kunde.SelectedRessource).Nkw.Id.ToString();
                }

                else if (_kunde.SelectedRessource.RessourcenArt == KundenRessourcenArt.Motor)
                {
                    KundenFahrzeugtyp = string.Format("{0} {1}", ((KundenMotor)_kunde.SelectedRessource).Motor.HerstellerBezeichnung,
                                                      ((KundenMotor)_kunde.SelectedRessource).Motor.Motorcode);

                    KTypeId = "#TecDocMotorID" + ((KundenMotor)_kunde.SelectedRessource).Motor.Id.ToString();
                }
                else if (_kunde.SelectedRessource.RessourcenArt == KundenRessourcenArt.Achse)
                {
                    KundenFahrzeugtyp = string.Format("{0} {1} {2}", ((KundenAchse)_kunde.SelectedRessource).Achse.HerstellerBezeichnung,
                                                      ((KundenAchse)_kunde.SelectedRessource).Achse.ModellBezeichnung,
                                                      ((KundenAchse)_kunde.SelectedRessource).Achse.Bezeichnung);

                    KTypeId = "#TecDocAchseID" + ((KundenAchse)_kunde.SelectedRessource).Achse.Id.ToString();
                }

                if (_kunde.SelectedRessource.RessourcenArt == KundenRessourcenArt.Pkw || _kunde.SelectedRessource.RessourcenArt == KundenRessourcenArt.Nkw)
                {
                    KundenFahrzeugkennzeichen = ((KundenFahrzeug)_kunde.SelectedRessource).Kennzeichen;
                    KundenFahrzeugErstzulassung = ((KundenFahrzeug)_kunde.SelectedRessource).Erstzulassung.HasValue
                                                      ? ((KundenFahrzeug)_kunde.SelectedRessource).Erstzulassung.Value.
                                                            ToString("dd.MM.yyyy")
                                                      : string.Empty;
                    KundenFahrzeugKilometerstand = ((KundenFahrzeug)_kunde.SelectedRessource).Kilometerstand.HasValue
                                                       ? ((KundenFahrzeug)_kunde.SelectedRessource).Kilometerstand.ToString
                                                             ()
                                                       : string.Empty;
                }
            }
            else
            {
                KundenFahrzeugtyp = string.Empty;
                KundenFahrzeugkennzeichen = string.Empty;
                KundenFahrzeugErstzulassung = string.Empty;
                KundenFahrzeugKilometerstand = string.Empty;
            }
            OnSelectedKundeChangedEvent();
        }


        /// <summary>
        /// Entfernt eine Position aus dem KVA
        /// </summary>
        /// <param name="_position">Die zu löschende Position</param>
        public void Remove(KVAPosition _position)
        {
            // no changes when read-only
            if (IsReadOnly)
            {
                return;
            }
            KVAPositionen.Remove(_position);
            FirePropertyChanged();
        }

        #endregion

        #region IEquatable Member

        public bool Equals(KVA _other)
        {
            return Id == _other.Id;
        }

        public override bool Equals(object _obj)
        {
            KVA toCompare = _obj as KVA;
            if (toCompare != null)
                return toCompare.Id == Id;

            return base.Equals(_obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion

        #region Events/Eventhandling

        void OnPositionPropertyChanged(object _sender, PropertyChangedEventArgs _e)
        {
            FirePropertyChanged();

            if (_e.PropertyName != "IsVisibleWarenkorb" && _e.PropertyName != "NotInWarenkorb")
                IsSaved = false;

        }

        private void FirePropertyChanged()
        {
            OnPropertyChanged("KeineSteuerNetto");
            OnPropertyChanged("ErmaeßigteSteuerNetto");
            OnPropertyChanged("ErmaeßigteSteuer");
            OnPropertyChanged("VolleSteuerNetto");
            OnPropertyChanged("VolleSteuer");
            OnPropertyChanged("AltteileSteuerNetto");
            OnPropertyChanged("AltteileSteuer");
            OnPropertyChanged("MaterialNetto");
            OnPropertyChanged("MaterialSteuer");
            OnPropertyChanged("MaterialGesamtUnrabattiert");
            OnPropertyChanged("MaterialRabatt");
            OnPropertyChanged("LohnNetto");
            OnPropertyChanged("LohnSteuer");
            OnPropertyChanged("LohnGesamtUnrabattiert");
            OnPropertyChanged("LohnRabatt");
            OnPropertyChanged("GesamtNetto");
            OnPropertyChanged("GesamtSteuer");
            OnPropertyChanged("GesamtRabatt");
            OnPropertyChanged("GesamtBrutto");
            OnPropertyChanged("AbweichendePreiseinheit");
            OnPropertyChanged("BelegRabattProzent");
            OnPropertyChanged("BelegRabattTotal");
            OnPropertyChanged("LohnMaterialGesamtUnrabattiert");

        }


        #region Implementation of INotifyPropertyChanged

        private void OnPropertyChanged(String _name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #endregion

 
        public bool UseAW
        {
            get { return _UseAW; }
            set { _UseAW = value; }
        }
    }
}