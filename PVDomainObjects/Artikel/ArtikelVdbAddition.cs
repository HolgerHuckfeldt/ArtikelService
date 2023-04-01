using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [Serializable]
    public class ArtikelVdbAddition
    {
        //Id
        public VdbArtikelId id { get; set; }

        //Daten
        public String ArtikelZustand { get; set; }
        public String DatentraegerAustauschnummer { get; set; }
        public String EanNummer { get; set; }
        public String Fehlertext { get; set; }
        public String Katalognummer { get; set; }
        public String LieferantenArtikelnummer { get; set; }
        public Int32 MehrwertSteuerschluessel { get; set; }
        public String OeNummer { get; set; }
        public String Preisart { get; set; }
        public Decimal Rabatt1 { get; set; }
        public Decimal Rabatt2 { get; set; }
        public String TauschteilKennzeichen { get; set; }
        public Int32 HWG { get; set; }
        public Int32 UWG { get; set; }
        public Int32 WAG { get; set; }
        public String WarengruppenBezeichnung { get; set; }
    }
}
