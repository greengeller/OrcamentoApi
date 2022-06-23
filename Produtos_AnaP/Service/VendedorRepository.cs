using OrcamentoApi.Models;

namespace OrcamentoApi.Service
{
    public class VendedorRepository
    {
        public Vendedor[] GetAllVendedor()
        {
            return new Vendedor[]
            {
                new Vendedor
                {
                    Id = 1,
                    Nome = "Camila Cristine",

                },

                new Vendedor
                {
                    Id = 2,
                    Nome = "Ana Paula",

                },

                new Vendedor
                {
                    Id = 3,
                    Nome = "Rubens Vinicius",

                },
            };
        }
    }
}
