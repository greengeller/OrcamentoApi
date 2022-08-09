using OrcamentoApi.Domain.Entities;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Delete(int id);
        void Insert(TEntity obj);
        IList<TEntity> Select();
        TEntity Select(int id);
        TEntity SelectName(string nome);
        void Update(TEntity obj);
    }
}