using OrcamentoApi.Domain.Dtos;
using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface IOrcamentoService : IBaseService<Orcamento>
    {
        Orcamento Add(Vendedor vendedor, Produtos produtos, int quantidade);
        IList<Orcamento> Get();
        Orcamento GetId(int id);
        Orcamento Update(int id, UpdateOrcamentoDto orcDto);
        Orcamento Updatequantidade(int id, UpdateQuantidadeDto orcDto);
    }
}