using OrcamentoApi.Data.Dtos;
using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Infra.Data.Repository;

namespace OrcamentoApi.Service
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly IOrcamentoRepository _baseRepository;
        private readonly OrcamentoRepository _orcamentoRepository;
        private readonly BaseRepository<Produtos> _produtosRepository;
        private readonly BaseRepository<Vendedor> _vendedorRepository;
       
        public OrcamentoService(OrcamentoRepository orcamentoRepository, BaseRepository<Produtos> produtosRepository, BaseRepository<Vendedor> vendedorRepository, IOrcamentoRepository baseRepository)
        {
            _orcamentoRepository = orcamentoRepository;
            _produtosRepository = produtosRepository;
            _vendedorRepository = vendedorRepository;
            _baseRepository = baseRepository;
        }
        public Orcamento AdicionaOrcamento(Produtos produtos, Vendedor vendedor, int quantidadeProduto)
        {
            var orcamento = new Orcamento(vendedor, produtos, quantidadeProduto);
            _orcamentoRepository.Insert(orcamento);
;            return orcamento;
        }
        public List<Orcamento> GetOrcamento()
        {
            return _orcamentoRepository.Select().ToList();            
        }
        public Orcamento GetId(int id)
        {
            return _orcamentoRepository.SelectId(id);
        }
        public Orcamento AtualizaOrcamento(int id, UpdateOrcamentoDto orcDto)
        {
            var orcamento = _orcamentoRepository.SelectId(id);
            var produto = _produtosRepository.SelectName(orcDto.Produtos.Nome);            
            var vendedor = _vendedorRepository.SelectName(orcDto.Vendedor.Nome);
            orcamento.Produtos = produto;
            orcamento.Vendedor = vendedor;
            var valorTotal = orcDto.Quantidade * produto.Valor;
            orcamento.Quantidade = orcDto.Quantidade;
            orcamento.ValorTotal = valorTotal;           
                      
            _orcamentoRepository.Update(id, orcamento);
            return orcamento;
        }
        public Orcamento AtualizaQuantidade(int id, UpdateQuantidadeDto orcDto)
        {
            var orcamento = _orcamentoRepository.SelectId(id);
            
            if (orcamento.Quantidade != orcDto.Quantidade)
            {
                orcamento.Quantidade = orcDto.Quantidade;
                var valorTotal = orcDto.Quantidade * orcamento.Produtos.Valor;
                orcamento.ValorTotal = valorTotal;

                _orcamentoRepository.Update(id, orcamento);
                return orcamento;
            }
            return orcamento;    
        }
        public Orcamento ExcluiOrcamento(int id)
        {
            var orcamento =_orcamentoRepository.SelectId(id);
          
            _baseRepository.Delete(id);
            return orcamento;
        }
    }
}
