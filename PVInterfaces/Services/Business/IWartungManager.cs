/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Susann Karras
* Modul:    Wartung
* Funktionen: Abstrahiert die Schnittstelle des Wartungmanagers und definiert seine Delegates 
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Fahrzeug;
using PV.DomainObjects.Kunden;
using PV.DomainObjects.ManagedObjects;
using PV.DomainObjects.Technik;
using PV.DomainObjects.Wartung;
using PV.DomainObjects.Wartung.TransferObjects;
using PV.Interfaces;
using PV.Utilities.Misc;

namespace PV.Business.Services
{
    /// <summary>
    /// Bietet Informationen für Wartung.
    /// </summary>
    public interface IWartungManager : IFinderManager, ISearchByStringManager
    {
        #region Properties

        decimal Oelfuellmenge { get; }

        bool SucheMitWeiterenHerstellern { get; set; }

        int PreSelectedWartung
        {
            get; 
            set;
        }

        /// <summary>
        /// Flag, ob der Manager in Modus Wartungen kombinieren ist
        /// </summary>
        bool CombineMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gibt an, ob es möglich ist, Wartungen zu kombinieren.
        /// </summary>
        bool IsCombinePossible
        {
            get;
            set;
        }

        /// <summary>
        /// Liste der kombinierten Wartungs-Ids
        /// </summary>
        IList<MaintenanceTo> Combined
        {
            get;
            set;
        }

        /// <summary>
        /// Liste der optionalen Wartungen, die ausgewählt sind.
        /// </summary>
        IList<MaintenanceSentenceTo> OptionalMaints
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt (private) den selektierten Kunden
        /// </summary>
        Kunde SelectedKunde
        {
            get;
        }


        /// <summary>
        /// Liefert den Namen des gesetzten Tab-Controls
        /// "Checklisten" oder "Arbeitswerte"
        /// </summary>
        string SelectedTabName
        {
            get;
            set;
        }

        WartungGruppierungsMode WartungsGruppenModus
        {
            get;
            set;
        }

        /// <summary>
        /// Setzt und liefert den FahrzeugTyp.
        /// </summary>
        Fahrzeug AktuellesFahrzeug
        {
            get;
        }

        FinderArtikelListe WartungArtikelListe { get; set; }

        FinderArtikelListe AnzeigeWartungArtikelListe { get; set; }

        /// <summary>
        /// Setzt und liefert die Liste aller relevanten fahrezueg zu einer TecDoc-Id/KtypNr.
        /// </summary>
        List<Fahrzeug> FahrzeugListe
        {
            get;
        }

        bool SindGenerischeDatenVisible
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die SuchbaumListe, für den Current Typen
        /// </summary>
        IList<WartungSuchbaumEintrag> SuchbaumListe
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die WartungsanzeigeRueckstellungen
        /// </summary>
        IList<WartungsHandbuch> WartungsanzeigeRueckstellungen
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die WartungsZusatzinformationen
        /// </summary>
        IList<WartungsHandbuch> WartungsZusatzinformationen
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die WartungshandbuchEintraege
        /// </summary>
        IList<WartungsHandbuchEintrag> WartungshandbuchEintraege
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die WartungsSpezialAngebote
        /// </summary>
        IList<WartungsChecklistePeriode> WartungsSpezialAngebote
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die WartungsChecklisteItems
        /// </summary>
        IList<WartungsChecklisteItem> WartungsChecklisteItemsShort
        {
            get;
        }


        /// <summary>
        /// Setzt und liefert die WartungsChecklisteItems
        /// </summary>
        IList<WartungsChecklisteItem> WartungsChecklisteItemsLong
        {
            get;
        }

        double AktuelleWartungsListeWert
        {
            get; set;
        }

        double AktuelleWartungsListeWertCalculated
        {
            get; set;
        }

        /// <summary>
        /// Setzt und liefert die TechnikLinks
        /// </summary>
        List<TechnikLink> TechnikLinks
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die selektierte Wartungszusatzinformation. 
        /// </summary>
        WartungsHandbuch SelectedWartungsZusatzinformation
        {
            get;
        }

        /// <summary>
        /// Liefert eine Liste von GenArtNr zurück
        /// </summary>
        /// <returns>Liste von Finderobjekten</returns>
        GenArtList GetGenArtNrList
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die selektierte WartungsanzeigeRueckstellung. 
        /// </summary>
        WartungsHandbuch SelectedWartungsanzeigeRueckstellungen
        {
            get;set;
        }

        IList<MaintenanceTo> MaintenanceList
        { 
            get;
        }

        List<PV.DomainObjects.Wartung.Assistent.MaintPeriod> AssistentSystem
        { 
            get; 
            set; 
        }


        string Disclaimer
        {
            get;
            set;
        }

        #endregion

        // --------------------------------------------------------------------------

        #region Business-Methoden

        void GetWartungArtikelListe(int key);

        void GetWartungArtikelListeByWeitereHerstellerClick(bool mitWeiterenHerstellern);

        /// <summary>
        /// Liefert die Liste aller Suchbaumeinträge aller Ebenen
        /// Aufteilung in Ebenen ist Sache des Frontends
        /// </summary>
        void LoadSuchbaumListe();

        /// <summary>
        /// Verarbeitet das ResetFinder der Oberklasse
        /// </summary>
        void OnResetFinder();

        void KundeZuordnen(Kunde kunde);

        void KundeZuWartungsmanager();

        void ResetKundendaten();

        void LoadTechnikLinks(WartungsChecklisteItem _item, WartungsChecklisteItem.TechnikLinkTyp _linkTyp);
        void LoadAllTechnikLinks(WartungsChecklisteItem _item);

        void AddToKVA(IList<WartungsChecklisteItem> list);
        void UpdateInKVA(IList<WartungsChecklisteItem> list);



        #endregion

        // --------------------------------------------------------------------------

        #region Set-Methoden

        void SetCurrentTyp(FahrzeugTyp typ);

        void SetCurrentChecklistenItem(WartungsChecklisteItem item);

        /// <summary>
        /// Setzt das Akteulle Fahrzeug.
        /// </summary>
        void SetAktuellesFahrzeug(Fahrzeug fahrzeug);

        /// <summary>
        /// Methode zum Selektieren des Suchbaumeintrags durch die Oberfläche
        /// </summary>
        /// <param name="eintrag">Der zu setzende Suchbaumeintrag als SuchbaumEintrag</param>
        void SelectSuchBaumEintrag(WartungSuchbaumEintrag eintrag);

        /// <summary>
        /// Lädt die Wartungsanzeige-Rueckstellungen.
        /// </summary>
        void SelectWartungsanzeigeRueckstellungen();

        /// <summary>
        /// Setzt die selektierte WartungsanzeigeRueckstellungInfo und lädt die dazugehörigen Items.
        /// </summary>
        /// <param name="handbuchId">Die selektierte Rueckstellungsinfo</param>
        void SelectWartungsanzeigeRueckstellung(int handbuchId);

        /// <summary>
        /// Lädt die Wartungs-ZusatzInformationen.
        /// </summary>
        void SelectWartungsZusatzInformationen();

        /// <summary>
        /// Setzt die selektierte WartungsZusatzInformation und lädt die dazugehörigen Items.
        /// </summary>
        /// <param name="handbuchId">Die selektierte Zusatzinfo</param>
        void SelectWartungsZusatzInformation(int handbuchId);

        #endregion

        // --------------------------------------------------------------------------
    }
}
