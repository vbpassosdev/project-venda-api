using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_venda_api.Models
{
    public class Titulo
    {
        [Key]
        public Guid Id { get; set; }

        // Relacionamentos
        [Required]
        public int EmpresaId { get; set; }
        public Empresa Cedente { get; set; } = null!;

        [Required]
        public Guid SacadoId { get; set; }
        public Sacado Sacado { get; set; } = null!;

        // =============================
        // Identificação do Título
        // =============================

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string NumeroDocumento { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string NossoNumero { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(5)")]
        public string Carteira { get; set; } = string.Empty;

        // =============================
        // Valores
        // =============================

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorDocumento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorMoraJuros { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal PercentualMulta { get; set; }

        // =============================
        // Datas
        // =============================

        [Required]
        public DateTime DataDocumento { get; set; }

        [Required]
        public DateTime DataProcessamento { get; set; }

        [Required]
        public DateTime Vencimento { get; set; }

        // =============================
        // Espécie
        // =============================

        [Column(TypeName = "varchar(5)")]
        public string Especie { get; set; } = "DM"; // Duplicata Mercantil

        [Column(TypeName = "varchar(5)")]
        public string EspecieMod { get; set; } = "R$";

        // =============================
        // Instruções
        // =============================

        [Column(TypeName = "varchar(200)")]
        public string Instrucao1 { get; set; } = string.Empty;

        [Column(TypeName = "varchar(200)")]
        public string Instrucao2 { get; set; } = string.Empty;


    }
}
