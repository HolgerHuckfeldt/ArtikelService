using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class ErsetzteArtikelnummer
    {
        [DataMember]
        public List<String> ErsetztVon { get; set; }
        [DataMember]
        public List<String> ErsetztDurch { get; set; }
    }
}
