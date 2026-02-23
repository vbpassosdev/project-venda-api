using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_venda_api.Models
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }

        // CPF ou CNPJ (sem formatação)
        [Required]
        [Column(TypeName = "varchar(14)")]
        [MaxLength(14)]
        public string CpfCnpj { get; set; } = string.Empty;

        // F = Física | J = Jurídica
        [Required]
        [Column(TypeName = "char(1)")]
        [MaxLength(1)]
        public string TipoPessoa { get; set; } = string.Empty;

        // Nome ou Razão Social
        [Required]
        [Column(TypeName = "varchar(150)")]
        [MaxLength(150)]
        public string RazaoSocial { get; set; } = string.Empty;

        // Endereço
        [Required]
        [Column(TypeName = "varchar(8)")]
        [MaxLength(8)]
        public string Cep { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(150)")]
        [MaxLength(150)]
        public string Logradouro { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(20)")]
        [MaxLength(20)]
        public string Numero { get; set; } = string.Empty;

        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string? Complemento { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Bairro { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Cidade { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "char(2)")]
        [MaxLength(2)]
        public string Uf { get; set; } = string.Empty;

        // Celular
        public int? CelularDdd { get; set; }
        public long? Celular { get; set; }

        // Telefone
        public int? TelefoneDdd { get; set; }
        public long? Telefone { get; set; }

        // Email opcional
        [Column(TypeName = "varchar(150)")]
        [MaxLength(150)]
        [EmailAddress]
        public string? Email { get; set; }
    }
}