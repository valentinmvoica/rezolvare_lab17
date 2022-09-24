using lab18.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<Eticheta> Etichete { get; set; }
        public DbSet<Categorie> Categorii { get; set; }
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Producator> Producatori { get; set; }
        public DbSet<ProdusElectronic> ProduseElectronice { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-CV0NQIA\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
