using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class VdbUserInfo
    {
        public int Kundennummer { get; set; }
        public int Standort { get; set; }
        public int Abteilung { get; set; }
        public int Firma { get; set; }
        public int Versandadresse { get; set; }
    }
}
