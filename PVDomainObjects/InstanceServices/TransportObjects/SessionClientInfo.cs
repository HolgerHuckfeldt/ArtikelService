using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PV.DomainObjects.InstanceServices.TransportObjects
{
    [DataContract]
    [Serializable]
    public class SessionClientInfo
    {
        [DataMember]
        public String name;

        [DataMember]
        public DateTime lastAlive;

        [DataMember]
        public DateTime registered;

        [DataMember]
        public DateTime loggedOn;
    }
}