/*********************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:      
 * Modul:       
 * Funktionen:  
 *********************************************/

using System;

using System.Threading;

namespace PVInterfaces.Services.Persistance
{
    
    public interface ISimplePasswordProvider
    {
   
        bool Authenticate(string pwd);

    }
}
