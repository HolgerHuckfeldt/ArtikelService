using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.TemotDosi;
using System.Collections.ObjectModel;

namespace PV.Business.Services
{
    public interface IStatisticManager
    {
        void CreateStat(string location, string extraInfo);
        void Flush();
    }
}
