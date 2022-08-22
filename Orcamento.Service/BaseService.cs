using OrcamentoApi.Domain.Entities;
using OrcamentoApi.Domain.Interfaces;

namespace OrcamentoApi.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public TEntity Add(TEntity obj)
        {
            _baseRepository.Insert(obj);
            return obj;
        }

        public void Delete(int id) => _baseRepository.Delete(id);

        public IList<TEntity> Get() => _baseRepository.Get().ToList();

        public TEntity GetId(int id) => _baseRepository.GetId(id);

        public TEntity Update(int id, TEntity obj)
        {
            _baseRepository.Update(id, obj);
            return obj;
        }
    }
}