using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_venda_api.Models
{
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ✅ ID gerado pelo banco
        public int Id { get; set; }

        // =============================
        // Dados básicos
        // =============================

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string CNPJCPF { get; set; } = string.Empty;

        [Column(TypeName = "varchar(150)")]
        public string Logradouro { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string Numero { get; set; } = string.Empty;

        [Column(TypeName = "varchar(100)")]
        public string Bairro { get; set; } = string.Empty;

        [Column(TypeName = "varchar(100)")]
        public string Cidade { get; set; } = string.Empty;

        [Column(TypeName = "varchar(2)")]
        public string UF { get; set; } = string.Empty;

        [Column(TypeName = "varchar(10)")]
        public string CEP { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string Telefone { get; set; } = string.Empty;

        // =============================
        // Dados bancários Banco do Brasil
        // =============================

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Agencia { get; set; } = string.Empty;

        [Column(TypeName = "varchar(2)")]
        public string AgenciaDigito { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Conta { get; set; } = string.Empty;

        [Column(TypeName = "varchar(2)")]
        public string ContaDigito { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Convenio { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string CodigoCedente { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(5)")]
        public string Modalidade { get; set; } = string.Empty;

        // =============================
        // PIX
        // =============================

        [Column(TypeName = "varchar(150)")]
        public string ChavePIX { get; set; } = string.Empty;
    }
}
