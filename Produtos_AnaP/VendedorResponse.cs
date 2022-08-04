using OrcamentoApi.Domain.Models;

namespace OrcamentoApi
{
    public class VendedorResponse
    {
        private readonly Orcamento orcamento;
        public VendedorResponse()
        {
        }
           
        public int Id { get; set; }
        public string? Nome { get; set; }
        public double Comissao => CalculaComissão();
        
        public double CalculaComissão()
        {
           var comissao = orcamento.ValorTotal * 0.2;
           return comissao;
        }

}
}
