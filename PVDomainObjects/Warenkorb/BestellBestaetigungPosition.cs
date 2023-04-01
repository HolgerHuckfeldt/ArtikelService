using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Warenkorb
{
    [Serializable]
    public class BestellBestaetigungPosition
    {
        public int PositionsNummer { get; set; }

        public bool Splitartikel { get; set; }

        public List<Unterpositionen> Unterposition { get; set; }

        //Position

        public Decimal MengeGesammt
        {
            get
            {
                Decimal _menge = 0;
                foreach (Unterpositionen u in Unterposition)
                {
                    _menge += u.Menge;
                }
                return _menge;
            }
        }
    }
}
