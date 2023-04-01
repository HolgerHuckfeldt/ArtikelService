/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz, Björn Schönwolff   
* Modul:    Modulübergreifend
* Funktionen: Kapselt Daten zu verschiedenen globalen Informationen
*****************************************************************************************************/

using System;
using PV.Utilities.Interfaces;

namespace PV.Business.Services
{
    /// <summary>
    /// Definiert die Delegates für den ControlManager
    /// </summary>
    public class ControlManagerDelegates
    {
        /// <summary>
        /// Verarbeitet das LastActiveIdentChangedEvent
        /// </summary>
        /// <param name="_art">Die LastActiveIdent</param>
        public delegate void LastActiveIdentChangedHandler( IdentArt? _art );
        public delegate void LastActiveArtikelIdentChangedHandler(IdentArtArtikel? _art);
        public delegate void LastActiveTrainingIdentChangedHandler(IdentArtTraining? _art);
        public delegate void LastActiveArbeitswertIdentChangedHandler(IdentArtArbeitswert? _art);
        public delegate void LastActiveWartungIdentChangedHandler(IdentArtWartung? _art);
    }

    /// <summary>
    /// Die verschiedenen Möglichkeiten, wie etwas identifiziert werden kann 
    /// </summary>
    public enum IdentArt
    {
        PKW,
        NKW,
        Motor,
        Achse,
        Nummern,
        Uni
    }

    public enum IdentArtArtikel
    {
        PKWArtikel,
        NKWArtikel,
        MotorenArtikel,
        AchsenArtikel,
        UniversalArtikel,
        NummernsucheArtikel,
        EigeneArtikel
    }

    public enum IdentArtWartung
    {
        WartungArbeitswerte,
        Checklisten
    }

    public enum IdentArtArbeitswert
    {
        Arbeitswerte,
        EigeneArbeitswerte,
        WartungArbeitswerte
    }

    public enum IdentArtTraining
    {
        Kategorie,
        TrainingsOrt
    }

    /// <summary>
    /// Kapselt Daten zu verschiedenen globalen Informationen
    /// </summary>
    public interface IControlManager
    {
        /// <summary>
        /// Welche Identifikation war als letztes aktiv
        /// </summary>
        IdentArt? LastActiveIdent
        { get; set; }

        /// <summary>
        /// Welche Artikel-Identifikation war als letztes aktiv
        /// </summary>
        IdentArtArtikel? LastActiveIdentArtikel
        { get; set; }

        /// <summary>
        /// Welche Training-Identifikation war als letztes aktiv
        /// </summary>
        IdentArtTraining? LastActiveIdentTraining
        { get; set; }

        /// <summary>
        /// Welche Arbeitswert-Identifikation war als letztes aktiv
        /// </summary>
        IdentArtArbeitswert? LastActiveIdentArbeitswert
        { get; set; }

        /// <summary>
        /// Welche Wartung-Identifikation war als letztes aktiv
        /// </summary>
        IdentArtWartung? LastActiveIdentWartung
        { get; set; }


        /// <summary>
        /// Verfügbarkeit von Modulen/Controls
        /// </summary>
        bool IsAssistentEnabled { get; set; }
        bool IsKundenverwaltungEnabled { get; set; }
        bool IsKvaEnabled { get; set; }
        bool IsModulboxBestellungenEnabled { get; set; }
        bool IsWarenkorbEnabled { get; set; }
        bool IsSammelnInEnabled { get; set; }

        void NavigateArtikelauswahl();
        void NavigateNummernsuche();
        void NavigatePkwAuswahl();
        void NavigateTechnik();
        void NavigateWarenkorb();
        void NavigateConfig();
        void NavigateArbeitswerte();
        void NavigateWartung();
        void NavigateKva();
        void NavigateDurchlaufartikelauswahl();
        void NavigateDurchlaufartikelauswahlWarenkorbImport();
        void SetSammelnInToKVA();

        /// <summary>
        /// Anwendungssteuerung
        /// </summary>
        void ForceCloseApplication();
        void ForceMinimizeApplication();
        void ForceMaximizeApplication();
        void ForceHideApplication();
        void ForceShowApplication();
    }
}
