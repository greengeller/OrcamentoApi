using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Infra.Data.Repository;

namespace OrcamentoApi.Service
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly IOrcamentoRepository _baseRepository;
        public OrcamentoService(IOrcamentoRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public Orcamento AdicionaOrcamento(Produtos produtos, Vendedor vendedor, int quantidadeProduto)
        {
            var orcamento = new Orcamento(vendedor, produtos, quantidadeProduto);
            _baseRepository.Insert(orcamento);
;            return orcamento;
        }
        public IList<Orcamento> GetOrcamento()
        {
            var orcamento = _baseRepository.Select();
            return orcamento;
        }
    }
}
