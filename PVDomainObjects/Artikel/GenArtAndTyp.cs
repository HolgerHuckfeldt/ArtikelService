using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class GenArtAndTyp
    {
        [DataMember]
        public ArtikelArt Art { get; set; }

        [DataMember]
        public int GenArt { get; set; }

        [DataMember]
        public int GenArtTecDoc { get; set; }

        [DataMember]
        public int? Typ { get; set; }

        [DataMember]
        public int? VehicleId { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("GenArt: " + GenArt.ToString());
            sb.AppendLine("Art: " + Art.ToString());
            if (Typ != null)
                sb.AppendLine("Typ: " + Typ.Value);
            return sb.ToString();
        }
    }

    [DataContract]
    [Serializable]
    public class GenArtList
    {
        [DataMember]
        public List<int> GenArtL { get; set; }

        [DataMember]
        public int Typ { get; set; }

        [DataMember]
        public int VehicleId { get; set; }

        [DataMember]
        public bool Wartung { get; set; }

        [DataMember]
        public bool MitWeiterenHerstellern { get; set; }
    }
}
