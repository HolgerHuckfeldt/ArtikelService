using System;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class Artikelinfo : DtoBase
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Wert { get; set; }
        [DataMember]
        public string WertRTF { get; set; }
        /// <summary>
        /// Soll das Attribut in der Liste angezeigt werden?
        /// </summary>
        [DataMember]
        public bool IsSofortanzeige { get; set; }
        [DataMember]
        public long Sortiernummer { get; set; }
        [DataMember]
        public int LinkageId { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} {2}", Name, Wert, IsSofortanzeige ? "(Sofortanzeige)" : "");
        }
    }
}
