using System;
using PV.DomainObjects.Common;

namespace PV.DomainObjects.Plus
{
    [Serializable]
    public class PlusKontogutschrift 
    {
        #region Properties

        public int GutschriftEuro
        {
            get; set;
        }

        public double PreisPunkte
        {
            get; set;
        }

        public PvImage Bild
        {
            get; set;
        }

        #endregion Properties

        #region Konstruktor

        public PlusKontogutschrift(int gutschrift, double punkte, PvImage bild)
        {
            GutschriftEuro = gutschrift;
            PreisPunkte = punkte;
            Bild = bild;
        }

        #endregion Konstruktor

    }
}
