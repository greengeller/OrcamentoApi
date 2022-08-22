using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Infra.SQL.Context;

namespace OrcamentoApi.Infra.SQL.Repository
{
    public class OrcamentoRepository : BaseRepository<Orcamento>, IOrcamentoRepository
    {     

        public OrcamentoRepository(AppDbContext context) : base(context)
        {            
        }

        public IList<Orcamento> Get() =>
                _context.Orcamentos
                .Include(o => o.Produtos)
                .Include(o => o.Vendedor).ToList();
        public Orcamento GetId(int id) =>
                _context.Orcamentos
                .Include(o => o.Produtos)
                .Include(o => o.Vendedor).First(x => x.Id == id);
    }
}

