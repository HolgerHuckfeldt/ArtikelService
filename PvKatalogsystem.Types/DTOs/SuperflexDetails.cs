using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class SuperflexDetails
    {
        public string Artikelnummer { get; set; }
        public string Herstellerkuerzel { get; set; }
        public bool IstLoseWare { get; set; }
        public decimal InhaltPreisfuerWarenkorblogikDecimal { get; set; }
        public string Bezeichnung { get; set; }

        public override string ToString()
        {
            return string.Format("{0}/{1}: {2}", Herstellerkuerzel,Artikelnummer,Bezeichnung);
        }
    }
}
