/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    MotorenIdentifikation
* Funktionen: Abstrahiert die Schnittstelle des MotorenManagers und definiert seine Delegates 
*****************************************************************************************************/

using System.Collections.Generic;
using PV.DomainObjects.Fahrzeug;

namespace PV.Business.Services
{
    /// <summary>
    /// Abstrahiert die Schnittstelle des MotorenManagers
    /// </summary>
    public interface IMotorenManager : ISearchByStringManager
    {

        void SearchByStringKVA(string strHelp, int TecDocID);

        #region Motorensuche [erweitert]

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
        /// Liefert eine Liste der Hubräume
        /// </summary>
        IList<string> HubraumListe
        {
            get;
        }

        /// <summary>
        /// Liefert den selektierten Hubraum
        /// </summary>
        string SelectedHubraum
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert eine Liste der Leistungen in KW
        /// </summary>
        IList<string> LeistungKWListe
        {
            get;
        }

        /// <summary>
        /// Liefert die selektierten LeistungKW
        /// </summary>
        string SelectedLeistungKW
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert eine Liste der Leistungen in KW
        /// </summary>
        IList<string> LeistungPSListe
        {
            get;
        }

        /// <summary>
        /// Liefert die selektierten LeistungPS
        /// </summary>
        string SelectedLeistungPS
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert eine Liste der Motorcodes
        /// </summary>
        IList<string> MotorCodeListe
        {
            get;
        }

        /// <summary>
        /// Liefert den selektierten Motorcode
        /// </summary>
        string SelectedMotorCode
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert eine Liste der Kraftstoffe
        /// </summary>
        IList<string> KraftstoffListe
        {
            get;
        }

        /// <summary>
        /// Liefert den selektierten Kraftstoff
        /// </summary>
        string SelectedKraftstoff
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert eine Liste der Motorarten
        /// </summary>
        IList<string> MotorartListe
        {
            get;
        }

        /// <summary>
        /// Liefert die selektierten Motorart
        /// </summary>
        string SelectedMotorart
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

        #region Motorenliste eingrenzen

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
        void FilterVisibleTypListe(string baujahr, string motorcode, string leistungPS, string leistungKW,
            string hubraum, string kraftstoff, string bauart);


        #endregion

        #region Motorenliste

        /// <summary>
        /// Liefert und setzt die gefilterte Liste der Motoren
        /// </summary>
        IList<Motor> VisibleMotorenListe
        {
            get;
        }

        /// <summary>
        /// Der derzeitig selektierte Motor
        /// </summary>
        Motor SelectedMotor
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
        /// Gibt ein FahrzeugTyp anhander der TypenId
        /// </summary>
        /// <param name="typId"></param>
        /// <returns>FahrzeugTyp</returns>
        Motor GetTypById( int typId );

        #endregion
    }
}