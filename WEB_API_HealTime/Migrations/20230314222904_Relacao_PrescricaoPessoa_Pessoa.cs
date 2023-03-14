using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class Relacao_PrescricaoPessoa_Pessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PrescricaoPacientes_PacienteId",
                table: "PrescricaoPacientes",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteId_PrescricoesPacientes",
                table: "PrescricaoPacientes",
                column: "PacienteId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacienteId_PrescricoesPacientes",
                table: "PrescricaoPacientes");

            migrationBuilder.DropIndex(
                name: "IX_PrescricaoPacientes_PacienteId",
                table: "PrescricaoPacientes");
        }
    }
}
