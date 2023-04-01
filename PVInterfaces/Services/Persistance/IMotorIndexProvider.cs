/***************************************************************************************************************************************
/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Achsidentifikation
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für den Motor Index erfüllen muss
 ***************************************************************************************************************************************/
using System.Collections.Generic;
using PV.DomainObjects.Fahrzeug;



namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für den Motor Index erfüllen muss
    /// </summary>
  
    public interface IMotorIndexProvider
    {
        #region Motoren suchen [erweitert]

        /// <summary>
        /// Initialisier das Laden der HerstellerStringListe
        /// </summary>
        void LoadHerstellerStringListe(MotorSuchInfoObjekt _info);

        /// <summary>
        /// Liefert die HerstellerStringListe
        /// </summary>
        /// <returns>Eine Liste der Herstellernamen</returns>
        
        IList<string> LoadHerstellerStringListeSimple(MotorSuchInfoObjekt _info);

        /// <summary>
        /// Initialisier das Laden der BaujahrListe
        /// </summary>
        void LoadBaujahrListe(MotorSuchInfoObjekt _info);

        /// <summary>
        /// Liefert die BaujahrListe
        /// </summary>
        
        IList<string> LoadBaujahrListeSimple(MotorSuchInfoObjekt _info);

        /// <summary>
        /// Initialisier das Laden der HubraumListe
        /// </summary>
        void LoadHubraumListe(MotorSuchInfoObjekt _info);

        /// <summary>
        /// Liefert die HubraumListe
        /// </summary>
        
        IList<string> LoadHubraumListeSimple(MotorSuchInfoObjekt _info);

        /// <summary>
        /// Initialisier das Laden der LeistungKWListe
        /// </summary>
        void LoadLeistungKWListe(MotorSuchInfoObjekt _info);

        /// <summary>
        /// Liefert die LeistungKWListe
        /// </summary>
        
        IList<string> LoadLeistungKWListeSimple(MotorSuchInfoObjekt _info);

        /// <summary>
        /// Initialisier das Laden der LeistungPSListe
        /// </summary>
        void LoadLeistungPSListe(MotorSuchInfoObjekt _info);

        /// <summary>
        /// Liefert die LeistungPSListe
        /// </summary>
        
        IList<string> LoadLeistungPSListeSimple(MotorSuchInfoObjekt _info);

        /// <summary>
        /// Initialisier das Laden der MotorcodeListe
        /// </summary>
        void LoadMotorCodeListe(MotorSuchInfoObjekt _info);

        /// <summary>
        /// Liefert die MotorcodeListe
        /// </summary>
        
        IList<string> LoadMotorCodeListeSimple(MotorSuchInfoObjekt _info);

        /// <summary>
        /// Initialisier das Laden der KraftstoffListe
        /// </summary>
        void LoadKraftstoffListe(MotorSuchInfoObjekt _info);

        /// <summary>
        /// liefert die KraftstoffListe
        /// </summary>
        
        IList<string> LoadKraftstoffListeSimple(MotorSuchInfoObjekt _info);

        /// <summary>
        /// Initialisier das Laden der MotorartListe
        /// </summary>
        void LoadMotorartListe(MotorSuchInfoObjekt _info);

        /// <summary>
        /// liefert die MotorartListe
        /// </summary>
        
        IList<string> LoadMotorartListeSimple(MotorSuchInfoObjekt _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Motoren anhand eines Infoobjektes
        /// </summary>
        /// <param name="_info">Der zu suchende String</param>
        void LoadMotorenListByExtendetSearch(MotorSuchInfoObjekt _info);

        /// <summary>
        /// liefert die Liste aller Motoren anhand eines Infoobjektes
        /// </summary>
        /// <param name="_info">Der zu suchende String</param>
        
        IList<Motor> LoadMotorenListByExtendetSearchSimple(MotorSuchInfoObjekt _info);

        #endregion

        #region Freitextsuche

        /// <summary>
        /// Initialisiert das Laden der Liste aller Suggestions für einen Suchstring
        /// </summary>
        /// <param name="_toSuggest">der Suchstring</param>
        void LoadFreetextSuggestion(string _toSuggest);

        /// <summary>
        /// liefert die Liste aller Suggestions für einen Suchstring
        /// </summary>
        /// <param name="_toSuggest">der Suchstring</param>
        
        IList<string> LoadFreetextSuggestionSimple(string _toSuggest);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Typen die einen bestimmten String enthalten
        /// </summary>
        /// <param name="_toSearch">Der zu suchende String</param>
        void LoadMotorenListByString(string _toSearch);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Typen die einen bestimmten String und TecDocID enthalten
        /// </summary>
        /// <param name="_toSearch">Der zu suchende String und TecDocID</param>
        void LoadMotorenListByStringUndTecDocID(string _toSearch, int _tecDocID);


        /// <summary>
        /// liefert die Liste aller Typen die einen bestimmten String enthalten
        /// </summary>
        /// <param name="_toSearch">Der zu suchende String</param>
        
        IList<Motor> LoadMotorenListByStringSimple(string _toSearch);

        #endregion

        #region Suche nach ID

        /// <summary>
        /// Liefert eine Achse anhand seiner ID
        /// </summary>
        /// <param name="_motorTypID">Die AchsTypID</param>
        /// <returns>Die Achse</returns>
        
        Motor GetMotorById( int _motorTypID );

        /// <summary>
        /// Liefert eine Liste von Typen anhand einer Liste von IDs
        /// </summary>
        /// <param name="_ids">Liste mit MotorTypIDs</param>
        /// <returns>Liste mit MotorTypen</returns>
        
        List<Motor> GetMotorenListeById( List<int> _ids );

        #endregion
    }
}
