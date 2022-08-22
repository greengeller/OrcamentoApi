using System.Linq;
using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Infra.Data.Context;

namespace OrcamentoApi.Infra.SQL.Repository
{
    public class VendedorRepository : BaseRepository<Vendedor>, IVendedorRepository
    {
        protected readonly OrcamentoRepository _orcamentoRepository;

        public VendedorRepository(AppDbContext context, OrcamentoRepository orcamentoRepository) : base(context)
        {            
            _orcamentoRepository = orcamentoRepository;
        }
        public Vendedor GetName(string nome) =>
           _context.Set<Vendedor>().First(x => x.Nome == nome);

        public double GetComissao(int id)
        {
            var orcamento = _orcamentoRepository.Get().ToList();
            var query = from Orcamento
                        in orcamento
                        where Orcamento.Vendedor.Id == id
                        select Orcamento.ValorTotal;
            return query.Sum();
        }     
    }
}

