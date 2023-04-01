using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Stammdaten
{
    [Serializable]
    [DataContract]
    public class MyArtikelKategorien
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Id_Alt { get; set; }
        [DataMember]
        public int ArticleId { get; set; }
        [DataMember]
        public int Position { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool IsEditable { get; set; }
    }
}
