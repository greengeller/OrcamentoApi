using OrcamentoApi.Domain.Dtos;
using OrcamentoApi.Domain.Entities;
using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Service;

namespace OrcamentoApi.Service
{
    public class VendedorService : BaseService<Vendedor>, IVendedorService
    {
        private readonly IVendedorRepository _vendedorRepository;

        public VendedorService(IVendedorRepository vendedorRepository) : base(vendedorRepository)
        {
           _vendedorRepository = vendedorRepository;
        }
        
        public Vendedor GetName(string nome) => _vendedorRepository.GetName(nome);
        
        public VendedorResponse GetComissao(Vendedor vendedor)
        {
            var valor = _vendedorRepository.GetComissao(vendedor.Id);
           
            VendedorResponse vendedorResponse = new(valor)
            {
                Id = vendedor.Id,
                Nome = vendedor.Nome                
            };
            return vendedorResponse;
        }        
    }
}