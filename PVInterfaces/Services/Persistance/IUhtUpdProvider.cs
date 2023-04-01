using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PV.Persistance.Provider
{
    
    public interface IUhtUpdProvider
    {
        
        int GetLatestRevision();
        
        byte[] GetLatestZipDataStream();
        
        Guid GetRepositoryId();
    }
}
