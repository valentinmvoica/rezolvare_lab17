namespace lab18.Models
{
    public class Producator
    {
        public int Id { get; set; }
        public string Nume  { get; set; }
        public string Adresa { get; set; }
        public string Cui{ get; set; }

        public List<Produs> Produse { get; set; } = new List<Produs>();

        public List<Categorie> Categorii { get; set; } = new List<Categorie>();

    }
}