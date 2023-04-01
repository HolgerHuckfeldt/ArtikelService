using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class SelectedItems
    {
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public bool IsSelected { get; set; }
    }
}
