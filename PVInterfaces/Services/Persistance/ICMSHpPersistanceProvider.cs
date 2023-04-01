using System.Collections.Generic;
using PV.DomainObjects.CMS;


namespace PV.Persistance.Provider
{
   
    public interface ICMSHpPersistanceProvider
    {
        
        bool SaveContent(CmsHpObject entry);
        
        bool DeleteContent(CmsHpObject entry);
        
        CmsHpObject LoadContent(CmsHpObject entry);
        
        List<CmsHpObject> LoadFirmenListe();
        
        List<CmsHpObject> LoadStandorteByFirma(CmsHpObject entry);
    }
}
