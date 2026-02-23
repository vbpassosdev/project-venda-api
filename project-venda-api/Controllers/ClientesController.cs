using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_venda_api.Data.Context;
using project_venda_api.Models;

namespace project_venda_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetClientes(string? nome)
        {
            var query = _context.Clientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
            {
                query = query.Where(c => c.RazaoSocial.Contains(nome));
            }

            var clientes = await query
                .Select(c => new {
                    id = c.Id,
                    nome = c.RazaoSocial
                })
                .Take(20) // 👈 limita para performance
                .ToListAsync();

            return Ok(clientes);
        }

        // 🔹 GET: api/clientes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        // 🔹 GET: api/clientes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound("Cliente não encontrado");

            return Ok(cliente);
        }

        // 🔹 POST: api/clientes
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Cliente cliente)
        {
            cliente.Id = Guid.NewGuid(); // BACKEND gera

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente),
                new { id = cliente.Id },
                cliente);
        }

        // 🔹 PUT: api/clientes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Cliente dto)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();

            cliente.RazaoSocial = dto.RazaoSocial;
            cliente.Email = dto.Email;
            cliente.Telefone = dto.Telefone;
            cliente.Celular = dto.Celular;
            cliente.TipoPessoa = dto.TipoPessoa;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 🔹 DELETE: api/clientes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
