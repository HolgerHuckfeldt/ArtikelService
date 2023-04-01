/*********************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Modulübergreifend  
 * Funktionen:  Abstrahiert die Schnittstelle, welche ein Manager implementieren muss, wenn er eine Freitextsuche anbietet 
 *********************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using PV.DomainObjects.History;
using PV.DomainObjects.Artikel;

namespace PV.Business.Services
{
    /// <summary>
    /// Abstrahiert die Schnittstelle, welche ein Manager implementieren muss, 
    /// damit ein generischer Finder davon bedient werden kann
    /// </summary>
    public interface ISearchByStringManager
    {
        /// <summary>
        /// Schnittstelle für die Freitextsuche
        /// </summary>
        /// <param name="toSearch">Der zu suchende String</param>
        void SearchByString(String toSearch);

        /// <summary>
        /// Schnittstelle für die Artikel-GenArtSuche (für RepDoc)
        /// </summary>
        /// <param name="_genArtNr">Der zu suchende GenArt</param>
        void SearchByGenArtNr(int _genArtNr);

        /// <summary>
        /// Methode zum Setzen des Strings, welcher Autosuggestion benötigt
        /// </summary>
        /// <param name="toSuggest">Der eingegebene String</param>
        void SetForFreetextSuggestion(string toSuggest, IdentArt aktuelleAuswahlIdentArt, bool isFromStartseite);

        /// <summary>
        /// Methode zum Setzen des Strings, welcher Autosuggestion benötigt
        /// </summary>
        /// <param name="toSuggest">Der eingegebene String</param>
        /// <param name="mitHerstellern"> </param>
        void SetForFreetextSuggestion(string toSuggest, bool mitHerstellern, IdentArt aktuelleAuswahlIdentArt);

        /// <summary>
        /// Liefert eine Liste von FreitextSuchSuggestions
        /// </summary>
        IList<string> FreetextSuggestionList
        {
            get;
        }

		/// <summary>
		/// Liefert eine Liste von FreitextSuchSuggestions
		/// </summary>
		IList<AutoSuggestItem> FreetextSuggestionGroupedList
		{
			get;
		}
		
		/// <summary>
        /// Liefert eine Liste der Letzten Sucheinträge
        /// </summary>
        IList<FreitextSuchHistory> FreetextHistoryList
        {
            get;
        }

        /// <summary>
        /// Liefert den zuletzt gesuchten Suchstring
        /// </summary>
        string LastSearchString
        {
            get;
        }


        /// <summary>
        /// Identifiziert diesen SearchByStringManager (z.B. "TechnikManager", "TrainingManager")
        /// </summary>
        string SearchByStringIdent
        {
            get;
        }
    }
}
