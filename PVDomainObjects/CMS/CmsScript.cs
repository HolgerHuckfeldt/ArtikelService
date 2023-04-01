using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.CMS
{
    [DataContract]
    public class CmsScript
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Script { get; set; }

        [DataMember]
        public int Version { get; set; }

        [DataMember]
        public int Revision { get; set; }

        [DataMember]
        public string Dependencies { get; set; }


    }
}
