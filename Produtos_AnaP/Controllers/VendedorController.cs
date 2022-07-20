using Microsoft.AspNetCore.Mvc;
using OrcamentoApi.Data;
using OrcamentoApi.Models;
using OrcamentoApi.Service;

namespace OrcamentoApi.Controllers63
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly OrcamentoContext _context;

        public VendedorController(OrcamentoContext context, OrcamentoService orcamentoService)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetVendedor()
        {
            var vendedor = _context.Vendedor;
            return Ok(vendedor);
        }

        [HttpGet("{id}")]
        public IActionResult GetVendedor(int id)
        {
            var vendedor = _context.Vendedor.FirstOrDefault(x => x.Id == id);

            if (vendedor != null)
            {
                var orcamento = _context.Orcamento;
                var query = from Orcamento
                            in orcamento
                            where Orcamento.Vendedor.Id == id
                            select Orcamento.ValorTotal;
                var somaValorTotal = query.Sum();
                VendedorResponse vendedorResponse = new(somaValorTotal)
                {
                    Id = id,
                    Nome = vendedor.Nome
                };

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

        [HttpPut]
        public IActionResult AtualizarVendedor(int id, [FromBody] string nome)
        {
            var vendedor = _context.Vendedor.FirstOrDefault(x => x.Id == id);

            if (id != null && vendedor != null)
            {
                vendedor.Nome = nome;

                _context.Vendedor.Update(vendedor);
                _context.SaveChanges();
                return Ok(vendedor);
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult ExcluirVendedor(int id)
        {
            var vendedor = _context.Vendedor.FirstOrDefault(x => x.Id == id);
            _context.Vendedor.Remove(vendedor);
            _context.SaveChanges();
            return Ok();
        }

    }
}
