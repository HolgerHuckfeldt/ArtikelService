using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Fahrzeug
{
    [Serializable]
    [DataContract]
    public class MotorInfo
    {
        [DataMember]
        public string Motorcode
        {
            get; set;
        }

        [DataMember]
        public int Motornummer
        {
            get; set;
        }

    }
}
