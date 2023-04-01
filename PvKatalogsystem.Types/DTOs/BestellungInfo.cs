using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.DTOs
{
    public class BestellungInfo
    {
        public Int32 Id { get; set; }
        public String Auftragsnummer { get; set; }
        public String BestellId { get; set; }
        public DateTime Bestelldatum { get; set; }
        public Bestellart BestellArt { get; set; }
        public String Liefermodus { get; set; }
        public String Lieferant { get; set; }
        public String Versandadresse { get; set; }
        public String BenutzerName { get; set; }
        public String ProfilName { get; set; }
        public String EmpfangsId { get; set; }
        public String OfflineBestellId { get; set; }

        public string BestellArtAnzeige
        {
            get
            {
                string returnVal = BestellArt.ToString();

                if (returnVal.Contains("PlusWarenkorbOnline"))
                    returnVal = "Plus Warenkorb Online bestellt";
                else if (returnVal.Contains("PlusWarenkorbPräsentationsbestellung"))
                    returnVal = "Plus Warenkorb Präsentationsbestellung";

                return returnVal;
            }
        }
    }

    public enum Bestellart
    {
        Online,
        Nacht,
        Präsentationsbestellung,
        PlusWarenkorbOnline,
        PlusWarenkorbPräsentationsbestellung
    }
}
