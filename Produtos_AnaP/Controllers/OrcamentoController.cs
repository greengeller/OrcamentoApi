using Microsoft.AspNetCore.Mvc;
using OcamentoApi.Models;
using OcamentoApi.Service;

namespace OcamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrcamentoController : ControllerBase
    {

        private readonly ILogger<OrcamentoController> _logger;
        private OrcamentoService _orcamentoService;
        private ProdutoRepository _produtoRepository;
        private VendedorRepository _vendedorRepository;

        public OrcamentoController(ILogger<OrcamentoController> logger, OrcamentoService orcamentoService, ProdutoRepository produtoRepository, VendedorRepository vendedorRepository)
        {
            _logger = logger;
            _orcamentoService = orcamentoService;
            _produtoRepository = produtoRepository;
            _vendedorRepository = vendedorRepository;
        }

               
        [HttpGet] 
        public async Task<ActionResult<Orcamento>> GetOrcamento([FromQuery] OrcamentoRequest orcamentoRequest)
        {
            var produtos = _produtoRepository.GetAllProdutos().FirstOrDefault(x => x.Nome == orcamentoRequest.NomeProduto);
            var vendedores = _vendedorRepository.GetAllVendedor();
            var quantidadeProduto = orcamentoRequest.Quantidade;
            var Id = new Random().Next();
            var random = new Random();
            if (produtos != null)
            {
                var orcamento = _orcamentoService.AdicionaOrcamento(Id, produtos, vendedores.ElementAt(random.Next(vendedores.Count())), quantidadeProduto);
                if (orcamento != null)
                {
                    return Ok(orcamento);
                }
            }
            
            return NotFound();
        }
    } 
   
}

