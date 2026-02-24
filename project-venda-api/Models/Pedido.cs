using project_venda_api.Models.Enums;
using project_venda_api.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Pedido
{
    [Key]
    public int Id { get; private set; }

    [Required]
    public Guid ClienteId { get; private set; }

    public Cliente? Cliente { get; private set; }

    public DateTime DataPedido { get; private set; } = DateTime.UtcNow;

    [Column(TypeName = "decimal(18,2)")]
    public decimal ValorTotal { get; private set; }

    [Column(TypeName = "varchar(20)")]
    public PedidoStatus Status { get; private set; } = PedidoStatus.Novo;

    public List<PedidoItem> Itens { get; private set; } = new();

    public Pedido(Guid clienteId)
    {
        ClienteId = clienteId;
    }

    public void AdicionarItem(PedidoItem item)
    {
        if (Status != PedidoStatus.Novo && Status != PedidoStatus.Liberado)
            throw new InvalidOperationException("Não é possível alterar um pedido finalizado.");

        Itens.Add(item);
        RecalcularTotal();
    }

    public void RemoverItem(PedidoItem item)
    {
        if (Status != PedidoStatus.Novo && Status != PedidoStatus.Liberado)
            throw new InvalidOperationException("Não é possível alterar um pedido finalizado.");

        Itens.Remove(item);
        RecalcularTotal();
    }

    private void RecalcularTotal()
    {
        ValorTotal = Itens.Sum(i => i.Subtotal);
    }

    public void MarcarComoPago()
    {
        if (!Itens.Any())
            throw new InvalidOperationException("Pedido não pode ser pago sem itens.");

        if (Status != PedidoStatus.Liberado)
            throw new InvalidOperationException("Pedido precisa estar liberado para pagamento.");

        Status = PedidoStatus.Pago;
    }

    public void Cancelar()
    {
        if (Status == PedidoStatus.Pago || Status == PedidoStatus.Faturado)
            throw new InvalidOperationException("Pedido pago não pode ser cancelado.");

        Status = PedidoStatus.Cancelado;
    }
}