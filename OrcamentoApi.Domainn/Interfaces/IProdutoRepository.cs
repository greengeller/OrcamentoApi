using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface IProdutoRepository : IBaseRepository<Produtos>
    {
        Produtos GetName(string nome);
    }
}