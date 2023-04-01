using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PV.DomainObjects.Stammdaten;

namespace PV.DomainObjects.LMS
{
    [DataContract]
    [Serializable]
    public class MeinTraining
    {
        #region Fields

        private int _id;
        private string _titel;
        private string _beschreibung;
        private String _ort;
        private DateTime _datumVon;
        private DateTime _datumBis;
        private List<Mitarbeiter> _teilnehmerListe;
        private Mitarbeiter _erstelltVon;

        #endregion

        #region Properties

        [DataMember]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember]
        public string Titel
        {
            get { return _titel; }
            set { _titel = value; }
        }

        [DataMember]
        public string Beschreibung
        {
            get { return _beschreibung; }
            set { _beschreibung = value; }
        }

        [DataMember]
        public String Ort
        {
            get { return _ort; }
            set { _ort = value; }
        }

        [DataMember]
        public List<Mitarbeiter> TeilnehmerListe
        {
            get { return _teilnehmerListe; }
            set { _teilnehmerListe = value; }
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
        public Mitarbeiter ErstelltVon
        {
            get { return _erstelltVon; }
            set { _erstelltVon = value; }
        }

        #endregion
    }
}
