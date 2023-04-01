/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz
 * Modul:    Stammdatenverwaltung   
 * Funktionen:  Kapselt die Informationen und Funktionen eines Kunden
 ************************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PV.DomainObjects.Common;
using PV.DomainObjects.Fahrzeug;
using PV.DomainObjects.Stammdaten;
using System.Runtime.Serialization;
using System.Linq;

namespace PV.DomainObjects.Kunden
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Kunden
    /// </summary>
    [Serializable]
    [DataContract]
    [KnownType( typeof( KundenAchse ) )]
    [KnownType( typeof( KundenMotor ) )]
    [KnownType( typeof( KundenNKW ) )]
    [KnownType( typeof( KundenPKW ) )]
    [KnownType( typeof( KundenRessourceBase ) )]
    public class Kunde : IEquatable<Kunde>
    {
        #region fields
        [DataMember]
        private List<KundenAchse> _AchsenListe;
        [DataMember]
        private List<KundenMotor> _MotorenListe;
        [DataMember]
        private List<KundenPKW> _PkwListe;
        [DataMember]
        private List<KundenNKW> _NkwListe;
        [DataMember]
        private ObservableCollection<KundenRessourceBase> _RessourcenListe;
        [DataMember]
        private string _Firma = string.Empty;
        [DataMember]
        private string _Name = string.Empty;
        [DataMember]
        private string _Vorname = string.Empty;
        #endregion

        #region Constructor

        public Kunde()
        {
            Id = Guid.NewGuid();
            Adresse = new Adresse();
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="_name">Der Name des Kunden</param>
        public Kunde( string _name )
            : this()
        {

            Name = _name;
        }

        #endregion

        #region Props

        /// <summary>
        /// Liefert und setzt das Erstellungsdatum
        /// </summary>
        [DataMember]
        public DateTime CreationDate
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt das Datum der letzten Bearbeitung
        /// </summary>
        [DataMember]
        public DateTime LastUse
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Erstellungsmitarbeiter
        /// </summary>
        [DataMember]
        public Guid CreationUser
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Mitarbeiter der letzten Bearbeitung
        /// </summary>
        [DataMember]
        public Guid LastUseUser
        {
            get;
            set;
        }

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
        /// Liefert und setzt die Guid der Werkstatt
        /// </summary>
        [DataMember]
        public Guid Werkstatt
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Namen
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// Vorname des Kunden
        /// </summary>

        public string Vorname
        {
            get
            {
                return _Vorname;
            }
            set
            {
                _Vorname = value;
            }
        }

        /// <summary>
        /// Anrede des Kunden
        /// </summary>
        [DataMember]
        public Anrede Anrede
        {
            get;
            set;
        }

        /// <summary>
        /// Setzt oder liefert die Adresse
        /// </summary>
        [DataMember]
        public Adresse Adresse
        {
            get;
            set;
        }

        /// <summary>
        /// RessourceUri
        /// </summary>
        [DataMember]
        public string KundeUri
        {
            get;
            set;
        }

        /// <summary>
        /// KundenNummer des Kunden
        /// </summary>
        [DataMember]
        public long Kundennummer
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Namen der Firma des Kunen
        /// </summary>

        public string Firma
        {
            get
            {
                return _Firma;
            }
            set
            {
                _Firma = value;
            }
        }

        /// <summary>
        /// Liefert die Liste der Achsen welche dem Kunden zugeordnet sind
        /// </summary>

        public List<KundenAchse> AchsenListe
        {
            get
            {
                if ( _AchsenListe == null )
                {
                    _AchsenListe = new List<KundenAchse>();
                }
                return _AchsenListe;
            }
        }

        /// <summary>
        /// Liefert die Liste der Motoren welche dem Kunden zugeordnet sind
        /// </summary>

        public List<KundenMotor> MotorenListe
        {
            get
            {
                if ( _MotorenListe == null )
                {
                    _MotorenListe = new List<KundenMotor>();
                }
                return _MotorenListe;
            }
        }

        /// <summary>
        /// Liefert die Liste der PKW welche dem Kunden zugeordnet sind
        /// </summary>

        public List<KundenPKW> PkwListe
        {
            get
            {
                if ( _PkwListe == null )
                {
                    _PkwListe = new List<KundenPKW>();
                }
                return _PkwListe;
            }
        }

        /// <summary>
        /// Liefert die Liste der NKW welche dem Kunden zugeordnet sind
        /// </summary>

        public List<KundenNKW> NkwListe
        {
            get
            {
                if ( _NkwListe == null )
                {
                    _NkwListe = new List<KundenNKW>();
                }
                return _NkwListe;
            }
        }

        /// <summary>
        /// Lifert die Liste aller KundenRessourcen
        /// </summary>

        public ObservableCollection<KundenRessourceBase> RessourcenListe
        {
            get
            {
                if ( _RessourcenListe == null )
                {
                    _RessourcenListe = new ObservableCollection<KundenRessourceBase>();
                }
                return _RessourcenListe;
            }
        }


        [NonSerializedAttribute]
        KundenRessourceBase _SelectedRessource;

        /// <summary>
        /// Liefert und setzt die derzeit selektierte Ressource (Achse, Motor, NKW, PKW)
        /// </summary>
        [DataMember]
        public KundenRessourceBase SelectedRessource
        {
            get
            {
                //Thomas [ Inhalt Ticket#: 1013600 ] Combo Box ist leer obwohl ein Fzg hinterlegt ist.
                if (_SelectedRessource == null && RessourcenListe != null && RessourcenListe.Count > 0)
                    _SelectedRessource = RessourcenListe[0];
                return _SelectedRessource;
            }
            set
            {
                _SelectedRessource = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Fügt dem Kunden eine neue Achse hinzu
        /// </summary>
        /// <param name="_achse">Die Hinzuzufügende Achse</param>
        public void AddAchse( Achse _achse )
        {
            string resUri = string.Format( DomainObjectConstants.AchsenTypRessourceUriSchema, _achse.Id );
            KundenAchse kundenAchse = new KundenAchse
                                          {
                                              Achse = _achse,
                                              RessourceUri = resUri,
                                              RessourcenArt = KundenRessourcenArt.Achse,
                                              RessourceDisplayString =
                                                  string.Format( "{0} {1} {2}", _achse.HerstellerBezeichnung,
                                                                _achse.ModellBezeichnung, _achse.Bezeichnung )
                                          };
            AchsenListe.Add( kundenAchse );
            CalculateRessourceListe();
        }

        /// <summary>
        /// Fügt dem Kunden einen neunen Motor hinzu
        /// </summary>
        /// <param name="_motor">Der hinzuzufügende Motor</param>
        public void AddMotor( Motor _motor )
        {
            string resUri = string.Format( DomainObjectConstants.MotorenTypRessourceUriSchema, _motor.Id );
            KundenMotor kundenMotor = new KundenMotor
                                          {
                                              Motor = _motor,
                                              RessourceUri = resUri,
                                              RessourcenArt = KundenRessourcenArt.Motor,
                                              RessourceDisplayString =
                                                  string.Format( "{0} {1}", _motor.HerstellerBezeichnung,
                                                                _motor.Motorcode )
                                          };
            MotorenListe.Add( kundenMotor );
            CalculateRessourceListe();
        }

        /// <summary>
        /// Fügt dem Kunden einen neuen NKW hinzu
        /// </summary>
        /// <param name="_nkw">Der hinzuzufügende NKW</param>
        /// <param name="_kennzeichen">Das Kennzeichen</param>
        /// <param name="_erstzulassung">Das Datum der Erstzulassung</param>
        /// <param name="_kilometerstand">Der Kilometerstand</param>
        public void AddNkw( NKWTyp _nkw, String _kennzeichen, DateTime? _erstzulassung, int _kilometerstand )
        {
            //Überprüfen ob das Fahrzeug mit diesem Kennzeichen und KTypID schon dem Kunden zugeordnet ist
            if (!string.IsNullOrEmpty(_kennzeichen) && NkwListe != null && NkwListe.Count > 0)
            {
                if ((from x in NkwListe
                     where x.Kennzeichen == _kennzeichen &&
                     x.Nkw.Id == _nkw.Id
                     select x).Count() > 0)
                    return;
            }
            else if (NkwListe != null && NkwListe.Count > 0)
            {
                if ((from x in NkwListe
                     where
                      x.Kennzeichen == "" &&
                     x.Nkw.Id == _nkw.Id
                     select x).Count() > 0)
                    return;
            }

            string resUri = string.Format( DomainObjectConstants.NKWTypRessourceUriSchema, _nkw.Id );
            KundenNKW kundenNkw = new KundenNKW
                                      {
                                          Nkw = _nkw,
                                          Erstzulassung = _erstzulassung,
                                          Kennzeichen = _kennzeichen,
                                          Kilometerstand = _kilometerstand,
                                          RessourcenArt = KundenRessourcenArt.Nkw,
                                          RessourceUri = resUri,
                                          RessourceDisplayString =
                                                  string.Format( "{0} {1} {2}", _nkw.HerstellerBezeichnung,
                                                                _nkw.ModellBezeichnung, _nkw.Bezeichnung )
                                      };
            if ( !string.IsNullOrEmpty( _kennzeichen ) )
            {
                kundenNkw.RessourceDisplayString = string.Format( "{0} ({1})", kundenNkw.RessourceDisplayString,
                                                                 _kennzeichen );
            }
            NkwListe.Add( kundenNkw );
            CalculateRessourceListe();
        }

        /// <summary>
        /// Fügt dem Kunden einen neuen PKW hinzu
        /// </summary>
        /// <param name="_pkw">Der hinzuzufügende PKW</param>
        /// <param name="_kennzeichen">Das Kennzeichen</param>
        /// <param name="_erstzulassung">Das Datum der Erstzulassung</param>
        /// <param name="_kilometerstand">Der Kilometerstand</param>
        public void AddPkw( PKWTyp _pkw, String _kennzeichen, DateTime? _erstzulassung, int _kilometerstand )
        {
            //Überprüfen ob das Fahrzeug mit diesem Kennzeichen und KTypID schon dem Kunden zugeordnet ist
            if (!string.IsNullOrEmpty(_kennzeichen) && PkwListe!= null && PkwListe.Count>0)
            {
                if((from x in PkwListe
                           where x.Kennzeichen == _kennzeichen && 
                           (x.Pkw.Id == _pkw.Id)
                                select x).Count() >0)
                    return;
            }
            else if (PkwListe!= null && PkwListe.Count>0)
            {
                if((from x in PkwListe
                           where
                            x.Kennzeichen == "" &&
                           (x.Pkw.Id == _pkw.Id)
                                select x).Count() >0)
                    return;
            }

            //if (!string.IsNullOrEmpty(_kennzeichen) && PkwListe != null && PkwListe.Count > 0)
            //{
            //    if ((from x in PkwListe
            //            where x.Kennzeichen == _kennzeichen &&
            //                  (x.Pkw != null && x.Pkw.Id == _pkw.Id)
            //            select x).Count() > 0)
            //        return;
            //}
            //else if (PkwListe != null && PkwListe.Count > 0)
            //{
            //    if ((from x in PkwListe
            //            where
            //                x.Kennzeichen == "" &&
            //                (x.Pkw != null && x.Pkw.Id == _pkw.Id)
            //            select x).Count() > 0)
            //        return;
            //}

            string resUri = string.Format( DomainObjectConstants.PKWTypRessourceUriSchema, _pkw.Id );
            KundenPKW kundenPkw = new KundenPKW
                                      {
                                          Pkw = _pkw,
                                          Erstzulassung = _erstzulassung,
                                          Kennzeichen = _kennzeichen,
                                          Kilometerstand = _kilometerstand,
                                          RessourcenArt = KundenRessourcenArt.Pkw,
                                          RessourceUri = resUri,
                                          RessourceDisplayString =
                                                  string.Format( "{0} {1} {2}", _pkw.HerstellerBezeichnung,
                                                                _pkw.ModellBezeichnung, _pkw.Bezeichnung )

                                      };
            if ( !string.IsNullOrEmpty( _kennzeichen ) )
            {
                kundenPkw.RessourceDisplayString = string.Format( "{0} ({1})", kundenPkw.RessourceDisplayString,
                                                                 _kennzeichen );
            }
            PkwListe.Add( kundenPkw );
            CalculateRessourceListe();
        }

        /// <summary>
        /// Kalkuliert die Ressourcenliste neu
        /// </summary>
        public void CalculateRessourceListe()
        {
            RessourcenListe.Clear();
            foreach ( KundenAchse kundenAchse in AchsenListe )
            {
                RessourcenListe.Add( kundenAchse );
            }
            foreach ( KundenMotor kundenMotor in MotorenListe )
            {
                RessourcenListe.Add( kundenMotor );
            }
            foreach ( KundenNKW kundenNkw in NkwListe )
            {
                RessourcenListe.Add( kundenNkw );
            }
            foreach ( KundenPKW kundenPkw in PkwListe )
            {
                RessourcenListe.Add( kundenPkw );
            }
        }

        #endregion

        #region IEquatable<Kunde> Member

        public bool Equals( Kunde other )
        {
            return Id == other.Id;
        }

        public override bool Equals( object obj )
        {
            Kunde toCompare = obj as Kunde;
            if ( toCompare != null )
                return toCompare.Id == Id;

            return base.Equals( obj );
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion
    }
}
