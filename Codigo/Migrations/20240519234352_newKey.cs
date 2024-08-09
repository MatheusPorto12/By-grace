using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByGrace.Migrations
{
    /// <inheritdoc />
    public partial class newKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente_Pedido_Produto",
                table: "Cliente_Pedido_Produto");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cliente_Pedido_Produto",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente_Pedido_Produto",
                table: "Cliente_Pedido_Produto",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente_Pedido_Produto",
                table: "Cliente_Pedido_Produto");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cliente_Pedido_Produto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente_Pedido_Produto",
                table: "Cliente_Pedido_Produto",
                column: "CodigoPedido");
        }
    }
}
