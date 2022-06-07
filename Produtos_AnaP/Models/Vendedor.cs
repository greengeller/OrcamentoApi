namespace OcamentoApi.Models
{
    public class Vendedor
    {
        public Vendedor(int id)
        {
            Id = id;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
