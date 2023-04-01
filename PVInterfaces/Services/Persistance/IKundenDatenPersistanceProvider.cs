/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Kundenverwaltung
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für die Kundenverwaltung erfüllen muss
 ***************************************************************************************************************************************/

using System;
using System.Collections.Generic;

using PV.DomainObjects.Kunden;
using PVInterfaces.Enums;


namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für die Kundenverwaltung erfüllen muss
    /// </summary>
   
    public interface IKundenDatenPersistanceProvider
    {
        /// <summary>
        /// Initiirt das Laden der KundenListe
        /// </summary>
        
        List<Kunde> LoadKundenListe();

        /// <summary>
        /// Speichert einen übergebenen Kunden
        /// </summary>
        /// <param name="_kunde">Der zu speichernde Kunde</param>
        /// <returns>Das Ergebnis des Speicherns als SaveResult</returns>
        
        SaveResults SaveKunde(Kunde _kunde);

        /// <summary>
        /// Löscht einen übergebenen Kunden
        /// </summary>
        /// <param name="_kundeId">Die GUID des zu löschenden Kunden</param>
        /// <returns>Das Ergebnis des Löschens als SaveResult</returns>
        
        SaveResults DeleteKunde(Guid _kundeId);

        /// <summary>
        /// Liefert die Maximale Kundennummer inkrementiert um 1
        /// </summary>
        /// <returns>Die neue Kundennummer</returns>
        
        int GetNewKundennummer();

        /// <summary>
        /// Muss vom Client in Intervallen kleibner 10min aufgerufen werden.
        /// </summary>
        
        void Alive();
    }
}
