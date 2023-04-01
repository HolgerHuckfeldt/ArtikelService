using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable] 
    public class Warengruppe
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
}
