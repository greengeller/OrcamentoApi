using OrcamentoApi.Data.Dtos;
using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface IOrcamentoRepository
    {
        void Insert(Orcamento orc);

        void Update(int id, Orcamento orcamento);

        void Delete(int id);

        List<Orcamento> Select();

        Orcamento SelectId(int id);
    }
}
