using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class ArtikelDokumenteUndLinks : DtoBase
    {
        public ArtikelDokumenteUndLinks()
        {
            Dokumente = new List<Dokument>();
            Links = new List<Link>();
        }

        [DataMember]
        public List<Dokument> Dokumente { get; set; }
        [DataMember]
        public List<Link> Links { get; set; }

        [DataMember]
        public int Id { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}",Id);
        }
    }
}
