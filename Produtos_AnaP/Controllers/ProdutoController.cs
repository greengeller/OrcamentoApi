using Microsoft.AspNetCore.Mvc;
using OrcamentoApi.Data;
using OrcamentoApi.Models;

namespace OrcamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly OrcamentoContext _context;
        public ProdutoController(OrcamentoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllProduto()
        {
            var produto = _context.Produtos;
            return Ok(produto);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.Id == id);
            if (produto != null)
            {
                return Ok(produto);
            }

            return NotFound("Esse Produto não existe");
        }

        [HttpPost]
        public IActionResult AdicionaProduto([FromBody] Produtos produtos)
        {
            _context.Add(produtos);
            _context.SaveChanges();
            if (produtos != null)
            {
                return Ok(produtos);
            }
            return NotFound();
        }
    }
}
