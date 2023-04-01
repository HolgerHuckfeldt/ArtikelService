using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class Unterposition
    {
        public DateTime? Lieferzeit { get; set; }

        public int Verfuegbarkeitskennzeichen { get; set; }

        public bool Rueckstand { get; set; }

        public int ErrorCodePosition { get; set; }

        public int UnterpositionsNummer { get; set; }

        public string HLK { get; set; }

        public string Notiz1 { get; set; }

        public string Notiz2 { get; set; }

        public string AktionsName { get; set; }

        public string Artikelnummer { get; set; }

        public long UmsatzBonus { get; set; }

        public long AktionBonus { get; set; }

        public long KonzeptBonus { get; set; }

        public long TauschBonus { get; set; }

        public long KompassBestellBonus { get; set; }

        public long LieferBonus { get; set; }

        public long OnlineBonus { get; set; }

        public long BonusPunktePosition { get; set; }

        public Decimal EKPreis { get; set; }

        public Decimal PositionSumme { get; set; }

        public Decimal Menge { get; set; }

        public Anlieferungsarten Lieferart { get; set; }
    }

    public enum Anlieferungsarten
    {
        Anlieferung = 5,
        Selbstabholung = 6,
        Nachtexpress = 12,
        Heimatstandort = 200
    }
}
