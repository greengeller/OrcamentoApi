using OrcamentoApi.Data.Dtos;
using OrcamentoApi.Domain.Entities;
using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Infra.Data.Repository;

namespace OrcamentoApi.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly BaseRepository<TEntity> _baseRepository;    
        
        public BaseService(BaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;           
        }
        public TEntity Add(TEntity obj)
        {
            _baseRepository.Insert(obj);
            return obj;
        }
        public void Delete(int id) => _baseRepository.Delete(id);
        public IList<TEntity> Get() => _baseRepository.Select();
        public TEntity GetById(int id) => _baseRepository.Select(id);
        public TEntity GetByName(string nome) => _baseRepository.SelectName(nome);
        public TEntity Update(TEntity obj)
        {
            _baseRepository.Update(obj);
            return obj;
        }
        public VendedorResponse CalculaComissao(Vendedor vendedor)
        {
            var valor = _baseRepository.GetComissao(vendedor.Id);
           
            VendedorResponse vendedorResponse = new(valor)
            {
                Id = vendedor.Id,
                Nome = vendedor.Nome                
            };
            return vendedorResponse;
        }
    }
}