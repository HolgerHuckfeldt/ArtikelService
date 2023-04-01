using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.Bestellung;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Warenkorb.Transactions
{
    [DataContract]
    [Serializable]
    public class wkWarenkorbTransactionReq : wkTransactionBaseReq
    {
        [DataMember]
        public IList<wkPositionTransactionReq> PositionTransactions { get; set; }

        [DataMember]
        public string Zahlweise   { get; set; }

        [DataMember]
        public string GuidKompass { get; set; }

        [DataMember]
        public Liefermodi Lieferart
        {
            get; set;
        }
    }
}
