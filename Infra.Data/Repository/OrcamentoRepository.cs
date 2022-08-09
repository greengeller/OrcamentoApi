using Microsoft.EntityFrameworkCore;
using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Infra.Data.Context;

namespace OrcamentoApi.Infra.Data.Repository
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        protected readonly OrcamentoContext _context;        
        public OrcamentoRepository(OrcamentoContext context)
        {
            _context = context;
        }
        public void Insert(Orcamento orc)
        {
            _context.Set<Orcamento>().Add(orc);
            _context.SaveChanges();
        }
        public void Update(int id, Orcamento orc)
        {                       
            _context.Entry(orc).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Set<Orcamento>().Remove(SelectId(id));
            _context.SaveChanges();
        }
        public List<Orcamento> Select() =>
                _context.Orcamento
                .Include(o => o.Produtos)
                .Include(o => o.Vendedor).ToList();
        public Orcamento SelectId(int id) =>
                _context.Orcamento
                .Include(o => o.Produtos)
                .Include(o => o.Vendedor).First(x => x.Id == id);
    }   
}

