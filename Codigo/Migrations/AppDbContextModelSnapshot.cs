﻿// <auto-generated />
using System;
using ByGrace.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ByGrace.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ByGrace.Classes.Cliente", b =>
                {
                    b.Property<int>("CodigoCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoCliente"));

                    b.Property<string>("CpfCliente")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(8);

                    b.Property<string>("EmailCliente")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("NascimentoCliente")
                        .HasColumnType("DATETIME")
                        .HasColumnOrder(4);

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnOrder(5);

                    b.Property<string>("SenhaCliente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnOrder(6);

                    b.Property<string>("TelefoneCliente")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR")
                        .HasColumnOrder(3);

                    b.Property<int>("TipoCliente")
                        .HasColumnType("int")
                        .HasColumnOrder(7);

                    b.HasKey("CodigoCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ByGrace.Classes.Pedido", b =>
                {
                    b.Property<int>("CodigoPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoPedido"));

                    b.Property<string>("BrCodePedido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(5);

                    b.Property<int>("CodigoClientePedido")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(4);

                    b.Property<int>("FormaPagamentoPedido")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("SituacaoPedido")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<double>("ValorPedido")
                        .HasColumnType("float")
                        .HasColumnOrder(1);

                    b.HasKey("CodigoPedido");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("ByGrace.Classes.PedidoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodigoPedido")
                        .HasColumnType("int");

                    b.Property<int>("CodigoProduto")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeProduto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cliente_Pedido_Produto");
                });

            modelBuilder.Entity("ByGrace.Classes.Produtos", b =>
                {
                    b.Property<int>("CodigoProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoProduto"));

                    b.Property<int>("CategoriaProduto")
                        .HasColumnType("int")
                        .HasColumnOrder(7);

                    b.Property<DateTime>("DataCadastroProduto")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(8);

                    b.Property<string>("DescricaoProduto")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("varchar")
                        .HasColumnOrder(2);

                    b.Property<bool>("DisponivelProduto")
                        .HasColumnType("bit")
                        .HasColumnOrder(6);

                    b.Property<byte[]>("FotoProduto")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnOrder(9);

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnOrder(1);

                    b.Property<int>("QuantidadeProduto")
                        .HasColumnType("int")
                        .HasColumnOrder(5);

                    b.Property<int>("TamanhoProduto")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<double>("ValorProduto")
                        .HasColumnType("float")
                        .HasColumnOrder(4);

                    b.HasKey("CodigoProduto");

                    b.ToTable("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
