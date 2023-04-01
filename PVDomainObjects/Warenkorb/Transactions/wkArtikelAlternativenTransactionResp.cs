using System;


namespace PV.DomainObjects.Warenkorb.Transactions
{
    [Serializable]
    public class wkArtikelAlternativenTransactionResp
    {
        public Artikel.VdbArtikelInfo ArtikelInfo { get; set; }
        public DateTime Abholzeitpunkt { get; set; }
        public String Artikelbezeichnung { get; set; }
        public Decimal VKPreis { get; set; }
        public DateTime Lieferzeitpunkt { get; set; }
        public long UmsatzBonus { get; set; }
        public long AktionBonus { get; set; }
        public long KonzeptBonus { get; set; }
        public long TauschBonus { get; set; }
        public long KompassBestellBonus { get; set; }
        public long LieferBonus { get; set; }
        public long SummeBonus { get; set; }
        public long OnlineBonus { get; set; }
    }
}
