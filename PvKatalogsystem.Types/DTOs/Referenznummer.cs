using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [DataContract]
    [Serializable]
    public class Referenznummer
    {
        [DataMember]
        public string Hersteller { get; set; }
        [DataMember]
        public string Nummer { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Hersteller, Nummer);
        }
    }
}
