using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace PV.DomainObjects.Warenkorb.Transactions
{
    [DataContract]
    [Serializable]
    public class wkPositionTransactionReq
    {
        public wkPositionTransactionReq()
        {
            Statusflag = new List<enPositionStatusflag>();
        }

        [DataMember]
        public enBatteriestatus BatterieStatus { get; set; }

        [DataMember]
        public List<enPositionStatusflag> Statusflag { get; set; }

        [DataMember]
        public string GUIDKompass { get; set; }

        [DataMember]
        public string GUIDRepdoc { get; set; }

        [DataMember]
        public string Text1 { get; set; }

        [DataMember]
        public string Text2 { get; set; }

        [DataMember]
        public int Nr { get; set; }

        [DataMember]
        public string HLK { get; set; }

        [DataMember]
        public string Artikelnummer { get; set; }

        [DataMember]
        public Decimal Menge { get; set; }

        [DataMember]
        public int PreisBonuspunkte { get; set; }

        [DataMember]
        public TransactionWarengruppe WarenGruppe { get; set; }

        [DataMember]
        public Guid PosGuid { get; set; }

        [DataMember]
        public string Aktionsname { get; set; }

        [DataMember]
        public long AktionsBonuspunkte { get; set; }

        [DataMember]
        public Anlieferungsarten Anlieferungsart { get; set; }

        // R.H. 26.11.2009
        [DataMember]
        public Int32 TauschBonuspunkte { get; set; }

        [DataMember]
        public BestellsystemEnum Bestellsystem { get; set; }
    }

    [Serializable]
    [DataContract]
    public class TransactionWarengruppe
    {
        [DataMember]
        public int UWGR { get; set; }
        [DataMember]
        public int WAGR { get; set; }
        [DataMember]
        public int HWGR { get; set; }
        [DataMember]
        public string Bezeichnung { get; set; }
    }

    [DataContract]
    [Serializable]
    public enum BestellsystemEnum
    {
        [EnumMember]
        Kompass = 1,
        [EnumMember]
        TecCom = 2,
        [EnumMember]
        None = 99
    }
}
