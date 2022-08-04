using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface IOrcamentoRepository
    {
        void Insert(Orcamento orc);

        void Update(Orcamento orc);

        void Delete(int id);

        IList<Orcamento> Select();

        Orcamento Select(int id);
    }
}
