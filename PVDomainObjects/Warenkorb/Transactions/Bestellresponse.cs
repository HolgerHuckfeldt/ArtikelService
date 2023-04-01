using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Warenkorb
{
    [Serializable]
    public class Bestellresponse
    {
        public Status Status { get; set; }

        public Decimal WarenkorbSumme { get; set; }

        public long GesamtBonuswert { get; set; }

        public long KontoStand { get; set; }

        public long ResponseID { get; set; }

        public int IdDB { get; set; }

        public string OfflineBestellId { get; set; }

        public long NewsID { get; set; }

        public DateTime Bestellzeit { get; set; }

        public long UmsatzBonus { get; set; }

        public long AktionBonus { get; set; }

        public long KonzeptBonus { get; set; }

        public long TauschBonus { get; set; }

        public long KompassBestellBonus { get; set; }

        public long LieferBonus { get; set; }

        public long SummeBonus { get; set; }

        public long OnlineBonus { get; set; }

        public int Lieferart { get; set; }

        public string Waehrung { get; set; }

        public string Message { get; set; }

        public List<DomainObjects.Warenkorb.BestellBestaetigungPosition> BestellBestaetigungArray { get; set; }

        public bool VdbSoapAccesDirect { get; set; }
    }
}
