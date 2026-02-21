using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BtgApi.Migrations
{
    /// <inheritdoc />
    public partial class NovoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeCliente = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutosFinanceiros",
                columns: table => new
                {
                    ProdutoFinanceiroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeProdutoFinanceiro = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosFinanceiros", x => x.ProdutoFinanceiroID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Aplicacoes",
                columns: table => new
                {
                    AplicacaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAplicacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProdutoFinanceiroID = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacoes", x => x.AplicacaoID);
                    table.ForeignKey(
                        name: "FK_Aplicacoes_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aplicacoes_ProdutosFinanceiros_ProdutoFinanceiroID",
                        column: x => x.ProdutoFinanceiroID,
                        principalTable: "ProdutosFinanceiros",
                        principalColumn: "ProdutoFinanceiroID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Resgates",
                columns: table => new
                {
                    ResgateID = table.Column<int>(type: "int", nullable: false),
                    ValorResgate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImpostoRenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorLiquidoIR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataResgate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProdutoFinanceiroID = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resgates", x => x.ResgateID);
                    table.ForeignKey(
                        name: "FK_Resgates_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resgates_ProdutosFinanceiros_ResgateID",
                        column: x => x.ResgateID,
                        principalTable: "ProdutosFinanceiros",
                        principalColumn: "ProdutoFinanceiroID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteID", "NomeCliente" },
                values: new object[,]
                {
                    { 1, "Luiz Cliente 1" },
                    { 2, "Pedro Cliente 2" },
                    { 3, "Joice Cliente 3" }
                });

            migrationBuilder.InsertData(
                table: "ProdutosFinanceiros",
                columns: new[] { "ProdutoFinanceiroID", "NomeProdutoFinanceiro" },
                values: new object[,]
                {
                    { 1, "Certificado de Depósito Bancário" },
                    { 2, "Fundos de Investimento" },
                    { 3, "Ações" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacoes_ClienteID",
                table: "Aplicacoes",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacoes_ProdutoFinanceiroID",
                table: "Aplicacoes",
                column: "ProdutoFinanceiroID");

            migrationBuilder.CreateIndex(
                name: "IX_Resgates_ClienteID",
                table: "Resgates",
                column: "ClienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicacoes");

            migrationBuilder.DropTable(
                name: "Resgates");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "ProdutosFinanceiros");
        }
    }
}
