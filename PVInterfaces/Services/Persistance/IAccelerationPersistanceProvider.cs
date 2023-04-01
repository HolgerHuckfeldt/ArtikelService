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

using PV.DomainObjects.Acceleration;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Common;

namespace PV.Persistance.Provider
{
    
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für Artikel erfüllen muss
    /// </summary>
 
    public interface IAccelerationPersistanceProvider
    {
     
        KbaSelectInfos GetForKbaSelect(ForKbaSelectProviderRequest forKbaSelectProviderRequest);
        
       
        PkwSelectInfos GetForPkwSelect(ForPkwSelectProviderRequest forPkwSelectProviderRequest);

       
        ArtikelSearchInfo GetForArtikelSearch(ArtikelProviderRequest<ArtikelNummernsucheArten> request);


    }
}
