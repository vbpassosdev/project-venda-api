using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_venda_api.Data.Context;
using project_venda_api.Models;

namespace project_venda_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfluenciadoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InfluenciadoresController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 GET: api/influenciadores
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var influenciadores = await _context.Influenciadores.ToListAsync();
            return Ok(influenciadores);
        }

        // 🔹 GET: api/influenciadores/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var influenciador = await _context.Influenciadores.FindAsync(id);

            if (influenciador == null)
                return NotFound();

            return Ok(influenciador);
        }

        // 🔹 POST: api/influenciadores
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 
        Influenciador influenciador)
        {


            influenciador.Id = Guid.NewGuid(); // BACKEND gera

            _context.Influenciadores.Add(influenciador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),
                new { id = influenciador.Id },
                influenciador);





        }

        // 🔹 PUT: api/influenciadores/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Influenciador influenciador)
        {
            if (id != influenciador.Id)
                return BadRequest("Id não corresponde");

            var existe = await _context.Influenciadores.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound();

            _context.Entry(influenciador).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // 🔹 DELETE: api/influenciadores/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var influenciador = await _context.Influenciadores.FindAsync(id);

            if (influenciador == null)
                return NotFound();

            _context.Influenciadores.Remove(influenciador);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
