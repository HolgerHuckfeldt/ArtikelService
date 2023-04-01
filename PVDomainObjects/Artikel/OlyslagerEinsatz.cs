using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class OlyslagerEinsatz
    {
        public OlyslagerEinsatz()
        {
            Intervalle = new List<string>();
            Artikel = new List<OlyslagerVorschlag>();
        }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public List<string> Intervalle { get; set; }

        [DataMember]
        public List<OlyslagerVorschlag> Artikel { get; set; }

    }
}
