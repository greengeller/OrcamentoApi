using OrcamentoApi.Models;

namespace OrcamentoApi.Data.Dtos
{
    public class ReadOrcamentoDto
    {
        public int Id { get; set; }
        public int VendedorId { get; set; }
        public virtual Vendedor NomeVendedor { get; set; }
        public virtual Produtos NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal { get; set; }
    }
}
