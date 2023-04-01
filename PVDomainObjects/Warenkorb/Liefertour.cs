using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Warenkorb
{
    //[Serializable]
    public class Liefertour
    {
        public DateTime Lieferung { get; set; }
        public DateTime PVServerTime { get; set; }
        public bool LiefertourHeuteNichtVerfuegbar { get; set; }
        public bool VDBVerfuegbar { get; set; }
    }
}
