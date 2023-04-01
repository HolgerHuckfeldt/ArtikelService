using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;
using PvKatalogsystem.Types.Enums;


namespace PvKatalogsystem.Types.Interfaces
{
    public interface IArtikelSQLService
    {
        List<Suchbaumknoten> GetSuchbaumknoten(ServiceContext context, ArtikelSuchoptionenFuerGetSuchbaumknoten suchoptionen);

        TemotStrip GetTemotStrip(int fzgId, int stripId);

        List<VerwandteArtikel> GetVerwandteArtikel(int articleId, int fahrzeugId, string fahrzeugArt);

        List<CsoFuerArtikelsuche> GetCsoFuerArtikelsuche();

        //List<MyArtikelKategorien> GetMeinSortimentArtikelIds(int profilId);

        //bool SaveMeinSortimentArtikel(ArtikelProviderRequest<MyArtikelKategorien> request);

        List<int> GetArtikelIds(TeaserTyp artikelDBtyp);
    }
}
