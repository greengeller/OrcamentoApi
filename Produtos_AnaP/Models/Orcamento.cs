namespace OcamentoApi.Models
{
    public class Orcamento
    {
       

        public Orcamento(int id, Vendedor vendedor, Produtos produtos)
        {
            Id = id;
            Vendedor = vendedor;
            Produtos = produtos;
            ComissaoVendedor = produtos.Valor * 0.20;
        }

        public int Id { get; set; }
       
        public Vendedor Vendedor { get; set; }
       
        public Produtos Produtos { get; set; }
       
        public double ComissaoVendedor { get; set; }

    
        
    }

    

  
}
