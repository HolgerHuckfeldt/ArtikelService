using ArtikelService.Dto;
using ArtikelService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PV.DomainObjects.Artikel;

namespace ArtikelService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtikelController : ControllerBase
    {
        [HttpGet]
        [Route("Suchbaum")]
        public async Task<ActionResult> GetSuchbaum()
        {

            var service = new SolrArtikelService();
            var suchbaumResult = service.GetSuchbaumEintragList(new ArtikelSuchbaumRequest()
            {
                Art = ArtikelArt.PKW,
                Typ = 8799,
                VehicleId = 74621,
                FirmaId = 1,
                Mobile = false,
                AlternativeCSO = ""
            });

            if (suchbaumResult != null && suchbaumResult.Any())
            {
                var result = new List<Dto.Suchbaum>();
                foreach (var suchbaumEintrag in suchbaumResult)
                {
                    result.Add(new Suchbaum()
                    {
                        Id = suchbaumEintrag.Id,
                        Bezeichnung = suchbaumEintrag.Bezeichnung,
                        ParentId = suchbaumEintrag.Parent
                    });
                }

                return Ok(result);
            }

            return NotFound();
        }


        [HttpGet]
        [Route("Artikel")]
        public async Task<ActionResult> GetArtikelListm()
        {

            var service = new SolrArtikelService();

            var request = new ArtikelProviderRequest<SuchknotenAndTyp>(
                9033,
                80001,
                1,
                5,
                0,
                false,
                false,
                new SuchknotenAndTyp()
                {
                    Art = ArtikelArt.PKW,
                    Knoten = new SuchbaumEintrag()
                    {
                        Bezeichnung = "Ölfilter",
                        IdNew = 782,
                        Id = 9923,
                        IsNew = true,
                        UseNewId = true,
                        HatGenerischeArtikel = true,
                        HatRessource = false,
                        Parent = 9921,
                        ParentNew = 9923,
                        Tiefe = 2
                        
                    },
                    Typ = 54288,
                    VehicleId = 68193
                },
                0,
                1,
                false,
                false
            );

            var suchbaumResult = service.GetArtikelListeBySuchknotenAndTyp(request);

            return Ok(suchbaumResult.ArtikelListe);
        }

    }
}
