namespace OrcamentoApi.Models
{
    //HATEOAS
    public class Recurso
    {
        public List<LinkDTO> Links { get; set; } = new List<LinkDTO>();
    }
}
