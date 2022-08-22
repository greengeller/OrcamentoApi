using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface IProdutoService : IBaseService<Produtos>
    {
        Produtos GetName(string nome);
    }
}