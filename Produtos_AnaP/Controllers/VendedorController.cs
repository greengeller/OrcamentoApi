using Microsoft.AspNetCore.Mvc;
using OrcamentoApi.Data;
using OrcamentoApi.Models;
using OrcamentoApi.Service;

namespace OrcamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly OrcamentoContext _context;
        private readonly OrcamentoService _orcamentoService;


        public VendedorController(OrcamentoContext context, OrcamentoService orcamentoService)
        {
            _context = context;
            _orcamentoService = orcamentoService;

        }
        [HttpGet]
        public async Task<IActionResult> GetVendedor()
        {
            var vendedor = _context.Vendedor;
            return Ok(vendedor);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendedor(int id)
        {
            var vendedor = _context.Vendedor.FirstOrDefault(x => x.Id == id);

            if (vendedor != null)
            {
                var orcamento = _context.Orcamento;
                var query = from Orcamento in orcamento where Orcamento.VendedorId == id select Orcamento.ValorTotal;
                var somaValorTotal = query.Sum();
                VendedorResponse vendedorResponse = new VendedorResponse(somaValorTotal);
                vendedorResponse.Id = id;
                vendedorResponse.Nome = vendedor.Nome;

                return Ok(vendedorResponse);
                
            }
           
                return NotFound("Esse vendedor não existe");

        }

        [HttpPost]
        public IActionResult AdicionaVendedor([FromBody] Vendedor vendedor)
        {
            if (vendedor != null)
            {
                _context.Add(vendedor);
                _context.SaveChanges();
                return Ok(vendedor);
            }
            return NotFound();
        }
    }
}