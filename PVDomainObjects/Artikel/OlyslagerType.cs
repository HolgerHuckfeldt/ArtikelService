using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class OlyslagerType
    {
        public OlyslagerType()
        {
            Einsaetze = new List<OlyslagerEinsatz>();
        }

        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public List<OlyslagerEinsatz> Einsaetze { get; set; }

    }
}
