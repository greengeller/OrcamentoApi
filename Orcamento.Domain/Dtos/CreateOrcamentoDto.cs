using OrcamentoApi.Domain.Entities;

namespace OrcamentoApi.Data.Dtos
{
    public class CreateOrcamentoDto 
    {
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
       
    }
}
