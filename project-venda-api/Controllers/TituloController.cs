using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_venda_api.Data.Context;
using project_venda_api.Dto;
using project_venda_api.Models;
using project_venda_api.Services;

namespace project_venda_api.Controllers
{
    [ApiController]
    [Route("api/titulos")]
    public class TituloController : Controller
    {
        private readonly AppDbContext _context;
        private readonly BoletoService _service;

        public TituloController(AppDbContext context, BoletoService service)
        {
            _context = context;
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TituloListDto>>> GetTitulos()
        {
            var titulos = await _context.Titulos
                .Include(t => t.Sacado)
                .Select(t => new TituloListDto
                {
                    Id = t.Id,
                    ClienteNome = t.Sacado.Nome,
                    NumeroDocumento = t.NumeroDocumento,
                    ValorDocumento = t.ValorDocumento,
                    Vencimento = t.Vencimento
                })
                .ToListAsync();

            return Ok(titulos);
        }

        [HttpPost("gerar/{tituloId}")]
        public IActionResult Gerar(Guid tituloId)
        {
            if (tituloId == Guid.Empty)
                return BadRequest(new { sucesso = false, mensagem = "Id do título não informado." });

            try
            {
                var pdf = _service.GerarBoleto(tituloId);

                return Ok(new
                {
                    sucesso = true,
                    pdfUrl = pdf
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    sucesso = false,
                    erro = ex.Message
                });
            }
        }
    }
}
