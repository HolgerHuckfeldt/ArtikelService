using System;
using System.Collections.Generic;

using System.Text;

namespace PV.Persistance.Provider
{
    
    public interface IPVBestellungProvider
    {
        
        bool IsBestellungVorhanden(string kundennummer, string bestellId, string offlineBestellId);
    }
}
