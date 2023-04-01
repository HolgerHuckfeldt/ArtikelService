using System.Collections.Generic;
using PV.DomainObjects.CMS;


namespace PV.Persistance.Provider
{
 
    public interface ICMSHandbuchPersistanceProvider
    {
        
        bool SaveContent(CmsHandbuchObject entry);
        
        bool DeleteContent(CmsHandbuchObject entry);
        
        CmsHandbuchObject LoadContent(CmsHandbuchObject entry);
        
        List<CmsHandbuchObject> LoadKennzeichenListe();
    }
}
