using OrcamentoApi.Data;
using OrcamentoApi.Models;

namespace OrcamentoApi.Service
{
    public class OrcamentoService
    {
        private readonly OrcamentoContext _context;
        public OrcamentoService(OrcamentoContext context)
        {
            _context = context;
        }

        public Orcamento AdicionaOrcamento(Produtos produtos, Vendedor vendedor, int quantidadeProduto)
        {
            var orcamento = new Orcamento(vendedor, produtos, quantidadeProduto);
            return orcamento;
        }

        


    }
}
