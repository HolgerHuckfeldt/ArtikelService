using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class KontoInfos
    {
        public decimal Gutschriften { get; set; }
        public decimal Lastschriften { get; set; }

        public long KontostandVerfuegbar { get; set; } //Saldo des Bonuskontos, alle Bonuspunkte,
        public long KontostandGesamt { get; set; } //Saldo des Bonuskontos, alle Bonuspunkte
        public long KontostandZweckgebunden { get; set; } //Saldo des Bonuskontos, alle zweckgebundenen Bonuspunkte
        public long MonatlichesKreditlimit { get; set; }

        public string Fehlercode { get; set; } //Abfrage des monatlichen Kreditlimits (nicht noch verfügbare Bestellsumme)
    }
}
