using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PV.DomainObjects.Warenkorb;

namespace PV.DomainObjects.Bestellung
{
    //[DataContract]
    [Serializable]
    public class bsPosition
    {
        //[DataMember]
        public bool Rueckstand { get; set; }

        //[DataMember]
        public string UserText1 { get; set; }

        //[DataMember]
        public string UserText2 { get; set; }

        //[DataMember]
        public int PositionsNummer { get; set; }

        //[DataMember]
        public bool Splitartikel { get; set; }

        //[DataMember]
        public int UnterpositionsNummer { get; set; }

        //[DataMember]
        public string HLK { get; set; }

        //[DataMember]
        public string Artikelnummer { get; set; }

        //[DataMember]
        public long UmsatzBonuspunkte { get; set; }

        //[DataMember]
        public long BonusPunktePosition { get; set; }

        //[DataMember]
        public long BonusPunktePositionSumme { get; set; }

        //[DataMember]
        public Decimal Menge { get; set; }

        //[DataMember]
        public Decimal EkPreis { get; set; }

        //[DataMember]
        public string Steuer { get; set; }

        //[DataMember]
        public Decimal PositionSumme { get; set; }

        [NonSerialized]
        private Anlieferungsarten _anlieferungsart;
        public Anlieferungsarten Anlieferungsart
        {
            get { return _anlieferungsart; }
            set { _anlieferungsart = value; }
        }

        //[DataMember]
        public DateTime Lieferzeit { get; set; }

        [NonSerialized]
        private wkVerfuegbarkeit _verfuegbarkeit;
        public wkVerfuegbarkeit Verfuegbarkeit
        {
            get { return _verfuegbarkeit; }
            set { _verfuegbarkeit = value; }
        }

        //[DataMember]
        public String Bezeichnung { get; set; }

        //[DataMember]
        public String Hersteller { get; set; }

        //[DataMember]
        public int ErrorCodePosition { get; set; }
    }
}
