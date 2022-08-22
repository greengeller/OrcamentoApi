using OrcamentoApi.Domain.Entities;
using OrcamentoApi.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OrcamentoApi.Domain.Models
{
    public class Orcamento : BaseEntity
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

        public virtual Vendedor Vendedor { get; set; }            
        public virtual Produtos Produtos { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal { get; set; }
    }
}
