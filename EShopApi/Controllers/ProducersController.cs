using Data.Models;
using EShopApi.DTOs;
using EShopApi.Extensions;
using lab18.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        [HttpGet("all")]
        public IEnumerable<ProducatorToGet> GetAllProducatori()
        {
            using var ctx = new ShopContext();
            return ctx.Producatori.Select(p => p.ToDto()).ToList();
        }

        [HttpPost]
        public ProducatorToGet CreateProducator([FromBody]ProducatorToCreate producatorToCreate)
        {
            using var ctx = new ShopContext();
            var noulProducator = new Producator
            {
                Nume = producatorToCreate.Nume,
                Adresa = producatorToCreate.Adresa,
                Cui = producatorToCreate.Cui                
            };

            ctx.Add(noulProducator);
            ctx.SaveChanges();
            return noulProducator.ToDto();
        }
    }
}
