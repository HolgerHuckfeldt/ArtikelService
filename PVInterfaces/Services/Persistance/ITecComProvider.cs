/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Achsidentifikation
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für den Motor Index erfüllen muss
 ***************************************************************************************************************************************/
using System.Collections.Generic;
using PV.DomainObjects.Fahrzeug;

using PV.DomainObjects.Artikel;


namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für den Motor Index erfüllen muss
    /// </summary>
    
    public interface ITecComProvider
    {

        
        TecComInfo GetTecComInfo(string artikelnummer, int dlnr, int quantity);

    }
}
