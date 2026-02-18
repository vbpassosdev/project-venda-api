using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_venda_api.Migrations
{
    /// <inheritdoc />
    public partial class Titulodbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Titulos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "varchar(50)", nullable: false),
                    NossoNumero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Carteira = table.Column<string>(type: "varchar(10)", nullable: false),
                    ValorDocumento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDocumento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataProcessamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorMoraJuros = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorMulta = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorDesconto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorAbatimento = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorIOF = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorOutrasDespesas = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PercentualMulta = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    MultaValorFixo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DataDesconto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataMulta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataMoraJuros = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiasDeProtesto = table.Column<string>(type: "varchar(5)", nullable: true),
                    DataProtesto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocalPagamento = table.Column<string>(type: "varchar(255)", nullable: false),
                    Especie = table.Column<string>(type: "varchar(20)", nullable: false),
                    EspecieMod = table.Column<string>(type: "varchar(20)", nullable: false),
                    Instrucao1 = table.Column<string>(type: "varchar(255)", nullable: true),
                    Instrucao2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    Aceite = table.Column<string>(type: "varchar(5)", nullable: false),
                    Parcela = table.Column<string>(type: "varchar(10)", nullable: false),
                    TotalParcelas = table.Column<string>(type: "varchar(10)", nullable: false),
                    SeuNumero = table.Column<string>(type: "varchar(50)", nullable: false),
                    TipoDiasProtesto = table.Column<string>(type: "varchar(5)", nullable: true),
                    TipoImpressao = table.Column<string>(type: "varchar(5)", nullable: true),
                    CodigoMora = table.Column<string>(type: "varchar(5)", nullable: true),
                    TipoDesconto = table.Column<string>(type: "varchar(5)", nullable: true),
                    TipoDesconto2 = table.Column<string>(type: "varchar(5)", nullable: true),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    CNPJCPF = table.Column<string>(type: "varchar(20)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(150)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    CEP = table.Column<string>(type: "varchar(10)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(50)", nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    TipoPessoa = table.Column<string>(type: "varchar(5)", nullable: false),
                    RespEmis = table.Column<string>(type: "varchar(5)", nullable: false),
                    CodigoCedente = table.Column<string>(type: "varchar(50)", nullable: false),
                    LayoutBol = table.Column<string>(type: "varchar(20)", nullable: false),
                    CaracTitulo = table.Column<string>(type: "varchar(20)", nullable: false),
                    TipoCarteira = table.Column<string>(type: "varchar(20)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "varchar(20)", nullable: false),
                    Modalidade = table.Column<string>(type: "varchar(20)", nullable: false),
                    CodTransmissao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Convenio = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Titulos");
        }
    }
}
