using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_venda_api.Migrations
{
    /// <inheritdoc />
    public partial class TituloBoleto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aceite",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "CNPJCPF",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "CaracTitulo",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "CodTransmissao",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "CodigoCedente",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "CodigoMora",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "Convenio",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "DataDesconto",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "DataMoraJuros",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "DataMulta",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "DataProtesto",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "DiasDeProtesto",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "LayoutBol",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "LocalPagamento",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "Modalidade",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "MultaValorFixo",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "Parcela",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "RespEmis",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "SeuNumero",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "TipoCarteira",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "TipoDesconto",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "TipoDesconto2",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "TipoDiasProtesto",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "TipoImpressao",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "TipoPessoa",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "TotalParcelas",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "ValorAbatimento",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "ValorDesconto",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "ValorIOF",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "ValorMulta",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "ValorOutrasDespesas",
                table: "Titulos");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorMoraJuros",
                table: "Titulos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentualMulta",
                table: "Titulos",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroDocumento",
                table: "Titulos",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "NossoNumero",
                table: "Titulos",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Instrucao2",
                table: "Titulos",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Instrucao1",
                table: "Titulos",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EspecieMod",
                table: "Titulos",
                type: "varchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Especie",
                table: "Titulos",
                type: "varchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Carteira",
                table: "Titulos",
                type: "varchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AddColumn<Guid>(
                name: "CedenteId",
                table: "Titulos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SacadoId",
                table: "Titulos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Cedentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    CNPJCPF = table.Column<string>(type: "varchar(20)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(150)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", nullable: false),
                    CEP = table.Column<string>(type: "varchar(10)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Agencia = table.Column<string>(type: "varchar(10)", nullable: false),
                    AgenciaDigito = table.Column<string>(type: "varchar(2)", nullable: false),
                    Conta = table.Column<string>(type: "varchar(20)", nullable: false),
                    ContaDigito = table.Column<string>(type: "varchar(2)", nullable: false),
                    Convenio = table.Column<string>(type: "varchar(20)", nullable: false),
                    CodigoCedente = table.Column<string>(type: "varchar(20)", nullable: false),
                    Modalidade = table.Column<string>(type: "varchar(5)", nullable: false),
                    ChavePIX = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cedentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sacados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    CNPJCPF = table.Column<string>(type: "varchar(20)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(150)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", nullable: false),
                    CEP = table.Column<string>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sacados", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Titulos_CedenteId",
                table: "Titulos",
                column: "CedenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Titulos_SacadoId",
                table: "Titulos",
                column: "SacadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Titulos_Cedentes_CedenteId",
                table: "Titulos",
                column: "CedenteId",
                principalTable: "Cedentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Titulos_Sacados_SacadoId",
                table: "Titulos",
                column: "SacadoId",
                principalTable: "Sacados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titulos_Cedentes_CedenteId",
                table: "Titulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Titulos_Sacados_SacadoId",
                table: "Titulos");

            migrationBuilder.DropTable(
                name: "Cedentes");

            migrationBuilder.DropTable(
                name: "Sacados");

            migrationBuilder.DropIndex(
                name: "IX_Titulos_CedenteId",
                table: "Titulos");

            migrationBuilder.DropIndex(
                name: "IX_Titulos_SacadoId",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "CedenteId",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "SacadoId",
                table: "Titulos");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorMoraJuros",
                table: "Titulos",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentualMulta",
                table: "Titulos",
                type: "decimal(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroDocumento",
                table: "Titulos",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "NossoNumero",
                table: "Titulos",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Instrucao2",
                table: "Titulos",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Instrucao1",
                table: "Titulos",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "EspecieMod",
                table: "Titulos",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)");

            migrationBuilder.AlterColumn<string>(
                name: "Especie",
                table: "Titulos",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)");

            migrationBuilder.AlterColumn<string>(
                name: "Carteira",
                table: "Titulos",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)");

            migrationBuilder.AddColumn<string>(
                name: "Aceite",
                table: "Titulos",
                type: "varchar(5)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Titulos",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Titulos",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CNPJCPF",
                table: "Titulos",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CaracTitulo",
                table: "Titulos",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Titulos",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodTransmissao",
                table: "Titulos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoCedente",
                table: "Titulos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoMora",
                table: "Titulos",
                type: "varchar(5)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Titulos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Convenio",
                table: "Titulos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDesconto",
                table: "Titulos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataMoraJuros",
                table: "Titulos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataMulta",
                table: "Titulos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataProtesto",
                table: "Titulos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiasDeProtesto",
                table: "Titulos",
                type: "varchar(5)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LayoutBol",
                table: "Titulos",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocalPagamento",
                table: "Titulos",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Titulos",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Modalidade",
                table: "Titulos",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "MultaValorFixo",
                table: "Titulos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Titulos",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Titulos",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Parcela",
                table: "Titulos",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RespEmis",
                table: "Titulos",
                type: "varchar(5)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SeuNumero",
                table: "Titulos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Titulos",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoCarteira",
                table: "Titulos",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoDesconto",
                table: "Titulos",
                type: "varchar(5)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoDesconto2",
                table: "Titulos",
                type: "varchar(5)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoDiasProtesto",
                table: "Titulos",
                type: "varchar(5)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoDocumento",
                table: "Titulos",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoImpressao",
                table: "Titulos",
                type: "varchar(5)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoPessoa",
                table: "Titulos",
                type: "varchar(5)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TotalParcelas",
                table: "Titulos",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Titulos",
                type: "varchar(2)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorAbatimento",
                table: "Titulos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorDesconto",
                table: "Titulos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorIOF",
                table: "Titulos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorMulta",
                table: "Titulos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorOutrasDespesas",
                table: "Titulos",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
