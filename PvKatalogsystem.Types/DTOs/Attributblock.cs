using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class Attributblock : DtoBase
    {
        public Attributblock()
        {
            Attribute = new List<Attribut>();
        }

        [DataMember]
        public List<Attribut> Attribute { get; set; }
        [DataMember]
        public long SortierNummer { get; set; }
        [DataMember]
        public List<int> ListLinkageId { get; set; }
        [DataMember]
        public int GenArtId { get; set; }

        public override string ToString()
        {
            return string.Join("¦", Attribute.Select(x => string.Format("{0}: {1} {2}", x.Kurzname, x.Wert, x.Einheit).Trim()));
        }

    }
}
