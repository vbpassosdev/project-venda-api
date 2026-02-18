using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_venda_api.Models
{
    public class Sacado
    {
        [Key]
        public Guid Id { get; set; }

        // =============================
        // Dados pessoais
        // =============================

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string CNPJCPF { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Logradouro { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Numero { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Bairro { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Cidade { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(2)")]
        public string UF { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string CEP { get; set; } = string.Empty;

        [Column(TypeName = "varchar(150)")]
        public string Email { get; set; } = string.Empty;
    }
}
