using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Fahrzeug
{
    [Serializable]
    public class PRInfos
    {
        [DataMember]
        public List<string> PrNumbers { get; set; }

        public string Kba { get; set; }

        public string Vin { get; set; }

    }
}
