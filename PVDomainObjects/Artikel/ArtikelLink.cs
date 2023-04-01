using System;

namespace PV.DomainObjects.Artikel
{
    [Serializable]
    public class ArtikelLink
    {
        public string Bezeichnung { get; set; }
        public string Uri { get; set; }

        public int DLNr { get; set; }
        public DokumentenTyp Typ { get; set; }
    }
}
