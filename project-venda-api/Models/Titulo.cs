using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_venda_api.Models
{
    public class Titulo
    {
        [Key]
        public Guid Id { get; set; }

        // =========================
        // DADOS DO TÍTULO
        // =========================

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string NumeroDocumento { get; set; } = string.Empty;

        [Column(TypeName = "varchar(50)")]
        public string NossoNumero { get; set; } = string.Empty;

        [Column(TypeName = "varchar(10)")]
        public string Carteira { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorDocumento { get; set; }

        [Required]
        public DateTime Vencimento { get; set; }

        public DateTime DataDocumento { get; set; }
        public DateTime DataProcessamento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ValorMoraJuros { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ValorMulta { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ValorDesconto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ValorAbatimento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ValorIOF { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ValorOutrasDespesas { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? PercentualMulta { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MultaValorFixo { get; set; }

        public DateTime? DataDesconto { get; set; }
        public DateTime? DataMulta { get; set; }
        public DateTime? DataMoraJuros { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string? DiasDeProtesto { get; set; }

        public DateTime? DataProtesto { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string LocalPagamento { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string Especie { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string EspecieMod { get; set; } = string.Empty;

        [Column(TypeName = "varchar(255)")]
        public string? Instrucao1 { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Instrucao2 { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string Aceite { get; set; } = string.Empty;

        [Column(TypeName = "varchar(10)")]
        public string Parcela { get; set; } = string.Empty;

        [Column(TypeName = "varchar(10)")]
        public string TotalParcelas { get; set; } = string.Empty;

        [Column(TypeName = "varchar(50)")]
        public string SeuNumero { get; set; } = string.Empty;

        [Column(TypeName = "varchar(5)")]
        public string? TipoDiasProtesto { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string? TipoImpressao { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string? CodigoMora { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string? TipoDesconto { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string? TipoDesconto2 { get; set; }

        // =========================
        // DADOS DO SACADO (CLIENTE)
        // =========================

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string CNPJCPF { get; set; } = string.Empty;

        [Column(TypeName = "varchar(150)")]
        public string Logradouro { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string Numero { get; set; } = string.Empty;

        [Column(TypeName = "varchar(100)")]
        public string Bairro { get; set; } = string.Empty;

        [Column(TypeName = "varchar(100)")]
        public string Cidade { get; set; } = string.Empty;

        [Column(TypeName = "varchar(10)")]
        public string CEP { get; set; } = string.Empty;

        [Column(TypeName = "varchar(50)")]
        public string Complemento { get; set; } = string.Empty;

        [Column(TypeName = "varchar(2)")]
        public string UF { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string Telefone { get; set; } = string.Empty;

        [Column(TypeName = "varchar(5)")]
        public string TipoPessoa { get; set; } = string.Empty;

        [Column(TypeName = "varchar(5)")]
        public string RespEmis { get; set; } = string.Empty;

        // =========================
        // DADOS DO CEDENTE
        // =========================

        [Column(TypeName = "varchar(50)")]
        public string CodigoCedente { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string LayoutBol { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string CaracTitulo { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string TipoCarteira { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string TipoDocumento { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string Modalidade { get; set; } = string.Empty;

        [Column(TypeName = "varchar(50)")]
        public string CodTransmissao { get; set; } = string.Empty;

        [Column(TypeName = "varchar(50)")]
        public string Convenio { get; set; } = string.Empty;
    }
}
