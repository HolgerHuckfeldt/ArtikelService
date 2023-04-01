using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Fahrzeug
{
    [DataContract]
    [Serializable]
    public class PkwInformation
    {
        [DataMember]
        public Hersteller hersteller;
        [DataMember]
        public Modell model;
        [DataMember]
        public PKWTyp type;

    }
}
