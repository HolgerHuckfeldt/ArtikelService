using PV.DomainObjects.Plus.PlusWarenkorb;
using PV.DomainObjects.Warenkorb;

//using PV.DomainObjects.Plus.PlusWarenkorb;

namespace PV.Business.Services
{
    public interface IPlusWarenkorbManager
    {
        /// <summary>
        /// Liefert den aktuellen Warenkorb
        /// </summary>
        PlusWarenkorb CurrentWarenkorb
        {
            get;
        }

        /// <summary>
        /// Erzeugt einen neuen Warenkob und setzt diesen als den aktuellen
        /// </summary>
        void CreateWarenkorb();

        void Update();

        void Stornieren();

        void Bestellen();

        KontoInfos GetKontoInformationen();
    }
}
