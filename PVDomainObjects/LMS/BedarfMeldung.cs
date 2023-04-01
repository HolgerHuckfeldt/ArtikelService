using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using PV.DomainObjects.Stammdaten;

namespace PV.DomainObjects.LMS
{
    [DataContract]
    [Serializable]
    public class BedarfMeldung
    {
        #region Fields

        private int _bedarfsMeldungID = -1;
        private Training _training;
        private List<Mitarbeiter> _meldenFürMitarbeiterListe;
        private DateTime _datumVon;
        private DateTime _datumBis;
        private Profil _currentProfil;
        private String _freierText;
        private TrainingsOrt _wunschOrt;
        private TrainingsTermin _termin;
        private Mitarbeiter _erstelltVon;
        private bool _istFreieBedarfsMeldung;

        #endregion

        #region Properties

        [DataMember]
        public TrainingsTermin Termin
        {
            get { return _termin; }
            set { _termin = value; }
        }

        [DataMember]
        public int BedarfsMeldungID
        {
            get { return _bedarfsMeldungID; }
            set { _bedarfsMeldungID = value; }
        }

        [DataMember]
        public Training Training
        {
            get { return _training; }
            set { _training = value; }
        }

        [DataMember]
        public List<Mitarbeiter> MeldenFürMitarbeiterListe
        {
            get { return _meldenFürMitarbeiterListe; }
            set { _meldenFürMitarbeiterListe = value; }
        }

        [DataMember]
        public DateTime DatumVon
        {
            get { return _datumVon; }
            set { _datumVon = value; }
        }

        [DataMember]
        public DateTime DatumBis
        {
            get { return _datumBis; }
            set { _datumBis = value; }
        }

        [DataMember]
        public Profil CurrentProfil
        {
            get { return _currentProfil; }
            set { _currentProfil = value; }
        }

        [DataMember]
        public String FreierText
        {
            get { return _freierText; }
            set { _freierText = value; }
        }

        [DataMember]
        public TrainingsOrt WunschOrt
        {
            get { return _wunschOrt; }
            set { _wunschOrt = value; }
        }

        [DataMember]
        public Mitarbeiter ErstelltVon
        {
            get { return _erstelltVon; }
            set { _erstelltVon = value; }
        }

        [DataMember]
        public bool IstFreieBedarfsMeldung
        {
            get { return _istFreieBedarfsMeldung; }
            set { _istFreieBedarfsMeldung = value; }
        }

        #endregion
    }
}
