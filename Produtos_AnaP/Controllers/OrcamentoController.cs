using Microsoft.AspNetCore.Mvc;
using OcamentoApi.Models;


namespace OcamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrcamentoController : ControllerBase
    {

        private readonly ILogger<OrcamentoController> _logger;

        public OrcamentoController(ILogger<OrcamentoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetOrcamento()
        {
            var orcamento = new Orcamento(); 
            
            orcamento.Produtos = new Produtos();
            orcamento.Vendedor = new Vendedor();
            var a = orcamento.Produtos.Valor = 50;
            orcamento.Produtos.Nome = "Grampeador";
            orcamento.Produtos.Id = 1;
            orcamento.Vendedor.Id = 1;
            orcamento.Vendedor.Nome = "Ana";
            orcamento.ComissaoVendedor = a * 0.022 ;
            return Ok(orcamento);

        }
    }
}
