using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.Enums
{
    public enum BestellungPositionAenderung
    {
        KeineÄnderung = 0,
        ÄnderungDerMenge = 1,
        ArtikelGelöscht = 2,
        NeuerArtikel = 3,
        ArtikelGetauscht = 4,
        ArtikelTextAnlegen_Ändern = 5,
        BestellzeitPrüfen = 6,
        NET = 7//Nachtexpress
    }
}
