using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Domain.Entities
{
    public abstract class BaseEntity : Recurso
    {
        public virtual int Id { get; set; }
    }
}
