using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class corrigindoRelacioamentos_parteII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PrescricaoPacientes_MedicoId",
                table: "PrescricaoPacientes");

            migrationBuilder.CreateIndex(
                name: "IX_PrescricaoPacientes_MedicoId",
                table: "PrescricaoPacientes",
                column: "MedicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PrescricaoPacientes_MedicoId",
                table: "PrescricaoPacientes");

            migrationBuilder.CreateIndex(
                name: "IX_PrescricaoPacientes_MedicoId",
                table: "PrescricaoPacientes",
                column: "MedicoId",
                unique: true);
        }
    }
}
