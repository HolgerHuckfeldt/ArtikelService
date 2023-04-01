using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects
{
    //[Serializable]
    public class VDBGetLoginResponse
    {
        public int Bestellid { get; set; }

        public int Lieferart  { get; set; }

        public int Zahlungsart { get; set; }

        public long Kreditlimit { get; set; }

        public string Waehrung  { get; set; }

        public int WaehrungsId { get; set; }

        public int Gueltigkeitsdauer { get; set; }

        public int Gueltigkeitstoleranz { get; set; }

        public bool NachtexpressErlaubt { get; set; }

        public bool VDBVerfuegbar { get; set; }

        public string Message { get; set; }

        public DateTime SystemTime { get; set; }
    }
}
