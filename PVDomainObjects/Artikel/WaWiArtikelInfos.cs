using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Artikel
{


    /// <summary>
    /// Verfügbarkeitsinfos von Warenwirtschaftssystemen.
    /// Aktuell von RepDoc und ProfiCar
    /// </summary>
    [Serializable]
    public class WaWiArtikelInfos
    {

        public string PictureUri { get; set; }

        public bool HasInfos { get; set; }

        /// <summary>
        /// Überschrift in der Artikelliste, meistens "Bestand".
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Wert in der Artikelliste, z.B. "2.00"
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Zusätzliche Infos, ohne das, was schon als Caption angezeugt wird.
        /// </summary>
        public List<KeyValuePair<string, string>> Zusatzinfos { get; set; }

    }
}
