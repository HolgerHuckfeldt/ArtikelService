using System;

namespace PvKatalogsystem.Types.Enums
{
    public enum Suchergebnisfelder
    {
        Ohne = 0, // wird für Serialisierung gebraucht
        Artikelnummer = 1,
        Gebrauchsnummer = 2,
        Ean = 4,
        Referenznummer = 8,
        Vergleichsnummer = 16,
        Matchcode = 32
    }
}
