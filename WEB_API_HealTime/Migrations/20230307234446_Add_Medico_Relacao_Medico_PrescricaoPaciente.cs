using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class Add_Medico_Relacao_Medico_PrescricaoPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmMedico = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    CrmMedico = table.Column<int>(type: "INT", nullable: false),
                    UfCrmMedico = table.Column<string>(type: "CHAR(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoId", x => x.MedicoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescricaoPacientes_MedicoId",
                table: "PrescricaoPacientes",
                column: "MedicoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescricaoPaciente_Medico",
                table: "PrescricaoPacientes",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "MedicoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescricaoPaciente_Medico",
                table: "PrescricaoPacientes");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_PrescricaoPacientes_MedicoId",
                table: "PrescricaoPacientes");
        }
    }
}
