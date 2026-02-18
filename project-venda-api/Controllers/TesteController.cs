using Microsoft.AspNetCore.Mvc;
using project_venda_api.Data.Context;

namespace project_venda_api.Controllers
{
    [ApiController]
    [Route("api/teste")]
    public class TesteController : Controller
    {
        private readonly AppDbContext _context;


        public TesteController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Conectado com sucesso ao banco!");
        }
    }
}
