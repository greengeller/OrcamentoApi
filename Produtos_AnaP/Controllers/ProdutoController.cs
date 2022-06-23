using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrcamentoApi.Data;
using OrcamentoApi.Models;
using OrcamentoApi.Service;
using System.Linq;
using System.Threading.Tasks;

namespace OrcamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private OrcamentoContext _context;

        public ProdutoController(OrcamentoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduto()
        {
            var produto = _context.Produtos;
            return Ok(produto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.Id == id);
            return Ok(produto);
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
