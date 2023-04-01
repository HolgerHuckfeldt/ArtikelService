using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Technik
{
    using System.Runtime.Serialization;

    [DataContract]
    public class OelInfo
    {
        [DataMember]
        public List<string> Viskositaeten { get; set; }
        [DataMember]
        public List<string> Freigaben { get; set; }

    }
}
