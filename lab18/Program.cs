// See https://aka.ms/new-console-template for more information
using Data.Models;
using lab18;
using lab18.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

ResetDb();



static Producator  ResetDb()
{
    using var ctx = new ShopContext();

    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();


    var prod1 = new Producator
    {
        Nume = "Scandia",
        Adresa = "Sibiu str Pateului",
        Cui="SDdasasdasd",        
    };
    var alimente = new Categorie
    {
        Nume = "Alimente",
        Pictograma = @"www.mancare.ro/poza"
    };
    prod1.Categorii.Add(alimente);
    var produs1 = new Produs {
        Nume = "Pate de rata",
        Producator = prod1,
        Stoc = 100,
        Categorie = alimente,
        Eticheta = new Eticheta
        {
            CodDeBare = Guid.NewGuid(),
            Pret=9.00            
        }
    };
    var produs2 = new Produs
    {
        Nume = "Pate de porc",
        Producator = prod1,
        Stoc = 50,
        Categorie = alimente,
        Eticheta = new Eticheta
        {
            CodDeBare = Guid.NewGuid(),
            Pret = 8.55
        }
    };
    var produs3 = new Produs
    {
        Nume = "Salam de sibiu",
        Producator = prod1,
        Stoc = 3,
        Categorie = alimente,
        Eticheta = new Eticheta
        {
            CodDeBare = Guid.NewGuid(),
            Pret = 30
        }
    };


    ctx.Categorii.Add(alimente);
    ctx.Producatori.Add(prod1);
    ctx.Produse.Add(produs1);
    ctx.Produse.Add(produs2);
    ctx.Produse.Add(produs3);



    ctx.SaveChanges();
    return prod1;
}