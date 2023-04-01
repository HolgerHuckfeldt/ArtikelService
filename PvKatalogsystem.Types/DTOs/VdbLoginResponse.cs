using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class VdbLoginResponse
    {
        public int BestellId { get; set; }

        public int Lieferart { get; set; }

        public int Zahlungsart { get; set; }

        public long Kreditlimit { get; set; }

        public string Waehrung { get; set; }

        public int WaehrungsId { get; set; }

        public int Gueltigkeitsdauer { get; set; }

        public int Gueltigkeitstoleranz { get; set; }

        public string OfflineBestellId { get; set; }

        public bool VdbVerfuegbar { get; set; }

        public bool NachtexpressErlaubt { get; set; }

    }
}
