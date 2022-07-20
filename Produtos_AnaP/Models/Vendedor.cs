using System.ComponentModel.DataAnnotations;

namespace OrcamentoApi.Models
{
    public class Vendedor
    {
        public Vendedor()
        {            
        }
        
        public Vendedor(int id, string nome)
        {
            Id = id;
            Nome = nome;           
        }

        [Key]
        public int Id { get; set; }       
        public string Nome { get; set; }     
    }
}
