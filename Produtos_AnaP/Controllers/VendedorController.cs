using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Service;

namespace OrcamentoApi.Controllers63
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorService _baseService;
       
        public VendedorController(IVendedorService baseService)
        {
            _baseService = baseService;            
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetVendedor()
        {
            var vendedor = _baseService.Get();
            if(vendedor == null)
            {
                return NotFound("Lista de Vendedor Vazia");
            }              
            return Ok(vendedor);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetComissaoVendedor(int id)
        {
            var vendedor = _baseService.GetId(id);
            if (vendedor != null)
            {
                var vendedorResponse = _baseService.GetComissao(vendedor);
                return Ok(vendedorResponse);
            }
            return NotFound("Vendedor Não Existe");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AdicionaVendedor([FromBody] Vendedor vendedor)
        {
            if (vendedor != null)
            {
                _baseService.Add(vendedor);
                return Ok($"Vendedor {vendedor} foi adicionado com sucesso"); ;
            }
            return NotFound();
        }

        [HttpPut]
        [AllowAnonymous]
        public IActionResult AtualizarVendedor(int id, [FromBody] string nome)
        {
            var vendedor = _baseService.GetId(id);

            if (vendedor != null)
            {
                vendedor.Nome = nome;

                _baseService.Update(id, vendedor);
                return Ok($"Vendedor {vendedor} foi atualizado com sucesso");
            }
            return NotFound();
        }

        [HttpDelete]
        [AllowAnonymous]
        public IActionResult ExcluirVendedor(int id)
        {
            var vendedor = _baseService.GetId(id);
            if (vendedor == null)
            {
                return NotFound("Vendedor Não Existe");
            }
            _baseService.Delete(id);
            return Ok($"Vendedor {vendedor} foi excluído com sucesso");
        }
    }
}
