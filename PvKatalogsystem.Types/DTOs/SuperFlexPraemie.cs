using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class SuperFlexPraemie
    {
        public int PaketId { get; set; }
        public bool IstMenge { get; set; }
        public bool IstPreis { get; set; }
        public bool IstLiter { get; set; }
        public decimal VonMengePreis { get; set; }
        public decimal BisMengePreis { get; set; }
        public decimal PraemieInEuro { get; set; }
    }
}
