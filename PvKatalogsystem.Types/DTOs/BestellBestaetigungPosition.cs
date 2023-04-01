using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class BestellBestaetigungPosition
    {
        public BestellBestaetigungPosition()
        {
            Unterpositionen = new List<Unterposition>();
        }

        public int PositionsNummer { get; set; }

        public bool IstLoseWare { get; set; }

        public bool Splitartikel { get; set; }

        public List<Unterposition> Unterpositionen { get; set; }

        public Decimal MengeGesamt
        {
            get
            {
                decimal menge = 0;

                Unterpositionen.Aggregate(menge, (summe, summand) => summe += summand.Menge);

                return menge;
            }
        }
    }
}
