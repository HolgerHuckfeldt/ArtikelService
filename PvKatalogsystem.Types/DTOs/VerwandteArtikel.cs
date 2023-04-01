using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class VerwandteArtikel
    {
        public int ArtikelId { get; set; }
        public int UnterartikelId { get; set; }
        public string Typ { get; set; }
        public bool SameKTypeOnly { get; set; }
        public decimal Amount { get; set; }
    }
}
