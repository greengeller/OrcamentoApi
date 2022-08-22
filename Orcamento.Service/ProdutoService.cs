using OrcamentoApi.Domain.Models;
using OrcamentoApi.Domain.Interfaces;

namespace OrcamentoApi.Service
{
    public class ProdutoService : BaseService<Produtos>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;        

        public ProdutoService(IProdutoRepository produtoRepository) : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;            
        }
        
        public Produtos GetName(string nome) => _produtoRepository.GetName(nome);
    }   
}
