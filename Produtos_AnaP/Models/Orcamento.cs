namespace OcamentoApi.Models
{
    public class Orcamento
    {
             
        public Orcamento()
        {
        }

        public Orcamento(int id, Vendedor vendedor, Produtos produtos, int quantidadeProduto)
        {
            Id = id;
            Vendedor = vendedor;
            Produtos = produtos;
            Quantidade = quantidadeProduto;
            ComissaoVendedor = produtos.Valor * 0.20;
            ValorTotal = Quantidade * Produtos.Valor;
          

         }

        public int Id { get; set; }

        public Vendedor Vendedor { get; set; }

        public Produtos Produtos { get; set; }

        public int Quantidade { get; set; }

        private double ComissaoVendedor { get; set; }

        public double ValorTotal { get; set; }
    }
}
