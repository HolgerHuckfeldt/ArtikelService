using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class GenArtSortiernummer
    {
        [DataMember]
        public int GenArtId { get; set; }
        [DataMember]
        public Int64 Sortiernummer { get; set; }
    }
}
