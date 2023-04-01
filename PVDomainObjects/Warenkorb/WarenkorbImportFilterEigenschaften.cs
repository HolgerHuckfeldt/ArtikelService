using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    [Serializable]
    public class WarenkorbImportStandards
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public FilterImportFileEncoding ImportFileEncoding { get; set; }
        [DataMember]
        public string AnzeigenName { get; set; }
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    [Serializable]
    public enum FilterImportFileEncoding
    {
        [EnumMember]
        ASCII = 0,
        [EnumMember]
        ANSI = 1
    }
}
