using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using Pv.Services.Shared.Dtos;

namespace Pv.Services.Shared.Interfaces
{
    
    public interface IVdbOrderService
    {
        
        OrderServiceResult FindProcessedVdbOrderBy(String offlineId);
    }
}
