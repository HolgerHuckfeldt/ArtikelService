using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Warenkorb.Transactions
{
    [Serializable]
    [DataContract]
    public class wkWarenkorbTransactionResp
    {
        [DataMember]
        public List<wkPositionTransactionResp> PositionTransactions { get; set; }

        [DataMember]
        public long ResponseId { get; set; }

        [DataMember]
        public bool ResponseIdSpecified { get; set; }

        [DataMember]
        public long NewsId { get; set; }

        [DataMember]
        public int ErrorCode { get; set; }
        
        [DataMember]
        public int ErrorCodeUser { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public long BestellId { get; set; }

        [DataMember]
        public string OfflineBestellId { get; set; }

        public bool VDBVerfuegbar { get; set; }

        [DataMember]
        public decimal Warenkorbsumme { get; set; }

        [DataMember]
        public List<Bonus> Bonuspunkte { get; set; }
    }
}
