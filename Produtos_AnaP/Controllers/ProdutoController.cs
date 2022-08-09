using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Service;

namespace OrcamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly BaseService<Produtos> _baseService;
        public ProdutoController(BaseService<Produtos> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllProduto()
        {
            var produto = _baseService.Get();
            if(produto == null)
            {
                return NotFound("Lista Vazia de Produtos");
            }
            return Ok(produto);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetProduto(int id)
        {
            var produto = _baseService.GetById(id);
            if (produto == null)
            {
                return NotFound("Produto Não Existe");                
            }
            return Ok(produto);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AdicionaProduto([FromBody] Produtos produtos)
        {
            _baseService.Add(produtos);
            if (produtos == null)
            {
                return NotFound("Produto Não Existe");                
            }
            return Ok($"Produto {produtos} foi adicionado com sucesso");
        }

        [HttpPut]
        [AllowAnonymous]
        public IActionResult AtualizarProduto(int id, [FromBody] Produtos novoProduto)
        {
            var produto = _baseService.GetById(id);
            if (produto == null)
            {
                return NotFound("Produto Não Existe");
            }

            produto.Nome = novoProduto.Nome;
            produto.Valor = novoProduto.Valor;

            _baseService.Update(produto);
            return Ok($"Produto {novoProduto} foi atualizado com sucesso");
        }

        [HttpDelete]
        [AllowAnonymous]
        public IActionResult ExcluirProduto(int id)
        {
            var produto = _baseService.GetById(id);

            if(produto == null)
            {
                return NotFound("Produto Não Existe");
            }
            _baseService.Delete(id);
            return Ok($"Produto {produto} foi excluído com sucesso");
        }
    }
}
