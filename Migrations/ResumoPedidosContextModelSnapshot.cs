﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResumoPedidos.Data;

#nullable disable

namespace ResumoPedidos.Migrations
{
    [DbContext(typeof(ResumoPedidosContext))]
    partial class ResumoPedidosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ResumoPedidos.Domain.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("IdCliente");

                    b.ToTable("CLIENTE", (string)null);
                });

            modelBuilder.Entity("ResumoPedidos.Domain.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduto"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int?>("IdResumoPedido")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(5,2)");

                    b.HasKey("IdProduto");

                    b.HasIndex("IdResumoPedido");

                    b.ToTable("PRODUTO", (string)null);
                });

            modelBuilder.Entity("ResumoPedidos.Domain.ResumoPedido", b =>
                {
                    b.Property<int>("IdResumoPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("INT");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("DECIMAL(5,2)");

                    b.HasKey("IdResumoPedido");

                    b.ToTable("RESUMOPEDIDO", (string)null);
                });

            modelBuilder.Entity("ResumoPedidos.Domain.Produto", b =>
                {
                    b.HasOne("ResumoPedidos.Domain.ResumoPedido", "ResumoPedido")
                        .WithMany("Produtos")
                        .HasForeignKey("IdResumoPedido");

                    b.Navigation("ResumoPedido");
                });

            modelBuilder.Entity("ResumoPedidos.Domain.ResumoPedido", b =>
                {
                    b.HasOne("ResumoPedidos.Domain.Cliente", "Cliente")
                        .WithMany("ResumoPedidos")
                        .HasForeignKey("IdResumoPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ResumoPedidos.Domain.Cliente", b =>
                {
                    b.Navigation("ResumoPedidos");
                });

            modelBuilder.Entity("ResumoPedidos.Domain.ResumoPedido", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
