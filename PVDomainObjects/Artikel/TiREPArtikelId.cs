using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [Serializable]
    public class TiREPArtikelId
    {
        [DataMember]
        public string Katalognummer { get; set; }

        [DataMember]
        public string Bemerkung1 { get; set; }
        [DataMember]
        public string Bemerkung2 { get; set; }

        [DataMember]
        public string Hlk { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Katalognummer: " + Katalognummer);
            sb.AppendLine("Hlk: " + Hlk);
            return sb.ToString();
        }
    }
}
