using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.TemotDosi;


namespace PVInterfaces.Services.Persistance
{
   
    public interface IMotortesterProvider
    {
        
        List<DosiTicket> GetMotortesterTickets(string kunde);
        
        void SetMotortesterStatus(int id, int status);
    }
}
