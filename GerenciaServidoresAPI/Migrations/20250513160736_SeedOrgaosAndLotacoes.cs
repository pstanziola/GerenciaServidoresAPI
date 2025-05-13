using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GerenciaServidoresAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrgaosAndLotacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lotacoes",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-111111111111"), "Hospital Municipal" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Escola Estadual" }
                });

            migrationBuilder.InsertData(
                table: "Orgaos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Secretaria de Saúde" },
                    { new Guid("11111111-1111-1111-1111-222222222222"), "Secretaria de Educação" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lotacoes",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-111111111111"));

            migrationBuilder.DeleteData(
                table: "Lotacoes",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Orgaos",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Orgaos",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-222222222222"));
        }
    }
}
