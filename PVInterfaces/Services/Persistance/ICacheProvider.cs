using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PV.Persistance.Provider
{

    public interface ICacheProvider
    {

        
        bool Put(string key, DateTime expiration, byte[] data);

        
        byte[] Get(string key);

        
        bool HasKey(string key);

        
        bool Delete(string key);

        
        bool Clear();

    }
}
