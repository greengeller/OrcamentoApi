using OrcamentoApi.Domain.Entities;

namespace OrcamentoApi.Domain.Models
{
    public class Produtos : BaseEntity
    {
        public Produtos()
        {          
        }
        public Produtos(int id, string nome, double valor)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
        }       
        public double Valor { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return " Id " + Id + " Nome " + Nome;
        }
    }
}

