/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Fahrzeughistory
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für die History erfüllen muss
 ***************************************************************************************************************************************/

using System;
using System.Collections.Generic;

using PV.DomainObjects.History;
using PVInterfaces.Enums;

namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für die History erfüllen muss
    /// </summary>
  
    public interface IHistoryPersistanceProvider
    {
        #region IdentHistory

        /// <summary>
        /// Läd die Identhistory für einen User
        /// </summary>
        /// <param name="_user">Der User für welchen die History geladen werden soll</param>
        /// <returns>Eine Liste von Historyeinträgen</returns>
        
        List<HistoryEntry> LoadIdentHistory( Guid _user );

        /// <summary>
        /// Läd die Identhistory für einen User
        /// </summary>
        /// <param name="_user">Der User für welchen die History geladen werden soll</param>
        /// <param name="_count">Der User für welchen die History geladen werden soll</param>
        /// <returns>Eine Liste von Historyeinträgen</returns>
        
        List<HistoryEntry> LoadIdentHistoryNew(Guid _user, int _count);

        /// <summary>
        /// Speichert eine Identhistory
        /// </summary>
        /// <param name="_liste">Die Liste von Historyeinträgen</param>
        /// <returns>Das Speicherergebnis in Form eines SaveResults</returns>
        
        SaveResults SaveIdentHistory(List<HistoryEntry> _liste);
 
        #endregion

        /// <summary>
        /// Speichert eine FreitextHistory
        /// </summary>
        /// <param name="_liste">Die Liste von Historyeinträgen</param>
        /// <returns>Das Speicherergebnis in Form eines SaveResults</returns>
        
        SaveResults SaveFreeTextHistory( List<FreitextSuchHistory> _liste );

        /// <summary>
        /// Muss vom Client in Intervallen kleibner 10min aufgerufen werden.
        /// </summary>
        
        void Alive();
    }
}
