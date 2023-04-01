using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Pv.Services.Shared.Dtos
{
    [DataContract]
    public class Bestellung
    {
        [DataMember]
        public List<BonusZuordnung> BonuspunkteListe
        {
            get;
            set;
        }
                
        [DataMember]
        public List<BestellungPosition> PositionenListe
        {
            get;
            set;
        }

        [DataMember]
        public List<BestellungFaultPosition> FaultPositionenListe
        {
            get;
            set;
        }

        [DataMember]
        public Int64 BestellId
        {
            get;
            set;
        }

        [DataMember]
        public DateTime Bestellzeit
        {
            get;
            set;
        }

        [DataMember]
        public String Waehrung
        {
            get;
            set;
        }

        [DataMember]
        public Decimal EkPreisSumme
        {
            get;
            set;
        }

        [DataMember]
        public Decimal BonusSumme
        {
            get;
            set;
        }


        [DataMember]
        public Decimal BonusKontostand
        {
            get;
            set;
        }

        [DataMember]
        public String Text1
        {
            get;
            set;
        }

        [DataMember]
        public String Text2
        {
            get;
            set;
        }

        [DataMember]
        public Int32 Firma
        {
            get;
            set;
        }

        [DataMember]
        public Int32 Standort
        {
            get;
            set;
        }
    }
}
