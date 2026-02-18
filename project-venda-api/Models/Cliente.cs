using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using project_venda_api.Models.Enums;

namespace project_venda_api.Models
{
    public class Cliente
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

        [Required]
        public TipoCliente TipoCliente { get; set; }


    }
}
