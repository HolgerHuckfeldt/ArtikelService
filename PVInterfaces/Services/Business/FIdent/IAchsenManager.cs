/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    AchsenIdentifikation
* Funktionen: Abstrahiert die Schnittstelle des AchsenManagers und definiert seine Delegates 
*****************************************************************************************************/


using System;
using System.Collections.Generic;
using PV.DomainObjects.Fahrzeug;
using PV.Interfaces;


namespace PV.Business.Services
{
    /// <summary>
    /// Abstrahiert die Schnittstelle des AchsenManagers
    /// </summary>
    public interface IAchsenManager : IFinderManager, ISearchByStringManager
    {

        #region Achsen suchen [Finder]

        /// <summary>
        /// Führt die Freitextsuche inklusive TecdocID aus
        /// </summary>
        /// <param name="toSearch">Der String und die TecdocID nach denen gesucht werden sollen</param>
        void SearchByStringKVA(string toSearch, int TecDocID);

        /// <summary>
        /// Liefert und Setzt die Liste der Hersteller
        /// </summary>
        IList<Hersteller> HerstellerListe
        {
            get;
        }

        /// <summary>
        /// Der derzeitig selektierte Hersteller
        /// </summary>
        Hersteller SelectedHersteller
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Liste der Modelle
        /// </summary>
        IList<Modell> ModellListe
        {
            get;
        }

        /// <summary>
        /// Das derzeitig selektierte Modell im Finder
        /// </summary>
        Modell SelectedModell
        {
            get;
            set;
        }

        #endregion

        #region Achsen suchen [erweitert]

        /// <summary>
        /// Liefert eine Liste der HerstellerNamen
        /// </summary>
        IList<string> HerstellerStringListe
        {
            get;
        }

        /// <summary>
        /// Liefert den selektierten HerstellerNamen
        /// </summary>
        string SelectedHerstellerString
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert eine Liste der ModellNamen
        /// </summary>
        IList<string> ModellStringListe
        {
            get;
        }

        /// <summary>
        /// Liefert den selektierten ModellNamen
        /// </summary>
        string SelectedModellString
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert eine Liste der Baujahre
        /// </summary>
        IList<string> BaujahrListe
        {
            get;
        }

        /// <summary>
        /// Liefert das selektierten Baujahr
        /// </summary>
        string SelectedBaujahr
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert eine Liste der Achstypen
        /// </summary>
        IList<string> AchstypListe
        {
            get;
        }

        /// <summary>
        /// Liefert den selektierten Achstyp
        /// </summary>
        string SelectedAchstyp
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert eine Liste der Achsarten
        /// </summary>
        IList<string> AchsartListe
        {
            get;
        }

        /// <summary>
        /// Liefert den selektierten Achsart
        /// </summary>
        string SelectedAchsart
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert eine Liste der AchsAchsausführungen
        /// </summary>
        IList<string> AchsausfuehrungListe
        {
            get;
        }

        /// <summary>
        /// Liefert den selektierten AchsAchsausführung
        /// </summary>
        string SelectedAchsausfuehrung
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert eine Liste der Bremsgrößeen
        /// </summary>
        IList<string> BremsgroesseListe
        {
            get;
        }

        /// <summary>
        /// Liefert den selektierten Bremsgröße
        /// </summary>
        string SelectedBremsgroesse
        {
            get;
            set;
        }

        /// <summary>
        /// Führt die erweiterte Suche aus
        /// </summary>
        void SearchExtendet();

        /// <summary>
        /// Resettet die Erweiterte Suche
        /// </summary>
        void ResetExtendetSearch();

        #endregion

        #region Achsenliste

        /// <summary>
        /// Liefert und setzt die gefilterte Liste der Achsen des SelectedModell
        /// </summary>
        IList<Achse> VisibleAchsenListe
        {
            get;
        }

        /// <summary>
        /// Die derzeitig selektierte Achse
        /// </summary>
        Achse SelectedAchse
        {
            get;
            set;
        }

        /// <summary>
        /// Setzt anhand einer TypID den Typen, sein Modell und seinen Hersteller
        /// </summary>
        /// <param name="typID">Die ID</param>
        bool SetTypByID( int typID );

        /// <summary>
        /// Gibt ein AchsenTyp anhander der TypenId
        /// </summary>
        /// <param name="typId">die ID</param>
        /// <returns>der AchsenTyp</returns>
        Achse GetTypById( int typId );

        #endregion

        #region Achsenliste eingrenzen

        /// <summary>
        /// Liefert die in der Achsliste vorhandenen Baujahre
        /// </summary>
        IList<KeyValuePair<string, int>> TypenListeBaujahr
        {
            get;
        }

        /// <summary>
        /// Liefert die in der Achsliste vorhandenen Achstypen
        /// </summary>
        IList<KeyValuePair<string, int>> TypenListeAchstyp
        {
            get;
        }


        /// <summary>
        /// Liefert die in der Achsliste vorhandenen Achsarten
        /// </summary>
        IList<KeyValuePair<string, int>> TypenListeAchsart
        {
            get;
        }

        /// <summary>
        /// Liefert die in der Achsliste vorhandenen Achsausführungen
        /// </summary>
        IList<KeyValuePair<string, int>> TypenListeAchsausfuehrung
        {
            get;
        }


        /// <summary>
        /// Liefert die in der Achsliste vorhandenen Bremsgrößen
        /// </summary>
        IList<KeyValuePair<string, int>> TypenListeBremsgroesse
        {
            get;
        }

        /// <summary>
        /// Filtert die VisibleTyenListe
        /// </summary>
        /// <param name="baujahr">Das Baujahr nach welchem gefiltert werden soll</param>
        /// <param name="achstyp">Der Achstyp nach welchem gefiltert werden soll</param>
        /// <param name="achsart">Die Achsart in PS nach welcher gefiltert werden soll</param>
        /// <param name="ausfuehrung">Die Achsausführung nach welcher gefiltert werden soll</param>
        /// <param name="bremsgroesse">Die Bremsgroesse nach welcher gefiltert werden soll</param>
        void FilterVisibleTypListe( string baujahr, string achstyp, string achsart, string ausfuehrung, string bremsgroesse );


        #endregion
    }
}
