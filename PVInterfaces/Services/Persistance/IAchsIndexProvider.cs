/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Achsidentifikation
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für den Achs Index erfüllen muss
 ***************************************************************************************************************************************/
using System.Collections.Generic;
using PV.DomainObjects.Fahrzeug;


namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für den Achs Index erfüllen muss
    /// </summary>
  
    public interface IAchsIndexProvider
    {
        #region Finder

        /// <summary>
        /// Initialisiert das Laden der Liste aller Hersteller
        /// </summary>
       
        IList<Hersteller> LoadHerstellerList();

        /// <summary>
        /// Initialisiert das Laden der Liste aller Modelle eines Herstellers
        /// </summary>
        /// <param name="_hersteller">Objekt mit Suchinformationen</param>
     
        IList<Modell> LoadModellList(Hersteller _hersteller);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Achsen 
        /// </summary>
        /// <param name="_modell">Das selektierte Modell</param>
        void LoadAchsenList(Modell _modell);

        /// <summary>
        /// liefert die Liste aller Achsen 
        /// </summary>
        /// <param name="_model">Das selektierte Modell</param>
      
        IList<Achse> LoadAchsenListSimple(Modell _model);

        #endregion

        #region Erweiterte Suche

        /// <summary>
        /// Initialisiert das Laden der Liste der HerstellerStrings
        /// </summary>
        void LoadHerstellerStringListe(AchsSuchInfoObjekt _info);

        /// <summary>
        /// liefert die Liste der HerstellerStrings
        /// </summary>
     
        IList<string> LoadHerstellerStringListeSimple(AchsSuchInfoObjekt _info);

        /// <summary>
        /// Initialisiert das Laden der Liste der ModellStrings
        /// </summary>
        void LoadModellStringListe(AchsSuchInfoObjekt _info);

        /// <summary>
        /// liefert die Liste der ModellStrings
        /// </summary>
        
        IList<string> LoadModellStringListeSimple(AchsSuchInfoObjekt _info);

        /// <summary>
        /// Initialisiert das Laden der Liste der Baujahre
        /// </summary>
        void LoadBaujahrListe(AchsSuchInfoObjekt _info);

        /// <summary>
        /// liefert die Liste der Baujahre
        /// </summary>
        
        IList<string> LoadBaujahrListeSimple(AchsSuchInfoObjekt _info);

        /// <summary>
        /// Initialisiert das Laden der Liste der Achstypen
        /// </summary>
        void LoadAchstypListe(AchsSuchInfoObjekt _info);

        /// <summary>
        /// liefert die Liste der Achstypen
        /// </summary>
        
        IList<string> LoadAchstypListeSimple(AchsSuchInfoObjekt _info);

        /// <summary>
        /// Initialisiert das Laden der Liste der Achsarten
        /// </summary>
        void LoadAchsartListe(AchsSuchInfoObjekt _info);

        /// <summary>
        /// liefert die Liste der Achsarten
        /// </summary>
        
        IList<string> LoadAchsartListeSimple(AchsSuchInfoObjekt _info);

        /// <summary>
        /// Initialisiert das Laden der Liste der Achsausführungen
        /// </summary>
        void LoadAchsausfuehrungListe(AchsSuchInfoObjekt _info);

        // <summary>
        /// liefert die Liste der Achsausführungen
        /// </summary>
        
        IList<string> LoadAchsausfuehrungListeSimple(AchsSuchInfoObjekt _info);

        /// <summary>
        /// Initialisiert das Laden der Liste der Bremsgrößen
        /// </summary>
        void LoadBremsgroesseListe(AchsSuchInfoObjekt _info);

        /// <summary>
        /// liefert die Liste der Bremsgrößen
        /// </summary>
        
        IList<string> LoadBremsgroesseListeSimple(AchsSuchInfoObjekt _info);

        /// <summary>
        /// Initialisiert das Laden der Achsen anhand eines  AchsSuchInfoObjekt
        /// </summary>
        /// <param name="_info">Das AchsSuchInfoObjekt</param>
        void LoadAchsenListeByExtendetSearch(AchsSuchInfoObjekt _info);

        /// <summary>
        /// liefert die Achsen anhand eines  AchsSuchInfoObjekt
        /// </summary>
        /// <param name="_info">Das AchsSuchInfoObjekt</param>
        
        IList<Achse> LoadAchsenListeByExtendetSearchSimple(AchsSuchInfoObjekt _info);

        #endregion

        #region Freitextsuche

        /// <summary>
        /// Initialisiert das Laden der Liste aller Typen die einen bestimmten String und TecDocID enthalten
        /// </summary>
        /// <param name="_toSearch">Der zu suchende String und TecDocID</param>
        void LoadAchsenListByStringUndTecDocID(string _toSearch, int _tecDocID);
        
        /// <summary>
        /// Initialisiert das Laden der Liste aller Achsen die einen bestimmten String enthalten
        /// </summary>
        /// <param name="_toSearch">Der zu suchende String</param>
        void LoadAchsenListByString(string _toSearch);

        /// <summary>
        /// liefert die Liste aller Achsen die einen bestimmten String enthalten
        /// </summary>
        /// <param name="_toSearch">Der zu suchende String</param>
        
        IList<Achse> LoadAchsenListByStringSimple(string _toSearch);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Suggestions für einen freien Suchstring
        /// </summary>
        /// <param name="_toSuggest">der Suchstring</param>
        void LoadFreetextSuggestion(string _toSuggest);

        /// <summary>
        /// liefert die Liste aller Suggestions für einen freien Suchstring
        /// </summary>
        /// <param name="_toSuggest">der Suchstring</param>
        
        IList<string> LoadFreetextSuggestionSimple(string _toSuggest);

        #endregion

        #region Methoden zur Suche nach IDs

        /// <summary>
        /// Liefert einen Hersteller anhand seiner ID
        /// </summary>
        /// <param name="_herstellerID">Die HerstellerID</param>
        /// <returns>Der Hersteller</returns>
        
        Hersteller GetHerstellerById(int _herstellerID);

        /// <summary>
        /// Liefert ein Modell anhand seiner ID
        /// </summary>
        /// <param name="_modellId">Die ModellID</param>
        /// <returns>Das Modell</returns>
        
        Modell GetModellById(int _modellId);

        /// <summary>
        /// Liefert eine Achse anhand ihrer ID
        /// </summary>
        /// <param name="_fahrzeugTypID">Die AchsIDID</param>
        /// <returns>Die Achse</returns>
        
        Achse GetAchseById(int _fahrzeugTypID);

        /// <summary>
        /// Liefert eine Liste von Achsen anhand einer Liste von IDs
        /// </summary>
        /// <param name="_ids">Liste mit AchsTypIDs</param>
        /// <returns>Liste mit AchsTypen</returns>
        
        List<Achse> GetAchseListeById( List<int> _ids );

        #endregion

    }
}
