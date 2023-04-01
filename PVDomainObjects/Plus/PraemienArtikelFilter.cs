using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Plus
{

    public class PraemienArtikelFilter
    {
        /// <summary>
        /// Mögliche Filtertypen der Prämienartikel
        /// </summary>
        public enum PraemienArtikelFilterEnum
        {
            Alle,
            Bis10000,
            Bis5000,
            Bis1500,
            Bis1000,
            Unter1000
        }

        public PraemienArtikelFilterEnum FilterEnum
        {
            get; set;
        }

        public String Bezeichnung
        {
            get; set;
        }

        public int Wert
        {
            get; set;
        }

        public PraemienArtikelFilter(PraemienArtikelFilterEnum filterEnum)
        {
            FilterEnum = filterEnum;
            Init();
        }

        private void Init()
        {
            switch(FilterEnum)
            {
                case PraemienArtikelFilterEnum.Alle:
                    Bezeichnung = "Alle";
                    Wert = Int32.MaxValue;
                    break;
                case PraemienArtikelFilterEnum.Unter1000:
                    Bezeichnung = "Unter 1000";
                    Wert = 999;
                    break;
                case PraemienArtikelFilterEnum.Bis1000:
                    Bezeichnung = "Bis 1000";
                    Wert = 1000;
                    break;
                case PraemienArtikelFilterEnum.Bis1500:
                    Bezeichnung = "Bis 1500";
                    Wert = 1500;
                    break;
                case PraemienArtikelFilterEnum.Bis5000:
                    Bezeichnung = "Bis 5000";
                    Wert = 5000;
                    break;
                case PraemienArtikelFilterEnum.Bis10000:
                    Bezeichnung = "Bis 10000";
                    Wert = 10000;
                    break;
            }
        }

        public override String ToString()
        {
            return Bezeichnung;
        }

    }
}
