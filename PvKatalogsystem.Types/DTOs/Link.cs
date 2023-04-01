
using System;
using System.Runtime.Serialization;
namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class Link : DtoBase
    {
        [DataMember]
        public string Bezeichnung { get; set; }
        [DataMember]
        public string Beschreibung { get; set; }
        [DataMember]
        public string Uri { get; set; }
        [DataMember]
        public long Sortiernummer { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Bezeichnung, Beschreibung, Uri);
        }
    }
}
