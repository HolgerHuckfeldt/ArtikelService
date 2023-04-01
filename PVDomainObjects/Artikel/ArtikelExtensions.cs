using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    /// <summary>
    /// Stellt Extension Methods zum einheitlichen Vergleichen von Artikeln zur Verfügung
    /// </summary>
    [Serializable]
    public static class ArtikelExtensions
    {
        /// <summary>
        /// Bestimmt den Grad der Identitätsprüfung
        /// </summary>
        public enum ArtikelEqualityLevel
        {
            /// <summary>
            /// Standardwert für den Vergleich innerhalb der PVKompassWPF Domäne
            /// </summary>
            Application,
            /// <summary>
            /// Schwächerer Vergleich für die VDB
            /// </summary>
            Vdb
        }

        public static bool EqualsArtikel(this Artikel sender, Artikel other)
        {
            return sender.EqualsArtikel(other, ArtikelEqualityLevel.Application);
        }

        public static bool EqualsArtikel(this Artikel sender, Artikel other, ArtikelEqualityLevel level)
        {
            switch (level)
            {
                case ArtikelEqualityLevel.Application:
                    return
                        (sender.ArtikelNummer.Equals(other.ArtikelNummer, StringComparison.InvariantCultureIgnoreCase))
                        && (sender.DatenlieferantenNummer == other.DatenlieferantenNummer)
                        && (sender.GenArtNr == other.GenArtNr);

                case ArtikelEqualityLevel.Vdb:
                    return
                        (sender.ArtikelNummer.Equals(other.ArtikelNummer, StringComparison.InvariantCultureIgnoreCase))
                        && (sender.HLK.Equals(other.HLK, StringComparison.InvariantCultureIgnoreCase));

                default:
                    throw new InvalidOperationException("EqualsArtikel() not implemented for level "+level);
            }
        }
    }
}
