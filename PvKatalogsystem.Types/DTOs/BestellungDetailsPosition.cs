using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class BestellungDetailsPosition
    {
        public int Id { get; set; }
        public String VdbHlk { get; set; }
        public String Bezeichnung { get; set; }
        public String Artikelnummer { get; set; }
        public String Hersteller { get; set; }
        public decimal EkEinzel { get; set; }
        public decimal EkSumme { get; set; }
        public decimal Menge { get; set; }
        public string Notiz1 { get; set; }
        public string Notiz2 { get; set; }

        // Plus Punkte Gesamt
        public long UmsatzPlusPunkte { get; set; }
        public long OnlinePlusPunkte { get; set; }
        public long KonzeptPlusPunkte { get; set; }
        public long AktionPlusPunkte { get; set; }
        public long TauschPlusPunkte { get; set; }
        public string AktionName { get; set; }

        public DateTime? Lieferdatum { get; set; }
        public string Lieferart { get; set; }
        public int PVPlus1 { get; set; }
        public int PVPlus2 { get; set; }
        public int MyProperty { get; set; }
        public bool Rueckstand { get; set; }
        public bool ShowGefahrgutkennzeichen { get; set; }
        public bool Splitartikel { get; set; }
        public bool IstLoseWare { get; set; }
        public string Steuer { get; set; }
        public string ALNummer { get; set; }
        public int Verfuegbarkeitskennzeichen { get; set; }
    }
}
