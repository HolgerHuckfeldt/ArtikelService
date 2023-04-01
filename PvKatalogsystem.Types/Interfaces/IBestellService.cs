using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;
using PvKatalogsystem.Types.Results;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface IBestellService
    {
        BestellSession GetBestellSession(ServiceContext context, bool validate, int superflexpaketId = 0);
        bool CancelBestellSession(ServiceContext context);
        bool ClearBestellSession(ServiceContext context, int superflexpaketId = 0);
        decimal AddPosition(ServiceContext context, int artikelId, decimal menge, bool replaceMenge, Artikel artikelSuperflex,
            decimal inhaltPreisfürWarenkorblogik = 0, bool istLoseWare = false);
        bool RemovePosition(ServiceContext context, int artikelId);
        Int32 BestellungSenden(ServiceContext context, BestellungPublikation publikation = BestellungPublikation.None);
        void LoadSuperflexPaketIntoBestellsession(ServiceContext context, int superflexPaketId);
       
        List<Artikel> LoadDealArtikel(ServiceContext context, DateTime dealDate);
        List<Artikel> LoadTitelangebote(ServiceContext context);
        ArtikelSearchResult LoadSuperflexPaketArtikelWithGenArt(ServiceContext context, int superflexPaketId, ArtikelSuchoptionen options, string artikelFormat = null);
        decimal AddDummyPosition(ServiceContext context, Artikel artikel, decimal menge);
        void UpdateEksummeAfterRabatt(ServiceContext context, decimal neueEksumme);

        ArtikelSearchResult LoadSuperflexPaketArtikel(ServiceContext context, int superflexPaketId, string suchtext, ArtikelSuchoptionen options, int pageIndex, int pageSize);
    }
}
