using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Warenkorb.Transactions
{
    [Serializable]
    [DataContract]
    public class wkPositionTransactionResp
    {
        //VerfuegbarkeitEigenschaften
        [DataMember]
        public List<wkUnterpositonTransactionResp> UnterPositionTransactions { get; set; }

        [DataMember]
        public decimal EKPreis { get; set; }

        [DataMember]
        public decimal Positionssumme { get; set; }

        [DataMember]
        public string ErrorCodeArtikel { get; set; }

        [DataMember]
        public Boolean FlagAlternative { get; set; }

        [DataMember]
        public string Text1 { get; set; }

        [DataMember]
        public string Text2 { get; set; }

        [DataMember]
        public wkPositionStatus VDBStatus { get; set; }

        [DataMember]
        public long UmsatzBonus { get; set; }

        [DataMember]
        public long AktionBonus { get; set; }

        [DataMember]
        public long KonzeptBonus { get; set; }

        [DataMember]
        public long TauschBonus { get; set; }

        [DataMember]
        public long KompassBestellBonus { get; set; }

        [DataMember]
        public long LieferBonus { get; set; }

        [DataMember]
        public long SummeBonus { get; set; }

        [DataMember]
        public long OnlineBonus { get; set; }

        [DataMember]
        public int Nr { get; set; }

        [DataMember]
        public string HLK { get; set; }

        [DataMember]
        public string Artikelnummer { get; set; }

        [DataMember]
        public TransactionWarengruppe Warengruppe { get; set; }

        [DataMember]
        public decimal Menge { get; set; }

        [DataMember]
        public bool NachtexpressMoeglich { get; set; }

        [DataMember]
        public Anlieferungsarten Anlieferungsart { get; set; }
    }
}
