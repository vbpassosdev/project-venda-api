using System.ComponentModel;

public enum PedidoStatus
{
    [Description("Pedido criado")]
    Novo,

    [Description("Pedido liberado para faturamento")]
    Liberado,

    [Description("Pedido faturado")]
    Faturado,

    [Description("Pedido cancelado")]
    Cancelado,

    [Description("Pedido pago")]
    Pago
}