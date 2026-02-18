using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_venda_api.Models
{
    public class PedidoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdPedido { get; set; }

        [Required]
        public int IdProduto { get; set; }

        [Required]
        [StringLength(200)]
        public string ProdutoNome { get; private set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]
        public int Quantidade { get; private set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor unitário deve ser maior que zero")]
        public decimal ValorUnitario { get; private set; }

        [NotMapped]
        public decimal Subtotal => Quantidade * ValorUnitario;

        // ========================
        // CONSTRUTOR
        // ========================

        public PedidoItem(int idProduto, string produtoNome, int quantidade, decimal valorUnitario)
        {
            AlterarProduto(produtoNome);
            AlterarQuantidade(quantidade);
            AlterarValorUnitario(valorUnitario);

            IdProduto = idProduto;
        }

        // ========================
        // REGRAS DE NEGÓCIO
        // ========================

        public void AlterarQuantidade(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");

            Quantidade = quantidade;
        }

        public void AlterarValorUnitario(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor unitário deve ser maior que zero.");

            ValorUnitario = valor;
        }

        public void AlterarProduto(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto é obrigatório.");

            ProdutoNome = nome;
        }
    }
}
