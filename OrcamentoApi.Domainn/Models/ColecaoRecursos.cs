namespace OrcamentoApi.Domain.Models
{
    //HATEOAS
    public class ColecaoRecursos<T> : Recurso where T : Recurso
    {
        public List<T> Valores { get; set; }
        public ColecaoRecursos(List<T> valores)
        {
            Valores = valores;
        }
    }
}
