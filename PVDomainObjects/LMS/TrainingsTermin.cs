using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PV.DomainObjects.LMS
{
    [DataContract]
    [Serializable]
    public class TrainingsTermin
    {
        #region fields

        private int _terminID;
        private int _teilnehmerMin;
        private int _teilnehmerMax;
        private Training _training;
        private IList<String> _trainerListe;
        private List<TrainingsOrt> _trainingsOrteListe;
        private DateTime? _datumVon;
        private DateTime? _datumBis;
        private String _zeitVon;
        private String _zeitBis;
        private int _anzahlAnmeldungen;
        private StatusEnum.TerminStatus _terminStatus;

        #endregion

        #region Properties

        [DataMember]
        public int AnzahlAnmeldungen
        {
            get { return _anzahlAnmeldungen; }
            set { _anzahlAnmeldungen = value; }
        }

        public int FreiePlaetze
        {
            get
            {
                return TeilnehmerMax - AnzahlAnmeldungen;
            }
        }

        [DataMember]
        public String ZeitBis
        {
            get { return _zeitBis; }
            set { _zeitBis = value; }
        }

        [DataMember]
        public String ZeitVon
        {
            get { return _zeitVon; }
            set { _zeitVon = value; }
        }

        [DataMember]
        public DateTime? DatumBis
        {
            get { return _datumBis; }
            set { _datumBis = value; }
        }

        [DataMember]
        public DateTime? DatumVon
        {
            get { return _datumVon; }
            set { _datumVon = value; }
        }

        [DataMember]
        public List<TrainingsOrt> TrainingsOrteListe
        {
            get { return _trainingsOrteListe; }
            set { _trainingsOrteListe = value; }
        }

        public string TrainingsOrteString
        {
            get
            {
                string result = "";

                if (TrainingsOrteListe != null && TrainingsOrteListe.Count > 0)
                {
                    foreach (TrainingsOrt ort in TrainingsOrteListe)
                    {
                        result += ", " + ort.Stadt;
                    }

                    if (result.StartsWith(", "))
                        result = result.Remove(0, 2);
                }

                return result;
            }
        }

        [DataMember]
        public IList<String> TrainerListe
        {
            get { return _trainerListe; }
            set { _trainerListe = value; }
        }

        [DataMember]
        public Training Training
        {
            get { return _training; }
            set { _training = value; }
        }

        [DataMember]
        public int TeilnehmerMax
        {
            get { return _teilnehmerMax; }
            set { _teilnehmerMax = value; }
        }

        [DataMember]
        public int TeilnehmerMin
        {
            get { return _teilnehmerMin; }
            set { _teilnehmerMin = value; }
        }

        [DataMember]
        public int TerminID
        {
            get { return _terminID; }
            set { _terminID = value; }
        }

        [DataMember]
        public StatusEnum.TerminStatus TerminStatus
        {
            get { return _terminStatus; }
            set { _terminStatus = value; }
        }

        #endregion
    }
}
