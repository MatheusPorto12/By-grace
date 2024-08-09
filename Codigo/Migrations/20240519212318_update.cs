﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByGrace.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CodigoCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailCliente = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    CpfCliente = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    TelefoneCliente = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    NascimentoCliente = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    NomeCliente = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    SenhaCliente = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    TipoCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CodigoCliente);
                });

            migrationBuilder.CreateTable(
                name: "Cliente_Pedido_Produto",
                columns: table => new
                {
                    CodigoPedido = table.Column<int>(type: "int", nullable: false),
                    CodigoCliente = table.Column<int>(type: "int", nullable: false),
                    CodigoProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente_Pedido_Produto", x => x.CodigoPedido);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    CodigoPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorPedido = table.Column<double>(type: "float", nullable: false),
                    FormaPagamentoPedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.CodigoPedido);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    CodigoProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DescricaoProduto = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    TamanhoProduto = table.Column<int>(type: "int", nullable: false),
                    ValorProduto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.CodigoProduto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Cliente_Pedido_Produto");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
