using Microsoft.AspNetCore.Mvc;
using project_venda_api.Services;
using project_venda_api.Models;

namespace project_venda_api.Controllers
{
    [ApiController]
    [Route("api/boleto")]
    public class BoletoController : ControllerBase
    {
        private readonly BoletoService _service;

        public BoletoController(BoletoService service)
        {
            _service = service;
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
