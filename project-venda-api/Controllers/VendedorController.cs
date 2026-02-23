using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_venda_api.Data.Context;
using project_venda_api.Models;

namespace project_venda_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendedorController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 GET: api/vendedor
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vendedor = await _context.Vendedores.ToListAsync();
            return Ok(vendedor);
        }

        // 🔹 GET: api/vendedor/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var vendedor = await _context.Vendedores.FindAsync(id);

            if (vendedor == null)
                return NotFound();

            return Ok(vendedor);
        }

        // 🔹 POST: api/vendedor
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Vendedor vendedor)
        {

            vendedor.Id = Guid.NewGuid(); // BACKEND gera

            _context.Vendedores.Add(vendedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),
                new { id = vendedor.Id },
                vendedor);
        }

        // 🔹 PUT: api/vendedor/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
                return BadRequest("Id não corresponde");

            var existe = await _context.Vendedores.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound();

            _context.Entry(vendedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // 🔹 DELETE: api/vendedor/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var vendedor = await _context.Vendedores.FindAsync(id);

            if (vendedor == null)
                return NotFound();

            _context.Vendedores.Remove(vendedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
