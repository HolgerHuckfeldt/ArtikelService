/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Artikel-Identifikation   
 * Funktionen:  Kapselt die Informationen und Funktionen eines Artikels
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text;
using PV.DomainObjectInterfaces;
using PV.DomainObjects.Arbeitswerte;
using PV.DomainObjects.Common;
using PV.DomainObjects.Warenkorb;
using PV.Utilities.Misc;
using PV.DomainObjects.Stammdaten;

namespace PV.DomainObjects.Artikel
{

    /// <summary>
    /// Kapselt die Informationen und Funktionen eines Artikels
    /// </summary>
    [DataContract]
    [Serializable]
    [KnownType(typeof(ArtikelKatalogIdent))]
    [KnownType(typeof(StuecklistenArtikel))]
    [KnownType(typeof(VerwandterArtikel))]
    [KnownType(typeof(IncentiveArtikel))]
    [KnownType(typeof(TopProdukt))]
    public class Artikel : ArtikelKatalogIdent, INotifyPropertyChanged, IKVAItem
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region events
        public virtual event PropertyChangedEventHandler PropertyChanged;

        public delegate void VerfuegbarkeitChanged();

        public VerfuegbarkeitChanged verfuegbarkeitChanged = null;

        protected void FirePCEvent(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            //else
            //    Log.Debug("PropertyChanged is null");

        }
        #endregion

        #region Fields


        /*
         * START VDB-OnDemandSection
         */

        //private Boolean _VdbDataLoaded;
        //private Boolean _VdbDataLoadingFailed;
        private List<Object> _CurrentFrontendObservers;

        private static List<Artikel> _FrontendObservedArticles;

        private static void AddFrontendObservedArticle(Artikel artikel)
        {
            if (_FrontendObservedArticles == null)
                _FrontendObservedArticles = new List<Artikel>();

            if ((from o in _FrontendObservedArticles where ReferenceEquals(artikel, o) select o).FirstOrDefault() == null)
            {
                _FrontendObservedArticles.Add(artikel);
                OnFrontendObservedArticlesChanged();
            }
        }

        private static void RemoveFrontendObservedArticle(Artikel artikel)
        {
            if (_FrontendObservedArticles == null)
                _FrontendObservedArticles = new List<Artikel>();

            if ((from o in _FrontendObservedArticles where ReferenceEquals(artikel, o) select o).FirstOrDefault() != null)
            {
                _FrontendObservedArticles.Remove(artikel);
                OnFrontendObservedArticlesChanged();
            }
        }

        private static void OnFrontendObservedArticlesChanged()
        {
            if (FrontendObservedArticlesChanged != null)
            {
                FrontendObservedArticlesChanged(null, new EventArgs());
            }
        }

        public static event EventHandler FrontendObservedArticlesChanged;

        public static List<Artikel> FrontendObservedArticles
        {
            get
            {
                return _FrontendObservedArticles;
            }
        }

        /*
         * END VDB-OnDemandSection
         */

        private IList<KeyValuePair<string, string>> _SofortArtikelInformationen;
        private IList<KeyValuePair<string, string>> _ArtikelInformationen;
        private IList<KeyValuePair<string, string>> _SofortArtikelInformationenOhneRTF;
        private IList<ArtikelInformationenFahrzeugbezogen> _SofortArtikelInformationenFahrzeugbezogenOhneRTF;
        private IList<KeyValuePair<string, string>> _ArtikelInformationenOhneRTF;
        private IList<KeyValuePair<string, string>> _ArtikelInformationenMitHTML;

        private PVItemListe<Artikel> _Stueckliste;

        private GefahrengutHinweise _GefahrengutHinweise;

        [DataMember]
        private List<VdbVerfuegbarkeitDetails> _VerfuegbarkeitDetaillist;

        [DataMember]
        private wkVerfuegbarkeit _Verfuegbarkeit;
        [DataMember]
        private int _SortVerfuegbarkeit;
        [DataMember]
        private wkVerfuegbarkeit _AbholVerfuegbarkeit;

        [DataMember]
        private bool _IsVDBArtikel; //VDB

        [DataMember]
        private string _VDBArtikelnummer = string.Empty; //VDB / PIMS
        private string _Bezeichnung = string.Empty; //PIMS
        private string _GenArtBezeichnung = string.Empty;
        private string _MarketingBezeichnung = string.Empty;

        [DataMember]
        private IList<PvImage> _Bilder; //PIMS

        [DataMember]
        private decimal _EKPreis; //VDB
        private wkPositionStatus _VDBStatus;
        private double _Streichpreis; //VDB
        private decimal _RepDocPreis;
        private IList<Arbeitsprozess> _ArbeitswerteListe;

        private bool _VDBArtikelInfoLoaded;
        private List<PreisStaffel> _StaffelPreise;

        private IList<NodeIdGenArt> _NodeIDs;

        [DataMember]
        private bool _IsAktionsartikel;

        [DataMember]
        private bool _HatBatterieFuellung;

        private Aktion _Aktion;

        [DataMember]
        private Int32 _AktionsBonuspunkte;
        [DataMember]
        private Int32 _Umsatzbonuspunkte;
        [DataMember]
        private Int32 _Konzeptbonuspunkte;
        [DataMember]
        private Int32 _Onlinebonuspunkte;
        [DataMember]
        private List<SensitiveArea> _SensitiveAreas;

        [NonSerialized]
        IList<string> _Gebrauchsnummern = null;

        [NonSerialized]
        string _GefundenUeberNummer = null;
        [NonSerialized]
        List<PV.DomainObjects.Artikel.Artikel_Nummernsuche.FoundBy> _GefundenUeberListe = null;

        [NonSerialized]
        IList<string> _ErsetzteArtikelnummern = null;
        [NonSerialized]
        IList<string> _ErsetzendeArtikelnummern = null;


        /// <summary>
        /// Spezielle Member für TopProdukte (dürfen nicht persistiert werden.)
        /// </summary>
        [DataMember]
        protected Int32 _TopBonuspunkte;
        [DataMember]
        protected Decimal _TopBonusfaktor;
        [DataMember]
        protected Boolean _IsTopBonusByFactor;
        [DataMember]
        protected Boolean _IsPreisvorteil;
        [DataMember]
        protected Boolean _NurWeitereHersteller;
        [DataMember]
        protected Boolean _IstUeberAutossuggestHersteller;

        private ArtikelBestandsInfo _BestandsInfo;


        public Artikel()
        {
            UStTag = String.Empty;
            Verfuegbarkeit = wkVerfuegbarkeit.OfflineVDB;
            AbholVerfuegbarkeit = wkVerfuegbarkeit.OfflineVDB;
            VerfuegbarkeitDetaillist = new List<VdbVerfuegbarkeitDetails>();
            ArtikelNummer = string.Empty;
            HerstellerKurzName = string.Empty;
            HerstellerName = string.Empty;
            Warengruppenbezeichnung = string.Empty;
            BaugruppenBezeichnung = string.Empty;
            HLK = string.Empty;
            _VDBArtikelInfoLoaded = false;
            UseKriterienDisplayString = false;
            BestandsInfo = new ArtikelBestandsInfo();
            SensitiveAreas = new List<SensitiveArea>();
            GefundenUeberListe = new List<PV.DomainObjects.Artikel.Artikel_Nummernsuche.FoundBy>();
        }

        #endregion

        #region IEquatable<Artikel> Member

        /*
         * START VDB-OnDemandSection
         */

        public void AddFrontendObserver(Object observer)
        {
            if (_CurrentFrontendObservers == null)
                _CurrentFrontendObservers = new List<object>();

            if ((from o in _CurrentFrontendObservers where ReferenceEquals(observer, o) select o).FirstOrDefault() == null)
            {
                _CurrentFrontendObservers.Add(observer);
                AddFrontendObservedArticle(this);
            }
        }

        public void RemoveFrontendObserver(Object observer)
        {
            if (_CurrentFrontendObservers == null)
                _CurrentFrontendObservers = new List<object>();

            if ((from o in _CurrentFrontendObservers where ReferenceEquals(observer, o) select o).FirstOrDefault() != null)
            {
                _CurrentFrontendObservers.Remove(observer);
                if (_CurrentFrontendObservers.Count == 0)
                {
                    RemoveFrontendObservedArticle(this);
                }
            }
        }

        /// <summary>
        /// Wird gesetzt, wenn der VdbArtikelManager die Vdb Abfrage in jedem Fall durchführen wird.
        /// So können mehrfachabfragen vermieden werden.
        /// </summary>
        public Boolean GatheredForVdbProcessing
        {
            get;
            set;
        }

        /*
         * END VDB-OnDemandSection
         */

        /// <summary>
        /// Vergleicht einen Artikel mit einem übergebenen Artikel auf Gleichheit
        /// </summary>
        /// <param name="other">Der Artikel mit dem die Gleichheit geprüft werden soll</param>
        /// <returns>true bei Gleichheit</returns>
        public virtual bool Equals(Artikel other)
        {
            return ArtikelNummer.Equals(other.ArtikelNummer) && DatenlieferantenNummer.Equals(other.DatenlieferantenNummer);
        }

        public override bool Equals(Object o)
        {
            Artikel other = o as Artikel;

            if (other != null)
                if (other.LfdNr != null && other.LfdNr > 0)
                    return ArtikelNummer.Equals(other.ArtikelNummer) && DatenlieferantenNummer.Equals(other.DatenlieferantenNummer)
                        && LfdNr.Equals(other.LfdNr);
                else
                    return ArtikelNummer.Equals(other.ArtikelNummer) && DatenlieferantenNummer.Equals(other.DatenlieferantenNummer);
            else
                return false;
        }

        public override int GetHashCode()
        {

            return ArtikelNummer.GetHashCode() + DatenlieferantenNummer.GetHashCode() + Typ.GetHashCode() + Art.GetHashCode();
        }

        #endregion

        #region Artikel Member

        /// <summary>
        /// Erforderlich für Testing!
        /// </summary>
        public string TestTag
        {
            get
            {
                return string.Format("{0}:{1}", HLK, TiRepArtikelNummer);
            }
        }

        /// <summary>
        /// Wird vom Webservice für RepDoc geliefert
        /// </summary>
        public ArtikelVdbAddition Additions
        {
            get;
            set;
        }

        [DataMember]
        public bool NurWeitereHersteller
        {
            get
            {
                return _NurWeitereHersteller;
            }
            set
            {
                _NurWeitereHersteller = value;
            }
        }

        [DataMember]
        public bool IstSuchstringFuerFreitextsucheVorhanden
        {
            get
            {
                return _IstUeberAutossuggestHersteller;
            }
            set
            {
                _IstUeberAutossuggestHersteller = value;
            }
        }

        public List<SensitiveArea> SensitiveAreas
        {
            get
            {
                return _SensitiveAreas;
            }
            set
            {
                _SensitiveAreas = value;
            }
        }

        //ToDo: mit 500.TMGanzzahl befüllen
        /// <summary>
        /// Dürfen nur ganzzahlige vielfache der Techn. Menegeneinheit bestellt werden?
        /// </summary>
        [DataMember]
        public bool IstGanzzahlMengeneinheit
        {
            get;
            set;
        }

        [DataMember]
        public bool IstEindeutig
        {
            get;
            set;
        }

        [DataMember]
        public bool TecCom
        {
            get;
            set;
        }
        
        public Artikel TecComDeleveryArtikel
        {
            get;
            set;
        }

        public long TecComDeleveryDlnr
        {
            get;
            set;
        }

        public bool IsTecComDeleveryArtikel
        {
            get;
            set;
        }

        public bool IsTecComArtikel
        {
            get;
            set;
        }

        public bool IsStuecklistenartikelInArtikelDetails
        {
            get;
            set;
        }
        
        #region Bonuspunkte PV:Plus

        //Alle Bonuspunkte müssen im Artikel Domain Objekt abgehandelt werden
        //auch für nicht Aktionsartikel oder Topprodukte muss angenommen werden,
        //dass die Vdb entsprechende Bonuspunkte zurückliefert, die wir anzeigen müssen.


        Decimal TopBonusfaktor
        {
            get
            {
                return _IsPreisvorteil ? 0m : _TopBonusfaktor;
            }
        }

        Boolean IsTopBonusByFaktor
        {
            get
            {
                return (!_IsPreisvorteil) && _IsTopBonusByFactor;
            }
        }

        Boolean IsPreisvorteil
        {
            get
            {
                return _IsPreisvorteil;
            }
        }

        [DataMember]
        public Int32 AktionsBonuspunkte
        {
            get
            {
                return _AktionsBonuspunkte;
            }
            set
            {
                _AktionsBonuspunkte = value;
                FirePCEvent("AktionsBonuspunkte");
            }
        }

        /// <summary>
        /// Liefert und setzt die Anzahl der Umsatzbonuspunkte für PLUS
        /// Daten kommen aus dem Webservice VDB::GetArtikelliste()[i]."Umsatzbonuspunkte Artikel"    
        /// </summary>
        [DataMember]
        public Int32 Umsatzbonuspunkte
        {
            get
            {
                return _Umsatzbonuspunkte;
            }
            set
            {
                _Umsatzbonuspunkte = value;
                FirePCEvent("Umsatzbonuspunkte");
                if (_IsTopBonusByFactor)
                {
                    FirePCEvent("TopBonuspunkte");
                }
            }
        }

        /// <summary>
        /// Liefert und setzt die Anzahl der Konzeptbonuspunkte für PLUS
        /// Daten kommen aus dem Webservice VDB::GetArtikelliste()[i]."Konzept-Bonus Artikel" 
        /// </summary>
        [DataMember]
        public int Konzeptbonuspunkte
        {
            get
            {
                return _Konzeptbonuspunkte;
            }
            set
            {
                _Konzeptbonuspunkte = value;
                FirePCEvent("Konzeptbonuspunkte");
            }
        }


        /// <summary>
        /// Liefert und setzt die Anzahl der Onlinebonuspunkte für PLUS
        /// Daten kommen aus dem Webservice VDB::GetArtikelliste()[i]."Kompass-Bestell-Bonus Artikel"
        /// </summary>
        [DataMember]
        public int Onlinebonuspunkte
        {
            get
            {
                return _Onlinebonuspunkte;
            }
            set
            {
                _Onlinebonuspunkte = value;
                FirePCEvent("Onlinebonuspunkte");
            }
        }

        public ArtikelBestandsInfo BestandsInfo
        {
            get
            {
                return _BestandsInfo;
            }
            set
            {
                _BestandsInfo = value;
                FirePCEvent("BestandsInfo");
                FirePCEvent("HasBestandsInfo");
            }
        }

        #endregion


        /// <summary>
        /// Kennzeichnet, ob der Artikel ein Aktionsartikel ist
        /// </summary>
        [DataMember]
        public bool IsAktionsartikel
        {
            get
            {
                return _IsAktionsartikel;
            }
            set
            {
                _IsAktionsartikel = value;
                FirePCEvent("IsAktionsartikel");
            }
        }

        /// <summary>
        /// Enthält die Daten der Aktion, falls der Artikel ein Aktionsartikel ist
        /// </summary>
        [DataMember]
        public virtual Aktion Aktion
        {
            get
            {
                return _Aktion;
            }
            set
            {
                _Aktion = value;
                FirePCEvent("Aktion");
            }
        }

        public virtual string Aktionsname
        {
            get
            {
                return (Aktion != null) ? Aktion.Aktionsname : String.Empty;
            }
        }

        public virtual string Aktionsclaim
        {
            get
            {
                return (Aktion != null) ? Aktion.Aktionsclaim : String.Empty;
            }
        }

        public virtual PvImage AktionsLogo
        {
            get
            {
                return (Aktion != null && Aktion.Aktionslogo != null) ? Aktion.Aktionslogo : null;
            }
        }

        public virtual string Aktionsartikelbeschreibung
        {
            get
            {
                return (Aktion != null) ? Aktion.Aktionsartikelbeschreibung : String.Empty;
            }
        }

        public virtual string AktionMaximalBestellMenge
        {
            get
            {
                return Aktion != null ? Aktion.Bestelllimit.ToString() : "- Kein Angabe";
            }
        }

        public virtual string AktionsGueltigBisDato
        {
            get
            {
                return Aktion != null ? Aktion.GueltigBisDato.ToShortDateString() : "- Kein Angabe";
            }
        }

        public virtual string Aktionsartikelbezeichnung
        {
            get
            {
                return Aktion != null ? Aktion.Aktionsartikelbezeichnung : String.Empty;
            }
        }


        [DataMember]
        public virtual decimal RepDocPreis
        {
            get
            {
                return _RepDocPreis;
            }
            set
            {
                _RepDocPreis = value;
                FirePCEvent("RepDocPreis");
            }
        }

        public virtual bool HatRepDocPreis
        {
            get { return (RepDocPreis > 0); }
        }

        /// <summary>
        /// Verfügbarkeit aus den WaWi-Systemen.
        /// </summary>
        public WaWiArtikelInfos WaWiVerfuegbarkeit { get; set; }

        /// <summary>
        /// Liefert setzt den Status, ob der Artikel bei der onlineVDB abgeprüft wurde
        /// </summary>
        public virtual bool WaWiVerfuegbarkeitLoaded
        {
            get
            {
                return _VDBArtikelInfoLoaded;
            }
            set
            {
                _VDBArtikelInfoLoaded = value;
                FirePCEvent("WaWiVerfuegbarkeitLoaded");
                FirePCEvent("HasBestandsInfo");
            }
        }
        public virtual bool HasBestandsInfo
        {
            get
            {
                if (!WaWiVerfuegbarkeitLoaded) return false;
                if (BestandsInfo == null) return false;
                if (BestandsInfo.DefaultInfo == null) return false;
                return true;
            }

        }


		public virtual bool HasSensitiveAreas
		{
			get
			{
				if(SensitiveAreas==null || SensitiveAreas.Count==0) return false;
				return true;
			}

		}


        [DataMember]
        public virtual bool HatBatterieFuellung
        {
            get { return _HatBatterieFuellung; }
            set { _HatBatterieFuellung = value; }
        }

        /// <summary>
        /// readonly
        /// </summary>
        public virtual IList<ArtikelKriterium> AlleKriterien
        {
            get
            {
                List<ArtikelKriterium> k = new List<ArtikelKriterium>();
                k.AddRange(Kriterien);
                k.AddRange(TypKriterien);
                return k;
            }
        }

        //ToDo: Prüfen, ob Marketingbeschreibung geladen wird
        [DataMember]
        public virtual IList<KeyValuePair<string, string>> SofortArtikelInformationen
        {
            get
            {
                if (_SofortArtikelInformationen == null)
                {
                    _SofortArtikelInformationen = new List<KeyValuePair<string, string>>();
                }
                return _SofortArtikelInformationen;
            }
            set
            {
                _SofortArtikelInformationen = value;
            }
        }

        [DataMember]
        public virtual IList<KeyValuePair<string, string>> SofortArtikelInformationenOhneRTF
        {
            get
            {
                if (_SofortArtikelInformationenOhneRTF == null)
                {
                    _SofortArtikelInformationenOhneRTF = new List<KeyValuePair<string, string>>();
                }
                return _SofortArtikelInformationenOhneRTF;
            }
            set
            {
                _SofortArtikelInformationenOhneRTF = value;
            }
        }

        [DataMember]
        public virtual IList<ArtikelInformationenFahrzeugbezogen> SofortArtikelInformationenFahrzeugbezogenOhneRTF
        {
            get
            {
                if (_SofortArtikelInformationenFahrzeugbezogenOhneRTF == null)
                {
                    _SofortArtikelInformationenFahrzeugbezogenOhneRTF = new List<ArtikelInformationenFahrzeugbezogen>();
                }
                return _SofortArtikelInformationenFahrzeugbezogenOhneRTF;
            }
            set
            {
                _SofortArtikelInformationenFahrzeugbezogenOhneRTF = value;
            }
        }

        [DataMember]
        public virtual IList<KeyValuePair<string, string>> ArtikelInformationen
        {
            get
            {
                if (_ArtikelInformationen == null)
                {
                    _ArtikelInformationen = new List<KeyValuePair<string, string>>();
                }
                return _ArtikelInformationen;
            }
            set
            {
                _ArtikelInformationen = value;
            }
        }

        [DataMember]
        public virtual IList<KeyValuePair<string, string>> ArtikelInformationenOhneRTF
        {
            get
            {
                if (_ArtikelInformationenOhneRTF == null)
                {
                    _ArtikelInformationenOhneRTF = new List<KeyValuePair<string, string>>();
                }
                return _ArtikelInformationenOhneRTF;
            }
            set
            {
                _ArtikelInformationenOhneRTF = value;
            }
        }

        [DataMember]
        public virtual IList<KeyValuePair<string, string>> ArtikelInformationenMitHTML
        {
            get
            {
                if (_ArtikelInformationenMitHTML == null)
                {
                    _ArtikelInformationenMitHTML = new List<KeyValuePair<string, string>>();
                }
                return _ArtikelInformationenMitHTML;
            }
            set
            {
                _ArtikelInformationenMitHTML = value;
            }
        }

        [DataMember]
        public virtual bool KZAT
        {
            get;
            set;
        }

        [DataMember]
        public virtual bool KZMat
        {
            get;
            set;
        }

        [DataMember]
        public virtual long HerstellerSortiernummer
        {
            get;
            set;
        }

        [DataMember]
        public virtual long HerstellerSortiernummerAbweichend
        {
            get;
            set;
        }

        [DataMember]
        public virtual bool KZSB
        {
            get;
            set;
        }

        [DataMember]
        public virtual bool KZZub
        {
            get;
            set;
        }

        [DataMember]
        public virtual PVItemListe<Artikel> Stueckliste
        {
            get
            {
                return _Stueckliste;
            }
            set
            {
                _Stueckliste = value;
                FirePCEvent("Stueckliste");
            }
        }

        [DataMember]
        public String PreiseinheitBezeichnung
        {
            get;
            set;
        }

        [DataMember]
        public virtual decimal PreiseinheitFaktor
        {
            get;
            set;
        }

        [DataMember]
        public virtual string PitstopWarengruppe
        {
            get;
            set;
        }

        [DataMember]
        public virtual string VdbWarengruppe
        {
            get;
            set;
        }

        //ToDO: Auf Datenbank Feld erstellen und befüllen
        [DataMember]
        public Int32 PreiseinheitSchluessel
        {
            get;
            set;
        }

        public virtual decimal InvPreiseinheitFaktor
        {
            get
            {
                return PreiseinheitFaktor == 0 ? 0 : 1 / PreiseinheitFaktor;
            }
        }

        [DataMember]
        public virtual decimal MengeneinheitFaktor
        {
            get;
            set;
        }

        [DataMember]
        public virtual decimal TechMengeneinheitFaktor
        {
            get;
            set;
        }

        [DataMember]
        public virtual decimal NeueMengefuerErweiterteVerfuegbarkeit
        {
            get;
            set;
        }

        [DataMember]
        public virtual String MengeneinheitBezeichnung
        {
            get;
            set;
        }

        [DataMember]
        public virtual String TechMengeneinheitBezeichnung
        {
            get;
            set;
        }

        //ToDO: Befüllen mit 500.M
        [DataMember]
        public virtual String MengeneinheitSchluessel
        {
            get;
            set;
        }

        //ToDO: Befüllen mit 500.TM
        [DataMember]
        public virtual String TechMengeneinheitSchluessel
        {
            get;
            set;
        }

        [DataMember]
        public virtual Boolean IstPseudoArtikel
        {
            get;
            set;
        }

        [DataMember]
        public virtual int VdbArtikelzustand
        {
            get;
            set;
        }

        public virtual Boolean HatStueckliste
        {
            get
            {
                return (HatStuecklistePV || HatStuecklisteTecDoc);
            }
        }

        [DataMember]
        public virtual Boolean HatStuecklistePV
        {
            get;
            set;
        }

        [DataMember]
        public double Pfandwert
        {
            get;
            set;
        }

        public List<AltteilePfandwerte> ListPfandwert
        {
            get
            {
                List<AltteilePfandwerte> retVal = new List<AltteilePfandwerte>();
                if (HatPfandwert)
                {
                    retVal.Add(new AltteilePfandwerte()
                    {
                        AltteilKennzeichen = AltteilKennzeichen.Equals("U") ? "Erstattungsfähiger Umweltbeitrag" : "Altteil-Pfand",
                        Pfandwert = Pfandwert
                    });
                }
                return retVal;
            }
        }

        private bool? _hatPfandwert = null;
        public bool HatPfandwert
        {
            get
            {
                if (!_hatPfandwert.HasValue && Pfandwert > 0)
                {
                    _hatPfandwert = AltteilKennzeichen != null;
                }
                else if (!_hatPfandwert.HasValue)
                {
                    _hatPfandwert = false;
                }
                return (bool)_hatPfandwert;

            }
        }

        private bool? _hatPfandwertSonstig = null;
        public bool HatPfandwertSonstig
        {
            get
            {
                if (!_hatPfandwertSonstig.HasValue && Pfandwert > 0)
                {
                    _hatPfandwertSonstig = AltteilKennzeichen != null && (AltteilKennzeichen.Equals("P") ||  AltteilKennzeichen.Equals("T"));
                }
                else if (!_hatPfandwertSonstig.HasValue)
                {
                    _hatPfandwertSonstig = false;
                }
                return (bool)_hatPfandwertSonstig;

            }
        }

        private bool? _hatPfandwertUB = null;
        public bool HatPfandwertUB
        {
            get
            {
                if (!_hatPfandwertUB.HasValue && Pfandwert > 0)
                {
                    _hatPfandwertUB = AltteilKennzeichen != null && AltteilKennzeichen.Equals("U");
                }
                else if (!_hatPfandwertUB.HasValue)
                {
                    _hatPfandwertUB = false;
                }
                return (bool)_hatPfandwertUB;

            }
        }

        [DataMember]
        public string AltteilKennzeichen
        {
            get;
            set;
        }

        [DataMember]
        public virtual Boolean HatStuecklisteTecDoc
        {
            get;
            set;
        }

        public virtual Boolean IstAlternativArtikelPopUp
        {
            get;
            set;
        }

        public virtual Boolean HatAlternativArtikel
        {
            get
            {
                return ((HatAlternativArtikelPV || HatAlternativArtikelTecDoc) && !IstAlternativArtikelPopUp);
            }
        }

        [DataMember]
        public virtual Boolean HatAlternativArtikelPV
        {
            get;
            set;
        }


        private Boolean _hatAlternativArtikelTecDoc;

        [DataMember]
        public virtual Boolean HatAlternativArtikelTecDoc
        {
            get
            {
                return _hatAlternativArtikelTecDoc;
            }
            set
            {
                _hatAlternativArtikelTecDoc = value;
            }
        }

        [DataMember]
        public virtual Boolean HatVerwandteArtikel
        {
            get;
            set;
        }

        [DataMember]
        public virtual Boolean HatZubehoerTecDOc
        {
            get;
            set;
        }


        [DataMember]
        public virtual wkVerfuegbarkeit Verfuegbarkeit
        {
            get
            {
                if (ExtraInfos.Contains(new KeyValuePair<string, string>("TecComDelivery", "true")))
                {
                    return wkVerfuegbarkeit.TecCom;
                }

                return _Verfuegbarkeit;
            }
            set
            {
                if (_Verfuegbarkeit != wkVerfuegbarkeit.TecCom)
                {
                    _Verfuegbarkeit = value;
                }

                FirePCEvent("Verfuegbarkeit");
                FirePCEvent("TecComVisible");

                if (verfuegbarkeitChanged != null)
                {
                    verfuegbarkeitChanged();
                }

            }
        }

        public bool TecComVisible
        {
            get
            {
                if (TecCom && Verfuegbarkeit == wkVerfuegbarkeit.Rueckstand)
                    return true;

                return false;
            }

        }

        [DataMember]
        public virtual List<VdbVerfuegbarkeitDetails> VerfuegbarkeitDetaillist
        {
            get
            {
                if (ExtraInfos.Contains(new KeyValuePair<string, string>("TecComDelivery", "true")))
                {
                    List<VdbVerfuegbarkeitDetails> back = new List<VdbVerfuegbarkeitDetails>();
                    back.Add(new VdbVerfuegbarkeitDetails()
                    {
                        Abholverfuegbarkeit = wkVerfuegbarkeit.TecCom,
                        Lieferverfuegbarkeit = wkVerfuegbarkeit.TecCom
                    });

                    return back;
                }

                return _VerfuegbarkeitDetaillist;
            }
            set
            {
                _VerfuegbarkeitDetaillist = value;
                FirePCEvent("VerfuegbarkeitDetaillist");
            }
        }
        
        [DataMember]
        public virtual int SortVerfuegbarkeit
        {
            get
            {
                return _SortVerfuegbarkeit;
            }
            set
            {
                _SortVerfuegbarkeit = value;
            }
        }

        [DataMember]
        public virtual wkVerfuegbarkeit AbholVerfuegbarkeit
        {
            get
            {
                if (ExtraInfos.Contains(new KeyValuePair<string, string>("TecComDelivery", "true")))
                {
                    return wkVerfuegbarkeit.TecCom;
                }

                return _AbholVerfuegbarkeit;
            }
            set
            {
                if (_AbholVerfuegbarkeit != wkVerfuegbarkeit.TecCom)
                {
                    _AbholVerfuegbarkeit = value;
                }

                _AbholVerfuegbarkeit = value;
                FirePCEvent("AbholVerfuegbarkeit");
                FirePCEvent("TecComVisible");
            }
        }

        [DataMember]
        public virtual List<ArtikelKriterium> TypKriterien
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Liste der Artikelkriterien
        /// </summary>
        [DataMember]
        public virtual IList<ArtikelKriterium> Kriterien
        {
            get;
            set;
        }

        [DataMember]
        public string KriterienDisplayString { get; set; }
        [DataMember]
        public bool UseKriterienDisplayString { get; set; }


        [DataMember]
        public virtual bool GefahrengutHinweiseLoaded
        {
            get;
            set;
        }

        [DataMember]
        public virtual IList<ArtikelDokument> Dokumente
        {
            get;
            set;
        }

        [DataMember]
        public virtual IList<ArtikelLink> Links
        {
            get;
            set;
        }

        //[DataMember]
        //public int LinkageId { get; set; }
        //[DataMember]
        //public int ArtikelId { get; set; }


        [DataMember]
        public virtual IList<string> Gebrauchsnummern
        {
            get { return _Gebrauchsnummern; }
            set { _Gebrauchsnummern = value; }
        }

        [DataMember]
        public virtual IList<string> ErsetzteArtikelnummern
        {
            get { return _ErsetzteArtikelnummern; }
            set { _ErsetzteArtikelnummern = value; }
        }

        [DataMember]
        public virtual IList<string> ErsetzendeArtikelnummern
        {
            get { return _ErsetzendeArtikelnummern; }
            set { _ErsetzendeArtikelnummern = value; }
        }

        [DataMember]
        public virtual string GefundenUeberNummer
        {
            get { return _GefundenUeberNummer; }
            set { _GefundenUeberNummer = value; }
        }

        [DataMember]
        public virtual List<PV.DomainObjects.Artikel.Artikel_Nummernsuche.FoundBy> GefundenUeberListe
        {
            get { return _GefundenUeberListe; }
            set { _GefundenUeberListe = value; }
        }

        [DataMember]
        public virtual GefahrengutHinweise GefahrengutHinweise
        {
            get
            {
                return _GefahrengutHinweise;
            }
            set
            {
                _GefahrengutHinweise = value;
                FirePCEvent("GefahrengutHinweise");
            }
        }

        [DataMember]
        public virtual string TiNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Status, ob der Artikel ein VDB Artikel ist.
        /// Nur VDB Artikel können auch bestellt werden.
        /// </summary>
        public virtual bool IsVDBArtikel
        {
            get
            {
                return _IsVDBArtikel;
            }
            set
            {
                _IsVDBArtikel = value;
                FirePCEvent("IsVDBArtikel");
            }

        }

        /// <summary>
        /// Liefert setzt den Status, ob der Artikel bei der onlineVDB abgeprüft wurde
        /// </summary>
        public virtual bool VDBArtikelInfoLoaded
        {
            get
            {
                return _VDBArtikelInfoLoaded;
            }
            set
            {
                _VDBArtikelInfoLoaded = value;
                FirePCEvent("VDBArtikelInfoLoaded");
            }
        }



        /// <summary>
        /// Liefert und setzt VDBArtikelNummer
        /// </summary>
        [DataMember]
        public virtual string VDBArtikelNummer
        {
            get
            {
                return _VDBArtikelnummer;
            }
            set
            {
                _VDBArtikelnummer = value;
            }
        }


        /// <summary>
        /// Liefert und setzt Warengruppenbezeichnung
        /// ToDO: Walter aus Webservice befüllen!
        /// </summary>
        [DataMember]
        public virtual string Warengruppenbezeichnung
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt Warengruppe
        /// </summary>
        [DataMember]
        public virtual uint Warengruppe
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt UnterWarengruppe
        /// </summary>
        [DataMember]
        public virtual uint UnterWarengruppe
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt HauptWarengruppe
        /// </summary>
        [DataMember]
        public virtual uint HauptWarengruppe
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt HLK
        /// </summary>
        [DataMember]
        public virtual string HLK
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt Baugruppe
        /// </summary>
        [DataMember]
        public virtual int? Baugruppe
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die BaugruppenBezeichnung
        /// </summary>
        [DataMember]
        public virtual string BaugruppenBezeichnung
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die Bezeichnung
        /// </summary>
        [DataMember]
        public virtual string Bezeichnung
        {
            get
            {
                return _Bezeichnung != null ? _Bezeichnung.Trim() : string.Empty;
            }
            set
            {
                _Bezeichnung = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Bezeichnung des Generischen Artikels
        /// </summary>
        [DataMember]
        public virtual string GenArtBezeichnung
        {
            get
            {
                return _GenArtBezeichnung != null ? _GenArtBezeichnung.Trim() : string.Empty;
            }
            set
            {
                _GenArtBezeichnung = value;
            }
        }
        
        /// <summary>
        /// Liefert und setzt die Marketing-Bezeichnung
        /// </summary>
        [DataMember]
        public virtual string MarketingBezeichnung
        {
            get
            {
                return _MarketingBezeichnung != null ? _MarketingBezeichnung.Trim() : string.Empty;
            }
            set
            {
                _MarketingBezeichnung = value;
            }
        }




        /// <summary>
        /// Liefert und setzt das Herstellerlogo
        /// </summary>
        [DataMember]
        public virtual PvImage HerstellerLogo
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert und setzt die Nummer des Bildes
        /// </summary>
        [DataMember]
        public virtual IList<PvImage> Bilder
        {
            get
            {
                if (_Bilder == null)
                    _Bilder = new ObservableCollection<PvImage>();

                if (this is IncentiveArtikel)
                {
                    //if (((IncentiveArtikel)this).IncentiveBundleBild != null && ((IncentiveArtikel)this).IncentiveBundleBild.ImageURI != PvImage.FromEmpty().ImageURI)
                    //{
                    //    ObservableCollection<PvImage> _tmp = new ObservableCollection<PvImage>();
                    //    _tmp.Add(((IncentiveArtikel)this).IncentiveBundleBild);
                    //    foreach (PvImage pic in _Bilder)
                    //    {
                    //        _tmp.Add(pic);
                    //    }
                    //    return _tmp;
                    //}
                }

                //if (Aktion != null && Aktion.Aktionsartikelthumb != null && Aktion.Aktionsartikelthumb.ImageURI != PvImage.FromEmpty().ImageURI)
                //{
                //    List<PvImage> artBilder = new List<PvImage>();
                //    artBilder.Clear();
                //    artBilder.Add(Aktion.Aktionsartikelthumb);

                //    foreach (PvImage bild in _Bilder)
                //    {
                //        artBilder.Add(bild);
                //    }

                //    return artBilder;
                //}

                return _Bilder;
            }
            set
            {
                _Bilder = value;
            }
        }

        /// <summary>
        /// Liefert das erste Bild an dem Artikel
        /// </summary>
        public virtual PvImage FirstBild
        {
            get
            {
                //if (this is IncentiveArtikel)
                //{
                //    if (((IncentiveArtikel)this).IncentiveBundleBild != null && ((IncentiveArtikel)this).IncentiveBundleBild.ImageURI != PvImage.FromEmpty().ImageURI)
                //        return ((IncentiveArtikel)this).IncentiveBundleBild;
                //}

                //if (Aktion != null && Aktion.Aktionsartikelthumb != null && Aktion.Aktionsartikelthumb.ImageURI != PvImage.FromEmpty().ImageURI)
                //{
                //    return Aktion.Aktionsartikelthumb;
                //}

                if (_Bilder == null || _Bilder.Count == 0)
                {
                    //return PvImage.FromEmpty();
                }

                return _Bilder[0];
            }
        }


        [DataMember]
        public virtual List<PreisStaffel> StaffelPreise
        {
            get
            {
                return _StaffelPreise;
            }
            set
            {
                _StaffelPreise = value;
                FirePCEvent("StaffelPreise");
            }
        }

        [DataMember]
        public virtual bool StaffelPreiseLoaded
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den EKPreis
        /// </summary>
        [DataMember]
        public virtual decimal EKPreis
        {
            get
            {
                return _EKPreis;
            }
            set
            {
                _EKPreis = value;
                FirePCEvent("EKPreis");
            }
        }

        /// <summary>
        /// Liefert und setzt den VDBStatus
        /// </summary>
        [DataMember]
        public virtual wkPositionStatus VDBStatus
        {
            get
            {
                return _VDBStatus;
            }
            set
            {
                _VDBStatus = value;
            }
        }

        /// <summary>
        /// Liefert und setzt den VKPreis
        /// </summary>
        [DataMember]
        public virtual decimal VKPreis
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den VKPreis für PitStop, R2/2012
        /// </summary>
        [DataMember]
        public virtual decimal VKPreisPitStop
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Streichpreis
        /// </summary>
        [DataMember]
        public virtual double Streichpreis
        {
            get
            {
                return _Streichpreis;
            }
            set
            {
                _Streichpreis = value;
                FirePCEvent("Streichpreis");
            }
        }

        /// <summary>
        /// Liefert und setzt den Herstellername
        /// </summary>
        [DataMember]
        public virtual string HerstellerName
        {
            get;
            set;
        }

        [DataMember]
        public virtual MyArtikelKategorien SelectedMyArtikelSortiment
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den HerstellerKurzName
        /// </summary>
        [DataMember]
        public virtual string HerstellerKurzName
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert die Liste der zugehörigen Arbeitswerte
        /// </summary>
        public virtual IList<Arbeitsprozess> ArbeitswerteListe
        {
            get
            {
                return _ArbeitswerteListe;
            }
            set
            {
                _ArbeitswerteListe = value;
                FirePCEvent("ArbeitswerteListe");
            }
        }


        /// <summary>
        /// Gibt an ob die Arbeitswerte-Liste schon geladen wurde
        /// </summary>
        public virtual bool ArbeitswerteListeLoaded
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert die Liste der Ids der Suchbaumknoten unter denen dieser Artikel zu finden ist
        /// </summary>
        [DataMember]
        public virtual IList<NodeIdGenArt> NodeIDs
        {
            get
            {
                if (_NodeIDs == null)
                    _NodeIDs = new List<NodeIdGenArt>();
                return _NodeIDs;
            }
            set
            {
                _NodeIDs = value;
            }
        }

        //ToDO: Befüllen mit 500 UstSchluessel
        [DataMember]
        public string UStTag
        {
            get;
            set;
        }

        [DataMember]
        public virtual int TiRepBaugruppenNummer
        {
            get;
            set;
        }

        [DataMember] //ToDo: Befüllen mit 810.RepDocBgBezeichnung
        public virtual string TiRepBaugruppenName
        {
            get;
            set;
        }

        [DataMember]
        public virtual string TiRepArtikelNummer
        {
            get;
            set;
        }

        [DataMember]
        public virtual string TiRepHersteller
        {
            get;
            set;
        }

        [DataMember]
        public DateTime? TeaserAnzeigedatumMin { get; set; }
        [DataMember]
        public DateTime? TeaserAnzeigedatumMax { get; set; }

        [DataMember]
        public String TeaserName { get; set; }

        [DataMember]
        public string Verpackungsart 
        { get; set; }
        [DataMember]
        public int EinheitenProVerpackung 
        { get; set; }
        [DataMember]
        public string Einheit 
        { get; set; }
        [DataMember]
        public decimal MengeProEinheit 
        { get; set; }

        public int MengeToSet
        { get; set; }

        /// <summary>
        /// Beim Import von Artikeln sollen keine notwendigen Artikel geladen werden
        /// </summary>
        [DataMember]
        public bool KeineNotwendigenArtikelLaden { get; set; }

        /// <summary>
        /// enthält alle zusätzlichen Infos für ein Artikel,
        /// 
        /// </summary>
        [DataMember]
        public List<SupplementaryParameterTypeContext> SupplementaryParameterType
        {
            get;
            set;
        }

        #endregion

        private Dictionary<string, string> _extraInfos = null;

        public Dictionary<string, string> ExtraInfos
        {
            get
            {
                if(_extraInfos == null)
                    _extraInfos = new Dictionary<string, string>();

                return _extraInfos;
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Artikelnummer: " + ArtikelNummer);
            sb.AppendLine("Datenlieferantennummer: " + DatenlieferantenNummer.ToString());
            sb.AppendLine("GenArtNr: " + GenArtNr.ToString());
            return sb.ToString();
        }
    }
}
