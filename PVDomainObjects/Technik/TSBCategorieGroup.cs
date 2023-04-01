using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    public class TSBCategorieGroup
    {
        [DataMember]
        public List<TSBCategory> Categories { get; set; }
        [DataMember]
        public string CategorieName { get; set; }

    }
}
