using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    public class SchnellmodusArtikel
    {
        public String Artikelnummer { get; set; }
        public String Hersteller { get; set; }
        public Decimal Menge { get; set; }
        public Guid PosGuid { get; set; }
    }
}
