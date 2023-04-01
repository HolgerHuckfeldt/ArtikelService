using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Warenkorb.Transactions
{
    [DataContract]
    [Serializable]
    public class StornoRequest
    {
        [DataMember]
        public string Systembenutzer { get; set; }
        [DataMember]
        public string Systempasswort { get; set; }
        [DataMember]
        public VdbUserInfo VdbUserInfo { get; set; }
        [DataMember]
        public long BestellId { get; set; }
        [DataMember]
        public string OfflineBestellId { get; set; }
    }
}
