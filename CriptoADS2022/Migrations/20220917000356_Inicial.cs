using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CriptoADS2022.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Moedas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    compra = table.Column<float>(type: "real", nullable: false),
                    venda = table.Column<int>(type: "int", nullable: false),
                    Moedaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moedas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Moedas_Moedas_Moedaid",
                        column: x => x.Moedaid,
                        principalTable: "Moedas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteid = table.Column<int>(type: "int", nullable: true),
                    moedaid = table.Column<int>(type: "int", nullable: true),
                    quantidade = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.id);
                    table.ForeignKey(
                        name: "FK_Conta_Clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Conta_Moedas_moedaid",
                        column: x => x.moedaid,
                        principalTable: "Moedas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Trasacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contaid = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quantidade = table.Column<float>(type: "real", nullable: false),
                    valor = table.Column<float>(type: "real", nullable: false),
                    operacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trasacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Trasacoes_Conta_contaid",
                        column: x => x.contaid,
                        principalTable: "Conta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conta_clienteid",
                table: "Conta",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_moedaid",
                table: "Conta",
                column: "moedaid");

            migrationBuilder.CreateIndex(
                name: "IX_Moedas_Moedaid",
                table: "Moedas",
                column: "Moedaid");

            migrationBuilder.CreateIndex(
                name: "IX_Trasacoes_contaid",
                table: "Trasacoes",
                column: "contaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trasacoes");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Moedas");
        }
    }
}
