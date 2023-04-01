using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Warenkorb
{

    public enum PositionStatus
    {
        KeineAenderung,
        NeuePosition,
        MengeGeaendert,
        ArtikelGetauscht,
        PositionGeloescht
    }

    public enum PositionVDBStatus
    {
        Reserviert,
        StueckLimit,
        BestellLimit,
        NotFound,
        KreditLimit
    }

    public class WarenkorbPosition
    {
        public String ArtikelNummer { get; set; } //PIMMS
        public String VDBArtikelNummer { get; set; } //VDB
        public String HLK { get; set; }
        public int Menge { get; set; }
        public bool Alternativen { get; set; }
        public String Bezeichnung { get; set; }
        public String VDBBezeichnung { get; set; }
        public int Warengruppe { get; set; }
        public int HauptWarengruppe { get; set; }
        public int UnterWarengruppe { get; set; }
        public int EKPreis { get; set; }
        public int VKPreis { get; set; }
        public PositionVDBStatus VDBStatusFlag { get; set; }
        public PositionStatus StatusFlag { get; set; }
    }
}
