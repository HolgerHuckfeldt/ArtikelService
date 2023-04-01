
using System;
using System.Runtime.Serialization;
namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class Preiseinheit : DtoBase
    {
        [DataMember]
        public string PreiseinheitBezeichnung { get; set; }
        [DataMember]
        public decimal PreiseinheitMenge { get; set; }
        [DataMember]
        public decimal PreisEinheitUmrechnungsFaktor { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", PreiseinheitBezeichnung, PreiseinheitMenge);
        }
    }
}
