using Microsoft.EntityFrameworkCore;

namespace lab18.Models
{
    internal class ShopContext:DbContext
    {
        public DbSet<Eticheta>  Etichete{ get; set; }
        public DbSet<Categorie> Categorii { get; set; }
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Producator> Producatori{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-CV0NQIA\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
