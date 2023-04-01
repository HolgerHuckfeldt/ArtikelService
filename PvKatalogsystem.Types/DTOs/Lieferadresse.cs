using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class Lieferadresse
    {
        public string Empfaenger { get; set; }

        public string EmpfaengerZusatz { get; set; }

        public string AdressZusatz { get; set; }

        public string Strasse { get; set; }

        public string Plz { get; set; }

        public string Ort { get; set; }
    }
}
