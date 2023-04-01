using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class Fahrzeugmodell
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime? BaujahrVon { get; set; }
        public DateTime? BaujahrBis { get; set; }
        public Fahrzeughersteller Hersteller { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2})", Hersteller.Name, Bezeichnung, Id);
        }
    }
}
