using System.ComponentModel.DataAnnotations;

namespace project_venda_api.Models
{
    public class BoletoRequest
    {
        public Guid CedenteId { get; set; }

        [Required]
        public Sacado Sacado { get; set; } = new();

        [Required]
        public Titulo Titulo { get; set; } = new();
    }
}
