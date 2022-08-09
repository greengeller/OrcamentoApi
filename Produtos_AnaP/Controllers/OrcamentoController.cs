using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrcamentoApi.Data.Dtos;
using OrcamentoApi.Domain.Models;
using OrcamentoApi.Infra.Data.Context;
using OrcamentoApi.Service;

namespace OrcamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrcamentoController : ControllerBase
    {
        private readonly ILogger<OrcamentoController> _logger;
        private readonly OrcamentoService _orcamentoService;
        private readonly OrcamentoContext _context;
        private readonly IUrlHelper _urlHelper;
        private readonly BaseService<Produtos> _produtosService;
        private readonly BaseService<Vendedor> _vendedorService;
        public OrcamentoController(ILogger<OrcamentoController> logger, OrcamentoService orcamentoService, OrcamentoContext context, IUrlHelper urlHelper, BaseService<Vendedor> vendedorService, BaseService<Produtos> produtosService)
        {
            _logger = logger;
            _orcamentoService = orcamentoService;
            _context = context;
            _urlHelper = urlHelper;
            _vendedorService = vendedorService;
            _produtosService = produtosService;
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

            var produtos = _produtosService.GetByName(orcamentoDto.NomeProduto);
            var quantidadeProduto = orcamentoDto.Quantidade;
            var random = new Random();
            var vendedores = _vendedorService.Get();

            if (produtos != null)
            {
                var orcamento = _orcamentoService.AdicionaOrcamento(produtos, vendedores[random.Next(vendedores.Count - 1)], quantidadeProduto);
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
            var orcamentos = _orcamentoService.GetOrcamento().ToList();           

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
            _orcamentoService.AtualizaOrcamento(id, orcDto);
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
            _orcamentoService.AtualizaQuantidade(id, orcDto);            
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
            _orcamentoService.ExcluiOrcamento(id);
            return Ok("Orçamento Excluído com Sucesso");
        }
    }
}
