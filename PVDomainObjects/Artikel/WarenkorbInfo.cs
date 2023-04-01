using System;
using PV.DomainObjects.Stammdaten;

namespace PV.DomainObjects.Warenkorb
{
    [Serializable]
    public class WarenkorbInfo
    {
        public Guid Id { get; set; }
        public int BelegNummer { get; set; }
        public string Title { get; set; }
        public int AnzahlPositionen { get; set; }
        public Mitarbeiter Benutzer { get; set; }
        public string Gruppe { get; set; }
        public DateTime GespeichertAm { get; set; }
    }
}
