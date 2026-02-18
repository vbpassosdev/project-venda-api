using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_venda_api.Models
{
    public class Influenciador
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Celular { get; set; } = string.Empty;
    }
}
