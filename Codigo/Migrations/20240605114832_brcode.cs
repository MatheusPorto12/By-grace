using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByGrace.Migrations
{
    /// <inheritdoc />
    public partial class brcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrCodePedido",
                table: "Pedido",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrCodePedido",
                table: "Pedido");
        }
    }
}
