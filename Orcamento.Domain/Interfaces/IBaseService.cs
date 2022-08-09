using OrcamentoApi.Domain.Entities;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity obj);
        void Delete(int id);
        IList<TEntity> Get();
        TEntity GetById(int id);
        TEntity Update(TEntity obj);
    }
}