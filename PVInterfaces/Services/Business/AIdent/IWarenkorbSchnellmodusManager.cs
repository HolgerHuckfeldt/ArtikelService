using System;
using PV.DomainObjects.Artikel;
using System.Collections.Generic;
using PV.DomainObjects.Warenkorb;

namespace PV.Business.Services
{
    public interface IWarenkorbSchnellmodusManager : INummernArtikelManager
    {
        SchnellmodusArtikel CurrentSchnellmodusArtikel { get; set; }
        void Init();
        void SearchBySchnellmodusArtikel();
        List<WarenkorbImportStandards> GetImportFilters();
        string ImportiereWarenkorb(WarenkorbImportRequest request);
    }
}
