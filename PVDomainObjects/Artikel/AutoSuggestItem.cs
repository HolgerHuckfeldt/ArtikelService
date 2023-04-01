using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class AutoSuggestItem
    {
        [DataMember]
        public String DisplayName { get; set; }
        [DataMember]
        public String DisplayNameSort { get; set; }
        [DataMember]
        public Int32 ResultCount { get; set; }
        [DataMember]
        public AutoSuggestItemTypes Type { get; set; }
        [DataMember]
        public int GenArtId { get; set; }

    }
}
