using OrcamentoApi.Domain.Entities;
using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> 
    {
        void Insert(TEntity obj);
        void Update(int id,TEntity obj);
        void Delete(int id);             
        IList<TEntity> Get();
        TEntity GetId(int id);             
    }
}