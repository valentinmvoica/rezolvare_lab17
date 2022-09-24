namespace EShopApi.DTOs
{
    public class ProductToCreate
    {
        public string Nume { get; set; }
        public int Stoc { get; set; }
        public int IdProductator { get; set; }
        public int IdCategorie { get; set; }
    }
}
