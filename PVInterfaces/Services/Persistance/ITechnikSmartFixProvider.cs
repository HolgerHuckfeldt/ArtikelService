using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PV.DomainObjects.Technik;
using PV.DomainObjects.Wartung;
using PV.DomainObjects.Wartung.Assistent;

namespace PV.Persistance.Provider
{
    
    public interface ITechnikSmartFixProvider
    {
        
        List<SmartFixSubject> GetSmartFixSubjects(int ktypeid, int motornummer);
        //
        //List<SmartFixData> GetSmartFixData(SmartFixElement element);
        
        List<SmartFixData> GetAllSmartFixData(List<SmartFixElement> elements);
        //
        //List<TSBCategory> GetTSBCategory(int typeId, string what);
        
        List<TSBCategorieGroup> GetAllTSBCategories(int typeId);
        //
        //List<TSBGroup> GetTSBData(int systemId);
        
        List<TSBGroup> GetAllTSBData(List<int> systemIds);

        
        List<TSBCategory> GetAllCallbackData(int ktypeid);

        
        List<string> GetDisclaimer(int type);

        
        List<string> GetDisclaimerArbeitswerte(int type);

        
        List<WartungsChecklisteItem> GetWartungsIntervalle(int _systemId, int typeid);

        
        List<WartungSystemIntervalleInfo> GetAlleWartungsIntervalle(int typeid);

        
        List<MaintSystem> Assistent_GetSystems(int type);

        
        List<MaintPeriod> Assistent_GetPeriod(int type, int systemId, string time, int km);

    }
}
