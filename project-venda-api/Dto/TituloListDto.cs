namespace project_venda_api.Dto
{
    public class TituloListDto
    {
        public Guid Id { get; set; }
        public required string ClienteNome { get; set; }
        public required string NumeroDocumento { get; set; }
        public decimal ValorDocumento { get; set; }
        public DateTime Vencimento { get; set; }
    }
}
