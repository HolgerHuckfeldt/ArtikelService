using System.Collections.Generic;
using PvKatalogsystem.Types.DTOs;
using PvKatalogsystem.Types.Enums;
using PvKatalogsystem.Types.Results;
using System;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface IArtikelService
    {
        //
        //[WebGet]
        //List<Artikel> GetArtikelList(IEnumerable<int> idList);

        Artikel GetArtikel(ServiceContext context, int artikelId, bool mitTauschartikel, bool mitTopProdukt = false, bool mobileArtikeldetails = false, Fahrzeugart fzgArt = null, int fzgId = 0);

        List<Artikel> GetArtikelList(ServiceContext context, IEnumerable<int> idList, bool mitTauschartikel, bool mitTopProdukt = false,
            bool nurCSOpassendeArtikel = false, bool showNurLieferbar = false, List<KeyValuePair<int,
            int>> artIdZuGenArtId = null, int selectedGenArtNummer = 0, string fzgIdent = "", 
            bool mobileArtikeldetails = false, bool usefzgIdentForFahrzeugId = false);


        ArtikelSearchResult FindArtikelByVdbArtikelnummerPrefix(ServiceContext context, string vdbHlk, string vdbArtikelnummerPrefix, bool mitTauschartikel, bool mitTopProdukt = false);

        
        ArtikelDetails GetArtikelDetails(ServiceContext context, int artikelId, Fahrzeugart fahrzeugArt, int fahrzeugId);        

        
        List<Dokument> GetArtikelDokumente(ServiceContext context, int artikelId);
        
        
        ArtikelSearchResult FindArtikelBySuchtext(ServiceContext context, string suchtext, Suchbaumtyp sbTyp, Fahrzeugart fzgArt, int fzgId, int genArtId, int startIndex, int rowCount, bool suchstringFuerHersteller, bool mobile = false);

        
        ArtikelSearchResult FindArtikelByGenArtAndTyp(ServiceContext context, Fahrzeugart fzgArt, int fzgId, int genArtId, int genArtIdTecDoc, int startIndex, int rowCount);

        
        ArtikelSearchResult FindArtikelByNummer(ServiceContext context, ArtikelSuchoptionenFuerNummernsuche suchoptionen);

        
        ArtikelSearchResult GetArtikelFuerGenArtNummerList(ServiceContext context, List<int> genArtNummern, Suchbaumtyp sbTyp, Fahrzeugart fzgArt, int fzgId, int startIndex, int rowCount, bool mitWeiterenHerstellern = false);

        
        ArtikelSearchResult FindArtikel(ServiceContext context, string suchtext, ArtikelSuchoptionen options, int startIndex, int rowCount);

        
        ArtikelSearchResult FindArtikelByOENummer(ServiceContext context, ArtikelSuchoptionenFuerNummernsuche suchoptionen);

        
        Artikel GetArtikelByKatalognummerUndHLK(ServiceContext context, string katalognummer, string hlk);
        
        
        Artikel GetArtikelByArtikelnummerUndHerstellernummerOrDLNr(ServiceContext context, string artikelnummer, long herstellernummer = 0, int dlnr = 0);

        
        Artikel GetArtikelByArtikelnummerUndHlkFuerPims1(ServiceContext context, string artikelnummer, string hlk);

        
        Artikel GetArtikelByArtikelnummerUndDLNr(ServiceContext context, string artikelnummer, int dlnr);

        
        List<Suchbaumknoten> GetSuchbaumknoten(ServiceContext context, ArtikelSuchoptionenFuerGetSuchbaumknoten suchoptionen);

        
        ArtikelSearchResult GetArtikelByGenerischerArtikel(ServiceContext context, UebergabeFuerSolr uebergabeFuerSolr);

        //
        //ArtikelSearchResult GetArtikelForPC(ServiceContext context, UebergabeFuerSolr uebergabeFuerSolr);


        
        List<Stuecklistenartikel> GetStueckliste(ServiceContext context, int artikelId, StuecklisteTyp typ, int selectedGenArtNummer = 0, Fahrzeugart fzgArt = null, int fzgId = 0);

        
        List<Artikel> GetTauschartikel(ServiceContext context, int artikelId);

        
        List<VerwandterArtikel> GetVerwandteArtikel(ServiceContext context, int artikelId, bool getZubehoer, bool mitSameKtypeOnly, Fahrzeugart fahrzeugArt, int fzgId, bool mobile = false);

        
        List<Artikel> GetVerwandteArtikelByArtikelList(ServiceContext context, List<int> artikelIds, Fahrzeugart fahrzeugArt, int fzgId);

        
        List<KeyValuePair<String, String>> GetLogistikInfos(ServiceContext context, int artikelId);

        
        ArtikelSonstigeNummern GetNummern(ServiceContext context, int artikelId);

        
        Dictionary<string, string> GetGefahrengutHinweise(int artikelId);

        
        List<int> GetFahrzeugIdsForArtikel(int artikelId, string typ, int fahrzeugTyp);

        
        ArtikelSearchResult GetTeaserArtikel(ServiceContext context, TeaserTyp teaserTyp);

        /// <summary>
        /// Liefert uns die Details eines Artikels
        /// </summary>
        /// <param name="hlk">VdbHerstellerKuerzel</param>
        /// <param name="artikelnummer">VdbArtikelnummer</param>
        /// <param name="fahrzeugId">FahrzeugId</param>
        /// <param name="csoCode">CsoCode</param>
        /// <returns></returns>
        
        Artikel GetArtikelDetailsByHlkAndArtikelnummer(ServiceContext context, string hlk, string artikelnummer, string csoCode);

        
        IDictionary<string, int> GetOutletArtikelInfo();

        
        ArtikelSearchResult FindArtikelByHlkAndArtikelnummer(ServiceContext context, string suchtext, ArtikelSuchoptionen options, int startIndex, int rowCount);

        
        ArtikelSearchResult FindSFPArtikelByHlkAndArtikelnummer(ServiceContext context, ArtikelSuchoptionen options, int startIndex, int rowCount);

        
        ArtikelSearchResult GetArtikelByMeinSortiment(ServiceContext context, List<int> artikelIds);
    }
}


//(ResponseFormat = WebMessageFormat.Json)