using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using PV.DomainObjects.Warenkorb;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable] 
    public class VdbArtikelInfo : VdbArtikelId
    {
        [DataMember]
        public List<VdbVerfuegbarkeitDetails> VerfuegbarkeitDetaillist { get; set; }

        [DataMember]
        public decimal EKPreis { get; set; }

        [DataMember]
        public int HauptWarengruppe { get; set; }

        [DataMember]
        public int UnterWarengruppe { get; set; }
        
        [DataMember]
        public int Warengruppe { get; set; }

        [DataMember]
        public wkVerfuegbarkeit Verfuegbarkeit { get; set; }

        [DataMember]
        public wkVerfuegbarkeit AbholVerfuegbarkeit { get; set; }

        [DataMember]
        public wkPositionStatus VDBStatus { get; set; }

        [DataMember]
        public string WarengruppenBezeichnung { get; set; }

        private List<Bonus> _bonuspunkte = new List<Bonus>();

        [DataMember]
        public List<Warenkorb.Bonus> Bonuspunkte
        {
            get { return _bonuspunkte; }
            set { _bonuspunkte = value; }
        }

        [DataMember]
        public bool Staffelpreise { get; set; }

        [DataMember]
        public double Streichpreis { get; set; }

        [DataMember]
        public long PreiseinheitEinkaufspreis { get; set; }

        [DataMember]
        public long PreiseinheitStreichpreis { get; set; }
    }
}
