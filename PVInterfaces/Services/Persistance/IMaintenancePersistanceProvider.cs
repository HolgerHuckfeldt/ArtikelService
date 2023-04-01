/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz
 * Modul:    Wartung
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für Wartung erfüllen muss
 ***************************************************************************************************************************************/

using System.Collections.Generic;
using PV.DomainObjects.Technik;
using PV.DomainObjects.Wartung.TransferObjects;
using PV.DomainObjects.Wartung.Assistent;

namespace PVInterfaces.Services.Persistance
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für Wartung erfüllen muss
    /// </summary>
    public interface IMaintenancePersistanceProvider
    {
        /// <summary>
        /// Liefert eine Liste der Maintenances für ein Fahrzeug
        /// </summary>
        /// <param name="fahrzeug">Das Fahrzeug, für das die Daten benötigt werden</param>
        /// <returns>Liste von MaintenanceTo</returns>
        
        List<MaintenanceTo> GetMaintenances(Fahrzeug fahrzeug );

        
        List<Fahrzeug> GetFahrzeuge(int _kTypNr);

        
        List<string> GetDisclaimer(int type);


    }
}