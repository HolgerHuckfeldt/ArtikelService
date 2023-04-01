using System;
using PV.Utilities.Misc;


namespace PV.DomainObjects.Warenkorb
{
    public class AddingPositionEventArgs : EventArgs
    {
        private Artikel.Artikel _Artikel;
        private Decimal _Menge;

        public AddingPositionEventArgs(Artikel.Artikel artikel, Decimal menge, Guid? posGuid)
        {
            _Artikel = artikel;
            _Menge = menge;
            PosGuid = posGuid;
        }


        public Artikel.Artikel Artikel
        {
            get
            {
                return _Artikel;
            }
        }

        public Decimal Menge
        {
            get
            {
                return _Menge;
            }
        }

        public Guid? PosGuid { get; set;}
    }

    [Serializable]
    public class ArtikelAddedEventArgs : EventArgs
    {
        private Artikel.Artikel _Artikel;

        public ArtikelAddedEventArgs(Artikel.Artikel _artikel, object id, bool alreadyExisted, decimal menge)
        {
            _Artikel = _artikel;
            AlreadyExistedBefore = alreadyExisted;
            Id = id;
            Menge = menge;
        }

        public Artikel.Artikel AddedArtikel
        {
            get
            {
                return _Artikel;
            }
        }

        public object Id { get; set; }

        public bool AlreadyExistedBefore { get; set; }

        public decimal Menge { get; set; }
    }

    public class CollectorArticleAddedEventArgs : EventArgs
    {
        public object Id { get; set; }

        public decimal Menge { get; set; }
    }

    public class NotwendigeArtikelEventArgs : EventArgs
    {
        public Artikel.Artikel Artikel { get; set; }
        public decimal Menge { get; set; }
        public PVItemListe<Artikel.VerwandterArtikel> LastFoundNotwendigeArtikel { get; set; }
        public Artikel.Artikel LastSuccessfullyQueriedArtikel { get; set; }
    }
}
