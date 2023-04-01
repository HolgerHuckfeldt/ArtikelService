using System;
using System.Data.SqlClient;


namespace PV.DomainObjects.Plus
{
    public class PraemienArtikelSortierung
    {

        /// <summary>
        /// Mögliche Sortierungstypen der Prämienartikel
        /// </summary>
        public enum PraemienArtikelSortierungEnum
        {
            Aufsteigend,
            Absteigend
        }

        public PraemienArtikelSortierungEnum SortierungEnum
        {
            get; set;
        }

        public SortOrder Sortierung
        {
            get; set;
        }

        public PraemienArtikelSortierung(PraemienArtikelSortierungEnum sortierungEnum)
        {
            SortierungEnum = sortierungEnum;
            Init();
        }

        private void Init()
        {
            switch(SortierungEnum)
            {
                case PraemienArtikelSortierungEnum.Absteigend:
                    Sortierung = SortOrder.Descending;
                    break;

                case PraemienArtikelSortierungEnum.Aufsteigend:
                    Sortierung = SortOrder.Ascending;
                    break;

                    default:
                    Sortierung = SortOrder.Unspecified;
                    break;
            }
        }

        public override string ToString()
        {
            return "PLUS-Punkte " + SortierungEnum.ToString().ToLower();
        }

    }
}
