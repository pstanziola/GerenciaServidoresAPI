using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciaServidoresAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lotacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orgaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servidores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    OrgaoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LotacaoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Sala = table.Column<string>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servidores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servidores_Lotacoes_LotacaoId",
                        column: x => x.LotacaoId,
                        principalTable: "Lotacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servidores_Orgaos_OrgaoId",
                        column: x => x.OrgaoId,
                        principalTable: "Orgaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servidores_LotacaoId",
                table: "Servidores",
                column: "LotacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Servidores_OrgaoId",
                table: "Servidores",
                column: "OrgaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servidores");

            migrationBuilder.DropTable(
                name: "Lotacoes");

            migrationBuilder.DropTable(
                name: "Orgaos");
        }
    }
}
