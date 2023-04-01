/***************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Stammdatenverwaltung
 * Funktionen:  Kapselt die Informationen, welche PV im Profil zusammenfasst.
 **************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using PV.DomainObjects.Warenkorb;
using GlobalEnums;

namespace PV.DomainObjects.Stammdaten
{
	/// <summary>
	/// Kapselt die Informationen, welche PV im Profil zusammenfasst
	/// </summary>
	[Serializable]
	[DataContract]
	public class Profil : INotifyPropertyChanged
	{
		#region Fields

		private List<Konzeptkennzeichen> _Konzeptkennzeichen = new List<Konzeptkennzeichen>();
        public List<decimal> _KonzeptkennzeichenRaw = new List<decimal>();
        private string _Bezeichnung = string.Empty;
		private string _LogoPfad = string.Empty;
		private string _Lizenzschluessel = string.Empty;
		private string _PVFirmaName = string.Empty;
		private string _PVStandortName = string.Empty;
		private string _PVStandortStrasse = string.Empty;
        private string _CSO = string.Empty;
		private string _PVStandortPLZ = string.Empty;
		private string _PVStandortTelefon = string.Empty;
		private string _PVStandortFax = string.Empty;
		private string _PVAbteilungName = string.Empty;
		private string _VersandAdresseStrasse = string.Empty;
		private string _VersandAdressePLZ = string.Empty;
		private string _VersandAdresseOrt = string.Empty;
		private string _Sprachschuessel = string.Empty;
		private string _Bundeslandschuessel = string.Empty;
		private string _Landkreisschuessel = string.Empty;
		private string _EmailHandelspartner = string.Empty;
		private string _VBA = string.Empty;
		private string _Firmenname = string.Empty;
		private string _Firmenzusatz = string.Empty;
		private string _InhaberGeschaeftsfuehrer = string.Empty;
		private string _Webseite = string.Empty;
		private string _Bank = string.Empty;
		private string _Steuernummer = string.Empty;
		private string _UStID = string.Empty;
		private string _Sitz = string.Empty;
		private string _RegisterGerichtUndNr = string.Empty;
		private bool _KonzeptMeinewerkstatt;
		private bool _KonzeptAutofit;
		private bool _KonzeptAutoprofi;
		private bool _KonzeptTruckprofi;
		private bool _KonzeptPvFlex;
		private Version _AktuelleVersion;
		private int _AnzahlTrainingsCardMitarbeiter;
		private int _AnzahlLoeschungenTcMitarbeiter;
        private string _UsedImportschema = string.Empty;
        private string _UsedImportPfad;
		#endregion

		/// <summary>
		/// Konstruktor
		/// </summary>
		public Profil()
		{
			Id = Guid.NewGuid();
			Adresse = new Adresse();
        }

		#region Properties

		[DataMember]
		public bool IstKundeVonHandelspartner
		{
			get;
			set;
		}

		[DataMember]
		public int HandelsPartnerOriginalVersandAdresseID
		{
			get;
			set;
		}

		[DataMember]
		public int BestellID
		{
			get;
			set;
		}
		/// <summary>
		/// Gibt an, ob das Profil gespeichert werden muss
		/// </summary>
		[DataMember]
		public bool Dirty
		{
			get;
			set;
		}

        /// <summary>
        /// Gibt an, welches Importschema fixiert wurde
        /// </summary>
        public string UsedImportschema
        {
            get
            {
                return _UsedImportschema;
            }
            set
            {
                _UsedImportschema = value;
            }
        }

        /// <summary>
        /// Gibt an, welcher ImportPfad fixiert wurde
        /// </summary>
        public string UsedImportPfad
        {
            get
            {
                return _UsedImportPfad;
            }
            set
            {
                _UsedImportPfad = value;
            }
        }

        /// <summary>
        /// Gibt an, ob der WK nicht sortiert werden soll
        /// </summary>
        public Boolean? WarenkorbNichtSortieren { get; set; }

        /// <summary>
        /// Übergabe von CustomerNumber wie z.B. StahlgruberKundennummer
        /// </summary>
        [DataMember]
        public List<SupplementaryParameterTypeContext> SupplementaryParameterType
        {
            get;
            set;
        }

        /// <summary>
        /// z.B. PV oder Stahlgruber, kommt von RoutingID
        /// </summary>
        [DataMember]
        public int Supplier { get; set; }

		#region Lokal gespeichert

		/// <summary>
		/// Liefert und setzt die ID in der Lokalen Datenbank
		/// </summary>
		[DataMember]
		public Guid Id
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die frei wählbare Bezeichnung des Profils
		/// </summary>
		[DataMember]
		public string Bezeichnung
		{
			get
			{
				return _Bezeichnung;
			}
			set
			{
				_Bezeichnung = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die Information, ob das Profil aktiv ist
		/// </summary>
		[DataMember]
		public bool IsActive
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt den Pfad wo auf einem Rechenr mit installierten
		/// Kompass sich die Logo-Bilddatei befindet
		/// </summary>
		[DataMember]
		public string LogoPfad
		{
			get
			{
				return _LogoPfad;
			}
			set
			{
				_LogoPfad = value;
			}
		}

		/// <summary>
		/// Gibt an ob es eine abweichende Lieferadresse für Plus eingetragen ist 
		/// </summary>
		[DataMember]
		public bool PlusAdresseAbweichend
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt den Empfänger der abweichende Lieferadresse für Plus
		/// </summary>
		[DataMember]
		public string PlusAdresseEmpfaenger
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt den Empfängerzusatz der abweichende Lieferadresse für Plus
		/// </summary>
		[DataMember]
		public string PlusAdresseEmpfaengerZusatz
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die Adresse der abweichende Lieferadresse für Plus
		/// </summary>
		[DataMember]
		public string PlusAdresseStrasse
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt den Adresszusatz der abweichende Lieferadresse für Plus
		/// </summary>
		[DataMember]
		public string PlusAdresseAdresszusatz
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die PLZ der abweichende Lieferadresse für Plus
		/// </summary>
		[DataMember]
		public string PlusAdressePLZ
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt den Ort der abweichende Lieferadresse für Plus
		/// </summary>
		[DataMember]
		public string PlusAdresseOrt
		{
			get;
			set;
		}

		[DataMember]
		public DateTime PlusAnmeldeDatum
		{
			get;
			set;
		}

		[DataMember]
		public DateTime PlusMitgliedsDatum
		{
			get;
			set;
		}

		#endregion

		#region Lokal und bei PV gespeichert

		/// <summary>
		/// Liefert und setzt die ID in der PV Datenbank
		/// </summary>
		[DataMember]
		public int ProfilId
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt den Lizenzschlüssel zu diesem Profil
		/// </summary>
		[DataMember]
		public string Lizenzschluessel
		{
			get
			{
				return _Lizenzschluessel;
			}
			set
			{
				_Lizenzschluessel = value;
			}
		}

		#endregion

		#region auf PV Server

		#region PVDaten

		#region Tabelle Standorte

		/// <summary>
		/// Liefert und setzt die FirmenID der PV Niederlassung
		/// </summary>
		[DataMember]
		public int PVFirmaID
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die StandortID der PV Niederlassung
		/// </summary>
		[DataMember]
		public int PVStandortID
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die Firmennamen der PV Niederlassung
		/// </summary>
		[DataMember]
		public string PVFirmaName
		{
			get
			{
				return _PVFirmaName;
			}
			set
			{
				_PVFirmaName = value;
			}
		}

		/// <summary>
		/// Liefert und setzt den Standortnamen der PV Niederlassung
		/// </summary>
		[DataMember]
		public string PVStandortName
		{
			get
			{
				return _PVStandortName;
			}
			set
			{
				_PVStandortName = value;
			}
		}

		/// <summary>
		/// Liefert und setzt den Straßennamen der PV Niederlassung
		/// </summary>
		[DataMember]
		public string PVStandortStrasse
		{
			get
			{
				return _PVStandortStrasse;
			}
			set
			{
				_PVStandortStrasse = value;
			}
		}

        /// <summary>
        /// Liefert die alternative CSO aus Profile.CSO
        /// </summary>
        [DataMember]
        public string CSO
        {
            get
            {
                return _CSO;
            }
            set
            {
                _CSO = value;
            }
        }

		/// <summary>
		/// Liefert und setzt die PLZ der PV Niederlassung
		/// </summary>
		[DataMember]
		public string PVStandortPLZ
		{
			get
			{
				return _PVStandortPLZ;
			}
			set
			{
				_PVStandortPLZ = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die Telefonnummer der PV Niederlassung
		/// </summary>
		[DataMember]
		public string PVStandortTelefon
		{
			get
			{
				return _PVStandortTelefon;
			}
			set
			{
				_PVStandortTelefon = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die Faxnummer der PV Niederlassung
		/// </summary>
		[DataMember]
		public string PVStandortFax
		{
			get
			{
				return _PVStandortFax;
			}
			set
			{
				_PVStandortFax = value;
			}
		}

		#endregion

		/// <summary>
		/// Liefert und setzt die ID der Abteilung der PV Niederlassung
		/// </summary>
		[DataMember]
		public int PVAbteilungID
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt den Namen der Abteilung der PV Niederlassung
		/// </summary>
		[DataMember]
		public string PVAbteilungName
		{
			get
			{
				return _PVAbteilungName;
			}
			set
			{
				_PVAbteilungName = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die ID der Versandadresse
		/// </summary>
		[DataMember]
		public int VersandAdresseID
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert die OnlineID
		/// </summary>
		[DataMember]
		public string OnlineID
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die Straße der Versandadresse
		/// </summary>
		[DataMember]
		public string VersandAdresseStrasse
		{
			get
			{
				return _VersandAdresseStrasse;
			}
			set
			{
				_VersandAdresseStrasse = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die PLZ der Versandadresse
		/// </summary>
		[DataMember]
		public string VersandAdressePLZ
		{
			get
			{
				return _VersandAdressePLZ;
			}
			set
			{
				_VersandAdressePLZ = value;
			}
		}

		/// <summary>
		/// Liefert und setzt den Ort der Versandadresse
		/// </summary>
		[DataMember]
		public string VersandAdresseOrt
		{
			get
			{
				return _VersandAdresseOrt;
			}
			set
			{
				_VersandAdresseOrt = value;
			}
		}

		/// <summary>
		/// Liefert und setzt den Ort der Versandadresse
		/// </summary>
		[DataMember]
		public string EmailHandelspartner
		{
			get
			{
				return _EmailHandelspartner;
			}
			set
			{
				_EmailHandelspartner = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die ID für MeineWerkstatt
		/// </summary>
		[DataMember]
		public int MeineWerkstattID
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die Information ob das Profil für OnlineBestellungen gesperrt ist
		/// </summary>
		[DataMember]
		public bool GesperrtFuerOnlineBestellung
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die Information ob das Profil für PV-Training gesperrt ist
		/// </summary>
		[DataMember]
		public bool GesperrtFuerPVTraining
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die AbsatzGruppe des Profils
		/// </summary>
		[DataMember]
		public int AbsatzGruppe
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die Absatzgruppenart des Profils
		/// </summary>
		[DataMember]
		public int AbsatzGruppeArt
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die Kundengruppe des Profils
		/// </summary>
		[DataMember]
		public int Kundengruppe
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die Region des Profils
		/// </summary>
		[DataMember]
		public int Region
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt den Waehrungsschlüssel des Profils
		/// </summary>
		[DataMember]
		public int WaehrungsSchluessel
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt den Sprachschlüssel des Profils
		/// </summary>
		[DataMember]
		public string Sprachschuessel
		{
			get
			{
				return _Sprachschuessel;
			}
			set
			{
				_Sprachschuessel = value;
			}
		}

		/// <summary>
		/// Liefert und setzt den Bundeslandschlüssel des Profils
		/// </summary>
		[DataMember]
		public string Bundeslandschuessel
		{
			get
			{
				return _Bundeslandschuessel;
			}
			set
			{
				_Bundeslandschuessel = value;
			}
		}

		/// <summary>
		/// Liefert und setzt den Landkreisschlüssel des Profils
		/// </summary>
		[DataMember]
		public string Landkreisschuessel
		{
			get
			{
				return _Landkreisschuessel;
			}
			set
			{
				_Landkreisschuessel = value;
			}
		}

		/// <summary>
		/// Liefert und setzt den VBA des Profils
		/// </summary>
		[DataMember]
		public string VBA
		{
			get
			{
				return _VBA;
			}
			set
			{
				_VBA = value;
			}
		}

        [DataMember]
	    public string ImageUrlActive
	    {
	        get; set;
	    }

        [DataMember]
        public string ImageUrlOver
        {
            get;
            set;
        }

        [DataMember]
        public string ImageUrlPassive
        {
            get;
            set;
        }


		#endregion

		#region Firmendaten

		/// <summary>
		/// Liefert und setzt die Kundennummer
		/// </summary>
		[DataMember]
		public int Kundennummer
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt den Firmennamen
		/// </summary>
		[DataMember]
		public string Firmenname
		{
			get
			{
				return _Firmenname;
			}
			set
			{
				_Firmenname = value;
			}
		}

		/// <summary>
		/// Liefert und setzt den Firmenzusatz
		/// </summary>
		[DataMember]
		public string Firmenzusatz
		{
			get
			{
				return _Firmenzusatz;
			}
			set
			{
				_Firmenzusatz = value;
			}
		}

		/// <summary>
		/// Liefert und setzt den Namen des Inhabers oder Geschäftsführers
		/// </summary>
		[DataMember]
		public string InhaberGeschaeftsfuehrer
		{
			get
			{
				return _InhaberGeschaeftsfuehrer;
			}
			set
			{
				_InhaberGeschaeftsfuehrer = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die Information, ob <see cref="InhaberGeschaeftsfuehrer"/> 
		/// der Name des Inhabers oder Geschäftsführers ist.
		/// Inhaber = true
		/// Geschäftsführer = false
		/// </summary>
		[DataMember]
		public bool? IstInhaber
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die Adresse
		/// </summary>
		[DataMember]
		public Adresse Adresse
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die Adresse der Webseite
		/// </summary>
		[DataMember]
		public string Webseite
		{
			get
			{
				return _Webseite;
			}
			set
			{
				_Webseite = value;
			}
		}

		/// <summary>
		/// Liefert und setzt den Namen der Bank
		/// </summary>
		[DataMember]
		public string Bank
		{
			get
			{
				return _Bank;
			}
			set
			{
				_Bank = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die Bankleitzahl der Bank
		/// </summary>
		/// 

		private string _blz;

		[DataMember]
		public string Blz
		{
			get { return _blz; }
			set { _blz = value; }
		}

		/// <summary>
		/// Liefert und setzt IBAN 
		/// </summary>
		[DataMember]
		public string IBAN
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt BIC
		/// </summary>
		[DataMember]
		public string BIC
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die Kontonumer
		/// </summary>
		[DataMember]
		public string Kontonummer
		{
			get;
			set;
		}

        /// <summary>
        /// Liefert und setzt die MeineArtikelKategorien
        /// </summary>
        [DataMember]
        public List<MyArtikelKategorien> MeineArtikelKategorien
        {
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt die Steuernummer
		/// </summary>
		[DataMember]
		public string Steuernummer
		{
			get
			{
				return _Steuernummer;
			}
			set
			{
				_Steuernummer = value;
			}
		}

		bool _isPitStop;
		/// <summary>
		/// Kunde ist Pitstop - Vertragsanfang und -ende dürfen nicht überprüft werden
		/// Das Vorhandensein des Kennzeichens ist massgeblich
		/// </summary>
		[DataMember]
		public bool IsPitStop
		{
			get
			{
				return _isPitStop;
			}
			set
			{
				_isPitStop = value;
			}
		}

        bool _hatTraining;
        /// <summary>
        /// Kunde hat HatTraining
        /// </summary>
        [DataMember]
        public bool HatKeinTraining
        {
            get
            {
                return _hatTraining;
            }
            set
            {
                _hatTraining = value;
            }
        }

		bool _isHandelspartner;
		/// <summary>
		/// Ist Handelspartner
		/// </summary>
		[DataMember]
		public bool IsHandelspartner
		{
			get
			{
				return _isHandelspartner;
			}
			set
			{
				_isHandelspartner = value;
			}
		}

		bool _IsPraesentationsmodus;
		/// <summary>
		/// Ist Handelspartner
		/// </summary>
		[DataMember]
		public bool IsPraesentationsmodus
		{
			get
			{
				return _IsPraesentationsmodus;
			}
			set
			{
				_IsPraesentationsmodus = value;
			}
		}


		/// <summary>
		/// Liefert und setzt die USt-ID
		/// </summary>
		[DataMember]
		public string UStId
		{
			get
			{
				return _UStID;
			}
			set
			{
				_UStID = value;
			}
		}

		/// <summary>
		/// Liefert und setzt den Sitz
		/// </summary>
		[DataMember]
		public string Sitz
		{
			get
			{
				return _Sitz;
			}
			set
			{
				_Sitz = value;
			}
		}

		/// <summary>
		/// Liefert und setzt das Registergericht und die Registernummer
		/// </summary>
		[DataMember]
		public string RegisterGerichtUndNr
		{
			get
			{
				return _RegisterGerichtUndNr;
			}
			set
			{
				_RegisterGerichtUndNr = value;
			}
		}

		/// <summary>
		/// Liefert und setzt das Logo in binärer Form, um es zum PV-Server zu übertragen
		/// </summary>
		[DataMember]
		public Byte[] Logo
		{
			get;
			set;
		}

        [DataMember]
        public string ProfileHash
        {
            get;
            set;
        }

        [DataMember]
        public string ProfileHashPresentation
        {
            get;
            set;
        }

        private string _lizenzHash;

        [DataMember]
        public string LizenzHash
        {
            get
            {
                return _lizenzHash;

            }
            set
            {
                _lizenzHash = value;
            }
        }

		/// <summary>
		/// Liefert die Liste der Konzeptkennzeichen zu diesem Profil
		/// </summary>
		[DataMember]
		public List<Konzeptkennzeichen> Konzeptkennzeichen
		{
			get
			{
				return _Konzeptkennzeichen;
			}
			set
			{
				_Konzeptkennzeichen = value;
			}
		}

        public List<Konzeptkennzeichen> KonzeptkennzeichenInEinstellungen
        {
            get
            {
                return _Konzeptkennzeichen.Where(x => x.IstSichtbar).ToList();
            }
        }

	    [DataMember]
	    public List<decimal> KonzeptkennzeichenRaw
	    {
	        get
	        {
	            return _KonzeptkennzeichenRaw;
	        }
	        set
	        {
	            _KonzeptkennzeichenRaw = value;
	        }
	    }

	    /// <summary>
		/// Liefert und setzt die verwendete Versionsnummer
		/// </summary>
		[DataMember]
		public Version AktuelleVersion
		{
			get
			{
				return _AktuelleVersion;
			}
			set
			{
				_AktuelleVersion = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die Anzahl der Mitarbeiter zur TrainingsCard
		/// </summary>
		[DataMember]
		public int AnzahlTrainingsCardMitarbeiter
		{
			get
			{
				return _AnzahlTrainingsCardMitarbeiter;
			}
			set
			{
				_AnzahlTrainingsCardMitarbeiter = value;
			}
		}

		[DataMember]
		public int AnzahlLoeschungenTcMitarbeiter
		{
			get
			{
				return _AnzahlLoeschungenTcMitarbeiter;
			}
			set
			{
				_AnzahlLoeschungenTcMitarbeiter = value;
			}
		}
		#endregion

		#endregion

		#region Konzeptkennzeichen
		/*
            Case 1: [WENN Konzeptkennzeichen=Autofit UND meinewerkstatt], DANN NUR Anzeige Marketing Reiter mit Autofit Logo.
            Case 2: [WENN Konzeptkennzeichen=Autoprofi UND meinewerkstatt], DANN NUR Anzeige Marketing Reiter mit Autoprofi Logo.
            Case 3: [WENN Konzeptkennzeichen=Truckprofi UND Autoprofi], DANN Anzeige Marketing Reiter mit Autoprofi Logo UND Anzeige Marketing Reiter mit Truckprofi Logo.
            Case 4: [WENN Konzeptkennzeichen=Truckprofi UND Autofit], DANN Anzeige Marketing Reiter mit Autofit Logo UND Anzeige Marketing Reiter mit Truckprofi Logo.
            Case 5: [WENN Konzeptkennzeichen=meinewerkstatt], DANN Anzeige Marketing Reiter mit meinewerkstatt Logo.
            Case 6: [WENN Konzeptkennzeichen=Autofit], DANN Anzeige Marketing Reiter mit Autofit Logo.
            Case 7: [WENN Konzeptkennzeichen=Autoprofi], DANN Anzeige Marketing Reiter mit Autoprofi Logo.
            */

		/// <summary>
		/// Liefert und setzt die Info, ob die Werkstatt in diesem Profil das Konzeptkennzeichen MeineWerkstatt hat
		/// </summary>
		[DataMember]
		public bool KonzeptMeinewerkstatt
		{
			get
			{
				return _KonzeptMeinewerkstatt;
			}
			set
			{
				if (_KonzeptMeinewerkstatt != value)
				{
					_KonzeptMeinewerkstatt = value;
					OnPropertyChanged("KonzeptMeinewerkstatt");
				}
			}
		}

		/// <summary>
		/// Liefert und setzt die Info, ob die Werkstatt in diesem Profil das Konzeptkennzeichen Autofit hat
		/// </summary>
		[DataMember]
		public bool KonzeptAutofit
		{
			get
			{
				return _KonzeptAutofit;
			}
			set
			{
				if (_KonzeptAutofit != value)
				{
					_KonzeptAutofit = value;
					OnPropertyChanged("KonzeptAutofit");
				}
			}
		}

		/// <summary>
		/// Liefert und setzt die Info, ob die Werkstatt in diesem Profil das Konzeptkennzeichen Autofit hat
		/// </summary>
		[DataMember]
		public bool KonzeptPvFlex
		{
			get
			{
				return _KonzeptPvFlex;
			}
			set
			{
				if (_KonzeptPvFlex != value)
				{
					_KonzeptPvFlex = value;
					OnPropertyChanged("KonzeptPvFlex");
				}
			}
		}


		/// <summary>
		/// Liefert und setzt die Info, ob die Werkstatt in diesem Profil das Konzeptkennzeichen Autoprofi hat
		/// </summary>
		[DataMember]
		public bool KonzeptAutoprofi
		{
			get
			{
				return _KonzeptAutoprofi;
			}
			set
			{
				if (_KonzeptAutoprofi != value)
				{
					_KonzeptAutoprofi = value;
					OnPropertyChanged("KonzeptAutoprofi");
				}
			}
		}

		/// <summary>
		/// Liefert und setzt die Info, ob die Werkstatt in diesem Profil das Konzeptkennzeichen Truckprofi hat
		/// </summary>
		[DataMember]
		public bool KonzeptTruckprofi
		{
			get
			{
				return _KonzeptTruckprofi;
			}
			set
			{
				if (_KonzeptTruckprofi != value)
				{
					_KonzeptTruckprofi = value;
					OnPropertyChanged("KonzeptTruckprofi");
				}
			}
		}

		#endregion

		#region Plus
		[DataMember]
		public bool PlusBestellungDeaktiviert
		{
			get;
			set;
		}

		#endregion

		#endregion

		/// <summary>
		/// Liefert die Information, ob ein Profil ein bestimmtes Konzeptkennzeichen hat
		/// </summary>
		/// <param name="_kzp">Das gesuchte Konzeptkennzeichen</param>
		/// <returns>True, wenn das Profil dieses Konzeptkennzeichen hat</returns>
		public bool HasKonzeptkennzeichen(EKonzeptkennzeichen _kzp)
		{
			if (Konzeptkennzeichen.Count > 0)
			{
				return (from konzeptkennzeichen in Konzeptkennzeichen
						where konzeptkennzeichen.KonzeptKzID == (int)_kzp &&
						konzeptkennzeichen.IsValid
						select konzeptkennzeichen).FirstOrDefault() != null;
			}
			return false;
		}

		public bool HasIbanBic()
		{
			if (string.IsNullOrEmpty(IBAN) || IBAN.Trim() == string.Empty) return false;
			if (string.IsNullOrEmpty(BIC) || BIC.Trim() == string.Empty) return false;
			return true;
		}

		public Konzeptkennzeichen FindKonzeptkennzeichen(EKonzeptkennzeichen _kzp)
		{

			if (Konzeptkennzeichen.Count > 0)
			{
				var kkz = (from konzeptkennzeichen in Konzeptkennzeichen
						where konzeptkennzeichen.KonzeptKzID == (int)_kzp &&
						konzeptkennzeichen.IsValid
						select konzeptkennzeichen).FirstOrDefault();

                //if (kkz == null &&_kzp == EKonzeptkennzeichen.PV_KOMPASS)
                //    return FindKonzeptkennzeichen(EKonzeptkennzeichen.PV_KOMPASS_CONNECT);

			    return kkz;
			}

			return null;
		}

		/// <summary>
		/// Setzt die Properties für die Konzeptkennzeichen
		/// </summary>
		public void DetermineKonzepte()
		{
			KonzeptMeinewerkstatt = HasKonzeptkennzeichen(EKonzeptkennzeichen.Meinewerkstatt);
			KonzeptAutofit = HasKonzeptkennzeichen(EKonzeptkennzeichen.Autofit);
			KonzeptAutoprofi = HasKonzeptkennzeichen(EKonzeptkennzeichen.Autoprofi);
			KonzeptTruckprofi = HasKonzeptkennzeichen(EKonzeptkennzeichen.Truckprofi);
		}

		/// <summary>
		/// Löst das PropertyChangedEvent aus
		/// </summary>
		/// <param name="_name">Der Name der Property welche sich geändert hat</param>
		private void OnPropertyChanged(String _name)
		{
			if (_PropertyChanged != null)
			{
				_PropertyChanged(this, new PropertyChangedEventArgs(_name));
			}
		}

		/// <summary>
		/// Extrahiert die VDBUserInfo und liefert ein VDBUserInfoObjekt
		/// </summary>
		/// <returns>Ein VDBUserInfo-Objekt</returns>
		public VdbUserInfo GetVdbUserInfo()
		{
			VdbUserInfo back = new VdbUserInfo();
			back.Abteilung = PVAbteilungID;
			back.Firma = PVFirmaID;
			back.Kundenummer = Kundennummer;
			back.Standort = PVStandortID;
			back.Versandadresse = VersandAdresseID;
            back.HandelspartnerVDBProvider = IsHandelspartner;
            back.Supplier = Supplier;
            back.SupplementaryParameterType = SupplementaryParameterType;
			return back;
		}

		[NonSerialized]
		private PropertyChangedEventHandler _PropertyChanged;
		/// <summary>
		/// Wird geworfen, wenn sich ein Property geändert hat
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				_PropertyChanged = (PropertyChangedEventHandler)Delegate.Combine(_PropertyChanged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				_PropertyChanged = (PropertyChangedEventHandler)Delegate.Remove(_PropertyChanged, value);
			}
		}

        [DataMember]
        public ZahlungsartInfos Zahlungsartinfos
        {
            get;
            set;
        }
    }
}
