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

        public OrcamentoController(ILogger<OrcamentoController> logger, OrcamentoService orcamentoService, OrcamentoContext context)
        {
            _logger = logger;
            _orcamentoService = orcamentoService;
            _context = context;
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

        [HttpGet("GetAll")]
        public List<Orcamento> GetAllOrcamentos()
        {
            return _context.Orcamento.ToList();
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarOrcamento(int id, [FromBody] UpdateOrcamentoDto updateOrcamentoDto)
        {
            var orcamento = _context.Orcamento
                .Include(o => o.Produtos)
                .FirstOrDefault(x => x.Id == id);

            var produto = _context.Produtos.FirstOrDefault(x => x.Nome == updateOrcamentoDto.Produtos.Nome);
            var vendedor = _context.Vendedor.FirstOrDefault(x => x.Nome == updateOrcamentoDto.Vendedor.Nome);

            if(orcamento !=  null && orcamento.Produtos != null)
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
    }

}
