using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_venda_api.Data.Context;
using project_venda_api.Dto;
using project_venda_api.Models;
using project_venda_api.Models.Enums;

namespace project_venda_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _context.Pedidos
                .Include(p => p.Cliente)
                .ToListAsync();

            var resultado = pedidos.Select(p => new PedidoListDto
            {
                Id = p.Id,
                ClienteNome = p.Cliente != null ? p.Cliente.RazaoSocial : "",
                DataPedido = p.DataPedido,
                ValorTotal = p.ValorTotal,
                Status = p.Status.ToString(),
                StatusDescricao = p.Status.GetDescription()
            });

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        // ✅ CRIAR
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PedidoCreateDto dto)
        {
            var pedido = new Pedido(dto.ClienteId);

            foreach (var itemDto in dto.Itens)
            {
                var item = new PedidoItem(
                     itemDto.ProdutoId,
                     itemDto.ProdutoNome,
                     itemDto.Quantidade,
                     itemDto.ValorUnitario
                 );

                pedido.AdicionarItem(item);
            }

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
        }

        // ✅ EDITAR
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PedidoUpdateDto dto)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Itens)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
                return NotFound();

            if (pedido.Status == PedidoStatus.Novo || pedido.Status == PedidoStatus.Liberado)
                return BadRequest("Somente pedidos Novo/Liberado podem ser alterados.");

            // Remove itens antigos
            foreach (var item in pedido.Itens.ToList())
            {
                pedido.RemoverItem(item);
            }

            // Adiciona novos
            foreach (var itemDto in dto.Itens)
            {
                var item = new PedidoItem(
                    itemDto.ProdutoId,
                    itemDto.ProdutoNome,
                    itemDto.Quantidade,
                    itemDto.ValorUnitario
                );

                pedido.AdicionarItem(item);
            }

            await _context.SaveChangesAsync();

            return Ok(pedido);
        }
    }
}