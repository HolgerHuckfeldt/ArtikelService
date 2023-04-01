/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-20015
 * Projekt:  PV-Kompass 
 * Author:   TB  
 * Modul:    Warenkorbimport
 * Funktionen:  Abstrahiert die Schnittstelle für den WarenkorbImport
 ***************************************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using PV.DomainObjects.Warenkorb;
using PV.DomainObjects.Artikel;

namespace PV.Persistance.Provider
{
    
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für WarenkorbImport erfüllen muss
    /// </summary>
    
    public interface IWarenkorbImportPersistanceProvider
    {
        /// <summary>
        /// Liefert für die Import-Datei die Warenkorbpositionen und und die nicht importierten Artikel zurück
        /// </summary>
        /// <param name="_art"></param>
        /// <returns></returns>
        
        WarenkorbImportResponse ImportiereWarenkorb(WarenkorbImportRequest request);

        /// <summary>
        /// Liefert die WarenkorbImportfilterEigenschaften für die FilterwarenkorbimportAuswahl-Combobox zurück
        /// </summary>
        /// <param name="_art"></param>
        /// <returns></returns>
        
        List<WarenkorbImportStandards> GetImportFilters();
    }
}
