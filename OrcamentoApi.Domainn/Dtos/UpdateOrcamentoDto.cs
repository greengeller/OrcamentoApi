using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Domain.Dtos
{
    public class UpdateOrcamentoDto
    {
        public virtual Vendedor? Vendedor { get; set; }
        public virtual Produtos? Produtos { get; set; }
        public int Quantidade { get; set; }
    }
}
