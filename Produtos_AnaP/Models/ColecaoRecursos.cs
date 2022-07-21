namespace OrcamentoApi.Models
{
    public class ColecaoRecursos<T> : Recurso
    {
        public List<T> Valores { get; set; }
        public ColecaoRecursos(List<T> valores)
        {
            Valores = valores;
        }
    }
}
