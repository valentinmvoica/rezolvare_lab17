using EShopApi.DTOs;
using lab18.Models;

namespace EShopApi.Extensions
{
    public static class ExtensiiProducator
    {
        public static ProducatorToGet ToDto(this Producator producator)
        {
            return 
                new ProducatorToGet 
                { 
                    Id = producator.Id, 
                    Adresa = producator.Adresa, 
                    Nume = producator.Nume, 
                    Cui = producator.Cui 
                };
        }
    }
}
