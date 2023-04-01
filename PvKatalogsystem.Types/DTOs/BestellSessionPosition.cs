using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    public class BestellSessionPosition
    {
        public BestellSessionPosition()
        {
            Positionsnummer = 0;
            Verfuegbarkeitsinfos = new LinkedList<BestellSessionVerfuegbarkeitsinfo>();
            Aenderungen = new HashSet<BestellungPositionAenderung>();
        }

        public int Id { get; set; }
        public int ArtikelId { get; set; }
        public int LinkageId { get; set; }
        public string VdbArtikelnummer { get; set; }
        public string VdbKatalogNummer { get; set; }
        public string VdbHlk { get; set; }
        public string Bezeichnung { get; set; }
        public string Artikelnummer { get; set; }
        public string Hersteller { get; set; }
        public decimal EkPreis { get; set; }
        public decimal EkSumme { get; set; }
        /// <summary>
        /// Kosten pro Artikel in Punkten. Nur relevant für Plus.
        /// </summary>
        public int PreisBonuspukte { get; set; }
        public decimal Menge { get; set; }
        public VdbVerfuegbarkeit Verfuegbarkeit { get; set; }
        public VdbVerfuegbarkeit AbholVerfuegbarkeit { get; set; }
        public int Positionsnummer { get; set; }
        public bool HasAlternativArtikel { get; set; }
        public bool HasIncentiveArtikel { get; set; }
        public string Notiz1 { get; set; }
        public string Notiz2 { get; set; }
        public String MengeneinheitBezeichnung { get; set; }
        public Decimal TechnischeMengeneinheitFaktor { get; set; }
        public String TechnischeMengeneinheitBezeichnung { get; set; }
        public Boolean TechnischeMengeneinheitIstGanzahleinheit { get; set; }
        public BestellungAnlieferungsart SelectedAnlieferungsartFilter { get; set; }

        public Decimal PreiseinheitFaktor { get; set; }
        public bool IsAbweichendePreiseinheit { get; set; }

        public BestellungPositionStatus VdbStatus { get; set; }
        public bool NachtexpressMoeglich { get; set; }
        public LinkedList<BestellSessionVerfuegbarkeitsinfo> Verfuegbarkeitsinfos { get; set; }

        public long? TopProduktId { get; set; }
        public long? ShowTopProduktId { get; set; }
        public bool TopProduktShown { get; set; }

        // Plus Punkte Gesamt
        public long UmsatzPlusPunkte { get; set; }
        public long OnlinePlusPunkte { get; set; }
        public long KonzeptPlusPunkte { get; set; }
        public long AktionPlusPunkte { get; set; }
        public long TauschPlusPunkte { get; set; }
        public string AktionName { get; set; }
        public bool HasPartsList { get; set; }

        // Vdb-Artikelhinweise
        public string ArtikelHinweisCaption { get; set; }
        public string ArtikelHinweisText { get; set; }

        public string BestellpositionGeteiltHinweisCaption { get; set; }
        public string BestellpositionGeteiltHinweisText { get; set; }

        public bool BestellpositionGeteilt { get; set; }

        public bool ArtikelHinweisVisible { get; set; }

        public virtual bool IstLoseWare { get; set; }
        public virtual decimal InhaltPreisfürWarenkorblogik { get; set; }

        public HashSet<BestellungPositionAenderung> Aenderungen { get; set; }
        
    }
}
