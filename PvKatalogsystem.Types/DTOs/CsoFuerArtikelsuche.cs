using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class CsoFuerArtikelsuche
    {
        public int CountrySalesOrganisationsId { get; set; }
        public string CsoCode { get; set; }
        public List<string> AnzeigeSuchbaum { get; set; }
        public List<string> AnzeigeNummernsuche { get; set; }
        public List<string> AnzeigeTeaser { get; set; }
        public List<string> NichtAnzeigenSuchbaum { get; set; }
        public List<string> NichtAnzeigenNummernsuche { get; set; }
        public List<string> NichtAnzeigenTeaser { get; set; }
        public bool WeitereHersteller_beruecksichtigen { get; set; }
    }
}
