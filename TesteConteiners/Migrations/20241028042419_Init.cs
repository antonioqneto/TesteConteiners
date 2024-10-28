using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TesteConteiners.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conteiners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    NumeroIdentificao = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Tipo = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteiners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conteiners_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConteinerId = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<byte>(type: "tinyint", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Conteiners_ConteinerId",
                        column: x => x.ConteinerId,
                        principalTable: "Conteiners",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Cliente 1" },
                    { 2, "Cliente 2" },
                    { 3, "Cliente 3" },
                    { 4, "Cliente 4" }
                });

            migrationBuilder.InsertData(
                table: "Conteiners",
                columns: new[] { "Id", "Categoria", "ClienteId", "NumeroIdentificao", "Status", "Tipo" },
                values: new object[,]
                {
                    { 1, 73, 1, "ABCD1234567", (byte)1, (byte)20 },
                    { 2, 69, 2, "BCDE7654321", (byte)2, (byte)40 },
                    { 3, 73, 2, "BCDE7664321", (byte)1, (byte)40 }
                });

            migrationBuilder.InsertData(
                table: "Movimentacoes",
                columns: new[] { "Id", "ConteinerId", "Fim", "Inicio", "Tipo" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 2, 2, new DateTime(2021, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conteiners_ClienteId",
                table: "Conteiners",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ConteinerId",
                table: "Movimentacoes",
                column: "ConteinerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "Conteiners");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
