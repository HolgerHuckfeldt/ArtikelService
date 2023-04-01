/*********************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:      
 * Modul:       
 * Funktionen:  
 *********************************************/

using System;
using System.Collections.Generic;

namespace PV.Persistance.Provider
{
    public interface IResourceProvider
    {
        byte[] GetByteStreamByUri(String _appUri);
        List<String> Domains
        {
            get;
        }
    }
}
