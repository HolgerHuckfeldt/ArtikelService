using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    public class TSBSystem
    {
        [DataMember]
        public string systemDescription { get; set; }

        [DataMember]
        public string oeCode { get; set; }

        [DataMember]
        public string Motorcode { get; set; }

        [DataMember]
        public List<TSBItem> items { get; set; }

        [DataMember]
        public int systemId { get; set; }

        [DataMember]
        private List<TSBGroup> _groups = null;
        public List<TSBGroup> groups
        {
            get
            {
                if (_groups == null)
                    _groups = new List<TSBGroup>();
                return _groups;
            }
        }

    }
}
