using System.Collections.Generic;

using PV.DomainObjects.Technik;

namespace PV.Persistance.Provider
{
    
    public interface IWartungIndexProvider
    {
        
        List<TechnikSuchErgebnis> SearchByString(string toSerach, int pkw);
    }
}
