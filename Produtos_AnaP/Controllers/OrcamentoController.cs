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

        [HttpGet("{id}")]
        //[ProducesResponseType(typeof(Orcamento), StatusCodes.Status200OK)]
        public ActionResult<Orcamento> GetOrcamento([FromRoute] int id)
        {
            //_logger.LogInformation($"API invoked at {DateTime.Now}");
            //var orcamento = id; // ProcessaOrcamentos(tipoDoProduto, quantidade)
            var orcamento = new Orcamento(1, new Vendedor(1), new Produtos());
            
            
            return Ok(orcamento);

        }
    }
}
