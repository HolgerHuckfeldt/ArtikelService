using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface IVdbService
    {
        void LoadArtikelVdbInfos(ServiceContext serviceContext, List<Artikel> artikelList);
        BestellSession ValidateWarenkorb(ServiceContext context, BestellSession currentBestellung);
        void CancelWarenkorb(ServiceContext context, BestellSession bestellung);
        BestellResponse DoBestellung(BestellRequest bestellRequest, Lieferadresse lieferadresse);
        VdbLoginResponse GetLogin(ServiceContext context);
        KontoInfos GetKontoInformationen(ServiceContext context);
        List<ArtikelStaffelpreis> GetStaffelPreise(ServiceContext context, VdbArtikelidentifikator ident);
    }
}
