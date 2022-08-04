using Microsoft.AspNetCore.Mvc;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Infra.Data.Context;

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

        [HttpPut]
        public IActionResult AtualizarProduto(int id, [FromBody] Produtos novoProduto)
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.Id == id);

            if (id != null)
            {               
                produto.Nome = novoProduto.Nome;
                produto.Valor = novoProduto.Valor;

                _context.Produtos.Update(produto);
                _context.SaveChanges();
                return Ok(produto);
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult ExcluirProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.Id == id);
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok();
        }
    }
}
