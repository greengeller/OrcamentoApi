namespace OcamentoApi.Models
{
    public class Orcamento
    {
        
        
        public int Id { get; set; }
       
        public Vendedor Vendedor { get; set; }
       
        public Produtos Produtos { get; set; }
       
        public double ComissaoVendedor { get; set; }

    
        public double CalculaComissaoVendedor(double valor)
        {
           var a = valor * 0.02;
           return a;
        }
    }

    

  
}
