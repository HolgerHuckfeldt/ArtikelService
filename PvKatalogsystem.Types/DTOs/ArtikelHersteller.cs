
using System;
using System.Runtime.Serialization;
namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class Artikelhersteller : DtoBase
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Logo { get; set; }
        [DataMember]
        public long Nummer { get; set; }

        [DataMember]
        public int DLNr { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
