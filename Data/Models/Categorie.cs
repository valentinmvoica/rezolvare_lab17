namespace lab18.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Pictograma { get; set; }
        public List<Produs> Produse { get; set; } = new List<Produs>();
        public List<Producator> Producatori { get; set; } = new List<Producator>();
    }
}