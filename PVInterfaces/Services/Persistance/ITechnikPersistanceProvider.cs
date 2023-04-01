/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für Technik erfüllen muss
 ***************************************************************************************************************************************/

using System.Collections.Generic;
using System.IO;

using PV.DomainObjects.Technik;

namespace PV.Persistance.Provider
{
    
    public interface ITechnikPersistanceProvider
    {
        #region ITechnikPersistanceProvider Member

        /// <summary>
        /// Liefert die Identifikationsdaten für ein Fahrzeug
        /// </summary>
        /// <param name="_kTypNr">Die Fahrzeugtyp-Id aus der TecDoc-DB</param>
        /// <returns>FahrzeugIdentifikation</returns>
        
        FahrzeugIdentifikation GetFahrzeugIdentifikation(int _kTypNr);

        /// <summary>
        /// Liefert eine Liste aller äquivalente Fahrzeug aus der Vivid-DB entsprechend dem aktuell, selektiertem aus TecDoc-DB.
        /// </summary>
        /// <param name="_kTypNr">Die Fahrzeugtyp-Id aus der TecDoc-DB</param>
        /// <returns>List<Fahrzeug></returns>
        
        List<Fahrzeug> GetFahrzeuge(int _kTypNr);

        /// <summary>
        /// Liefert Infos zu den Ölfüllmengen
        /// </summary>
        /// <param name="_kTypeNr"></param>
        /// <returns></returns>
        
        FuellmengenInfo GetFuellmengenInfo(int _kTypeNr);

                       
        OelInfo GetViskursitaet(int ktypeid);

        /// <summary>
        /// Liefert eine Liste aller Einstelldaten.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug für das die Daten benötigt werden</param>
        /// <param name="_hauptgruppe">Die Hauptgruppe, für die die Daten benötigt werden</param>
        /// <returns>List<Einstelldatum></returns>
        
        List<Einstelldatum> GetEinstelldaten(Fahrzeug _fahrzeug, EnumHauptgruppe.Hauptgruppe _hauptgruppe);

        /// <summary>
        /// Liefert eine Liste aller Einstelldaten.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug für das die Daten benötigt werden</param>
        /// <param name="gruppen">Die Hauptgruppen, für die die Daten benötigt werden</param>
        /// <returns>List<GetAlleEinstelldaten></returns>
        
        List< KeyValuePair<EnumHauptgruppe.Hauptgruppe,List<Einstelldatum>>> GetAlleEinstelldaten(Fahrzeug _fahrzeug, List<EnumHauptgruppe.Hauptgruppe> gruppen);

        /// <summary>
        /// Liefert eine Liste aller Einstelldatum-Zusatzinfos.
        /// </summary>
        /// <param name="_handbuchId">Die Id für das Handbuch, für das die Daten benötigt werden</param>
        /// <returns>List<EinstelldatumZusatzinfo></returns>
        
        List<EinstelldatumZusatzinfo> GetEinstelldatumZusatzinfos(int _handbuchId);

        /// <summary>
        /// Liefert eine Liste aller Reparaturhandbücher.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <returns>List<Reparaturhandbuch></returns>
        
        List<Reparaturhandbuch> GetReparaturhandbuecher(Fahrzeug _fahrzeug);

        /// <summary>
        /// Liefert eine Liste aller ReparaturhandbuchEinträge.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_hauptgruppe">Die Hauptgruppe, für die die Daten benötigt werden</param>
        /// <param name="_handbuchId">Die ID des Reparaturhandbuchs, für das die Daten benötigt werden</param>
        /// <returns>List<ReparaturhandbuchEintrag></returns>
        
        List<ReparaturhandbuchEintrag> GetReparaturhandbuchEintraege(Fahrzeug _fahrzeug, EnumHauptgruppe.Hauptgruppe _hauptgruppe, int _handbuchId);

        /// <summary>
        /// Liefert eine Liste aller Schmiermittel.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug für das die Daten benötigt werden</param>
        /// <param name="_hauptgruppe">Die Hauptgruppe, für die die Daten benötigt werden</param>
        /// <returns>List<Schmiermittel></returns>
        
        List<Schmiermittel> GetSchmiermittel(Fahrzeug _fahrzeug, EnumHauptgruppe.Hauptgruppe _hauptgruppe);

        /// <summary>
        /// Liefert eine Liste aller Motormanagement-Systeme.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug für das die Daten benötigt werden</param>
        /// <returns>List<MotormanagementSystem></returns>
        
        List<MotormanagementSystem> GetMotormanagementSysteme(Fahrzeug _fahrzeug);

        /// <summary>
        /// Lieferte eine Liste aller MotormanagementEinbaulageComponenten.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_mmSystemId">Die ID des Motormanagement-Systems, für die die Daten benötigt werden</param>
        /// <returns>List<MotormanagementEinbaulageComponente></returns>
        
        List<MotormanagementEinbaulageComponente> GetMotormanagementEinbaulageComponenten(Fahrzeug _fahrzeug, int _mmSystemId);

        /// <summary>
        /// Liefert eine Liste aller MotorManagementComponenten.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug für das die Daten benötigt werden</param>
        /// <param name="_hauptgruppe">Die Hauptgruppe, für die die Daten benötigt werden</param>
        /// <param name="_mmSystemId">Die ID des Motormanagement-Systems, für die die Daten benötigt werden</param>
        /// <returns>List<MMComponente></returns>
        
        List<MotormanagementComponente> GetMotormanagementComponenten(Fahrzeug _fahrzeug, EnumHauptgruppe.Hauptgruppe _hauptgruppe, int _mmSystemId);

        /// <summary>
        /// Liefert die Motormanagement-Componente.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_componenteId">Die Id der Componente, für die die Daten benötigt werden</param>
        /// <param name="_mmSystemId">Die ID des Motormanagement-Systems, für die die Daten benötigt werden</param>
        /// <returns>MotormanagementComponente</returns>
        
        MotormanagementComponente GetMotormanagementComponente(Fahrzeug _fahrzeug, int _componenteId, int _mmSystemId);

        /// <summary>
        /// Liefert eine Liste aller Sicherungskästen.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug für das die Daten benötigt werden</param>
        /// <returns>List<Sicherungskasten></returns>
        
        List<Sicherungskasten> GetSicherungskaesten(Fahrzeug _fahrzeug);

        /// <summary>
        /// Liefert eine Liste aller Sicherungen.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug für das die Daten benötigt werden</param>
        /// <param name="_sicherungsKastenId">Die Id des Sicherungskasten für den die Daten benötigt werden</param>
        /// <returns>List<Sicherung></returns>
        
        List<Sicherung> GetSicherungen(Fahrzeug _fahrzeug, int _sicherungsKastenId);

        /// <summary>
        /// Liefert eine Liste aller Gruppen für tech. Zeichnungen.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <returns>List<TechnischeZeichnungGruppe></returns>
        
        List<TechnischeZeichnungGruppe> GetTechnischeZeichnungGruppen(Fahrzeug _fahrzeug);

        /// <summary>
        /// Lädt das ganze Geraffel für den Finder.
        /// Ist da aus Performance-gründen.
        /// </summary>
        /// <param name="_fahrzeug"></param>
        /// <returns></returns>
        
        TechnikFinderInfos GetFinderInfos(Fahrzeug _fahrzeug);



        /// <summary>
        /// Liefert eine Liste aller tech. Zeichnungen.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_hauptgruppe">Die Hauptgruppe, für die die Daten benötigt werden</param>
        /// <param name="_zeichnungGruppeId">Die ID der ZeichnungGruppe, für den die Daten benötigt werden</param>
        /// <returns>List<TechnischeZeichnungGruppeItem></returns>
        
        List<TechnischeZeichnungGruppeItem> GetTechnischeZeichnungGruppeItems(Fahrzeug _fahrzeug, EnumHauptgruppe.Hauptgruppe _hauptgruppe, int _zeichnungGruppeId);


        
        List<TechnischeZeichnungGruppeItem> GetTechnischeZeichnungGruppeItemsAll(Fahrzeug _fahrzeug, List<KeyValuePair< EnumHauptgruppe.Hauptgruppe , int >> gruppe);

        /// <summary>
        /// Liefert eine Liste aller DiagnoseCodes. Wildcards werden unterstützt.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_code">Der DiagnoseCode, für den die Daten benötigt werden</param>
        /// <returns>List<DiagnoseCode></returns>
        
        List<DiagnoseCode> GetDiagnoseCodes(Fahrzeug _fahrzeug, string _code);

        
        List<int> GetDiagnoseCodeComponenten(string _code);

        /// <summary>
        /// Liefert das Bild für die Lage des EOBD-Steckers.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <returns>List<BlobLageEobdStecker></returns>
        
        BlobLageEOBDStecker GetBlobLageEobdStecker(Fahrzeug _fahrzeug);

        /// <summary>
        /// Liefert die DefaultDiagnose
        /// </summary>
        
        DefaultDiagnose GetDefaultDiagnose(int _errorcodeId);

        /// <summary>
        /// Liefert Informationen zu einem Image.
        /// </summary>
        /// <param name="_blobId">Id des Blobs</param>
        /// <returns>Blob</returns>
        
        Blob GetBlob(int _blobId);

        /// <summary>
        /// Liefert eine Liste aller KlimaanlageSchaltplan-Fahrzeuge.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <returns>List<KomfortelektronikFahrzeug></returns>
        
        List<KomfortelektronikFahrzeug> GetKlimaanlageSchaltplanFahrzeuge(Fahrzeug _fahrzeug);

        /// <summary>
        /// Liefert eine Liste aller KlimaanlageSchaltplan-Systeme.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_komfortFahrzeug">Das selektierte KomfortelektronikFahrzeug, für das die Daten benötigt werden</param>
        /// <returns>List<KomfortelektronikSystem></returns>
        
        List<KomfortelektronikSystem> GetKlimaanlageSchaltplanSysteme(Fahrzeug _fahrzeug, KomfortelektronikFahrzeug _komfortFahrzeug);

        /// <summary>
        /// Liefert eine Liste aller Komfortelektronik-Fahrzeuge.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <returns>List<KomfortelektronikFahrzeug></returns>
        
        List<KomfortelektronikFahrzeug> GetKomfortelektronikFahrzeuge(Fahrzeug _fahrzeug);

        /// <summary>
        /// Liefert eine Liste aller Komfortelektronik-Systeme.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_komfortFahrzeug">Das selektierte KomfortelektronikFahrzeug, für das die Daten benötigt werden</param>
        /// <returns>List<KomfortelektronikSystem></returns>
        
        List<KomfortelektronikSystem> GetKomfortelektronikSysteme(Fahrzeug _fahrzeug, KomfortelektronikFahrzeug _komfortFahrzeug);

        /// <summary>
        /// Liefert eine Liste aller Komfortelektronik-Componenten.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_komfortFahrzeug">Das selektierte Komfortelektronik-Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_komfortSystem">Das selektierte Komfortelektronik-System, für das die Daten benötigt werden</param>
        /// <returns>List<KomfortelektronikComponente></returns>
        
        List<KomfortelektronikComponente> GetKomfortelektronikComponenten(Fahrzeug _fahrzeug, KomfortelektronikFahrzeug _komfortFahrzeug, KomfortelektronikSystem _komfortSystem);

        /// <summary>
        /// Liefert eine Liste aller Komfortelektronik-Schaltpläne.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_komfortFahrzeug">Das selektierte Komfortelektronik-Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_komfortSystem">Das selektierte Komfortelektronik-System, für das die Daten benötigt werden</param>
        /// <returns>List<KomfortelektronikSchaltplan></returns>
        
        List<KomfortelektronikSchaltplan> GetKomfortelektronikSchaltplan(Fahrzeug _fahrzeug, KomfortelektronikFahrzeug _komfortFahrzeug, KomfortelektronikSystem _komfortSystem);

        
        List<KfzCallback> GetKfzCallbackList();

        
        List<KfzCallback> GetKfzCallbackListByType(int typeid);

        //Stream GetImage(string imageName);

        #endregion

        #region WartungToTechnik-Link-Methoden

        /// <summary>
        /// Liefert eine Liste aller Einstelldaten.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_adjHeaderId">Die ReferenzId</param>
        /// <returns>List<Einstelldatum></returns>
        
        List<Einstelldatum> GetEinstelldatenByHeaderId(Fahrzeug _fahrzeug, int _adjHeaderId);

        /// <summary>
        /// Liefert eine Liste aller Schmiermittel.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_mainGroup">Die Hauptgruppe, für die die Daten benötigt werden</param>
        /// <param name="_lbrSystemsId">Die ReferenzId</param>
        /// <returns>List<Schmiermittel></returns>
        
        List<Schmiermittel> GetSchmiermittelBySystemId(Fahrzeug _fahrzeug, string _mainGroup, int _lbrSystemsId);

        /// <summary>
        /// Liefert eine Liste aller Reparaturhandbücher.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_dstrNamesId">Die ReferenzId</param>
        /// <returns>List<Reparaturhandbuch></returns>
        
        List<Reparaturhandbuch> GetReparaturhandbuecherById(Fahrzeug _fahrzeug, int _dstrNamesId);

        /// <summary>
        /// Liefert eine Liste aller Gruppen für tech. Zeichnungen.
        /// </summary>
        /// <param name="_tdrwGroupId">Die ReferenzId</param>
        /// <returns>List<TechnischeZeichnungGruppe></returns>
        
        List<TechnischeZeichnungGruppe> GetTechnischeZeichnungGruppenByGroupId(int _tdrwGroupId, int typeid);

        #endregion

        
        List<int> GetGenArtsForComponent(List<string> comps);

        
        string GetAuthKey();

    }
}
