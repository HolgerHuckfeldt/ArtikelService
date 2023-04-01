using System;
using PV.DomainObjects.Artikel;

namespace PV.Business.Services
{
    public interface ICollectorManager
    {
        ArtikelKatalogIdent GetKatalogIdById(object id);
        void ChangePositionOnId(object id, Artikel artikel);
    }
}
