using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class DefaultValue_TipoMedicacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TiposMedicacoes",
                columns: new[] { "TipoMedicacaoId", "ClasseAplicacao", "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[,]
                {
                    { 1, 1, "Experimental", "NASAL" },
                    { 2, 2, "Experimental EXPERIMENTE CALADO", "PILULA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposMedicacoes",
                keyColumn: "TipoMedicacaoId",
                keyValue: 2);
        }
    }
}
