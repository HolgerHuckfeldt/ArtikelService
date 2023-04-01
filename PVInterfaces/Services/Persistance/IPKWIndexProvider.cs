/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Fahrzeugidentifikation
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für den PKW Index erfüllen muss
 ***************************************************************************************************************************************/
using System.Collections.Generic;
using PV.DomainObjects.Fahrzeug;


namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für PKW erfüllen muss
    /// </summary>
  public interface IPKWIndexProvider
    {
        #region Finder

        /// <summary>
        /// Initialisiert das Laden der Liste aller Hersteller
        /// </summary>
        
        IList<Hersteller> LoadHerstellerList();

        IList<Hersteller> LoadHerstellerList(int profileId);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Modelle eines Herstellers
        /// </summary>
        /// <param name="hersteller">Objekt mit Suchinformationen</param>
        
        IList<Modell> LoadModellList(Hersteller hersteller);

  IList<Modell> LoadModellList(Hersteller hersteller, int profileId);
        /// <summary>
        /// Initialisiert das Laden der Liste aller Typen eines Modells eines Herstellers
        /// </summary>
        /// <param name="model">Das ausgewählte Model</param>
        void LoadPKWTypList( Modell model );

        void LoadPKWTypList(Modell model, int profileId);

        
        IList<PKWTyp> LoadPKWTypListSimple(Modell model);

       
        IList<PKWTyp> LoadPKWTypListSimple(Modell model, int profileId);

        #endregion

        #region Erweiterte Suche

        /// <summary>
        /// Initialisiert das Füllen der Herstellerliste in der erweiterten Suche
        /// </summary>
        /// <param name="info">Objekt mit Suchinformationen</param>
        void LoadHerstellerStringList( FahrzeugSuchInfoObject info );
        void LoadHerstellerStringList(FahrzeugSuchInfoObject info, int profileId);

        
        HashSet<string> LoadHerstellerStringListSimple(FahrzeugSuchInfoObject info);

        /// <summary>
        /// Initialisiert das Füllen der Modellliste in der erweiterten Suche
        /// </summary>
        /// <param name="info">Objekt mit Suchinformationen</param>
        void LoadModellStringList( FahrzeugSuchInfoObject info );


        
        HashSet<string> LoadModellStringListSimple(FahrzeugSuchInfoObject info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Baujahre anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="info">Objekt mit Suchinformationen</param>
        void LoadBaujahrListe( FahrzeugSuchInfoObject info );

        
        HashSet<string> LoadBaujahrListeSimple( FahrzeugSuchInfoObject info );

        /// <summary>
        /// Initialisiert das Laden der Liste aller Hubräume anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="info">Objekt mit Suchinformationen</param>
        void GetHubraumListe(FahrzeugSuchInfoObject info);


        
        HashSet<string> GetHubraumListeSimple( FahrzeugSuchInfoObject info );


        /// <summary>
        /// Initialisiert das Laden der Liste aller Leistungen in KW anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="info">Objekt mit Suchinformationen</param>
        void GetLeistungKWListe( FahrzeugSuchInfoObject info );


        
        HashSet<string> GetLeistungKWListeSimple( FahrzeugSuchInfoObject info );


        /// <summary>
        /// Initialisiert das Laden der Liste aller Leistungen in PS anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="info">Objekt mit Suchinformationen</param>
        void GetLeistungPSListe( FahrzeugSuchInfoObject info );


        
        HashSet<string>GetLeistungPSListeSimple(FahrzeugSuchInfoObject info);


        /// <summary>
        /// Initialisiert das Laden der Liste aller Motorcodes anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="info">Objekt mit Suchinformationen</param>
        void GetMotorcodeListe( FahrzeugSuchInfoObject info );

        
        HashSet<string> GetMotorcodeListeSimple(FahrzeugSuchInfoObject info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller KraftstoffArten anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="info">Objekt mit Suchinformationen</param>
        void GetKraftstoffListe( FahrzeugSuchInfoObject info );

        
        HashSet<string> GetKraftstoffListeSimple(FahrzeugSuchInfoObject info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Bauarten anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="info">Objekt mit Suchinformationen</param>
        void GetBauartListe( FahrzeugSuchInfoObject info );

        
        HashSet<string> GetBauartListeSimple(FahrzeugSuchInfoObject info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Typen anhand eines Infoobjektes
        /// </summary>
        /// <param name="info">Der zu suchende String</param>
        void LoadPKWTypListByExtendetSearch( FahrzeugSuchInfoObject info );

        
        IList<PKWTyp> LoadPKWTypListByExtendetSearchSimple(FahrzeugSuchInfoObject info);


        #endregion

        #region Freitextsuche

        /// <summary>
        /// Initialisiert das Laden der Liste aller Typen die einen bestimmten String enthalten
        /// </summary>
        /// <param name="toSearch">Der zu suchende String</param>
        void LoadPKWTypListByString( string toSearch );


        /// <summary>
        /// Initialisiert das Laden der Liste eines Typen die einen bestimmten String und eine bestimmte TecDocId enthalten
        /// </summary>
        /// <param name="toSearch">Der zu suchende String</param>
        void LoadPKWTypListByStringKVAundTecTocID(string toSearch, int _TecTocID);

        
        IList<PKWTyp> LoadPKWTypListByStringSimple(string toSearch);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Typen eines KTypes
        /// </summary>
        /// <param name="ktype">Der zu suchende KType</param>
        
        IList<PKWTyp> LoadPKWTypListByKTypeSimple(int ktype);


   
        IList<PKWTyp> LoadPKWTypListByStringSimple(string toSearch, int profileId);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Suggestions für einen freien Suchstring
        /// </summary>
        /// <param name="toSuggest">der Suchstring</param>
        void LoadFreetextSuggestion( string toSuggest );

        void LoadFreetextSuggestion(string toSuggest, int profileId);

        
        IList<string> LoadFreetextSuggestionSimple(string toSuggest);

        
        IList<string> LoadFreetextSuggestionSimple(string toSuggest, int profileId);
        #endregion

        #region Methoden zur Suche nach IDs

        /// <summary>
        /// Liefert einen Hersteller anhand seiner ID
        /// </summary>
        /// <param name="herstellerID">Die HerstellerID</param>
        /// <returns>Der Hersteller</returns>
        
        Hersteller GetHerstellerById(int herstellerID);

      
        Hersteller GetHerstellerById(int herstellerID, int profileId);
        /// <summary>
        /// Liefert ein Modell anhand seiner ID
        /// </summary>
        /// <param name="modellId">Die ModellID</param>
        /// <returns>Das Modell</returns>
        
        Modell GetModellById(int modellId);

      
        Modell GetModellById(int modellId, int profileId);

        /// <summary>
        /// Liefert einen FahrzeugTyp anhand seiner ID
        /// </summary>
        /// <param name="fahrzeugTypID">Die FahrzeugTypID</param>
        /// <returns>Der FahrzeugTyp</returns>
        
        PKWTyp GetFahrzeugTypById(int fahrzeugTypID);

        
        PKWTyp GetFahrzeugTypById(int fahrzeugTypID, int profileId);

        /// <summary>
        /// Liefert eine Liste von FahrzeugTypen anhand einer Liste von IDs
        /// </summary>
        /// <param name="ids">Liste mit FahrzeugTypIDs</param>
        /// <returns>Liste mit FahrzeugTypen</returns>
        
        List<PKWTyp> GetFahrzeugTypsById(List<int> ids);

        
        List<PKWTyp> GetFahrzeugTypsById(List<int> ids, int profileId);

        
        PkwInformation GetPkwInformationByTypeId(int fahrzeugTypID);

       
        PkwInformation GetPkwInformationByTypeId(int fahrzeugTypID, int profileId);

        #endregion
    }
}
