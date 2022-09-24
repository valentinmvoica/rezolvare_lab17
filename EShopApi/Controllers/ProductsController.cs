using Data.Models;
using EShopApi.DTOs;
using lab18;
using lab18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stocMinim"></param>
        /// <returns></returns>
        [HttpGet("all")]
        public IEnumerable<ProductToGet> Get([Optional][FromQuery] int? stocMinim)
        {
            using var ctx = new ShopContext();

            List<Produs> produse = new List<Produs>();
            if (stocMinim != null)
                produse = ctx.Produse.Include(p => p.Producator).Where(p => p.Stoc > stocMinim).ToList();
            else
            {
                produse = ctx.Produse.Include(p => p.Producator).ToList();
            }

            var result = new List<ProductToGet>();
            produse.ForEach(p =>
            {
                result.Add(new ProductToGet
                {
                    Nume = p.Nume,
                    Id = p.Id,
                    NumeProducator = p.Producator.Nume,
                    Stoc = p.Stoc
                });
            });

            return result;
        }

        /// <summary>
        /// Returneaza un produs in functie de id
        /// </summary>
        /// <param name="id">id-ul produsului</param>
        /// <param name="includeEticheta">specifica daca informatiile despre eticheta vor fi incluse sau nu</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Produs Get([FromRoute] int id, [FromQuery] bool includeEticheta)
        {
            using var ctx = new ShopContext();

            if (includeEticheta)
            {
                return ctx.Produse.Include(p => p.Eticheta).Where(p => p.Id == id).FirstOrDefault();
            }
            else
                return ctx.Produse.Where(p => p.Id == id).FirstOrDefault();
        }


        [HttpGet("maiMultiParams/{nume}/{stoc}")]
        public Produs GetAll([FromRoute] string nume, [FromRoute] int stoc)
        {
            using var ctx = new ShopContext();

            return ctx.Produse.Where(p => p.Nume == nume && p.Stoc >= stoc).FirstOrDefault();
        }

        [HttpGet("valoare-totala")]
        public double GetValoareTotala()
            => DataAccessLayer.Instance.GetTotalStockValue();


        [HttpPost("create-product")]
        public Produs CreateProduct([FromBody] ProductToCreate productToCreate)
        {
            return DataAccessLayer.Instance.AddProdus(productToCreate.Nume, productToCreate.Stoc, productToCreate.IdProductator, productToCreate.IdCategorie);
        }


        [HttpPut("schimba-stoc")]
        public void SchimbaStoc([FromRoute] int idProdus, [FromBody] int stoc)
        {
            using var ctx = new ShopContext();

            var produs = ctx.Produse.Where(p => p.Id == idProdus).FirstOrDefault();

            produs.Stoc = stoc;

            ctx.SaveChanges();
        }

        /// <summary>
        /// Sterge un produs in functie de id
        /// </summary>
        /// <param name="idProdus">id-ul produsului sters</param>
        [HttpDelete]
        public void StergeProdus([FromBody] int idProdus)
        {
            using var ctx = new ShopContext();
            var produs = ctx.Produse.Where(p => p.Id == idProdus).FirstOrDefault();

            if (produs != null)
            {
                ctx.Produse.Remove(produs);
            }

            ctx.SaveChanges();
        }


       
    }
}
