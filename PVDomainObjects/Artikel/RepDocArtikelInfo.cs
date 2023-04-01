using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [Serializable]
    public class RepDocArtikelInfo
    {
        public String HLKA { get; set; }
        public String ATNR { get; set; }
        public Boolean Verfuegbar { get; set; }
        public Boolean AndererStandort { get; set; }
        public Boolean Alternative { get; set; }
        public String ArtikelBezeichnung { get; set; }
        public List<RepDocArtikelInfo> Alternativartikel { get; set; }
    }
}
