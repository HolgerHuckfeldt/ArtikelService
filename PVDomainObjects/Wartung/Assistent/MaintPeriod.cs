using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Wartung.Assistent
{
    [DataContract]
    public class MaintPeriod
    {
        public MaintPeriod()
        {
            Optionals = new List<KeyValuePair<string,string>>();
        }

        [DataMember]
        public string SystemName;

        [DataMember]
        public string Name;
        [DataMember]
        public int Id;
        [DataMember]
        public List<KeyValuePair<string,string>> Optionals;
    }
}
