namespace OrcamentoApi.Models
{
    public class Orcamento
    {

        public Orcamento()
        {
        }

        public Orcamento(Vendedor vendedor, Produtos produtos, int quantidadeProduto)
        {
            Vendedor = vendedor;
            Produtos = produtos;
            Quantidade = quantidadeProduto;
            ValorTotal = Quantidade * Produtos.Valor;
        }

        public int Id { get; set; }
        public Vendedor Vendedor { get; set; }
        public Produtos Produtos { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal { get; set; }
        public int VendedorId { get; set; }
        public int ProdutoId { get; set; }
    }
}
