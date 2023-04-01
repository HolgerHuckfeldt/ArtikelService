using System;
using System.Collections.Generic;

namespace PvKatalogsystem.Types.DTOs
{
    public class Lkw : DtoBase
    {
        public Lkw()
        {
            Motorcodes = new List<string>();
            Radstaende = new List<KeyValuePair<string, int>>();
            Federungen = new List<KeyValuePair<string, string>>();
        }

        public int Id { get; set; }
        public int NTypNummer { get; set; }
        public Fahrzeugmodell Modell { get; set; }
        public string Typ { get; set; }
        public DateTime? BaujahrVon { get; set; }
        public DateTime? BaujahrBis { get; set; }
        public int? LeistungKwVon { get; set; }
        public int? LeistungPsVon { get; set; }
        public int? LeistungKwBis { get; set; }
        public int? LeistungPsBis { get; set; }
        public int?  Hubraum { get; set; } //ccm
        public List<string> Motorcodes { get; set; }
        public string Bauart { get; set; }
        public string Achse { get; set; }
        public List<KeyValuePair<string, int>> Radstaende { get; set; }
        public List<KeyValuePair<string, string>> Federungen { get; set; }
        public decimal? Tonnage { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} {2}", Id, Modell.Bezeichnung, Typ);
        }
    }
}
