using System.Linq;
using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Infra.SQL.Context;

namespace OrcamentoApi.Infra.SQL.Repository
{
    public class ProdutoRepository : BaseRepository<Produtos>, IProdutoRepository
    {    

        public ProdutoRepository(AppDbContext context) : base(context)
        {            
        }

        public Produtos GetName(string nome) =>
           _context.Set<Produtos>().First(x => x.Nome == nome);
    }    
}

