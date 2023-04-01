/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    NKW-Identifikation
* Funktionen:   Abstrahiert die Schnittstelle des NKWFahrzeugmanagers und definiert dessen Delegates
*               Der NKWFahrzeugmanagers stellt alle Funktioenen zur Identifikation eines NKW bereit
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using PV.DomainObjects.Fahrzeug;
using PV.Interfaces;

namespace PV.Business.Services
{
    /// <summary>
    /// Abstrahiert die Schnittstelle des Businesslayers zum Frontend bezüglich der Fahrzeugdaten
    /// </summary>
    public interface INKWFahrzeugManager : IFinderManager, ISearchByStringManager
    {
       

        #region Finder

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
        /// Das derzeitig selektierte Modell
        /// </summary>
        Modell SelectedModell
        {
            get;
        }

        #endregion

        #region Erweiterte Suche

        /// <summary>
        /// Schnittstelle für die Fahrzeugsuche anhand des Übergabewertes aus dem KVA
        /// </summary>
        /// <param name="toSearch">Der zu suchende String</param>
        void SearchByStringKVA(String toSearch, int TecDocID);

        /// <summary>
        /// Liefert und Setzt die Liste der HerstellerStrings
        /// </summary>
        IList<string> HerstellerStringListe
        {
            get;
        }

        /// <summary>
        /// Der derzeitig selektierte Hersteller
        /// </summary>
        string SelectedHerstellerString
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Liste der ModellStrings
        /// </summary>
        IList<string> ModellStringListe
        {
            get;
        }

        /// <summary>
        /// Der derzeitig selektierter ModellString
        /// </summary>
        string SelectedModellString
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die IListe aller Baujahre in der Datenbasis
        /// </summary>
        IList<string> BaujahrListe
        {
            get;
        }


        /// <summary>
        /// Das derzeitig selektierte Baujahr
        /// </summary>
        string SelectedBaujahr
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert die IListe aller Hubräume in der Datenbasis
        /// </summary>
        IList<string> HubraumListe
        {
            get;
        }


        /// <summary>
        /// Der derzeitig selektierte Hubraum
        /// </summary>
        string SelectedHubraum
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert die IListe aller Leistungen in KW in der Datenbasis
        /// </summary>
        IList<string> LeistungKWListe
        {
            get;
        }


        /// <summary>
        /// Die derzeitig selektierte LeistungKW
        /// </summary>
        string SelectedLeistungKW
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert die IListe aller Leistungen in PS in der Datenbasis
        /// </summary>
        IList<string> LeistungPSListe
        {
            get;
        }


        /// <summary>
        /// Die derzeitig selektierte LeistungPS
        /// </summary>
        string SelectedLeistungPS
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert die IListe aller Motorcodes in der Datenbasis
        /// </summary>
        IList<string> MotorcodeListe
        {
            get;
        }


        /// <summary>
        /// Der derzeitig selektierte Motorcode
        /// </summary>
        string SelectedMotorcode
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert die IListe aller Kraftstoffe in der Datenbasis 
        /// </summary>
        IList<string> KraftstoffListe
        {
            get;
        }


        /// <summary>
        /// Der derzeitig selektierte Kraftstoff
        /// </summary>
        string SelectedKraftstoff
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert die IListe aller Bauarten in der Datenbasis
        /// </summary>
        IList<string> BauartListe
        {
            get;
        }


        /// <summary>
        /// Die derzeitig selektierte Bauart
        /// </summary>
        string SelectedBauart
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert die IListe aller Tonnagen in der Datenbasis
        /// </summary>
        IList<string> TonnagenListe
        {
            get;
        }


        /// <summary>
        /// Die derzeitig selektierte Tonnage
        /// </summary>
        string SelectedTonnage
        {
            get;
            set;
        }


        /// <summary>
        /// Liefert die IListe aller Achsenanzahlen in der Datenbasis
        /// </summary>
        IList<string> AchsenConfigListe
        {
            get;
        }


        /// <summary>
        /// Die derzeitig selektierte AchsenConfig
        /// </summary>
        string SelectedAchsenConfig
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

        #region Typenliste


        /// <summary>
        /// Liefert und setzt die gefilterte Liste der Typen des SelectedModell
        /// </summary>
        IList<NKWTyp> VisibleTypenListe
        {
            get;
        }

        /// <summary>
        /// Der derzeitig selektierte KFZTyp
        /// </summary>
        NKWTyp SelectedTyp
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
        /// Gibt ein NKWTyp anhander der TypenId
        /// </summary>
        /// <param name="typId">die ID</param>
        /// <returns>der NKWTyp</returns>
        NKWTyp GetTypById( int typId );

        #endregion

        #region Typliste eingrenzen

        /// <summary>
        /// Liefert die in der Typliste vorhandenen Baujahre
        /// </summary>
        IList<KeyValuePair<string, int>> TypenListeBaujahr
        {
            get;
        }

        /// <summary>
        /// Liefert die in der Typliste vorhandenen Motorcodes
        /// </summary>
        IList<KeyValuePair<string, int>> TypenListeMotorcode
        {
            get;
        }


        /// <summary>
        /// Liefert die in der Typliste vorhandenen Motorleistungen in KW
        /// </summary>
        IList<KeyValuePair<string, int>> TypenListeLeistungKW
        {
            get;
        }


        /// <summary>
        /// Liefert die in der Typliste vorhandenen Motorleistungen in PS
        /// </summary>
        IList<KeyValuePair<string, int>> TypenListeLeistungPS
        {
            get;
        }


        /// <summary>
        /// Liefert die in der Typliste vorhandenen Motorhubräume
        /// </summary>
        IList<KeyValuePair<string, int>> TypenListeHubraum
        {
            get;
        }


        /// <summary>
        /// Liefert die in der Typliste vorhandenen Kraftstoffarten
        /// </summary>
        IList<KeyValuePair<string, int>> TypenListeKraftstoff
        {
            get;
        }


        /// <summary>
        /// Liefert die in der Typliste vorhandenen Bauarten
        /// </summary>
        IList<KeyValuePair<string, int>> TypenListeBauart
        {
            get;
        }


        /// <summary>
        /// Liefert die in der Typliste vorhandenen Tonnage
        /// </summary>
        IList<KeyValuePair<string, int>> TypenListeTonnage
        {
            get;
        }


        /// <summary>
        /// Liefert die in der Typliste vorhandenen Achsen
        /// </summary>
        IList<KeyValuePair<string, int>> TypenListeAchsen
        {
            get;
        }


        /// <summary>
        /// Filtert die VisibleTyenListe
        /// </summary>
        /// <param name="baujahr">Das Baujahr nach welchem gefiltert werden soll</param>
        /// <param name="motorcode">Der Motorcode nach welchem gefiltert werden soll</param>
        /// <param name="leistungPS">Die Leistung in PS nach welcher gefiltert werden soll</param>
        /// <param name="leistungKW">Die Leistung in PS nach welcher gefiltert werden soll</param>
        /// <param name="hubraum">Der Hubraum nach welchem gefiltert werden soll</param>
        /// <param name="kraftstoff">Die Kraftstoffart nach welcher gefiltert werden soll</param>
        /// <param name="bauart">Die Bauart nach welcher gefiltert werden soll</param>
        /// /// <param name="tonnage">Die Tonnage nach welcher gefiltert werden soll</param>
        /// /// <param name="achsen">Die Achsen nach welcher gefiltert werden soll</param>
        void FilterVisibleTypListe( string baujahr, string motorcode, string leistungPS, string leistungKW,
            string hubraum, string kraftstoff, string bauart, string tonnage, string achsen );

        #endregion
    }
}
