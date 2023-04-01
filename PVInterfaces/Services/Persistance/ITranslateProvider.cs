using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.Persistance.Provider
{
    public interface ITranslateProvider
    {
        string GetTranslation(string lang, string key);
    }
}
