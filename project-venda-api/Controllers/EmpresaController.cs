using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_venda_api.Data.Context;
using project_venda_api.Models;

namespace project_venda_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : Controller
    {
        private readonly AppDbContext _context;
        public EmpresaController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empresas = await _context.Empresas.ToListAsync();
            return Ok(empresas);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll),
                new { id = empresa.Id }, empresa);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpresa
            (int id, [FromBody] Empresa empresaUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa == null )
                return NotFound("Produto não encontrado.");

            empresa.Nome = empresaUpdate.Nome;
            empresa.CNPJCPF = empresaUpdate.CNPJCPF;
            empresa.Logradouro = empresaUpdate.Logradouro;
            empresa.Numero = empresaUpdate.Numero;
            empresa.Bairro = empresaUpdate.Bairro;
            empresa.Cidade = empresaUpdate.Cidade;
            empresa.UF = empresaUpdate.UF;
            empresa.CEP = empresaUpdate.CEP;
            empresa.Telefone = empresaUpdate.Telefone;
            empresa.Agencia = empresaUpdate.Agencia;
            empresa.AgenciaDigito = empresaUpdate.AgenciaDigito;
            empresa.Conta = empresaUpdate.Conta;
            empresa.ContaDigito = empresaUpdate.ContaDigito;
            empresa.Convenio = empresaUpdate.Convenio;
            empresa.CodigoCedente = empresaUpdate.CodigoCedente;
            empresa.Modalidade = empresaUpdate.Modalidade;
            empresa.ChavePIX = empresaUpdate.ChavePIX;
            
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}
