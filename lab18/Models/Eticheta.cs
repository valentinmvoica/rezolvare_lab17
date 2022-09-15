using System.Reflection.Emit;

namespace lab18.Models
{
    internal class Eticheta
    {
        public int Id { get; set; }
        public Guid CodDeBare { get; set; }
        public double Pret { get; set; }
        public int ProdusId { get; set; }
        public Produs Produs { get; set; }
    }
}