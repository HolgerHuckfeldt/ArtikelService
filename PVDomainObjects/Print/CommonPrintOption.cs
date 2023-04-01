using System;

namespace PV.DomainObjects.Print
{
    /// <summary>
    /// repensentiert die DruckOptionen zum speichern und Anzeugen der gespeicherten Daten
    /// des PrintSettingsProvider
    /// </summary>
    [Serializable]
    public class CommonPrintOption
    {

        public bool KundenDaten { get; set; }
        public bool ArtikelArbeitswertNummern { get; set; }
        public bool HinweiseZuArbeitswerten { get; set; }
        public bool ArtikelHersteller { get; set; }
        public bool Umfasst{ get; set;}
        public bool Freitext { get; set; }

    }
}
