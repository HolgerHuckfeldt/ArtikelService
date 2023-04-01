using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Fahrzeug
{
    public class FahrzeugInfosRepdoc
    {
        public string DateErstzulassung { get; set; }
        public string HerstellerBez1 { get; set; }
        public string KBA { get; set; }
        public string MotorCode { get; set; }
        public string Kennzeichen { get; set; }
        public string kmStand { get; set; }
        public string FahrzeugID { get; set; }
        public string TypVarianteVersion { get; set; }
        public int TypID { get; set; }

        public string KundenNr { get; set; }
        public string Anrede { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Strasse { get; set; }
        public string StrasseNr { get; set; }
        public string PLZ { get; set; }
        public string Ort { get; set; }
        public string Telefon { get; set; }
        public string eMail { get; set; }
    }
}
