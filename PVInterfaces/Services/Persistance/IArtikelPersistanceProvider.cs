/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Artikelsuche
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für Artikel erfüllen muss
 ***************************************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using PV.DomainObjects.Artikel;
using PV.DomainObjects.Common;
using PV.DomainObjects.Stammdaten;

namespace PV.Persistance.Provider
{
    
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für Artikel erfüllen muss
    /// </summary>

    public interface IArtikelPersistanceProvider
    {
        /// <summary>
        /// Liefert für den Artikel _art die Verwandten Artikel
        /// Mit dem jeweiligen GenArt verknüpfte Artikel müssen zusätzlich geladen werden
        /// </summary>
        /// <param name="_art"></param>
        /// <returns></returns>
        
        List<VerwandterArtikel> GetVerwandteArtikelByArtikel(ArtikelProviderRequest<ArtikelKatalogIdent> request);

        /// <summary>
        /// Liefert die Stückliste für einen Artikel
        /// und bindet Fahrzeugabhängige Kriterien an die Entities
        /// </summary>
        /// <param name="_art">Pkw,Nkw oder null</param>
        /// <param name="_mandant"></param>
        /// <returns>Stückliste</returns>
        
        List<StuecklistenArtikel> GetTecDocStuecklisteByArtikel(ArtikelProviderRequest<ArtikelKatalogIdent> request);

        /// <summary>
        /// Liefert die Stückliste für einen Artikel
        /// und bindet Fahrzeugabhängige Kriterien an die Entities
        /// </summary>
        /// <param name="_art">Pkw,Nkw oder null</param>
        /// <param name="_mandant"></param>
        /// <returns>Stückliste</returns>
        
        List<StuecklistenArtikel> GetPVStuecklisteByArtikel(ArtikelProviderRequest<ArtikelKatalogIdent> request);

        /// <summary>
        /// Liefert die Zubehörliste für einen Artikel
        /// </summary>
        /// <param name="_art">Pkw,Nkw oder null</param>
        /// <param name="_mandant"></param>
        /// <returns>Zubehörliste</returns>
        
        List<ZubehoerArtikel> GetZubehoerByArtikel(ArtikelProviderRequest<ArtikelKatalogIdent> request);

        /// <summary>
        /// Liefert, die Gefahrenguthinweise für den Artikel
        /// </summary>
        /// <param name="_artikel">Artikel, für den die Hinweise gesucht sind</param>
        /// <returns>Gefahrenguthinweise oder null</returns>
        
        GefahrengutHinweise GetGefahrengutHinweiseByArtikel(Artikel _artikel);

        /// <summary>
        /// liefert die Bilder für die Zoomdarstellung
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        
        List<PvImage> GetArtikelZoomBilder(ArtikelProviderRequest<ArtikelKatalogIdent> request);
        
        /// <summary>
        /// Initialisiert das Laden der Liste aller Suggestions für einen freien Suchstring
        /// </summary>
        /// <param name="toSuggest">der Suchstring</param>
        void GetFreetextSuggestion(ArtikelProviderRequest<AutoSuggestSuchfilter> request);

        
        List<AutoSuggestItem> GetFreetextSuggestionSimple(ArtikelProviderRequest<AutoSuggestSuchfilter> request);

        /// <summary>
        /// Liefert eine Liste aller Suchbaumeinträge in einer angegebenen Sprache
        /// </summary>
        /// <param name="_art">Die Angabe welcher Suchbaum gewünscht ist</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_typ"></param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <returns>Liste von SuchbaumEintrag</returns>
        
        List<SuchbaumEintrag> GetSuchbaumEintragList(ArtikelSuchbaumRequest artikelSuchbaumRequest);

        /// <summary>
        /// Liefert die Artikelliste anhand eines Suchbaumeintrages für einen Typen in einer angegebenen Sprache
        /// </summary>
        /// <param name="_art">Die Angabe welche Artikel gewünscht ist</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_knoten">Der Suchbaumeintrag</param>
        /// <param name="_typ">Der Typ</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns></returns>
        
        ArtikelProviderResult<Artikel> GetArtikelListeBySuchknotenAndTyp(ArtikelProviderRequest<SuchknotenAndTyp> request);

        /// <summary>
        /// Liefert die Artikelliste anhand eines GenArt für einen Typen in einer angegebenen Sprache
        /// </summary>
        /// <param name="_art">Die Angabe welche Artikel gewünscht ist</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_genArt">Der Generische Artikel</param>
        /// <param name="_typ">Der Typ</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns></returns>
        
        List<Artikel> GetArtikelListeByGenArtikelAndTyp(ArtikelProviderRequest<GenArtAndTyp> request);


        /// <summary>
        /// Liefert die Artikelliste anhand eines Suchbaumeintrages für einen Typen in einer angegebenen Sprache
        /// KOMBINIERT MIT EINER FREITEXTSUCHE ZUR WEITEREN EINSCHRÄNKUNG
        /// </summary>
        /// <param name="_art">Die Angabe für was man Artikel sucht</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_toSearch">Der zu suchende String</param>
        /// <param name="_typ">Der Typ</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste von Artikeln</returns>
        
        ArtikelProviderResult<Artikel> GetArtikelListeBySuchstringSuchknotenAndTyp(
            ArtikelProviderRequest<SuchstringSuchknotenTyp> request);
        
        /// <summary>
        /// Liefert die Artikelliste anhand eines Suchbaumeintrages für einen Typen in einer angegebenen Sprache
        /// </summary>
        /// <param name="_art">Die Angabe für was man Artikel sucht</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_toSearch">Der zu suchende String</param>
        /// <param name="_typ">Der Typ</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste von Artikeln</returns>
        
        ArtikelProviderResult<Artikel> GetArtikelListeBySuchstring(ArtikelProviderRequest<SuchstringAndTyp> request);
        
        /// <summary>
        /// Liefert für einen Artikel die IDs der PKWs in welchen er verwendet wird
        /// </summary>
        /// <param name="_genArtNr">Die Nummer des generischen Artikels</param>
        /// <param name="_artikelNummer">Die Nummer des Artikels</param>
        /// <param name="_dLNr">Die Datenlieferantennummer</param>
        /// <returns>Die Liste der TypIDs</returns>
        
        List<int> GetPKWForArtikel(int? _genArtNr, string _artikelNummer, Int64 _dLNr, int _fahrzeugTyp, int artikelId);

        /// <summary>
        /// Liefert für einen Artikel die IDs der NKWs in welchen er verwendet wird
        /// </summary>
        /// <param name="_genArtNr">Die Nummer des generischen Artikels</param>
        /// <param name="_artikelNummer">Die Nummer des Artikels</param>
        /// <param name="_dLNr">Die Datenlieferantennummer</param>
        /// <returns>Die Liste der TypIDs</returns>
        
        List<int> GetNKWForArtikel(int? _genArtNr, string _artikelNummer, Int64 _dLNr, int fahrzeugTyp, int artikelId);

        /// <summary>
        /// Liefert für einen Artikel die IDs der Achsen in welchen er verwendet wird
        /// </summary>
        /// <param name="_genArtNr">Die Nummer des generischen Artikels</param>
        /// <param name="_artikelNummer">Die Nummer des Artikels</param>
        /// <param name="_dLNr">Die Datenlieferantennummer</param>
        /// <returns>Die Liste der TypIDs</returns>
        
        List<int> GetAchsenForArtikel(int? _genArtNr, string _artikelNummer, Int64 _dLNr, int fahrzeugTyp, int artikelId);

        /// <summary>
        /// Liefert für einen Artikel die IDs der Motoren in welchen er verwendet wird
        /// </summary>
        /// <param name="_genArtNr">Die Nummer des generischen Artikels</param>
        /// <param name="_artikelNummer">Die Nummer des Artikels</param>
        /// <param name="_dLNr">Die Datenlieferantennummer</param>
        /// <returns>Die Liste der TypIDs</returns>
        
        List<int> GetMotorForArtikel(int? _genArtNr, string _artikelNummer, Int64 _dLNr, int fahrzeugTyp, int artikelId);

        /// <summary>
        /// Liefert eine Liste von Artikeln, deren OE-Nummern einen bestimmten String enthalten
        /// </summary>
        /// <param name="_nummer">Die Nummer nach der gesucht werden soll</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste der zusätzlichen Artikel</returns>
        
        ArtikelProviderResult<Artikel> GetArtikelByReferenzNummer(ArtikelProviderRequest<ArtikelNummernsucheArten> request);

        
        ArtikelProviderResult<Artikel> GetArtikelByOENummerForDVSE(ArtikelProviderRequest<ArtikelOENummerForDVSE> request);

        /// <summary>
        /// Liefert eine Liste von Artikeln, deren EA-Nummern einen bestimmten String enthalten
        /// </summary>
        /// <param name="_nummer">Die Nummer nach der gesucht werden soll</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste der zusätzlichen Artikel</returns>
        
        ArtikelProviderResult<Artikel> GetArtikelByEAN(ArtikelProviderRequest<ArtikelNummernsucheArten> request);

        /// <summary>
        /// Liefert eine Liste von Angebotsartikeln, die in der Teaserschaltfläche angezeigt werden sollen
        /// </summary>
        /// <returns>Liste der zusätzlichen Artikel</returns>
        
        ArtikelProviderResult<Artikel> GetTeaserArtikel(ArtikelProviderRequest<String> request);

        /// <summary>
        /// Liefert eine Liste von Incentiveartikeln, die in der Teaserschaltfläche angezeigt werden sollen
        /// </summary>
        /// <returns>Liste der zusätzlichen Artikel</returns>
        
        ArtikelProviderResult<Artikel> GetTeaserIncentiveArtikel(ArtikelProviderRequest<String> request);
        
        /// <summary>
        /// Liefert eine Liste von notwendigen Artikeln, deren Artikelnummern einer bestimmten GenArtNr zugehören
        /// </summary>
        /// <param name="GenArtListe">Die Nummer nach der gesucht werden soll</param>
        /// <param name="_AnzHersteller">max Anzahl der Hersteller </param>
        /// <param name="_AnzArtikel">max Anzahl der Artikel pro Hersteller</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <returns>Liste der zusätzlichen Artikel</returns>
        
        ArtikelProviderResult<Artikel> GetNotwendigeArtikelFuerGenArtList(ArtikelProviderRequest<GenArtList> request);

        /// <summary>
        /// Liefert eine Liste von Artikeln, deren Artikelnummern einen bestimmten String enthalten
        /// </summary>
        /// <param name="_nummer">Die Nummer nach der gesucht werden soll</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste der zusätzlichen Artikel</returns>
        
        ArtikelProviderResult<Artikel> GetArtikelByArtikelNummer(ArtikelProviderRequest<ArtikelNummernsucheArten> request);

        /// <summary>
        /// Liefert eine Liste von Artikeln, deren Artikelnummern einen bestimmten String enthalten
        /// </summary>
        /// <param name="_nummer">Die Nummer nach der gesucht werden soll</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste der zusätzlichen Artikel</returns>
        
        ArtikelProviderResult<Artikel> GetArtikelByMatchcode(ArtikelProviderRequest<ArtikelNummernsucheArten> request);

        /// <summary>
        /// Liefert eine Liste von Artikeln, deren Gebrauchsnummern einen bestimmten String enthalten
        /// </summary>
        /// <param name="_nummer">Die Nummer nach der gesucht werden soll</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste der zusätzlichen Artikel</returns>
        
        ArtikelProviderResult<Artikel> GetArtikelByGebrauchsNummer(ArtikelProviderRequest<ArtikelNummernsucheArten> request);

        /// <summary>
        /// Liefert eine Liste von Artikeln, deren Vergleichsnummern einen bestimmten String enthalten
        /// </summary>
        /// <param name="_nummer">Die Nummer nach der gesucht werden soll</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste der zusätzlichen Artikel</returns>
        
        ArtikelProviderResult<Artikel> GetArtikelByVergleichsNummer(ArtikelProviderRequest<ArtikelNummernsucheArten> request);

        /// <summary>
        /// Liefert Artikel anhand von TmodInformationen
        /// </summary>
        /// <param name="_strip">Die Temot-Strip-ID</param>
        /// <param name="_carid">Die Temot-Car-ID</param>
        /// <param name="_streering">Lenkung ja/nein</param>
        /// <param name="_ktyp">Der TecDoc KTyp</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste von Artikeln</returns>
        
        ArtikelProviderResult<Artikel> GetArtikelListForTemod(ArtikelProviderRequest<TemotId> request);

        
        ArtikelDetailContainer GetPackedArtikelDetails(ArtikelProviderRequest<Artikel> request);

        /// <summary>
        /// Erzeugt aus einer Liste von KatalogIds eine Liste von TecdocArtikeln
        /// evtl. vorhandene Typ verknüpfungen werden berücksichtigt.
        /// </summary>
        /// <param name="_artikelliste">Liste von KatalogIds</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste von TecdocArtikeln</returns>
        
        List<Artikel> GetTecdocArtikelByKatalogIdListe(ArtikelProviderRequest<List<ArtikelKatalogIdent>> request);

        /// <summary>
        /// Erzeugt aus einer Liste von KatalogIds eine Liste von TecdocArtikeln
        /// evtl. vorhandene Typ verknüpfungen werden berücksichtigt.
        /// </summary>
        /// <param name="_artikelliste">Liste von KatalogIds</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste von TecdocArtikeln</returns>
        
        List<Artikel> GetTecdocArtikelByKatalogIdListePims1(ArtikelProviderRequest<List<ArtikelKatalogIdent>> request);

        /// <summary>
        /// Erzeugt aus einer Liste von VDB-Artikeldaten eine Liste von TecdocArtikeln
        /// </summary>
        /// <param name="_artikelliste">Liste von VDB-Artikeldaten</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste von TecdocArtikeln</returns>
        
        List<Artikel> GetTecdocArtikelByVDBArtikelliste(ArtikelProviderRequest<List<VdbArtikelId>> request);

        /// <summary>
        /// Erzeugt aus einer ArtNr und DLNr eine Liste von Alternativartikeln
        /// </summary>
        /// <returns>Liste von Artikeln</returns>
        
        List<Artikel> GetTecDocAlternativArtikelByArtNrUndDLNr(ArtikelProviderRequest<ArtikelID> request);
      

        /// <summary>
        /// Erzeugt aus einer Liste von TiREP-Artikeldaten eine Liste von TecdocArtikeln
        /// </summary>
        /// <returns>Liste von TecdocArtikeln</returns>
        
        List<Artikel> GetTecdocArtikelByTiREPArtikelliste(ArtikelProviderRequest<List<TiREPArtikelId>> request);
        
        /// <summary>
        /// Liefert das TopProdukt zu einem Produkt
        /// </summary>
        /// <param name="artikel">das Basisprodukt</param>
        /// <returns>Top-Produkt-Artikel</returns>
        
        TopProdukt GetTopProduktByArtikel(ArtikelProviderRequest<ArtikelKatalogIdent> request);

        /// <summary>
        /// Lädt die Bonusaktionsartikel für einen Kunden
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        
        ArtikelProviderResult<Artikel> GetBonusArtikelByKunde(ArtikelProviderRequest<string> request);

        
        MobileArtikelDetails GetArtikelDetailsByArtikelId(ArtikelProviderRequest<MobileArtikelDetailsRequest> request);

        
        ArtikelProviderResult<Artikel> GetArtikelListByArtikelIdList(ArtikelProviderRequest<List<int>> request);

        
        List<int> EutotaxTypes();

        
        ArtikelProviderResult<Artikel> GetArtikelByMeinSortiment(ArtikelProviderRequest<String> request);

        
        bool SaveMeinSortimentArtikel(ArtikelProviderRequest<MyArtikelKategorien> request);
    }
}
