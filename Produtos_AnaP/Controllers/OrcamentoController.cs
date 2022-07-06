using Microsoft.AspNetCore.Mvc;
using OrcamentoApi.Data;
using OrcamentoApi.Models;
using OrcamentoApi.Request;
using OrcamentoApi.Service;

namespace OrcamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrcamentoController : ControllerBase
    {
        private readonly ILogger<OrcamentoController> _logger;
        private readonly OrcamentoService _orcamentoService;
        private readonly OrcamentoContext _context;

        public OrcamentoController(ILogger<OrcamentoController> logger, OrcamentoService orcamentoService, OrcamentoContext context)
        {
            _logger = logger;
            _orcamentoService = orcamentoService;
            _context = context;
        }

        [HttpPost]
        public ActionResult<Orcamento> GetOrcamento([FromBody] OrcamentoRequest orcamentoRequest)
        {
            _logger.LogInformation("Start inserting Orcamentos");

            var produtos = _context.Produtos.FirstOrDefault(x => x.Nome == orcamentoRequest.NomeProduto);
            var quantidadeProduto = orcamentoRequest.Quantidade;
            var random = new Random();
            var vendedores = _context.Vendedor.ToList();

            if (produtos != null)
            {
                var orcamento = _orcamentoService.AdicionaOrcamento(produtos, vendedores[random.Next(vendedores.Count - 1)], quantidadeProduto);
                if (orcamento != null)
                {
                    _context.Add(orcamento);
                    _context.SaveChanges();
                    _logger.LogInformation("Success inserting Orcamentos");

                    return Ok(orcamento);
                }
            }
            return NotFound();
        }

        [HttpGet("GetAll")]
        public List<Orcamento> GetAllOrcamentos()
        {
            return _context.Orcamento.ToList();
        }
    }
}

           