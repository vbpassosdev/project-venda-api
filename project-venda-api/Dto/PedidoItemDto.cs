namespace project_venda_api.Dto
{
    public class PedidoItemDto
    {
            public int ProdutoId { get; set; }
            public string ProdutoNome { get; set; } = string.Empty;
            public int Quantidade { get; set; }
            public decimal ValorUnitario { get; set; }
    }
    
}
