using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_venda_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePedidoStatustypeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Pedidos",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Pedidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");
        }
    }
}
