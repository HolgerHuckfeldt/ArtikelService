using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    public class DurchlaufArtikel
    {
        public String Artikelnummer { get; set; }
        public Decimal Menge { get; set; }
        public Guid PosGuid { get; set; }
        public string OriginalHersteller { get; set; }
        public string OriginalBezeichnung { get; set; }
        public double OriginalVKPreis { get; set; }
        public double OriginalEKPreis { get; set; }
        public bool OEArtikel { get; set; }

        public string Herkunft { get; set; }

    }
}
