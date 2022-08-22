using OrcamentoApi.Domain.Dtos;
using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface IVendedorService : IBaseService<Vendedor>
    {
        VendedorResponse GetComissao(Vendedor vendedor);
        Vendedor GetName(string nome);
    }
}