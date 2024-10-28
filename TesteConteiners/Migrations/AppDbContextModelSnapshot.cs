﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteConteiners.Data;

#nullable disable

namespace TesteConteiners.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TesteConteiners.Data.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Cliente 1"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Cliente 2"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Cliente 3"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Cliente 4"
                        });
                });

            modelBuilder.Entity("TesteConteiners.Data.Models.Conteiner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroIdentificao")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Tipo")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Conteiners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Categoria = 73,
                            ClienteId = 1,
                            NumeroIdentificao = "ABCD1234567",
                            Status = (byte)1,
                            Tipo = (byte)20
                        },
                        new
                        {
                            Id = 2,
                            Categoria = 69,
                            ClienteId = 2,
                            NumeroIdentificao = "BCDE7654321",
                            Status = (byte)2,
                            Tipo = (byte)40
                        },
                        new
                        {
                            Id = 3,
                            Categoria = 73,
                            ClienteId = 2,
                            NumeroIdentificao = "BCDE7654321",
                            Status = (byte)1,
                            Tipo = (byte)40
                        });
                });

            modelBuilder.Entity("TesteConteiners.Data.Models.Movimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ConteinerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Tipo")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("ConteinerId");

                    b.ToTable("Movimentacoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConteinerId = 1,
                            Fim = new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Inicio = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tipo = (byte)1
                        },
                        new
                        {
                            Id = 2,
                            ConteinerId = 2,
                            Fim = new DateTime(2021, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Inicio = new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tipo = (byte)4
                        });
                });

            modelBuilder.Entity("TesteConteiners.Data.Models.Conteiner", b =>
                {
                    b.HasOne("TesteConteiners.Data.Models.Cliente", null)
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("TesteConteiners.Data.Models.Movimentacao", b =>
                {
                    b.HasOne("TesteConteiners.Data.Models.Conteiner", null)
                        .WithMany()
                        .HasForeignKey("ConteinerId")
                        .OnDelete(DeleteBehavior.NoAction);
                });
#pragma warning restore 612, 618
        }
    }
}
