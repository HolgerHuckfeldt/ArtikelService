using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    public class BestellSession
    {
        public BestellSession()
        {
            Positionen = new List<BestellSessionPosition>();
            PositionenLoseWare = new List<BestellSessionPosition>();
            SuperflexpaketArtikel = new List<Artikel>();
        }

        public List<BestellSessionPosition> Positionen { get; set; }

        public List<BestellSessionPosition> PositionenLoseWare { get; set; }

        public List<Artikel> SuperflexpaketArtikel { get; set; }

        public int Id { get; set; }
        public BestellungStatus BestellungStatus { get; set; }
        public string Zahlweise { get; set; }
        public decimal EkSumme { get; set; }

        public string ErrorText { get; set; }
        public bool IsDirty { get; set; }
        public int SuperflexpaketId { get; set; }
        public bool GesperrtOnlineBestellung { get; set; }
        public bool PlusBestellungDeaktiviert { get; set; }
        public bool HasPlus { get; set; }
        public List<PlusPunktModel> PlusPunkte { get; set; }
        public string Kundenname { get; set; }
        public int Kundennummer { get; set; }
        public string KundenStrasse { get; set; }
        public string KundenORT_PLZ { get; set; }
        public long BestellId { get; set; }
        public long ResponseId_ValidateWarenkorb { get; set; }
        public string VdbOfflineBestellId { get; set; }
        public long BelegNummer { get; set; }
        public string LieferantName { get; set; }
        public string LieferantStrasse { get; set; }
        public string LieferantORT_PLZ { get; set; }
        public BestellungLiefermodus Liefermodus { get; set; }
        public BestellungLiefermodus SelectedLiefermodus { get; set; }

        public bool NachtexpressErlaubt { get; set; }
        public bool IstPlusBestellung { get; set; }
        public bool Gespeichert { get; set; }
        public int GespeichertWarenkorbId { get; set; }

        public DateTime? Lieferdatum { get; set; }
        public bool CanPerformBestellung { get; set; }
        public bool HasKredit { get; set; }

        public long UmsatzPlusPunkte { get; set; }
        public long LieferPlusPunkte { get; set; }
        public long OnlinePlusPunkte { get; set; }
        public long KonzeptPlusPunkte { get; set; }
        public long AktionsPlusPunkte { get; set; }
        public long TauschPlusPunkte { get; set; }
        public long GesamtBonuswert { get; set; }

        public long KontoPlusPunkte { get; set; }
        public long KontostandZweckgebunden { get; set; }

        /// <summary>
        /// Lieferdatum der letzten Teillieferung oder der Gesamtlieferung
        /// </summary>
        public DateTime? MinLieferDatum { get; set; }

        /// <summary>
        /// Datum der Gesamtlieferung zuzüglich 2 Monate
        /// </summary>
        public DateTime? MaxLieferDatum { get; set; }

        public DateTime? LastVdbTransaction { get; set; }

        public int Gueltigkeitsdauer { get; set; }

        /// <summary>
        /// Bestellnotiz im Warenkorb
        /// </summary>
        public string BestellnotizAngabe { get; set; }

        /// <summary>
        /// BestellnotizBestellnummer im Warenkorb
        /// </summary>
        public string BestellnotizBestellnummer { get; set; }
        
        public decimal PraemieFuerSuperflexpaket { get; set; }

        public decimal AnzahlArtikel { get; set; }

        public decimal UnterGrenzeFuerSuperflexpaketPraemie { get; set; }

        public bool IstMengePraemie { get; set; }

        public bool IstPreisPraemie { get; set; }

        public bool IstLiterPraemie { get; set; }

        public bool IstDealBestellung { get; set; }
    }

    public class PlusPunktModel
    {
        public string Bezeichnung { get; set; }
        public long Punkte { get; set; }
    }
}
