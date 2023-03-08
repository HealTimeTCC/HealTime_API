using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class Medicos_Default : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "MedicoId", "CrmMedico", "NmMedico", "UfCrmMedico" },
                values: new object[,]
                {
                    { 1, 12345, "Dr Val", "SP" },
                    { 2, 12345, "Dr Teste", "RJ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "MedicoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "MedicoId",
                keyValue: 2);
        }
    }
}
