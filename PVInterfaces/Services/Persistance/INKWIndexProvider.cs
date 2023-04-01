/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Fahrzeugidentifikation
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für NKW erfüllen muss
 ***************************************************************************************************************************************/

using System.Collections.Generic;
using PV.DomainObjects.Fahrzeug;

namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für NKW erfüllen muss
    /// </summary>
 public interface INKWIndexProvider
    {
        #region Methoden zur Identifikation nach "Baum" (Hersteller->Modelle->Typen) und erweiterte Suche

        /// <summary>
        /// Liefert eine Liste aller Hersteller
        /// </summary>
        /// <returns>Liste der Hersteller</returns>
        
        IList<Hersteller> GetHerstellerList(int profileId);

        /// <summary>
        /// Liefert eine Liste aller Modelle eines Herstellers in einer vorgegebenen Sprache
        /// </summary>
        /// <param name="_hersteller">Der Hersteller für welchen die Modelle gesucht werden</param>
        /// <returns>Liste von NKW-Modell</returns>
        
        IList<Modell> GetModellList(Hersteller _hersteller, int profileId);

        #endregion

        /// <summary>
        /// Initialisiert das Laden der Typliste
        /// </summary>
        /// <param name="_model">Das ausgewählte Model</param>
        /// <param name="profileId">Profile Id aus der DB</param>
        
        void LoadNKWTypList( Modell _model, int profileId );

        /// <summary>
        /// Initialisiert das Laden der Typliste
        /// </summary>
        /// <param name="_model">Das ausgewählte Model</param>
        /// <returns>Liste mit NKW-Typen</returns>
        
        IList<NKWTyp> LoadNKWTypListSimple(Modell _model, int profileId);

        #region Erweiterte Suche

        /// <summary>
        /// Initialisiert das Laden der Liste aller Herstellernamen anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        
        void LoadHerstellerStringList(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Herstellernamen anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        /// <returns>Eine Liste von Herstellerstrings</returns>
        
        IList<string> LoadHerstellerStringListSimple(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Modellnamen anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        
        void LoadModellStringList(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Modellnamen anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        /// <returns>Eine Liste von ModellStrings</returns>
        
        IList<string> LoadModellStringListSimple(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Baujahre anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        
        void LoadBaujahrListe(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Baujahre anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        /// <returns>Liste aller Baujahre</returns>
        
        IList<string> LoadBaujahrListeSimple(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Hubräume anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        
        void LoadHubraumListe(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Hubräume anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        /// <returns>Eine Liste aller Hubräume</returns>
        
        IList<string> LoadHubraumListeSimple(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Leistungen in KW anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        
        void LoadLeistungKWListe(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Leistungen in KW anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        /// <returns>Eine Liste aller Leistungen in KW</returns>
        
        IList<string> LoadLeistungKWListeSimple(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Leistungen in PS anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        
        void LoadLeistungPSListe(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Leistungen in PS anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        /// <returns>Eine Liste aller Leistungen in PS</returns>
        
        IList<string> LoadLeistungPSListeSimple(FahrzeugSuchInfoObject _info);


        /// <summary>
        /// Initialisiert das Laden der Liste aller Motorcodes anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        
        void LoadMotorcodeListe(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Motorcodes anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        /// <returns>Eine Liste aller Motorcodes</returns>
        
        IList<string> LoadMotorcodeListeSimple(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Kraftstoffe anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        
        void LoadKraftstoffListe(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Kraftstoffe anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        /// <returns>Eine Liste aller Kraftstoffen</returns>
        
        IList<string> LoadKraftstoffListeSimple(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Bauarten anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        
        void LoadBauartListe(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Bauarten anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        /// <returns>Eine Liste aller Bauarten</returns>
        
        IList<string> LoadBauartListeSimple(FahrzeugSuchInfoObject _info);


        /// <summary>
        /// Initialisiert das Laden der Liste aller Tonnagen anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        
        void LoadTonnagenListe(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Tonnagen anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        /// <returns>Eine Liste aller Tonnagen</returns>
        
        IList<string> LoadTonnagenListeSimple(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Achskonfigurationen anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        
        void LoadAchsenConfigListe(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Achskonfigurationen anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        /// <returns>Eine Liste aller Achskonfigurationen</returns>
        
        IList<string> LoadAchsenConfigListeSimple(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller NKWTypen anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        
        void LoadNKWTypListByExtendetSearch(FahrzeugSuchInfoObject _info);

        /// <summary>
        /// Initialisiert das Laden der Liste aller NKWTypen anhand bereits gewählter Kriterien
        /// </summary>
        /// <param name="_info">Objekt mit Suchinformationen</param>
        
        IList<NKWTyp> LoadNKWTypListByExtendetSearchSimple(FahrzeugSuchInfoObject _info);

        #endregion

        #region Freitextsuche

        /// <summary>
        /// Initialisiert das Laden der Liste aller Typen die einen bestimmten String enthalten
        /// </summary>
        /// <param name="_toSearch">Der zu suchende String</param>
        void LoadNKWTypListByString(string _toSearch, int profileId);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Typen die einen bestimmten String und TecDocID enthalten
        /// </summary>
        /// <param name="_toSearch">Der zu suchende String und TecDocID</param>
        void LoadNKWTypListByStringKVAundTecTocID(string _toSearch, int _TecDocID, int profileId);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Typen die einen bestimmten String enthalten
        /// </summary>
        /// <param name="_toSearch">Der zu suchende String</param>
        /// <returns>Eine Liste mit NKW-Typen</returns>
        
        IList<NKWTyp> LoadNKWTypListByStringSimple(string _toSearch, int profileId);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Suggestions für einen freien Suchstring
        /// </summary>
        /// <param name="_toSuggest">der Suchstring</param>
        void LoadFreetextSuggestion(string _toSuggest, int profileId);

        /// <summary>
        /// Initialisiert das Laden der Liste aller Suggestions für einen freien Suchstring
        /// </summary>
        /// <param name="_toSuggest">der Suchstring</param>
        /// <returns>Eine Liste mit Vorschlagsstrings</returns>
        
        IList<string> LoadFreetextSuggestionSimple(string _toSuggest, int profileId);


        #endregion

        #region Methoden zur Suche nach IDs

        /// <summary>
        /// Liefert einen Hersteller anhand seiner ID
        /// </summary>
        /// <param name="_herstellerID">Die HerstellerID</param>
        /// <returns>Der Hersteller</returns>
        
        Hersteller GetHerstellerById(int _herstellerID, int profileId);

        /// <summary>
        /// Liefert ein Modell anhand seiner ID
        /// </summary>
        /// <param name="_modellId">Die ModellID</param>
        /// <returns>Das Modell</returns>
        
        Modell GetModellById(int _modellId, int profileId);

        /// <summary>
        /// Liefert einen FahrzeugTyp anhand seiner ID
        /// </summary>
        /// <param name="_fahrzeugTypID">Die FahrzeugTypID</param>
        /// <returns>Der FahrzeugTyp</returns>
        
        NKWTyp GetFahrzeugTypById(int _fahrzeugTypID, int profileId);

        /// <summary>
        /// Liefert eine Liste von FahrzeugTypen anhand einer Liste von IDs
        /// </summary>
        /// <param name="_ids">Liste mit FahrzeugTypIDs</param>
        /// <returns>Liste mit FahrzeugTypen</returns>
        
        List<NKWTyp> GetFahrzeugTypsById(List<int> _ids, int profileId);

        #endregion
    }
}
