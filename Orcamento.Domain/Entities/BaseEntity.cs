using OrcamentoApi.Domain.Interfaces;

namespace OrcamentoApi.Domain.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
    }
}
