/*********************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:      
 * Modul:       
 * Funktionen:  
 *********************************************/

using System;

using System.Threading;
using PV.Business.Services;

namespace PV.Persistance.Provider
{

    
    public interface IRessourceProvider
    {
        byte[] NoImage{get;}

     
        byte[] GetImageSourceByUri(String _uri);
        
      
        object GetRessourceSync(string suri, bool thumb, RessourceResult ResResult);

     
        Guid GetRessource(Uri uri, bool thumb, RessourceResult ResType, SendOrPostCallback callBack);

   
        Guid GetRessource(string bildname, bool thumb, RessourceResult ResType, SendOrPostCallback callBack);


        Guid GetRessource(string dateiname, int dl, string type, bool thumb, RessourceResult ResType, SendOrPostCallback callBack);
    }
}
