namespace OcamentoApi
{
    public class OrcamentoRequest
    {
        public OrcamentoRequest()
        {

        }
        public OrcamentoRequest(string nomeProduto, int quantidade)
        {
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
        }

        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
