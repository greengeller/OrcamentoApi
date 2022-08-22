using OrcamentoApi.Data.Dtos;
using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface IOrcamentoService
    {
        Orcamento AdicionaOrcamento(Produtos produto, Vendedor vendedor, int quantidadeProduto);
        Orcamento AtualizaOrcamento(int id, UpdateOrcamentoDto orcDto);
        Orcamento AtualizaQuantidade(int id, UpdateQuantidadeDto orcDto);
        Orcamento ExcluiOrcamento(int id);
        Orcamento GetId(int id);
        List<Orcamento> GetOrcamento();
    }
}
