
using System;
using System.Runtime.Serialization;
namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class Dokument : DtoBase
    {
        [DataMember]
        public string Bezeichnung { get; set; }
        [DataMember]
        public string Dokumenttyp { get; set; }
        [DataMember]
        public string Dateityp { get; set; }
        [DataMember]
        public string Dateiname { get; set; }
        [DataMember]
        public string Fileformat { get; set; }
        [DataMember]
        public long Sortiernummer { get; set; }

        public override string ToString()
        {
            return string.Format("Bezeichnung: {0}, Typ: {1}, Dateiname: {2}", Bezeichnung, Dokumenttyp, Dateiname);
        }
    }
}
