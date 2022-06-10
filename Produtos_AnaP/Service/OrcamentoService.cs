using OcamentoApi.Models;

namespace OcamentoApi.Service
{
    public class OrcamentoService
    {

     
        public Orcamento AdicionaOrcamento(int id, Produtos produtos, Vendedor vendedor, int quantidadeProduto)
        {
            return new Orcamento(id, vendedor, produtos, quantidadeProduto);
        }

    }
}
