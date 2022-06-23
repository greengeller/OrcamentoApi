using OrcamentoApi.Models;

namespace OrcamentoApi.Service
{
    public class ProdutoRepository
    {
        public Produtos[] GetAllProdutos()
        {
            return new Produtos[]
            {
                new Produtos
                {
                    Id = 1,
                    Nome = "Borracha",
                    Valor = 2.52
                },

                new Produtos
                {
                    Id = 2,
                    Nome = "Lapiseira",
                    Valor = 4.99
                },

                new Produtos
                {
                    Id = 3,
                    Nome = "Caneta",
                    Valor = 2.56
                },

                new Produtos
                {
                    Id = 4,
                    Nome = "Sulfite",
                    Valor = 10.99
                },

                new Produtos
                {
                    Id = 5,
                    Nome = "Grampeador",
                    Valor = 5.99
                }
            };
        }
    }
}
