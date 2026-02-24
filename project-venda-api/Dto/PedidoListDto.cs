namespace project_venda_api.Dto
{
    public class PedidoListDto
    {
        public int Id { get; set; }
        public required string ClienteNome { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public required string Status { get; set; }
        public required string StatusDescricao { get; set; }
    }
}
