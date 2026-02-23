namespace project_venda_api.Dto
{
    public class PedidoCreateDto{
        public Guid ClienteId { get; set; }
        public required List<PedidoItemDto> Itens { get; set; }
    }
}
