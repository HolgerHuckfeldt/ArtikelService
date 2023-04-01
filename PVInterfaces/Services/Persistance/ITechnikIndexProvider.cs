using System.Collections.Generic;

using PV.DomainObjects.Technik;

namespace PV.Persistance.Provider
{
    
    public interface ITechnikIndexProvider
    {
        
        List<TechnikSuchErgebnis> SearchByString(string toSearch, int pkw);

        
        List<TechnikSuchErgebnis> HtmlSearchByString(string toSearch, string hersteller);
    }
}
