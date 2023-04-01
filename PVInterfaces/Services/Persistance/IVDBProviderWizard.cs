using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PV.DomainObjects.Artikel;
using PV.DomainObjects.Warenkorb.Transactions;

namespace PVInterfaces.Services.Persistance
{
    
    public interface IVDBProviderWizard
    {
        
        List<VdbArtikelInfo> GetVdbArtikelInfos(List<VdbArtikelId> _artikelListe, wkTransactionBaseReq baseReq);
    }
}
