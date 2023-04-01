/*********************************************************************************************************
 * Copyright    Absolute Software GmbH 2008-2009
 * Projekt:     PV-Kompass 
 * Author:      Dirk Lannatewitz (WaLi seit 8.Mai.2009)
 * Modul:       Warenkorb 
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für die Warenkörbe erfüllen muss
 *********************************************************************************************************/

using System;
using System.Collections.Generic;

using PV.DomainObjects.Stammdaten;
using PV.DomainObjects.Warenkorb;
using PVInterfaces.Enums;

namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für die Warenkörbe erfüllen muss
    /// </summary>
  
    public interface IWarenkorbPersistanceProvider
    {
        /// <summary>
        /// Liefert die maximale WarenkorbBelegnummer inkrementiert um 1
        /// </summary>
        /// <returns>Die neue Belegnummer</returns>
        
        int GetNextBelegNummer();

        /// <summary>
        /// Sichert einen Warenkorb und aktualisiert die BelegID, falls noch nicht vorhanden
        /// </summary>
        /// <param name="_warenkorb">Der zu sichernde Warenkorb</param>
        
        SaveResults Save(wkWarenkorb _warenkorb);

        /// <summary>
        /// Sichert einen Warenkorb und aktualisiert die BelegID, falls noch nicht vorhanden
        /// </summary>
        /// <param name="_warenkorb">Der zu sichernde Warenkorb</param>
        /// <param name="_positionen">Die Serialisierte Liste der Warenkorbpositionen</param>
        
        SaveResults SaveWithPositions( wkWarenkorb _warenkorb, byte[] _positionen, Guid _user, Guid _profil );

        /// <summary>
        /// Liefert eine Liste aller Warenkörbe für einen Mitarbeiter
        /// </summary>
        /// <returns>Liste von Warenkörben</returns>
        
        List<WarenkorbInfo> LoadWarenkorbListe();

        /// <summary>
        /// Lädt einen Warenkorb
        /// </summary>
        /// <param name="_warenkorbId">Die Guid des Warenkorbes</param>
        /// <returns>Der Warenkorb</returns>
        
        wkWarenkorb LoadWarenkorb(Guid _warenkorbId);

        /// <summary>
        /// Liefert die serialisierte Liste der Warenkorb-Positionen zu einem Warenkorb
        /// </summary>
        /// <param name="_warenkorb">Der Warenkorb für welchen die Positionen geladen werden sollen</param>
        /// <returns>Liste der serialisierten Warenkorb-Positionen</returns>
        
        byte[] GetPositionsForWarenkorb(wkWarenkorb _warenkorb);

        /// <summary>
        /// Löscht einen Warenkorb
        /// </summary>/// <param name="_warenkorbId">Die Guid des zu löschenden Warenkorbes</param>
        /// <returns>Das Ergebnis des Löschens in Form eines SaveResults</returns>
        
        SaveResults DeleteWarenkorb(Guid _warenkorbId);

        /// <summary>
        /// Lädt die serialisierten Positionen eines Warenkorbs
        /// </summary>
        /// <param name="_warenkorbId"></param>
        /// <returns></returns>
        
        byte[] LoadWarenkorbPositions(Guid _warenkorbId);

        /// <summary>
        /// Hält die Named-Pipe offen
        /// </summary>
        
        void Alive();
    }
}
