using System;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class Attribut : DtoBase
    {
        /// <summary>
        /// wird nur in den Details verwendet
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// wird nur in Listen verwendet
        /// </summary>
        [DataMember]
        public string Kurzname { get; set; }

        [DataMember]
        public string Wert { get; set; }

        [DataMember]
        public string Einheit { get; set; }

        [DataMember]
        public int LinkageId { get; set; }

        [DataMember]
        public long Sortiernummer { get; set; }

        /// <summary>
        /// soll der Name in der Liste verborgen werden?
        /// </summary>
        [DataMember]
        public bool HideName { get; set; }

        /// <summary>
        /// Soll das Attribut in der Liste angezeigt werden?
        /// </summary>
        [DataMember]
        public bool IsSofortanzeige { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Wert: {1}, Einheit: {2}", Name, Wert, Einheit);
        }
    }
}
