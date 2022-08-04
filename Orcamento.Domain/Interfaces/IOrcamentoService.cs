using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface IOrcamentoService
    {
        Orcamento AdicionaOrcamento(Produtos produto, Vendedor vendedor, int quantidadeProduto);
    }
}
