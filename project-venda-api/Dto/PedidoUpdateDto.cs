namespace project_venda_api.Dto
{
    public class PedidoUpdateDto
    {
        public Guid ClienteId { get; set; }
        public List<PedidoItemDto> Itens { get; set; } = new();
     
    }
}
