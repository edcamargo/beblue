using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beblue.Repositories.Migrations
{
    public partial class CreateInitial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "db");

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ClienteId = table.Column<string>(nullable: true),
                    TotalVenda = table.Column<double>(nullable: false),
                    ValorCashback = table.Column<double>(nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "db",
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashbackGenero",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GeneroId = table.Column<string>(nullable: true),
                    DiaSemana = table.Column<int>(nullable: false),
                    PercentualCashbackDia = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashbackGenero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashbackGenero_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalSchema: "db",
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Disco",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GeneroId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Preco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disco_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalSchema: "db",
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItem",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PedidoId = table.Column<string>(nullable: true),
                    DiscoId = table.Column<string>(nullable: true),
                    ValorCashBack = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Disco_DiscoId",
                        column: x => x.DiscoId,
                        principalSchema: "db",
                        principalTable: "Disco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalSchema: "db",
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashbackGenero_GeneroId",
                schema: "db",
                table: "CashbackGenero",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Disco_GeneroId",
                schema: "db",
                table: "Disco",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                schema: "db",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_DiscoId",
                schema: "db",
                table: "PedidoItem",
                column: "DiscoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_PedidoId",
                schema: "db",
                table: "PedidoItem",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashbackGenero",
                schema: "db");

            migrationBuilder.DropTable(
                name: "PedidoItem",
                schema: "db");

            migrationBuilder.DropTable(
                name: "Disco",
                schema: "db");

            migrationBuilder.DropTable(
                name: "Pedido",
                schema: "db");

            migrationBuilder.DropTable(
                name: "Genero",
                schema: "db");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "db");
        }
    }
}
