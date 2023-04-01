using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PV.DomainObjects.InstanceServices.TransportObjects;

namespace PVInterfaces.Services.Persistance.InstanceServices.DataContracts
{
    public interface IPvInstanceCallback
    {
       
        void OnClientInfosChanged(List<SessionClientInfo> infos);
    }
}