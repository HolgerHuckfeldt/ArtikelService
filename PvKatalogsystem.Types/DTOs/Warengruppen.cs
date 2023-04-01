using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class Warengruppen
    {
        [DataMember]
        public String VdbWAGR { get; set; }
        [DataMember]
        public String PitstopWAGR { get; set; }
    }
}
