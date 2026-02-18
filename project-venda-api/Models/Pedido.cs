using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_venda_api.Models
{
    public enum StatusPedido
    {
        Pendente,
        Pago,
        Cancelado
    }

    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; private set; }

        public DateTime DataPedido { get; private set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; private set; }

        [Required]
        public StatusPedido Status { get; private set; } = StatusPedido.Pendente;

        public List<PedidoItem> Itens { get; private set; } = new();

        // ========================
        // CONSTRUTOR
        // ========================

        public Pedido(int clienteId)
        {
            ClienteId = clienteId;
        }

        // ========================
        // REGRAS DE NEGÓCIO
        // ========================

        public void AdicionarItem(PedidoItem item)
        {
            if (Status != StatusPedido.Pendente)
                throw new InvalidOperationException("Não é possível alterar um pedido finalizado.");

            Itens.Add(item);
            RecalcularTotal();
        }

        public void RemoverItem(PedidoItem item)
        {
            if (Status != StatusPedido.Pendente)
                throw new InvalidOperationException("Não é possível alterar um pedido finalizado.");

            Itens.Remove(item);
            RecalcularTotal();
        }

        public void RecalcularTotal()
        {
            ValorTotal = Itens.Sum(i => i.Subtotal);
        }

        public void MarcarComoPago()
        {
            if (!Itens.Any())
                throw new InvalidOperationException("Pedido não pode ser pago sem itens.");

            Status = StatusPedido.Pago;
        }

        public void Cancelar()
        {
            if (Status == StatusPedido.Pago)
                throw new InvalidOperationException("Pedido pago não pode ser cancelado.");

            Status = StatusPedido.Cancelado;
        }
    }
}
