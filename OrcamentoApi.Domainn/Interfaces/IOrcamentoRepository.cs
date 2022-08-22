using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface IOrcamentoRepository : IBaseRepository<Orcamento>
    {
        IList<Orcamento> Get();
        Orcamento GetId(int id);
    }
}