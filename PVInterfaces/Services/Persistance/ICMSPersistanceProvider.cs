using System.Collections.Generic;
using PV.DomainObjects.CMS;


namespace PV.Persistance.Provider
{

    public interface ICMSPersistanceProvider
    {
        
        bool SaveContent(CmsObject entry);
        
        CmsObject LoadCMSSettingsContent(CmsObject entry);
        
        CmsObject LoadContent(CmsObject entry);
        
        List<CmsObject> LoadListContent(CmsObject entry);
        
        bool SaveSetting(CmsSetting setting);
        
        bool SaveSettings(IList<CmsSetting> liste);
        
        bool SaveScript(CmsScript script);
        
        CmsSetting GetSetting(string name);
        
        IList<CmsSetting> GetAllSettings();
        
        CmsHpObject LoadFirmenLogo(int firma, int standort, bool isPitStop);
        
        CmsHandbuchObject LoadHandbuch(int kkzid);
        
        List<CmsHandbuchObject> LoadKennzeichenLinks();
        
        List<KeyValuePair<string,string>> LoadConfigs();
        
        List<string> GetHighlightStrings();
        
        CmsScript GetScript(string name, int version);
        
        List<CmsScript> GetAllScripts();
    }
}
