using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrcamentoApi.Domain.Dtos;
using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Service;

namespace OrcamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrcamentoController : ControllerBase
    {
        private readonly ILogger<OrcamentoController> _logger;
        private readonly IOrcamentoService _orcamentoService;        
        private readonly IUrlHelper _urlHelper;
        private readonly IProdutoService _produtosService;
        private readonly IVendedorService _vendedorService;

        public OrcamentoController(ILogger<OrcamentoController> logger, IOrcamentoService orcamentoService, IUrlHelper urlHelper, IProdutoService produtosService, IVendedorService vendedorService)
        {
            _logger = logger;
            _orcamentoService = orcamentoService;
            _urlHelper = urlHelper;
            _produtosService = produtosService;
            _vendedorService = vendedorService;
        }

        //HATEOAS
        private void GerarLinks(Orcamento orcamento)
        {
            orcamento.Links.Add(new LinkDTO(_urlHelper.Link(nameof(GetOrcamentos), new { id = orcamento.Id }), rel: "self", metodo: "GET"));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CriarOrcamento([FromBody] CreateOrcamentoDto orcamentoDto)
        {
            _logger.LogInformation("Start inserting Orçamentos");

            var produtos = _produtosService.GetName(orcamentoDto.NomeProduto);
            var quantidadeProduto = orcamentoDto.Quantidade;
            var random = new Random();
            var vendedores = _vendedorService.Get();

            if (produtos != null)
            {
                var orcamento = _orcamentoService.Add(vendedores[random.Next(vendedores.Count - 1)], produtos, quantidadeProduto);
                if (orcamento != null)
                {
                    _logger.LogInformation("Success inserting Orçamentos");
                    return Ok(orcamento);
                }
            }
            return NotFound();
        }

        [HttpGet(Name = nameof(GetOrcamentos))] //HATEOAS
        [AllowAnonymous]
        public ActionResult<ColecaoRecursos<Orcamento>>GetOrcamentos()
        {
            var orcamentos = _orcamentoService.Get().ToList();           

            orcamentos.ForEach(o => GerarLinks(o));

            var resultado = new ColecaoRecursos<Orcamento>(orcamentos);
            resultado.Links.Add(new LinkDTO(_urlHelper.Link(nameof(GetOrcamentos), new { }), rel: "self", metodo: "GET"));

            return resultado;
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public ActionResult AtualizarOrcamento(int id, [FromBody] UpdateOrcamentoDto orcDto)
        {
            var orcamento = _orcamentoService.GetId(id);
            if (orcamento == null)
            {
                return NotFound();
            }
            _orcamentoService.Update(id, orcamento);
            return Ok(orcamento);
        }

        [HttpPatch]
        [AllowAnonymous]
        public ActionResult AtualizarQuantidade(int id, [FromBody] UpdateQuantidadeDto orcDto)
        {
            var orcamento = _orcamentoService.GetId(id);
            if (orcamento == null)
            {
                return NotFound();
            }
            _orcamentoService.Update(id, orcamento);            
            return Ok(orcamento);
        }

        [HttpDelete]
        [AllowAnonymous]
        public ActionResult ExcluiOrcamento(int id)
        {
            var orcamento = _orcamentoService.GetId(id);
            if(orcamento == null)
            {
                return NotFound();           
            }
            _orcamentoService.Delete(id);
            return Ok("Orçamento Excluído com Sucesso");
        }
    }
}
