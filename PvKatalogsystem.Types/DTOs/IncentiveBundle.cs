using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    public class IncentiveBundle
    {
        public int Id { get; set; }
        public string Artikelnummer { get; set; }
        public string Hersteller { get; set; }
        public string Bezeichnung { get; set; }
        public string Vorschaubild { get; set; }
        public decimal? MengeMin { get; set; }
        public string Claim { get; set; }
        public string Sofortbeschreibung { get; set; }
        public decimal? IncentiveArtikelMenge { get; set; }
        public ArtikelAktionsinformation Aktionsinformation { get; set; }
        public VdbArtikelinformationen VdbInformation { get; set; }
    }
}
