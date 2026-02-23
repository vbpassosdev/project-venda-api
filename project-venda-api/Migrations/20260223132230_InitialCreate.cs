using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_venda_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CpfCnpj = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    TipoPessoa = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Uf = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    CelularDdd = table.Column<int>(type: "int", nullable: true),
                    Celular = table.Column<long>(type: "bigint", nullable: true),
                    TelefoneDdd = table.Column<int>(type: "int", nullable: true),
                    Telefone = table.Column<long>(type: "bigint", nullable: true),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Celular = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    ProdutoNome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoItens_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Titulos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    SacadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "varchar(30)", nullable: false),
                    NossoNumero = table.Column<string>(type: "varchar(20)", nullable: false),
                    Carteira = table.Column<string>(type: "varchar(5)", nullable: false),
                    ValorDocumento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorMoraJuros = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentualMulta = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DataDocumento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataProcessamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Especie = table.Column<string>(type: "varchar(5)", nullable: false),
                    EspecieMod = table.Column<string>(type: "varchar(5)", nullable: false),
                    Instrucao1 = table.Column<string>(type: "varchar(200)", nullable: false),
                    Instrucao2 = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Titulos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Titulos_Sacados_SacadoId",
                        column: x => x.SacadoId,
                        principalTable: "Sacados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItens_PedidoId",
                table: "PedidoItens",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Titulos_EmpresaId",
                table: "Titulos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Titulos_SacadoId",
                table: "Titulos",
                column: "SacadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "PedidoItens");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Titulos");

            migrationBuilder.DropTable(
                name: "Vendedores");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Sacados");
        }
    }
}
