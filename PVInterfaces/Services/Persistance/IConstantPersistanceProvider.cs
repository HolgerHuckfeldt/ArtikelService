/*********************************************************************************************************
 * Copyright    Absolute Software GmbH 2008-2009
 * Projekt:     PV-Kompass 
 * Author:      Dirk Lannatewitz
 * Modul:       Stammdatenverwaltung 
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für die Konstanten erfüllen muss
 *********************************************************************************************************/

using System.Collections.Generic;
using System.Runtime.Serialization;

using PV.DomainObjects.Kunden;
using PV.DomainObjects.Common;

namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für die Stammdaten erfüllen muss
    /// </summary>

    public interface IConstantPersistanceProvider
    {
        /// <summary>
        /// Liefert die Version der Datenbank
        /// </summary>
        /// <returns>Liste von Anreden</returns>
        
        long GetVersion();

        /// <summary>
        /// Liefert die Liste der Anreden
        /// </summary>
        /// <returns>Liste von Anreden</returns>
        
        List<Anrede> GetAnreden();

        /// <summary>
        /// Liefert eine Liste aller in der DB gespeicgerten Einheiten
        /// </summary>
        /// <returns></returns>
        
        List<Einheit> GetEinheiten();

        /// <summary>
        /// Liefert eine Liste aller in der DB gespeicherten USt-Arten
        /// </summary>
        /// <returns></returns>
        
        List<UStArt> GetUStArten();

        /// <summary>
        /// Muss vom Client in Intervallen kleibner 10min aufgerufen werden.
        /// </summary>
        
        void Alive();
    }
}
