using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.Artikel;
using PvKatalogsystem.Types.DTOs;


namespace ArtikelService.PVSolrServices.Mapper
{
    public class SuchbaumEintragMapper
    {
        public static SuchbaumEintrag Map(Suchbaumknoten dto)
        {
            var eintrag = new SuchbaumEintrag();

            eintrag.Id = dto.Id;
            eintrag.Bezeichnung = dto.Bezeichnung;
            eintrag.HatGenerischeArtikel = dto.IsEndknoten;
            eintrag.HatRessource = dto.IsTemotStrip;
            eintrag.TemotStripId = dto.TemotStripId;
            eintrag.Parent = dto.ParentId ?? 0;
            eintrag.Tiefe = dto.Ebene + 1;
            eintrag.SuchknotenGrafik = dto.SuchknotenGrafik;
            
            return eintrag;
        }

        public static List<SuchbaumEintrag> Map(IEnumerable<Suchbaumknoten> dtoList)
        {
            var result = new List<SuchbaumEintrag>();
            foreach (var dto in dtoList)
            {
                result.Add(Map(dto));
            }
            return result;
        }
    }
}
