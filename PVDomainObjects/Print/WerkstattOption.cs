using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Print
{
    [Serializable] 
    public class WerkstattOption
    {
        public bool Name { get; set; }
        public bool Zusatz{ get; set;}
        public bool Logo{ get; set;}
        public bool Firmenanschrifft { get; set; }
        public bool AbsenderImAdressFenster { get; set; }
        public bool Kontaktdaten { get; set; }
        public bool Freitext { get; set; }
        public bool Steuernummer { get; set; }
        public bool Inhaber { get; set; }
        public bool Sitz { get; set; }
        public bool RegisterGericht { get; set; }
        public bool BankVerbindung { get; set; }
    }
}
