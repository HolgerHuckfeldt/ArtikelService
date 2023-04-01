using PV.DomainObjects.Artikel;

namespace PV.Business.Services
{
    public interface ITopProdukteManager
    {
        /// <summary>
        /// Das gerade gültige Top Produkt
        /// </summary>
        TopProdukt TopArtikel { get; }

        /// <summary>
        /// Veranlasst Warenkorb oder Kva die entsprechende Position gegen das Top Produkt zu tauschen
        /// </summary>
        /// <param name="_artikel"></param>
        void ChooseTopProdukt();

        /// <summary>
        /// Soll vom Front End aufgerufen werden, wenn der Benutzer eine Aktion ausgeführt hat,
        /// die ein TopProdukt ungültig macht
        /// </summary>
        void InvalidateTopProdukt();
    }
}

