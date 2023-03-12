using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class UniqueFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CONCAT_PrescricaPacienteId_MedicacaoId",
                table: "PrescricoesMedicacoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CONCAT_PrescricaPacienteId_MedicacaoId",
                table: "PrescricoesMedicacoes",
                columns: new[] { "PrescricaoPacienteId", "MedicacaoId" });

            migrationBuilder.CreateIndex(
                name: "IX_PrescricoesMedicacoes_PrescricaoPacienteId",
                table: "PrescricoesMedicacoes",
                column: "PrescricaoPacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CONCAT_PrescricaPacienteId_MedicacaoId",
                table: "PrescricoesMedicacoes");

            migrationBuilder.DropIndex(
                name: "IX_PrescricoesMedicacoes_PrescricaoPacienteId",
                table: "PrescricoesMedicacoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CONCAT_PrescricaPacienteId_MedicacaoId",
                table: "PrescricoesMedicacoes",
                columns: new[] { "PrescricaoPacienteId", "MedicacaoId" })
                .Annotation("SqlServer:Clustered", false);
        }
    }
}
