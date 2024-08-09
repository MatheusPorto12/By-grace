using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByGrace.Migrations
{
    /// <inheritdoc />
    public partial class Att : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoProduto",
                table: "Produtos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FotoProduto",
                table: "Produtos",
                type: "varbinary",
                nullable: false,
                defaultValue: new byte[0])
                .Annotation("Relational:ColumnOrder", 5);
        }
    }
}
