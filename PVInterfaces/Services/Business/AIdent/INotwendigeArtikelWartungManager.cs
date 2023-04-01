using PV.DomainObjects.Artikel;
using PV.Utilities.Misc;

namespace PV.Business.Services
{
    public interface INotwendigeArtikelWartungManager
    {
        /// <summary>
        /// Liefert notwendige Artikel zu der Wartung seinem generischen Artikel
        /// </summary>
        /// <param name="_artikel"></param>
        /// <returns>Observable Collection</returns>
        PVItemListe<Artikel> GetNotwendigeArtikelAsync(GenArtList _GenArtList);
    }
}
