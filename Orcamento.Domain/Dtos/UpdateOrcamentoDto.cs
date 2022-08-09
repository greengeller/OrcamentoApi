using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Data.Dtos
{
    public class UpdateOrcamentoDto
    {
        public virtual Vendedor? Vendedor { get; set; }
        public virtual Produtos? Produtos { get; set; }
        public int Quantidade { get; set; }
    }
}
