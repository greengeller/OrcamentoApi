using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrcamentoApi.Data;
using OrcamentoApi.Models;
using OrcamentoApi.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OrcamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrcamentoController : ControllerBase
    {

        private readonly ILogger<OrcamentoController> _logger;
        private OrcamentoService _orcamentoService;
        private OrcamentoContext _context;
       

        public OrcamentoController(ILogger<OrcamentoController> logger, OrcamentoService orcamentoService, OrcamentoContext context)
        {
            _logger = logger;
            _orcamentoService = orcamentoService;
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<Orcamento>> GetOrcamento([FromQuery] OrcamentoRequest orcamentoRequest)
        {
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
                    return Ok(orcamento);
                }
            }

            return NotFound();
        }

    }
}

           