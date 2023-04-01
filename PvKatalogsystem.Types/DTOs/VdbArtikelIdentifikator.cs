
using System;
using System.Runtime.Serialization;
namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class VdbArtikelidentifikator : DtoBase
    {
        [DataMember]
        public string Artikelnummer { get; set; }
        [DataMember]
        public string Herstellerkuerzel { get; set; }
        
        public override string ToString()
        {
            return string.Format("{0}, {1}", Herstellerkuerzel, Artikelnummer);
        }

    }
}
