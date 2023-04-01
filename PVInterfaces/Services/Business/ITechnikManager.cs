/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Susann Karras
* Modul:    Technik
* Funktionen: Abstrahiert die Schnittstelle des Technikmanagers und definiert seine Delegates 
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using PV.DomainObjects.Fahrzeug;
using PV.DomainObjects.Technik;
using PV.Interfaces;
using PV.DomainObjects.Wartung;

namespace PV.Business.Services
{
    /// <summary>
    /// Bietet Informationen zu der aktuell ausgewählten Technik.
    /// </summary>
    public interface ITechnikManager : IFinderManager, ISearchByStringManager
    {
        // --------------------------------------------------------------------------

        #region Properties

        List<KfzCallback> Rueckrufe
        {
            get;
        }

        List<TSBCategory> RueckrufeHeynes { get; set; }

        List<KfzCallback> GetRueckrufe(int ktypeid);

        /// <summary>
        /// Setzt und liefert die SuchbaumListe, für den Current Typen
        /// </summary>
        IList<TechnikSuchbaumEintrag> SuchbaumListe
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert den FahrzeugTyp.
        /// </summary>
        Fahrzeug AktuellesFahrzeug
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die Liste aller relevanten fahrezueg zu einer TecDoc-Id/KtypNr.
        /// </summary>
        List<Fahrzeug> FahrzeugListe
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        bool SindGenerischeDatenVisible
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die Einstelldaten
        /// </summary>
        List<Einstelldatum> Einstelldaten
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die EinstelldatumZusatzinfos
        /// </summary>
        List<EinstelldatumZusatzinfo> EinstelldatumZusatzinfos
        {
            get;
            set;
        }

        /// <summary>
        /// Setzt und liefert die SmartFixGruppen
        /// </summary>
        List<SmartFixSubject> SmartFixGruppen
        {
            get;
        }
       
        List<SmartFixData> SmartFixDaten
        {
            get;
        }

        List<TSBCategory> TSBCategories
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die Schmiermittel
        /// </summary>
        List<Schmiermittel> Schmiermittel
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die ReparaturhandbuchEinträge
        /// </summary>
        List<ReparaturhandbuchEintrag> ReparaturhandbuchEintraege
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die Reparaturhandbücher
        /// </summary>
        List<Reparaturhandbuch> Reparaturhandbuecher
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die Motormanagement-EinbaulageComponenten
        /// </summary>
        List<MotormanagementEinbaulageComponente> MotormanagementEinbaulageComponenten
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die Motormanagement-Componenten
        /// </summary>
        List<MotormanagementComponente> MotormanagementComponenten
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die Motormanagement-Componenten für den selektierten DiagnoseCode.
        /// </summary>
        List<MotormanagementComponente> DiagnoseCodeComponenten
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die Sicherungen
        /// </summary>
        List<Sicherung> Sicherungen
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die DiagnoseCodes
        /// </summary>
        List<DiagnoseCode> DiagnoseCodes
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die DefaultDiagnose.
        /// </summary>
        DefaultDiagnose DefaultDiagnose
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        bool KomfortElektronikFahrzeugHasBeenSelected
        {
            get;
            set;
        }

        /// <summary>
        /// Setzt und liefert das Bild für die Lage des EOBD-Steckers.
        /// </summary>
        BlobLageEOBDStecker BlobLageEobdStecker
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die Komfortelektronik-Fahrzeuge
        /// </summary>
        List<KomfortelektronikFahrzeug> KomfortelektronikFahrzeuge
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die Komfortelektronik-Systeme
        /// </summary>
        List<KomfortelektronikSystem> KomfortelektronikSysteme
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die Komfortelektronik-Componenten
        /// </summary>
        List<KomfortelektronikComponente> KomfortelektronikComponenten
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die Komfortelektronik-Schaltpläne
        /// </summary>
        List<KomfortelektronikSchaltplan> KomfortelektronikSchaltplaene
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die allgem. Information
        /// </summary>
        AllgemeineInformation AllgemeineInformation
        {
            get;
            set;
        }

        /// <summary>
        /// Setzt und liefert alle allgem. Informationen
        /// </summary>
        List<AllgemeineInformation> AllgemeineInformationen
        {
            get;
        }


        /// <summary>
        /// Setzt und liefert das selektierten Reparaturhandbuch.
        /// </summary>
        Reparaturhandbuch SelectedReparaturhandbuch
        {
            get;
        }

        //EinstelldatumZusatzinfo SelectedEinstelldatenZusatzinfo
        //{
        //    get;
        //}

        /// <summary>
        /// Setzt und liefert das selektierte MotormanagementSystem.
        /// </summary>
        MotormanagementSystem SelectedMotormanagementSystem
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert die selektierte MotormanagementKomponente.
        /// </summary>
        MotormanagementComponente SelectedMotormanagementKomponente
        {
            get;
            set;
        }

        /// <summary>
        /// Setzt und liefert die selektierten tech. Zeichnung.
        /// </summary>
        Blob SelectedTechnischeZeichnungBlob
        {
            get;
            set;
        }

         /// <summary>
        /// Lädt die Informationen zu einem Blob (Dateiname, Größe, ...)
        /// </summary>
        Blob LoadBlob(int blobId);


        List<TechnischeZeichnungGruppeItem> TechnischeZeichnungGruppeItems
        {
            get;
        }
        List<TechnischeZeichnungGruppe> TechnischeZeichnungGruppen
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert den selektierten Suchbaumeintrag
        /// </summary>
        TechnikSuchbaumEintrag SelectedSuchbaumEintrag { get; set; }

        /// <summary>
        /// Setzt und liefert den selektierten Sicherungskasten.
        /// </summary>
        Sicherungskasten SelectedSicherungsKasten
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert das selektierten KomfortelektronikSystem.
        /// </summary>
        KomfortelektronikSystem SelectedKomfortelektronikSystem
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert das selektierten KomfortelektronikComponenten für die ausgewählte Seite.
        /// </summary>
        List<KomfortelektronikComponente> SelectedKomfortelektronikComponenten
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert den selektierten KomfortelektronikSchaltplan für die ausgewählte Seite.
        /// </summary>
        KomfortelektronikSchaltplan SelectedKomfortelektronikSchaltplan
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert das selektierten KomfortelektronikFahrzeug für die ausgewählte Seite.
        /// </summary>
        KomfortelektronikFahrzeug SelectedKomfortelektronikFahrzeug
        {
            get;
            set;
        }

        List<EinstelldatumZusatzinfo> SelectedEinstelldatenZusatzinfo
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

        #region Set-Methoden

        /// <summary>
        /// Setzt das aktuelle Fahrzeug anhand
        /// einen Vivid Type-ID
        /// </summary>
        /// <param name="typeid"></param>
        void SetAktuellesFahrzeugByTypeId(int typeid);

        /// <summary>
        /// Setzt das Akteulle Fahrzeug.
        /// </summary>
        void SetAktuellesFahrzeug( Fahrzeug _fahrzeug );

        /// <summary>
        /// Methode zum Selektieren des Suchbaumeintrags durch die Oberfläche
        /// </summary>
        /// <param name="_eintrag">Der zu setzende Suchbaumeintrag als SuchbaumEintrag</param>
        void SelectSuchBaumEintrag( TechnikSuchbaumEintrag _eintrag );

        /// <summary>
        /// Liefert die Identifikationsdaten für ein Fahrzeug
        /// </summary>
        /// <param name="_kTypNr">Die Fahrzeugtyp-Id aus der TecDoc-DB</param>
        /// <returns>FahrzeugIdentifikation</returns>
        FahrzeugIdentifikation SelectFahrzeugIdentifikation( int _kTypNr );

        /// <summary>
        /// Liefert die EinstelldatumZusatzinfos für ein Reparaturhandbuch
        /// </summary>
        /// <param name="_handbuchId">Die Id des Reparaturhandbuches</param>
        void SelectEinstelldatumZusatzinfos( int _handbuchId );

        /// <summary>
        /// Lädt die Image-Informationen.
        /// </summary>
        /// <param name="_blobId">Die Id des Image, welches Information über Dateinamen enthält</param>
        Blob SelectBlob( int _blobId );

        /// <summary>
        /// Lädt die DiagnoseCodes.
        /// </summary>
        /// <param name="_diagnoseCode">Der selektierte DiagnoseCode</param>
        void SelectDiagnoseCodes( string _diagnoseCode );

        /// <summary>
        /// Setzt den selektierte DiagnoseCode und lädt die dazugehörige Motormanagement-Componenten.
        /// </summary>
        /// <param name="_diagnoseCode">Der selektierte DiagnoseCode</param>
        void SelectDiagnoseCodeComponente( DiagnoseCode _diagnoseCode );

        /// <summary>
        /// Selektiert eine MotormanagementKomponente
        /// </summary>
        /// <param name="comp"></param>
        void SelectMotormanagementKomponente( MotormanagementComponente comp );

        /// <summary>
        /// Setzt das selektierte Komfortelektonik-Fahrzeug und lädt die dazugehörigen KlimaanlageSchaltplan-Systeme.
        /// </summary>
        /// <param name="_fahrzeug">Das selektierte Fahrzeug</param>
        void SelectKlimaanlageSchaltplanFahrzeug( KomfortelektronikFahrzeug _fahrzeug );

        /// <summary>
        /// Setzt das selektierte Komfortelektonik-Fahrzeug und lädt die dazugehörigen Komfortelektronik-Systeme.
        /// </summary>
        /// <param name="_fahrzeug">Das selektierte Fahrzeug</param>
        void SelectKomfortelektronikFahrzeug( KomfortelektronikFahrzeug _fahrzeug );

        /// <summary>
        /// Setzt das selektierte Komfortelektonik-System und lädt die dazugehörigen Komfortelektronik-Schaltpläne und -Componenten.
        /// </summary>
        /// <param name="_keSystem">Das selektierte System</param>
        void SelectKomfortelektronikSystem( KomfortelektronikSystem _keSystem );

        /// <summary>
        /// Setzt die Komfortelektronik-Componenten und den -Schaltplan für die Seitenzahl.
        /// </summary>
        /// <param name="_seite">Seitenzahl</param>
        void SelectKomforelektronikFuerSeite( string _seite );

        #endregion

        // --------------------------------------------------------------------------

        #region Load-Methoden

        void LoadRueckrufe();
        
        void LoadSuchbaumListe();

        void LoadSchmiermittel();

        void LoadAlleReparaturhandbuecher();

        void LoadEinstelldaten();

        void LoadTechnischeZeichungen();
  
        void LoadKlimaanlageSchaltplanFahrzeuge();

        void LoadKlimaanlageSchaltplanSysteme();

        void SetCurrentTyp( FahrzeugTyp typ );

        #endregion

        // --------------------------------------------------------------------------

        #region Load-Methoden für Wartung

        bool LoadEinstelldatenByTechnikLinks(List<TechnikLink> _links);
        bool LoadEinstelldatenByTechnikLinksDummy(List<TechnikLink> _links);

        bool LoadSchmiermittelByTechnikLinks(List<TechnikLink> _links);
        bool LoadSchmiermittelByTechnikLinksDummy(List<TechnikLink> _links);

        bool LoadReparaturhandbuecherByTechnikLinks(List<TechnikLink> _links);
        bool LoadReparaturhandbuecherByTechnikLinksDummy(List<TechnikLink> _links);

        bool LoadTechnischeZeichnungGruppenByTechnikLinks(List<TechnikLink> _links);
        bool LoadTechnischeZeichnungGruppenByTechnikLinksDummy(List<TechnikLink> _links);

        void ClearAllDummy();

        #endregion

        // --------------------------------------------------------------------------

        bool LoadTechnischeZeichnungBreadcrumbByEinstelldatenLink();
        void LoadReparaturhandbuchEintraege(Reparaturhandbuch handbuch);
    }
}
