using OrcamentoApi.Domain.Dtos;
using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Service;

namespace OrcamentoApi.Service
{
    public class OrcamentoService : BaseService<Orcamento>, IOrcamentoService
    {
        private readonly IOrcamentoRepository _orcamentoRepository;       
        private readonly IProdutoRepository _produtosRepository;
        private readonly IVendedorRepository _vendedorRepository;
        
        public OrcamentoService(IOrcamentoRepository orcamentoRepository, IProdutoRepository produtosRepository, IVendedorRepository vendedorRepository) : base(orcamentoRepository)
        {
            _orcamentoRepository = orcamentoRepository;
            _produtosRepository = produtosRepository;
            _vendedorRepository = vendedorRepository;
            
        }
        public Orcamento Add(Vendedor vendedor, Produtos produtos, int quantidade)
        {
            var orcamento = new Orcamento(vendedor, produtos, quantidade );
            _orcamentoRepository.Insert(orcamento);
;            return orcamento;
        }
        
        public Orcamento Update(int id, UpdateOrcamentoDto orcDto)
        {
            var orcamento = _orcamentoRepository.GetId(id);
            var produto = _produtosRepository.GetName(orcDto.Produtos.Nome);            
            var vendedor = _vendedorRepository.GetName(orcDto.Vendedor.Nome);
            orcamento.Produtos = produto;
            orcamento.Vendedor = vendedor;
            var valorTotal = orcDto.Quantidade * produto.Valor;
            orcamento.Quantidade = orcDto.Quantidade;
            orcamento.ValorTotal = valorTotal;           
                      
            _orcamentoRepository.Update(id, orcamento);
            return orcamento;
        }
        public Orcamento Updatequantidade(int id, UpdateQuantidadeDto orcDto)
        {
            var orcamento = _orcamentoRepository.GetId(id);
            
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
        public IList<Orcamento> Get() => _orcamentoRepository.Get();
        public Orcamento GetId(int id) => _orcamentoRepository.GetId(id);
    }
}
