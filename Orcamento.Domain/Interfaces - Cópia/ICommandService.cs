using OrcamentoApi.Data.Dtos;
using OrcamentoApi.Domain.Entities;
using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Domain.Interfaces
{
    public interface ICommandService<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity obj);
        TEntity Update(int id, TEntity obj);
        void Delete(int id);
        IList<TEntity> Get();
        TEntity GetId(int id);            
    }
}