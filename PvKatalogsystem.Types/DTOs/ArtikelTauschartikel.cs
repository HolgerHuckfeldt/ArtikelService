using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class ArtikelTauschartikel
    {
        public ArtikelTauschartikel()
        {
            TecdocTauschartikel = new List<Artikel>();
            PvTauschartikel = new List<Artikel>();
        }

        [DataMember]
        public List<Artikel> TecdocTauschartikel { get; set; }
        [DataMember]
        public List<Artikel> PvTauschartikel { get; set; }

        public override string ToString()
        {
            return string.Format("PV: {0}, TECDOC: {1}", PvTauschartikel.Count, TecdocTauschartikel.Count);
        }
    }
}
