using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrcamentoApi.Models
{
    public class Orcamento
    {
        public Orcamento()
        {
        }        
        public Orcamento(double valor, int quantidadeProduto )
        {
            ValorTotal = valor * quantidadeProduto;
        }
        
        public Orcamento(Vendedor vendedor, Produtos produtos, int quantidadeProduto)
        {
            Vendedor = vendedor;
            Produtos = produtos;
            Quantidade = quantidadeProduto;
            ValorTotal = produtos.Valor * quantidadeProduto;
        }

        [Key]
        public int Id { get; set; }      
        public virtual Vendedor Vendedor { get; set; }            
        public virtual Produtos Produtos { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal { get; set; }
    }
}
