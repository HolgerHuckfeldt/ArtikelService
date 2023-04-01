using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    public class AttributListe
    {
        public string Key { get; set; }
        public string KritBezEinheit { get; set; }
        public List<string> Werte { get; set; }
    }
}
