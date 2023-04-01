/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Arbeitswerte
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für Arbeitswerte erfüllen muss
 ***************************************************************************************************************************************/

using System.Collections.Generic;
using PV.DomainObjects.Arbeitswerte;


namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für Arbeitswerte erfüllen muss
    /// </summary>
 
    public interface IArbeitswertePersistanceProvider
    {
        /// <summary>
        /// Liefert einen Suchbaum für einen PKW-Typen
        /// </summary>
        /// <param name="_typ">Der PKW-Typ für welchen der Suchbaum angefordert wird</param>
        /// <returns>Der Suchbaum</returns>
        
        IList<ArbeitswertTreeItem> GetSearchTree( int _typ );

        /// <summary>
        /// Liefert einen Wartungs-Suchbaum für einen PKW-Typen
        /// </summary>
        /// <param name="_typ">Der PKW-Typ für welchen der Suchbaum angefordert wird</param>
        /// <returns>Der Suchbaum</returns>
        
        IList<ArbeitswertTreeItem> GetWartungsSearchTree( int _typ );

        /// <summary>
        /// Liefert eine Liste von Arbeitswerten
        /// </summary>
        /// <param name="_typ">Die Typid des Fahrzeugs</param>
        /// <param name="_treeNode">Der Suchbaumeintrag für welchen die Arbeitswerte benötigt werden</param>
        
        void GetArbeitswertListe( int _typ, ArbeitswertTreeItem _treeNode );

        /// <summary>
        /// Liefert eine Liste von Arbeitswerten
        /// </summary>
        /// <param name="_typ">Die Typid des Fahrzeugs</param>
        /// <param name="_treeNode">Der Suchbaumeintrag für welchen die Arbeitswerte benötigt werden</param>
        /// <returns>Liste von Arbeitswerten</returns>
        
        IList<Arbeitsprozess> GetArbeitswertListeSimple( int _typ, ArbeitswertTreeItem _treeNode );

        /// <summary>
        /// Liefert eine Liste von Wartungs-Arbeitswerten
        /// </summary>
        /// <param name="_typ">Der KFZ-Zyp fpr welchen der Arbeitswertebaum gesucht wird</param>
        /// <param name="_treeNode">Der Suchbaumeintrag für welchen die Arbeitswerte benötigt werden</param>
        
        void GetWartungsArbeitswertListe( int _typ, ArbeitswertTreeItem _treeNode );

        /// <summary>
        /// Liefert eine Liste von Wartungs-Arbeitswerten
        /// </summary>
        /// <param name="_typ">Der KFZ-Zyp fpr welchen der Arbeitswertebaum gesucht wird</param>
        /// <param name="_nummernListe">Eine Liste von Arbeitsprozessnummern</param>
        
        IList<Arbeitsprozess> GetArbeitswertListeByNumernListe( int _typ, IList<string> _nummernListe );

        /// <summary>
        /// Liefert eine Liste von Wartungs-Arbeitswerten
        /// </summary>
        /// <param name="_typ">Der KFZ-Zyp fpr welchen der Arbeitswertebaum gesucht wird</param>
        /// <param name="_treeNode">Der Suchbaumeintrag für welchen die Arbeitswerte benötigt werden</param>
        /// <returns>Liste von Arbeitswerten</returns>
        
        IList<Arbeitsprozess> GetWartungsArbeitswertListeSimple( int _typ, ArbeitswertTreeItem _treeNode );

        /// <summary>
        /// Liefert eine Liste von Arbeitswerten anhand einer Stringsuche
        /// </summary>
        /// <param name="_typ">Die Typid des Fahrzeugs</param>
        /// <param name="_toSearch">Der String für welchen die Arbeitswerte benötigt werden</param>
        
        void GetArbeitswertListebyString( int _typ, string _toSearch );

        /// <summary>
        /// Liefert eine Liste von Arbeitswerten anhand einer Stringsuche
        /// </summary>
        /// <param name="_typ">Die Typid des Fahrzeugs</param>
        /// <param name="_toSearch">Der String für welchen die Arbeitswerte benötigt werden</param>
        /// <returns>Liste von Arbeitswerten</returns>
        
        IList<Arbeitsprozess> GetArbeitswertListebyStringSimple( int _typ, string _toSearch );

        /// <summary>
        /// Liefert eine Liste von Arbeitswerten anhand einer Stringsuche
        /// </summary>
        /// <param name="_typ">Die Typid des Fahrzeugs</param>
        /// <param name="_toSearch">Der String für welchen die Arbeitswerte benötigt werden</param>
        
        void GetWartungsArbeitswertListebyString( int _typ, string _toSearch );

        /// <summary>
        /// Liefert eine Liste von Arbeitswerten anhand einer Stringsuche
        /// </summary>
        /// <param name="_typ">Die Typid des Fahrzeugs</param>
        /// <param name="_toSearch">Der String für welchen die Arbeitswerte benötigt werden</param>
        /// <returns>Liste von Arbeitswerten</returns>
        
        IList<Arbeitsprozess> GetWartungsArbeitswertListebyStringSimple( int _typ, string _toSearch );

        /// <summary>
        /// Liefert für einen Generischen Artikel die Arbeitswerte für ein speziellen Fahrzeugtyp
        /// </summary>
        /// <param name="_typ">Der Typ für die Info benötigt wird</param>
        /// <param name="_genArt">der Generische ArtikelTyp für die Info benötigt wird</param>
        /// <returns>Liste von Arbeitswerten</returns>
        
        IList<Arbeitsprozess> GetArbeitswerteListeByTypAndArtikel( int _typ, int _genArt );

        /// <summary>
        /// Wendet den DotAWCalculator auf eine Liste von ArbeisprozessNummern an und gibt eine NEUE bereinigte Liste zurück
        /// </summary>
        /// <param name="_typ">Der Typ für welchen die Kalulation erfolgen soll</param>
        /// <param name="_processListe">Die Liste der zu kalkulierenden ArbeitsprozessNummern</param>
        /// <returns>Die Liste der geänderten Arbeitprozesse</returns>
        
        IList<Arbeitsprozess> CalculateArbeitsprozessListe( int _typ, IList<string> _processListe );

        /// <summary>
        /// Liefert für die Arbeitswertsuche die FreitextSuchEmpfehlung
        /// </summary>
        /// <param name="_typ">Der Typ für welchen die Kalulation erfolgen soll</param>
        /// <param name="_toSuggest">Der Text für welchen eine Suggestion gesucht wird</param>
        /// <returns>Liste der Suggeststrings</returns>
        
        IList<string> GetArbeitswerteFreetextSuggestion(int _typ, string _toSuggest);

        /// <summary>
        /// Liefert für die Arbeitswertsuche die FreitextSuchEmpfehlung
        /// </summary>
        /// <param name="_typ">Der Typ für welchen die Kalulation erfolgen soll</param>
        /// <param name="_toSuggest">Der Text für welchen eine Suggestion gesucht wird</param>
        /// <returns>Liste der Suggeststrings</returns>
        
        IList<string> GetArbeitswerteFreetextSuggestionSimple(int _typ, string _toSuggest);

        /// <summary>
        /// Liefert für die WartungsArbeitswertsuche die FreitextSuchEmpfehlung
        /// </summary>
        /// <param name="_typ">Der Typ für welchen die Kalulation erfolgen soll</param>
        /// <param name="_toSuggest">Der Text für welchen eine Suggestion gesucht wird</param>
        /// <returns>Liste der Suggeststrings</returns>
        
        IList<string> GetWartungsArbeitswerteFreetextSuggestion( int _typ, string _toSuggest );

        /// <summary>
        /// Liefert den Arbeitswert für eine Nummer für einen bestimmten PKW
        /// </summary>
        /// <param name="_typ">Der Typ für welchen ein Arbeitswert gesucht wird</param>
        /// <param name="_nummer">Die Nummer des gesuchten AW</param>
        /// <returns>der ARbeitswert</returns>
        
        Arbeitsprozess GetArbeitswertByNumber( int _typ, string _nummer );

        
        List<string> GetDisclaimer(int type);
    }
}
