using OrcamentoApi.Models;

namespace OrcamentoApi.Data.Dtos
{
    public class CreateOrcamentoDto
    {
        public int Id { get; set; }
        public virtual Produtos NomeProduto { get; set; }
        public int Quantidade { get; set; }
       
    }
}
