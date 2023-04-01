using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.Artikel;

namespace PV.Business.Services
{
    public interface IArtikelLoadingCustomer
    {
        void OnLoadingComplete(Object customerId, List<Artikel> artList);
    }
}
