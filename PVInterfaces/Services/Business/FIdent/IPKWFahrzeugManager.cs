/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    PKW-Identifikation
* Funktionen:   Abstrahiert die Schnittstelle des Fahrzeugmanagers und definiert dessen Delegates
*               Der PKWFahrzeugManager stellt alle Funktioenen zur Identifikation eines PKW bereit
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
    public interface IPKWFahrzeugManager : IFinderManager, ISearchByStringManager
    {
       


        /// <summary>
        /// Schnittstelle für die Fahrzeugsuche anhand des Übergabewertes aus dem KVA
        /// </summary>
        /// <param name="toSearch">Der zu suchende String und die zugehörige TecDocID</param>
        void SearchByStringKVA(String toSearch, int TecDocID);

        /// <summary>
        /// Liefert und setzt den selektierten Hersteller
        /// </summary>
        Hersteller SelectedHersteller
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt das selektierte Modell
        /// </summary>
        Modell SelectedModell
        {
            get;
            set;
        }
        

        #region PKWSuche [erweitert]

        /// <summary>
        /// Liefert und Setzt die Liste der HerstellerStrings der erweiterten Suche
        /// </summary>
        IList<string> HerstellerStringListe
        {
            get;
        }

        /// <summary>
        /// Liefert die Liste der Hersteller bereinigt um die ausgewählten
        /// </summary>
        IList<Hersteller> HerstellerGesamtListe
        {
            get;
        }

        /// <summary>
        /// Liefert die Liste der Hersteller welche gewählt wurden
        /// </summary>
        IList<Hersteller> HerstellerListe
        {
            get;
        }

        /// <summary>
        /// Der derzeitig selektierte HerstellerString der erweiterten Suche
        /// </summary>
        string SelectedHerstellerString
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und Setzt die Liste der ModellStrings der erweiterten Suche
        /// </summary>
        IList<string> ModellStringListe
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert den Namen des selektierten Modells in der erweiterten Suche
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
        IList<PKWTyp> VisibleTypenListe
        {
            get;
        }

        /// <summary>
        /// Der derzeitig selektierte KFZTyp
        /// </summary>
        PKWTyp SelectedTyp
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
        /// Gibt ein PKWTyp anhander der TypenId
        /// </summary>
        /// <param name="typId">die ID</param>
        /// <returns>der PKWTyp</returns>
        PKWTyp GetTypById( int typId );

        List<PKWTyp> GetTypesById(List<int> typId);

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
        /// Filtert die VisibleTyenListe
        /// </summary>
        /// <param name="baujahr">Das Baujahr nach welchem gefiltert werden soll</param>
        /// <param name="motorcode">Der Motorcode nach welchem gefiltert werden soll</param>
        /// <param name="leistungPS">Die Leistung in PS nach welcher gefiltert werden soll</param>
        /// <param name="leistungKW">Die Leistung in PS nach welcher gefiltert werden soll</param>
        /// <param name="hubraum">Der Hubraum nach welchem gefiltert werden soll</param>
        /// <param name="kraftstoff">Die Kraftstoffart nach welcher gefiltert werden soll</param>
        /// <param name="bauart">Die Bauart nach welcher gefiltert werden soll</param>
        void FilterVisibleTypListe( string baujahr, string motorcode, string leistungPS, string leistungKW, string hubraum, string kraftstoff, string bauart );

        /// <summary>
        /// Resettet alle Filter der VisibleTyenListe
        /// </summary>
        void ResetVisibleTypenListe();

        PRInfos PrInfos { get; set; }

        string PrInfosVinFromManager { get; set; }

        #endregion
    }
}
