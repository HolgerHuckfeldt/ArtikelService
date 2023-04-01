/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Artikelsuche
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für Artikel erfüllen muss
 ***************************************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using PV.DomainObjects.Artikel;
using PV.DomainObjects.Common;

namespace PV.Persistance.Provider
{
    
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für Artikel erfüllen muss
    /// </summary>
  
    public interface IDeliverProvider
    {
        /// <summary>
        /// TecCom Infos zu dem Artikel
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        
        List<int> GetTecComInfos(Artikel a);
    }
}
