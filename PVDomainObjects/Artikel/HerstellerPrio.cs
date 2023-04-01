using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    public class HerstellerPrio
    {
        public int Kkz { get; set; }
        public int HerstellerId { get; set; }
        public int Hersteller { get; set; }
        public int Sortiernummer { get; set; }
        public int GenArtId { get; set; }
        public Anzeigen Anzeigen { get; set; }
    }

    public enum Anzeigen
    {
        Sofort_anzeigen = 0,
        Weitere_Hersteller = 1,
        Nicht_anzeigen = 2
    }
}
