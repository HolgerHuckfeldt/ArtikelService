using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Types.DTOs
{
    public class BestellResponse
    {
        public BestellResponse()
        {
            BestellBestaetigungArray = new List<BestellBestaetigungPosition>();
        }

        public BestellungStatus Status { get; set; }

        public Decimal WarenkorbSumme { get; set; }

        public long GesamtBonuswert { get; set; }

        public long KontoStand { get; set; }

        public long ResponseID { get; set; }

        public long NewsID { get; set; }

        public DateTime Bestellzeit { get; set; }

        public long UmsatzBonus { get; set; }

        public long LieferBonus { get; set; }

        public long AktionBonus { get; set; }

        public long KonzeptBonus { get; set; }

        /// <summary>
        /// Tauschbonus für TopProdukt
        /// </summary>
        public long TauschBonus { get; set; }

        public long KompassBestellBonus { get; set; }

        public long SummeBonus { get; set; }

        public long OnlineBonus { get; set; }

        public int Lieferart { get; set; }

        public string Waehrung { get; set; }

        public string Message { get; set; }

        public List<BestellBestaetigungPosition> BestellBestaetigungArray { get; set; }
    }
}
