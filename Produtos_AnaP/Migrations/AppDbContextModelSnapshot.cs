﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrcamentoApi.Infra.SQL.Context;

#nullable disable

namespace OrcamentoApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OrcamentoApi.Domain.Models.LinkDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Href")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Metodo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrcamentoId")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutosId")
                        .HasColumnType("int");

                    b.Property<string>("Rel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VendedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrcamentoId");

                    b.HasIndex("ProdutosId");

                    b.HasIndex("VendedorId");

                    b.ToTable("LinkDTO");
                });

            modelBuilder.Entity("OrcamentoApi.Domain.Models.Orcamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProdutosId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.Property<int>("VendedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutosId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Orcamentos");
                });

            modelBuilder.Entity("OrcamentoApi.Domain.Models.Produtos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("OrcamentoApi.Domain.Models.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("OrcamentoApi.Domain.Models.LinkDTO", b =>
                {
                    b.HasOne("OrcamentoApi.Domain.Models.Orcamento", null)
                        .WithMany("Links")
                        .HasForeignKey("OrcamentoId");

                    b.HasOne("OrcamentoApi.Domain.Models.Produtos", null)
                        .WithMany("Links")
                        .HasForeignKey("ProdutosId");

                    b.HasOne("OrcamentoApi.Domain.Models.Vendedor", null)
                        .WithMany("Links")
                        .HasForeignKey("VendedorId");
                });

            modelBuilder.Entity("OrcamentoApi.Domain.Models.Orcamento", b =>
                {
                    b.HasOne("OrcamentoApi.Domain.Models.Produtos", "Produtos")
                        .WithMany()
                        .HasForeignKey("ProdutosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrcamentoApi.Domain.Models.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produtos");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("OrcamentoApi.Domain.Models.Orcamento", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("OrcamentoApi.Domain.Models.Produtos", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("OrcamentoApi.Domain.Models.Vendedor", b =>
                {
                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
