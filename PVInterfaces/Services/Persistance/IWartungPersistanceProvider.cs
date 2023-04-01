/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Wartung
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für Wartung erfüllen muss
 ***************************************************************************************************************************************/

using System.Collections.Generic;

using PV.DomainObjects.Technik;
using PV.DomainObjects.Wartung;
using PV.DomainObjects.Wartung.TransferObjects;

namespace PV.Persistance.Provider
{
    
    public interface IWartungPersistanceProvider
    {
        #region IWartungPersistanceProvider Member

        /// <summary>
        /// Liefert eine Liste aller Wartungsanzeigen-Rückstell-Infos.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <returns>List<WartungsHandbuch></returns>
        
        List<WartungsHandbuch> GetWartungsanzeigeRueckstellungen(Fahrzeug _fahrzeug);

        /// <summary>
        /// Liefert eine Liste aller Wartungs-Zusatzinformationen.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <returns>List<WartungsHandbuch></returns>
        
        List<WartungsHandbuch> GetWartungsZusatzInformationen(Fahrzeug _fahrzeug);

        /// <summary>
        /// Liefert eine Liste aller WartungshanduchEintraege.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_handbuchId">Die ID des Wartunghandbuches, für das die Daten benötigt werden</param>
        /// <returns>List<WartungsHandbuchEintrag></returns>
        
        List<WartungsHandbuchEintrag> GetWartungsItems(Fahrzeug _fahrzeug, int _handbuchId);

        /// <summary>
        /// Liefert eine Liste aller WartungsChecklisten.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <returns>List<WartungsCheckliste></returns>
        
        List<WartungsCheckliste> GetWartungsChecklisten(Fahrzeug _fahrzeug);

        /// <summary>
        /// Liefert eine Liste aller WartungsChecklistePerioden.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_checklisteId">Die Id der WartungsCheckliste, für das die Daten benötigt werden</param>
        /// <returns>List<WartungsChecklistePeriode></returns>
        
        List<WartungsChecklistePeriode> GetWartungsChecklistPerioden(Fahrzeug _fahrzeug, int _checklisteId);

        /// <summary>
        /// Liefert eine Liste aller Wartungs-SpezialAngebote.
        /// Gilt für alle Fahrzeuge!
        /// </summary>
        /// <returns>List<WartungsChecklistePeriode></returns>
        
        List<WartungsChecklistePeriode> GetWartungsSpezialAngebote();

        /// <summary>
        /// Liefert eine Liste aller WartungsChecklisteItems.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_periodeId">Die Id der ChecklistePeriode, für die die Daten benötigt werden</param>
        /// <returns>List<WartungsChecklisteItem></returns>
        
        List<WartungsChecklisteItem> GetWartungsChecklisteItems(Fahrzeug _fahrzeug, int _periodeId);

        /// <summary>
        /// Liefert eine Liste der WartungsChecklisteItems für die Detailansicht
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_periodeId">Die Id der ChecklistePeriode, für die die Daten benötigt werden</param>
        /// <returns>List<WartungsChecklisteItem></returns>
        
        List<WartungsChecklisteItem> GetWartungsChecklisteDetailItems(Fahrzeug _fahrzeug, int _periodeId);

        /// <summary>
        /// Liefert eine Liste aller Checklisten, die Steuerriemenintervall-Items haben.
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <returns>List<int></returns>
        
        List<int> GetSteuerriemenintervalle(Fahrzeug _fahrzeug);

        /// <summary>
        /// Liefert eine Liste aller Steuerriemenintervall-Items.
        /// </summary>
        /// <param name="_checklisteId">Die Id der WartungsCheckliste, für das die Daten benötigt werden</param>
        /// <returns>List<WartungsChecklisteItem></returns>
        
        List<WartungsChecklisteItem> GetSteuerriemenintervallItems(int _systemId, int typeid);

        /// <summary>
        /// Liefert eine Liste aller Details für das SteuerriemenintervallItem.
        /// </summary>
        /// <param name="_itemId">Die Id des ChecklistItems, für die die Daten benötigt werden</param>
        /// <param name="_checklisteId">Die Id der Checkliste, für die die Daten benötigt werden</param>
        /// <param name="_anmerkungId">Die Id der Anmerkung, für die die Daten benötigt werden</param>
        /// <returns>List<WartungsChecklisteItem></returns>
        
        List<WartungsChecklisteItem> GetSteuerriemenintervallItemDetails(int _systemId, int typeid);

        /// <summary>
        /// KType und MotorNummer to Vivid-ID
        /// </summary>
        /// <param name="_fahrzeug"></param>
        /// <returns></returns>
        
        int MapToVivid(Fahrzeug _fahrzeug);

        #endregion

        #region WartungToTechnik-Link-Methoden

        /// <summary>
        /// Liefert eine Liste der Technikverlinkungen
        /// </summary>
        /// <param name="_fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <param name="_item">Das ChecklistenItem, für das die Daten benötigt werden</param>
        /// <param name="_linkTyp">Der LinkTyp, für den die Daten benötigt werden</param>
        /// <returns>List<TechnikLink></returns>
        
        List<TechnikLink> GetTechnikLinks(Fahrzeug _fahrzeug, WartungsChecklisteItem _item, WartungsChecklisteItem.TechnikLinkTyp _linkTyp);

        
        List<TechnikLink> GetAllTechnikLinks(Fahrzeug _fahrzeug, WartungsChecklisteItem _item);

        
        List<MaintenanceTo> GetArbeitsprozesse(Fahrzeug _fahrzeug, int systemId, List<int> periodId);

        #endregion
    }
}
