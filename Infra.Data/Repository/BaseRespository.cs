using Microsoft.EntityFrameworkCore;
using OrcamentoApi.Data.Dtos;
using OrcamentoApi.Domain.Entities;
using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Infra.Data.Context;

namespace OrcamentoApi.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly OrcamentoContext _context;
        private readonly OrcamentoRepository _orcamentoRepository;

        public BaseRepository(OrcamentoContext context, OrcamentoRepository orcamentoRepository)
        {
            _context = context;
            _orcamentoRepository = orcamentoRepository;
        }
        public void Insert(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }
        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Set<TEntity>().Remove(Select(id));
            _context.SaveChanges();
        }
        public IList<TEntity> Select() =>
            _context.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _context.Set<TEntity>().First(x => x.Id == id);

        public TEntity SelectName(string nome) =>
           _context.Set<TEntity>().First(x => x.Nome == nome);

        public double GetComissao(int id)
        {
            var orcamento = _orcamentoRepository.Select().ToList();
            var query = from Orcamento
                        in orcamento
                        where Orcamento.Vendedor.Id == id
                        select Orcamento.ValorTotal;
                        return query.Sum();   
        }
    }
}

