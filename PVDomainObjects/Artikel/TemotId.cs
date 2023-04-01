using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class TemotId
    {
        [DataMember]
        public string Strip { get; set; }
        [DataMember]
        public string Carid { get; set; }
        [DataMember]
        public int Streering { get; set; }
        [DataMember]
        public Int32 Ktyp { get; set; }
        [DataMember]
        public Int32 VehicleId { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Strip: " + Strip);
            sb.AppendLine("Carid: " + Carid);
            sb.AppendLine("Steering: " + Streering.ToString());
            sb.AppendLine("Ktyp: " + Ktyp.ToString());
            return sb.ToString();
        }
    }
}
