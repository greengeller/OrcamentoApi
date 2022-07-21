using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrcamentoApi.Data;
using OrcamentoApi.Data.Dtos;
using OrcamentoApi.Models;
using OrcamentoApi.Request;
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

        public OrcamentoController(ILogger<OrcamentoController> logger, OrcamentoService orcamentoService, OrcamentoContext context, IUrlHelper urlHelper)
        {
            _logger = logger;
            _orcamentoService = orcamentoService;
            _context = context;
            _urlHelper = urlHelper;
        }
        private void GerarLinks(Orcamento orcamento)
        {
            orcamento.Links.Add(new LinkDTO(_urlHelper.Link(nameof(GetOrcamentos), new { id = orcamento.Id }), rel: "self", metodo: "GET"));           
        }

        [HttpPost]
        public ActionResult<Orcamento> CriarOrcamento([FromBody] OrcamentoRequest orcamentoRequest)
        {
            _logger.LogInformation("Start inserting Orcamentos");

            var produtos = _context.Produtos.FirstOrDefault(x => x.Nome == orcamentoRequest.NomeProduto);
            var quantidadeProduto = orcamentoRequest.Quantidade;
            var random = new Random();
            var vendedores = _context.Vendedor.ToList();

            if (produtos != null)
            {
                var orcamento = _orcamentoService.AdicionaOrcamento(produtos, vendedores[random.Next(vendedores.Count - 1)], quantidadeProduto);
                if (orcamento != null)
                {
                    _context.Add(orcamento);
                    _context.SaveChanges();
                    _logger.LogInformation("Success inserting Orcamentos");

                    return Ok(orcamento);
                }
            }
            return NotFound();
        }

        [HttpGet(Name = nameof(GetOrcamentos))]
        public async Task<ActionResult<ColecaoRecursos<Orcamento>>> GetOrcamentos()
        {
            var orcamentos = await _context.Orcamento
                .Include(o => o.Produtos)
                .Include(o => o.Vendedor).ToListAsync();
            orcamentos.ForEach(o => GerarLinks(o));

            var resultado = new ColecaoRecursos<Orcamento>(orcamentos);
            resultado.Links.Add(new LinkDTO(_urlHelper.Link(nameof(GetOrcamentos), new { }), rel: "self", metodo: "GET"));
            
            return resultado;
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarOrcamento(int id, [FromBody] UpdateOrcamentoDto updateOrcamentoDto)
        {
            var orcamento = _context.Orcamento
                .Include(o => o.Produtos)
                .FirstOrDefault(x => x.Id == id);

            var produto = _context.Produtos.FirstOrDefault(x => x.Nome == updateOrcamentoDto.Produtos.Nome);
            var vendedor = _context.Vendedor.FirstOrDefault(x => x.Nome == updateOrcamentoDto.Vendedor.Nome);

            if (orcamento != null && orcamento.Produtos != null)
            {
                var valorTotal = updateOrcamentoDto.Quantidade * produto.Valor;
                orcamento.ValorTotal = valorTotal;

                orcamento.Quantidade = updateOrcamentoDto.Quantidade;
                orcamento.Produtos = produto;
                orcamento.Vendedor = vendedor;

                _context.Orcamento.Update(orcamento);
                _context.SaveChanges();

                return Ok(orcamento);
            }            
            return BadRequest();
        }

        [HttpPatch]
        public ActionResult AtualizarDadosOrcamento(int id, [FromBody] UpdateQuantidadeDto updateQuantidadeDto)
        {
            var orcamento = _context.Orcamento
                .Include(o => o.Produtos)
                .Include(o => o.Vendedor)
                .FirstOrDefault(x => x.Id == id);

            if(orcamento.Quantidade != updateQuantidadeDto.Quantidade)
            {
                orcamento.Quantidade = updateQuantidadeDto.Quantidade;
                var valorTotal = updateQuantidadeDto.Quantidade * orcamento.Produtos.Valor;
                orcamento.ValorTotal = valorTotal;
               
                _context.Orcamento.Update(orcamento);              
            }
            
            _context.SaveChanges();
            return Ok(orcamento);
        }

         [HttpDelete]
        public ActionResult ExcluiOrcamento(int id)
        {
            var orcamento = _context.Orcamento.FirstOrDefault(x => x.Id == id);

            _context.Orcamento.Remove(orcamento);
            _context.SaveChanges();
            return Ok();
        }
    }
}
