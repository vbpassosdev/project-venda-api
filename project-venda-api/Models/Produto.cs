using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_venda_api.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ✅ ID gerado pelo banco
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Referencia { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Estoque não pode ser negativo")]
        public int Estoque { get; set; }

        public bool Ativo { get; private set; } = true;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // opcional
        public DateTime DataCadastro { get; private set; } = DateTime.UtcNow;

        // ========================
        // REGRAS DE NEGÓCIO
        // ========================

        public void BaixarEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");

            if (quantidade > Estoque)
                throw new InvalidOperationException("Estoque insuficiente.");

            Estoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");

            Estoque += quantidade;
        }

        public void Inativar() => Ativo = false;

        public void Ativar() => Ativo = true;
    }
}
