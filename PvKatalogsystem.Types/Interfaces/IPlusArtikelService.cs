using System.Collections.Generic;
using PvKatalogsystem.Types.DTOs;
using PvKatalogsystem.Types.Enums;
using PvKatalogsystem.Types.Results;
using System;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface IPlusArtikelService
    {
        
        List<Suchbaumknoten> GetSuchbaumknoten(Suchbaumtyp sbTyp);

        
        ArtikelSearchResult GetArtikelBySuchbaumknoten(List<int> genArtIds, Suchbaumtyp sbTyp);

        
        ArtikelSearchResult GetTeaserArtikel(TeaserTyp teaserTyp);

        
        ArtikelSearchResult GetAlleArtikel(Suchbaumtyp sbTyp);
    }
}
