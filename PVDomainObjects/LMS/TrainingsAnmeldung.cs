using System;
using System.Collections.Generic;
using PV.DomainObjects.Stammdaten;
using System.Runtime.Serialization;

namespace PV.DomainObjects.LMS
{
    [DataContract]
    [Serializable]
    public class TrainingsAnmeldung
    {
        #region fields

        private List<Mitarbeiter> _teilnehmerListe;
        private DateTime _stornoDatum;
        private DateTime _anmeldungDatum;
        private int _mitarbeiterId;
        private TrainingsTermin _termin;
        private StatusEnum.AnmeldeStatus _status;
        private StatusEnum.ZahlungsArt _zahlungsArt;
        private StatusEnum.TrainingsCard _trainingsCard;
        private int _verbrauchteTrainingsTage;

        #endregion

        #region Properties

        [DataMember]
        public List<Mitarbeiter> TeilnehmerListe
        {
            get { return _teilnehmerListe; }
            set { _teilnehmerListe = value; }
        }

        [DataMember]
        public DateTime StornoDatum
        {
            get { return _stornoDatum; }
            set { _stornoDatum = value; }
        }

        [DataMember]
        public DateTime AnmeldungDatum
        {
            get { return _anmeldungDatum; }
            set { _anmeldungDatum = value; }
        }

        [DataMember]
        public int MitarbeiterID
        {
            get { return _mitarbeiterId; }
            set { _mitarbeiterId = value; }
        }

        [DataMember]
        public TrainingsTermin Termin
        {
            get { return _termin; }
            set { _termin = value; }
        }

        [DataMember]
        public StatusEnum.AnmeldeStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        [DataMember]
        public StatusEnum.ZahlungsArt ZahlungsArt
        {
            get { return _zahlungsArt; }
            set { _zahlungsArt = value; }
        }

        [DataMember]
        public StatusEnum.TrainingsCard TrainingsCard
        {
            get { return _trainingsCard; }
            set { _trainingsCard = value; }
        }

        [DataMember]
        public int VerbrauchteTrainingsTage
        {
            get { return _verbrauchteTrainingsTage; }
            set { _verbrauchteTrainingsTage = value; }
        }

        #endregion
    }
}
