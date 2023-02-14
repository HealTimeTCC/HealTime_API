using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class TipoMedicacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicacoes_TipoMedicacao_TipoMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Medicacoes_TipoMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.CreateIndex(
                name: "IX_Medicacoes_TipoMedicacaoId",
                table: "Medicacoes",
                column: "TipoMedicacaoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicacao_TipoMedicacao_TipoMedicacaoId",
                table: "Medicacoes",
                column: "TipoMedicacaoId",
                principalTable: "TipoMedicacao",
                principalColumn: "TipoMedicacaoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicacao_TipoMedicacao_TipoMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Medicacoes_TipoMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.CreateIndex(
                name: "IX_Medicacoes_TipoMedicacaoId",
                table: "Medicacoes",
                column: "TipoMedicacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicacoes_TipoMedicacao_TipoMedicacaoId",
                table: "Medicacoes",
                column: "TipoMedicacaoId",
                principalTable: "TipoMedicacao",
                principalColumn: "TipoMedicacaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
