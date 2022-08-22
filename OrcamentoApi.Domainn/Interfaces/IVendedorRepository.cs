using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface IVendedorRepository : IBaseRepository<Vendedor>
    {
        double GetComissao(int id);
        Vendedor GetName(string nome);
    }
}