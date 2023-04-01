/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Eigene Arbeitswert Verwaltung
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für die Persistierung der Eigenen Arbeitswerte erfüllen muss
 ***************************************************************************************************************************************/

using System;
using System.Collections.Generic;

using PV.DomainObjects.Stammdaten;
using PVInterfaces.Enums;

namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für die Persistierung der Eigenen Arbeitswerte erfüllen muss
    /// </summary>
   
    public interface IEigeneArbeitswertePersistanceProvider
    {
        /// <summary>
        /// Liefert für eine Werkstatt die eigenen Arbeitswerte
        /// </summary>
        /// <param name="werkstatt">Die Werkstatt</param>
        /// <returns>Liste der eigenen Arbeitswerte</returns>
        
        List<EigenerArbeitswert> GetEigenerArbeitswertListe( Werkstatt werkstatt );

        /// <summary>
        /// Liefert die nächste freie Nummer in der DB für einen Eigenen Arbeitswert
        /// </summary>
        /// <returns></returns>
        
        int GetNextEigenenArbeitswertNummer();

        /// <summary>
        /// Das Ding wieder freigeben
        /// </summary>
        /// <returns></returns>
        
        int GetNextDurchlaufarbeitswertId();

        
        void ReleaseDurchlaufarbeitswertId(int nummer);
        /// <summary>
        /// Sichert einen übergebenen eigenen Arbeitswert
        /// </summary>
        /// <param name="eigenerArbeitswert">Der zu sichernde eigene Arbeitswert</param>
        
        SaveResults Save( EigenerArbeitswert eigenerArbeitswert );

        /// <summary>
        /// Löscht einen übergebenen eigenen Arbeitswert
        /// </summary>
        /// <param name="eigenerArbeitswertId">Die Guid des zu löschende eigenen Arbeitswertes</param>
        
        SaveResults Delete( Guid eigenerArbeitswertId );

        /// <summary>
        /// Liefert einen eigenen Arbeitswert anhand seiner Nummer
        /// </summary>
        /// <param name="nummer">Die Nummer des gesuchten eigenen Arbeitswertes</param>
        /// <returns>Der eigene Arbeitswert</returns>
        
        EigenerArbeitswert GetEigenerArbeitswertByNummer( int nummer );

        /// <summary>
        /// Liefert einen eigenen Arbeitswert anhand seiner Guid
        /// </summary>
        /// <param name="id">Die Gudi des gesuchten eigenen Arbeitswertes</param>
        /// <returns>Der eigene Arbeitswert</returns>
        
        EigenerArbeitswert GetEigenerArbeitswertByGuid(Guid id);


        /// <summary>
        /// Muss vom Client in Intervallen kleibner 10min aufgerufen werden.
        /// </summary>
        
        void Alive();
    }
}
