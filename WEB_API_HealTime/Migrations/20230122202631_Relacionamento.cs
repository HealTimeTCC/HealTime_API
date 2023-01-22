using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class Relacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrausParentesco",
                columns: table => new
                {
                    GrauParentescoId = table.Column<int>(type: "int", nullable: false),
                    DescGrauParentesco = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrausParentesco", x => x.GrauParentescoId);
                });

            migrationBuilder.CreateTable(
                name: "ResponsaveisPaciente",
                columns: table => new
                {
                    ResponsavelPacienteId = table.Column<int>(type: "int", nullable: false),
                    PacienteInId = table.Column<int>(type: "int", nullable: false),
                    PacienteIdPessoaId = table.Column<string>(type: "varchar(40)", nullable: true),
                    ResponsavelId = table.Column<int>(type: "int", nullable: false),
                    IdResponsavelPessoaId = table.Column<string>(type: "varchar(40)", nullable: true),
                    GrauParentescoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsaveisPaciente", x => x.ResponsavelPacienteId);
                    table.ForeignKey(
                        name: "FK_ResponsaveisPaciente_GrausParentesco_GrauParentescoId",
                        column: x => x.GrauParentescoId,
                        principalTable: "GrausParentesco",
                        principalColumn: "GrauParentescoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponsaveisPaciente_Pessoas_IdResponsavelPessoaId",
                        column: x => x.IdResponsavelPessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId");
                    table.ForeignKey(
                        name: "FK_ResponsaveisPaciente_Pessoas_PacienteIdPessoaId",
                        column: x => x.PacienteIdPessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisPaciente_GrauParentescoId",
                table: "ResponsaveisPaciente",
                column: "GrauParentescoId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisPaciente_IdResponsavelPessoaId",
                table: "ResponsaveisPaciente",
                column: "IdResponsavelPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisPaciente_PacienteIdPessoaId",
                table: "ResponsaveisPaciente",
                column: "PacienteIdPessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponsaveisPaciente");

            migrationBuilder.DropTable(
                name: "GrausParentesco");
        }
    }
}
