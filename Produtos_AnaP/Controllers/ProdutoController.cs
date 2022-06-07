using Microsoft.AspNetCore.Mvc;
using OcamentoApi.Models;
using OcamentoApi.Service;

namespace OcamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoController(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public Produtos[] Get()
        {
            return _produtoRepository.GetAllProdutos();
        }

    }
}
