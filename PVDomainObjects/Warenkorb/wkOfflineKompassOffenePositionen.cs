using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Warenkorb
{
    public class wkOfflineKompassFehler
    {
        public List<wkOfflineKompassOffenePositionen> offenePositionen { get; set; }
        public int BestellID { get; set; }
        public string OfflineBestellID { get; set; }
        public string BestellDatum { get; set; }
        public string BestellZeit { get; set; }
    }

    public class wkOfflineKompassOffenePositionen
    {
        public Artikel.Artikel ArtikelRef { get; set; }
        public DateTime Abholzeitpunkt { get; set; }
        public DateTime Lieferzeitpunkt { get; set; }
        public long UmsatzBonus { get; set; }
        public long AktionBonus { get; set; }
        public long KonzeptBonus { get; set; }
        public long TauschBonus { get; set; }
        public long KompassBestellBonus { get; set; }
        public long LieferBonus { get; set; }
        public long SummeBonus { get; set; }
        public long OnlineBonus { get; set; }
        public long Menge { get; set; }
    }
}
