using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.Warenkorb;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Warenkorb.Transactions
{
    [Serializable]
    [DataContract]
    public class wkUnterpositonTransactionResp
    {
        [DataMember]
        public wkVerfuegbarkeit Verfuegbarkeitskennzeichen { get; set; }
        [DataMember]
        public wkVerfuegbarkeit AbholVerfuegbarkeitskennzeichen { get; set; }
        [DataMember]
        public bool BeimLieferbonusBeruecksichtigen { get; set; }
        [DataMember]
        public int VerfuegbarkeitskennzeichenSortieren { get; set; }
        [DataMember]
        public DateTime bestellschlusszeit { get; set; }
        [DataMember]
        public Boolean bestellschlusszeitSpecified { get; set; }
        [DataMember]
        public DateTime Lieferzeitpunkt { get; set; }
        [DataMember]
        public long Menge { get; set; }
        [DataMember]
        public DateTime Abholzeitpunkt { get; set; }
        [DataMember]
        public wkPositionStatus Status { get; set; }
    }    
}
