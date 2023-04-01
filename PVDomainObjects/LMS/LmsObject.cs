using System;

namespace PV.DomainObjects.LMS
{
    [Serializable]
    public class LmsObject
    {
        #region Fields

        private MeinTraining _meinTraining;
        private TrainingsAnmeldung _anmeldung;
        private BedarfMeldung _bedarf;

        private bool _istMeinTraining;
        private bool _istBedarfMeldung;
        private bool _istAnmeldung;

        private string _trainingsNummer = "";
        private string _titel = "";
        private string _beschreibung = "";


        #endregion

        #region Props

        #region Identifier

        public bool IstMeinTraining
        {
            get { return _istMeinTraining; }
            set
            {
                if (_istMeinTraining != value)
                {
                    _istMeinTraining = value;
                }
                if (_istMeinTraining)
                {
                    IstBedarfMeldung = false;
                    IstAnmeldung = false;
                }
            }
        }

        public bool IstBedarfMeldung
        {
            get { return _istBedarfMeldung; }
            set
            {
                if (_istBedarfMeldung != value)
                {
                    _istBedarfMeldung = value;
                }
                if (_istBedarfMeldung)
                {
                    IstMeinTraining = false;
                    IstAnmeldung = false;
                }
            }
        }

        public bool IstAnmeldung
        {
            get { return _istAnmeldung; }
            set
            {
                if (_istAnmeldung != value)
                {
                    _istAnmeldung = value;
                }
                if (_istAnmeldung)
                {
                    IstMeinTraining = false;
                    IstBedarfMeldung = false;
                }
            }
        }

        public TrainingsAnmeldung Anmeldung
        {
            get { return _anmeldung; }
            set
            {
                if (_anmeldung != value)
                {
                    _anmeldung = value;
                }
            }
        }

        public BedarfMeldung Bedarf
        {
            get { return _bedarf; }
            set
            {
                if (_bedarf != value)
                {
                    _bedarf = value;
                }
            }
        }

        public MeinTraining MeinTraining
        {
            get { return _meinTraining; }
            set
            {
                if (_meinTraining != value)
                {
                    _meinTraining = value;
                }
            }
        }

        public Training Training { get; set; }

        public TrainingsTermin Termin { get; set; }

        #endregion

        #region StatusSpalte

        public StatusEnum.AnmeldeStatus Status { get; set; }

        public string StatusString
        {
            get
            {
                switch (Status)
                {
                    case StatusEnum.AnmeldeStatus.Abgesagt:
                        return "Abgesagt";
                    case StatusEnum.AnmeldeStatus.Angemeldet:
                        return "Angemeldet";
                    case StatusEnum.AnmeldeStatus.Bedarf_Gemeldet:
                        return "Bedarf gemeldet";
                    case StatusEnum.AnmeldeStatus.Nicht_Erschienen:
                        return "Nicht erschienen";
                    case StatusEnum.AnmeldeStatus.Storniert:
                        return "Storniert";
                    case StatusEnum.AnmeldeStatus.Teilgenommen:
                        return "Teilgenommen";
                    default:
                        return "";
                }
            }
        }

        #endregion

        #region Bezeichnung und Beschreibungsspalte

        public string TrainingsNummer
        {
            get { return _trainingsNummer; }
            set { _trainingsNummer = value; }
        }

        public string Titel
        {
            get { return _titel; }
            set { _titel = value; }
        }

        public string Beschreibung
        {
            get { return _beschreibung; }
            set { _beschreibung = value; }
        }

        public string ZusatzInfoText
        {
            get
            {
                if (Training != null && !string.IsNullOrEmpty(Training.ZusatzInfo))
                {
                    return Training.ZusatzInfo;
                }
                return "";
            }
        }

        public bool HatVorgaengerTraining
        {
            get
            {
                if (Training != null && Training.Vorgaenger != null)
                {
                    return true;
                }
                return false;
            }
        }

        public Training VorgaengerTraining
        {
            get { return HatVorgaengerTraining ? Training.Vorgaenger : null; }
        }

        #endregion

        #region Weitere Spalten

        public string Kategorie { get; set; }

        public string DatumsStringVonBis
        {
            get
            {
                if (DatumVon != null && DatumVon != DateTime.MinValue
                    && DatumBis != null && DatumBis != DateTime.MinValue)
                {
                    if (DatumVon == DatumBis)
                    {
                        return Convert.ToDateTime(DatumVon).ToShortDateString();
                    }
                    return Convert.ToDateTime(DatumVon).ToShortDateString() + " - "
                           + Convert.ToDateTime(DatumBis).ToShortDateString();
                }
                if (DatumVon != null && DatumVon != DateTime.MinValue)
                {
                    return Convert.ToDateTime(DatumVon).ToShortDateString();
                }
                if (DatumBis != null && DatumBis != DateTime.MinValue)
                {
                    return Convert.ToDateTime(DatumBis).ToShortDateString();
                }
                return "Datum unbekannt";
            }
        }

        public string Ort { get; set; }

        public string Dauer
        {
            get { return Training != null ? Training.Dauer : ""; }
        }

        public string ZahlungsArt
        {
            get { return Anmeldung != null ? Anmeldung.ZahlungsArt.ToString().Replace("_", " ") : ""; }
        }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        #endregion

        #endregion

        public LmsObject(MeinTraining meinTraining)
        {
            IstMeinTraining = true;
            MeinTraining = meinTraining;

            Status = StatusEnum.AnmeldeStatus.Teilgenommen;
            Titel = meinTraining.Titel;
            Beschreibung = meinTraining.Beschreibung;

            Kategorie = "Eigenes Training";
            Ort = meinTraining.Ort;
            DatumVon = meinTraining.DatumVon;
            DatumBis = meinTraining.DatumBis;
        }

        public LmsObject(TrainingsAnmeldung anmeldung)
        {
            IstAnmeldung = true;
            Anmeldung = anmeldung;

            Status = anmeldung.Status;

            if (Anmeldung.Termin != null)
            {
                Termin = Anmeldung.Termin;
                Ort = Anmeldung.Termin.TrainingsOrteString;
                DatumVon = Anmeldung.Termin.DatumVon;
                DatumBis = Anmeldung.Termin.DatumBis;

                if (Anmeldung.Termin.Training != null)
                {
                    Training = Anmeldung.Termin.Training;
                    TrainingsNummer = Training.Nummer;
                    Titel = Training.Titel;
                    Beschreibung = Training.KurzBeschreibung;
                    Kategorie = Training.Kategorie;
                }
            }
        }

        public LmsObject(BedarfMeldung bedarf)
        {
            bool lmserror = false;
            IstBedarfMeldung = true;
            Bedarf = bedarf;
            
            Status = StatusEnum.AnmeldeStatus.Bedarf_Gemeldet;

            if (bedarf.Training != null)
            {
                Training = bedarf.Training;
                TrainingsNummer = bedarf.Training.Nummer;
                Titel = bedarf.Training.Titel;
                Beschreibung = bedarf.Training.KurzBeschreibung;
                Kategorie = bedarf.Training.Kategorie;
                DatumVon = bedarf.DatumVon;
                DatumBis = bedarf.DatumBis;
                Ort = bedarf.WunschOrt != null ? bedarf.WunschOrt.Stadt : "";
            }

            if (bedarf.Termin != null)
            {
                Termin = bedarf.Termin;
                Training = bedarf.Termin.Training;
                if (bedarf.Termin.Training != null)
                {
                    TrainingsNummer = bedarf.Termin.Training.Nummer;
                    Titel = bedarf.Termin.Training.Titel;
                    Beschreibung = bedarf.Termin.Training.KurzBeschreibung;
                    Kategorie = bedarf.Termin.Training.Kategorie;
                }
                else
                {
                    // Fehler, darf eingentlich nicht passieren
                    lmserror = true;
                }
                DatumVon = bedarf.Termin.DatumVon;
                DatumBis = bedarf.Termin.DatumBis;
                Ort = bedarf.Termin.TrainingsOrteString;
            }

            if (bedarf.Training == null && bedarf.Termin == null)
            {
                Titel = "Freie Bedarfsmeldung";
                Beschreibung = bedarf.FreierText;
                Kategorie = "Freier Bedarf";
                DatumVon = bedarf.DatumVon;
                DatumBis = bedarf.DatumBis;
                Ort = bedarf.WunschOrt != null ? bedarf.WunschOrt.Stadt : "";
            }
            if (lmserror == true) // nicht schön, kompiliert aber sonst nicht
                lmserror = false;
        }
    }
}