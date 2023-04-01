using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class SpellcheckResult
    {
        [DataMember]
        public string Word { get; set; }
        [DataMember]
        public string WordDisplay { get; set; }
        [DataMember]
        public int Freq { get; set; }
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public bool ValueCorrect { get; set; }
    }
}
