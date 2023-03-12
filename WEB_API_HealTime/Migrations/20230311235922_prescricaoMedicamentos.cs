using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class prescricaoMedicamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrescricaoMedicacao",
                columns: table => new
                {
                    PrescricaoPacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicacaoId = table.Column<int>(type: "int", nullable: false),
                    Qtde = table.Column<int>(type: "int", nullable: false),
                    Intervalo = table.Column<int>(type: "int", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONCAT_PrescricaPacienteId_MedicacaoId", x => new { x.PrescricaoPacienteId, x.MedicacaoId });
                    table.ForeignKey(
                        name: "PK_MedicacaoId_PrescricaoMedicao",
                        column: x => x.MedicacaoId,
                        principalTable: "Medicacoes",
                        principalColumn: "MedicacaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "PK_PrescricaoPacienteId_PrescricaoMedicao",
                        column: x => x.PrescricaoPacienteId,
                        principalTable: "PrescricaoPacientes",
                        principalColumn: "PrescricaoPacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescricaoMedicacao_MedicacaoId",
                table: "PrescricaoMedicacao",
                column: "MedicacaoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescricaoMedicacao");
        }
    }
}
