using OrcamentoApi.Data;
using OrcamentoApi.Models;

namespace OrcamentoApi.Service
{
    public class OrcamentoService
    {
        public OrcamentoService()
        {          
        }
        public Orcamento AdicionaOrcamento(Produtos produtos, Vendedor vendedor, int quantidadeProduto)
        {
            var orcamento = new Orcamento(vendedor, produtos, quantidadeProduto);
            return orcamento;
        }
    }
}
