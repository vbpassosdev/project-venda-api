using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_venda_api.Data.Context;
using project_venda_api.Models;

namespace project_venda_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            var produtos = await _context.Produtos
                .Where(p => p.Ativo)
                .AsNoTracking()
                .ToListAsync();

            return Ok(produtos);
        }

        // GET: api/produto/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id && p.Ativo);

            if (produto == null)
                return NotFound("Produto não encontrado.");

            return Ok(produto);
        }

        // POST: api/produto
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        // PUT: api/produto/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarProduto(int id, [FromBody] Produto produtoAtualizado)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null || !produto.Ativo)
                return NotFound("Produto não encontrado.");

            produto.Referencia = produtoAtualizado.Referencia;
            produto.Descricao = produtoAtualizado.Descricao;
            produto.Preco = produtoAtualizado.Preco;
            produto.Estoque = produtoAtualizado.Estoque;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH: api/produto/{id}/estoque/baixar
        [HttpPatch("{id}/estoque/baixar")]
        public async Task<ActionResult> BaixarEstoque(int id, [FromQuery] int quantidade)
        {
            if (quantidade <= 0)
                return BadRequest("Quantidade deve ser maior que zero.");

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null || !produto.Ativo)
                return NotFound("Produto não encontrado.");

            try
            {
                produto.BaixarEstoque(quantidade);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(produto);
        }

        // PATCH: api/produto/{id}/estoque/repor
        [HttpPatch("{id}/estoque/repor")]
        public async Task<ActionResult> ReporEstoque(int id, [FromQuery] int quantidade)
        {
            if (quantidade <= 0)
                return BadRequest("Quantidade deve ser maior que zero.");

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null || !produto.Ativo)
                return NotFound("Produto não encontrado.");

            try
            {
                produto.ReporEstoque(quantidade);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(produto);
        }

        // DELETE: api/produto/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> InativarProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return NotFound("Produto não encontrado.");

            if (!produto.Ativo)
                return BadRequest("Produto já está inativo.");

            produto.Inativar();
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
