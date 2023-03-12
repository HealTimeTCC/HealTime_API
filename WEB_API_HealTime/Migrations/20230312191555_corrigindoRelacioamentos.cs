using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class corrigindoRelacioamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Medicacoes_StatusMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Medicacoes_TipoMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.CreateIndex(
                name: "IX_Medicacoes_StatusMedicacaoId",
                table: "Medicacoes",
                column: "StatusMedicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicacoes_TipoMedicacaoId",
                table: "Medicacoes",
                column: "TipoMedicacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Medicacoes_StatusMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Medicacoes_TipoMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.CreateIndex(
                name: "IX_Medicacoes_StatusMedicacaoId",
                table: "Medicacoes",
                column: "StatusMedicacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicacoes_TipoMedicacaoId",
                table: "Medicacoes",
                column: "TipoMedicacaoId",
                unique: true);
        }
    }
}
