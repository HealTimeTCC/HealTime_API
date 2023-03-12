using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class RelationTipoMedicamento_Medicamento_Status_medicamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicacoes_StatusMedicacoes_StatusMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicacoes_TiposMedicacoes_TipoMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Medicacoes_StatusMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Medicacoes_TipoMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.RenameTable(
                name: "PrescricaoMedicacao",
                newName: "PrescricoesMedicacoes");

            migrationBuilder.RenameIndex(
                name: "IX_PrescricaoMedicacao_MedicacaoId",
                table: "PrescricoesMedicacoes",
                newName: "IX_PrescricoesMedicacoes_MedicacaoId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Medicacao_StatusMedicacao",
                table: "Medicacoes",
                column: "StatusMedicacaoId",
                principalTable: "StatusMedicacoes",
                principalColumn: "StatusMedicacaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicacao_TipoMedicacao",
                table: "Medicacoes",
                column: "TipoMedicacaoId",
                principalTable: "TiposMedicacoes",
                principalColumn: "TipoMedicacaoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicacao_StatusMedicacao",
                table: "Medicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicacao_TipoMedicacao",
                table: "Medicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Medicacoes_StatusMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Medicacoes_TipoMedicacaoId",
                table: "Medicacoes");

            migrationBuilder.RenameTable(
                name: "PrescricoesMedicacoes",
                newName: "PrescricaoMedicacao");

            migrationBuilder.RenameIndex(
                name: "IX_PrescricoesMedicacoes_MedicacaoId",
                table: "PrescricaoMedicacao",
                newName: "IX_PrescricaoMedicacao_MedicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicacoes_StatusMedicacaoId",
                table: "Medicacoes",
                column: "StatusMedicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicacoes_TipoMedicacaoId",
                table: "Medicacoes",
                column: "TipoMedicacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicacoes_StatusMedicacoes_StatusMedicacaoId",
                table: "Medicacoes",
                column: "StatusMedicacaoId",
                principalTable: "StatusMedicacoes",
                principalColumn: "StatusMedicacaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicacoes_TiposMedicacoes_TipoMedicacaoId",
                table: "Medicacoes",
                column: "TipoMedicacaoId",
                principalTable: "TiposMedicacoes",
                principalColumn: "TipoMedicacaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
