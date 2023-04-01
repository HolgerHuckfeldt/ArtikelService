using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class GenerischerArtikel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Bezeichnung { get; set; }
        [DataMember]
        public int GenArtNummerTecDoc { get; set; }
    }
}
