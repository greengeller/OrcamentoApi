using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrcamentoApi.Domain.Entities;
using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Infra.SQL.Context;

namespace OrcamentoApi.Infra.SQL.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;        

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Insert(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }
        public void Update(int id, TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Set<TEntity>().Remove(GetId(id));
            _context.SaveChanges();
        }
        public IList<TEntity> Get() =>
            _context.Set<TEntity>().ToList();

        public TEntity GetId(int id) =>
            _context.Set<TEntity>().First(x => x.Id == id);
    }
}
