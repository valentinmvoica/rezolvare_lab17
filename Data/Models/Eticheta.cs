using System.Reflection.Emit;
using System.Text.Json.Serialization;

namespace lab18.Models
{
    public class Eticheta
    {
        public int Id { get; set; }
        public Guid CodDeBare { get; set; }
        public double Pret { get; set; }
        public int? ProdusId { get; set; }
        [JsonIgnore]
        public Produs Produs { get; set; }
    }
}