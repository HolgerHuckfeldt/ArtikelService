using System.Collections.Generic;

using PV.DomainObjects.Artikel;
using PV.DomainObjects.Common;
using PV.DomainObjects.Plus;

namespace PV.Persistance.Provider
{
  
    public interface IPlusPersistanceProvider
    {
        
        List<SuchbaumEintrag> GetPlusSuchbaum();

        
        List<PraemienArtikel> GetArtikelBySuchbaumknoten(List<int> genArtIds);

        
        List<PraemienArtikel> GetTeaserArtikelPageOne();

        
        List<PraemienArtikel> GetTeaserArtikelPageTwo();

        
        List<PraemienArtikel> GetTeaserArtikelTop();
        
        
        List<PraemienArtikel> GetAlleArtikel();
    }
}
