using Microsoft.AspNetCore.Mvc;
using project_venda_api.Data.Context;
using project_venda_api.Service;
using project_venda_api.Services;

namespace project_venda_api.Controllers
{

        [ApiController]
        [Route("api/nfes")]
        public class NFEsController : ControllerBase
        {
            private readonly NFSeService _service;

            public NFEsController(NFSeService service)
            {
                _service = service;
            }

            [HttpPost("{docId}")]
            public IActionResult Gerar(int docId)
            {
                try
                {
                    var caminho = _service.GerarNfse(docId);

                    var nomeArquivo = Path.GetFileName(caminho);

                    var url = $"{Request.Scheme}://{Request.Host}/nfses/{nomeArquivo}";

                    return Ok(new
                    {
                        sucesso = true,
                        pdfUrl = url
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
