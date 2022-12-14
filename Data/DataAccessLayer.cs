using Data.Models;
using lab18.Exceptions;
using lab18.Models;
using Microsoft.EntityFrameworkCore;

namespace lab18
{
    public class DataAccessLayer
    {
        private static DataAccessLayer instance = null;
        public static DataAccessLayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccessLayer();
                }
                return instance;
            }
        }
        private DataAccessLayer()
        {
        }

        public Categorie AddCategorie(string nume, string urlPoza)
        {
            using var ctx = new ShopContext();

            var categorie = new Categorie { Nume = nume, Pictograma = urlPoza };
            ctx.Add(categorie);
            ctx.SaveChanges();
            return categorie;
        }
        public Producator AddProducator(string nume, string cui, string adresa)
        {
            using var ctx = new ShopContext();

            var producator = new Producator { Nume = nume, Cui = cui, Adresa = adresa };
            ctx.Add(producator);

            ctx.SaveChanges();

            return producator;
        }
        public void SchimbaPretul(int idProdus, double pretNou)
        {
            using var ctx = new ShopContext();

            var produs = ctx.Produse.Include(p => p.Eticheta).FirstOrDefault(p => p.Id == idProdus);

            if (produs == null)
            {
                throw new NotFoundException($"Produsul {idProdus} nu exista");
            }
            produs.Eticheta.Pret = pretNou;

            ctx.SaveChanges();
        }
        public double GetTotalStockValue()
        {
            using var ctx = new ShopContext();
            return ctx.Produse.Include(p => p.Eticheta).Sum(p => p.Stoc * p.Eticheta.Pret);
        }
        public double GetTotalStockValueForProducer(int producerId)
        {
            using var ctx = new ShopContext();
            return ctx.Produse.Include(p => p.Eticheta).Where(p => p.ProducatorId == producerId).Sum(p => p.Stoc * p.Eticheta.Pret);
        }
        public Produs AddProdus(string Nume, int stoc, int idProducator, int idCategorie)
        {
            using var ctx = new ShopContext();


            if (!ctx.Producatori.Any(p => p.Id == idProducator))
            {
                throw new NotFoundException($"Producatorul {idProducator} nu exista");
            }
            Console.Clear();
            if (!ctx.Categorii.Any(c => c.Id == idCategorie))
            {
                throw new NotFoundException($"Categoria {idCategorie} nu exista");
            }

            var produs = new Produs
            {
                Nume = Nume,
                Stoc = stoc,
                ProducatorId = idProducator,
                CategorieId = idCategorie,
                Eticheta = ctx.Etichete.First(e => e.Id == 1)

            };

            ctx.Add(produs);

            ctx.SaveChanges();
            return produs;
        }

        public double ValoareCatProd(int idCategorie, int idProducator)
        {
            using var ctx = new ShopContext();

            if (!ctx.Producatori.Any(p => p.Id == idProducator))
            {
                throw new NotFoundException($"Producatorul {idProducator} nu exista");
            }

            if (!ctx.Categorii.Any(c => c.Id == idCategorie))
            {
                throw new NotFoundException($"Categoria {idCategorie} nu exista");
            }

            return ctx.Produse
                            .Where(p => p.CategorieId == idCategorie && p.ProducatorId == idProducator)
                            .Sum(p => p.Stoc * p.Eticheta.Pret);
        }
        public void StergeCategorie(int idCategorie)
        {
            using var ctx = new ShopContext();

            if (!ctx.Categorii.Any(c => c.Id == idCategorie))
            {
                throw new NotFoundException($"Categoria {idCategorie} nu exista");
            }

            var categoria = ctx.Categorii.Include(c=>c.Produse).First(c=>c.Id == idCategorie);

            categoria.Produse.ForEach(p => p.CategorieId = null);

            ctx.Categorii.Remove(categoria);

            ctx.SaveChanges();
        }

        public void StergeProdus(int idProus)
        {
            using var ctx = new ShopContext();

            var produs = ctx.Produse.Include(p=>p.Eticheta).First(p => p.Id == idProus);

            produs.Eticheta.ProdusId = null;
            ctx.Remove(produs);
            ctx.SaveChanges();
        }

    }
}
