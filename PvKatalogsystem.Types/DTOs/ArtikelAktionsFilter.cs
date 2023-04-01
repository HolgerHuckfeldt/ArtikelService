using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class ArtikelAktionsFilter
    {
        public ArtikelAktionsFilter(int aktionsnummer, int kundengruppe, int absatzgruppe)
        {
            Aktionsnummer = aktionsnummer;
            Kundengruppe = kundengruppe;
            Absatzgruppe = absatzgruppe;
        }

        public int Aktionsnummer { get; set; }
        public int Kundengruppe { get; set; }
        public int Absatzgruppe { get; set; }
    }
}
