using System.Collections.Generic;
using System;

namespace PvKatalogsystem.Types.DTOs
{
    public class Achse : DtoBase
    {
        public Achse()
        {
            Bremsengroesse = new List<string>();
        }
        public int Id { get; set; }
        public int Achsnummer { get; set; }
        public Fahrzeugmodell Modell { get; set; }
        public string Typ { get; set; }
        public List<string> Bremsengroesse { get; set; }
        public string Ausfuehrung { get; set; }
        public string Achsart { get; set; }
        public DateTime? BaujahrVon { get; set; }
        public DateTime? BaujahrBis { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} {2}", Id, Modell.Bezeichnung, Typ);
        }
    }
}
