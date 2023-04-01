using System.Collections.Generic;
using PV.DomainObjects.CMS;


namespace PV.Persistance.Provider
{
    
    public interface IStandortPersistanceProvider
    {
        
        StandortObject LoadStandort(StandortObject entry);
        
        List<StandortObject> LoadStandorte();
        
        List<StandortObject> LoadStandorteByFirma(StandortObject entry);
    }
}
