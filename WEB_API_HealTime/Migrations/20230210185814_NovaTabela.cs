using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class NovaTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrausParentesco",
                columns: table => new
                {
                    GrauParentescoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescGrauParentesco = table.Column<string>(type: "VARCHAR(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrauParentescoId", x => x.GrauParentescoId);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    NomePessoa = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    SobrenomePessoa = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CpfPessoa = table.Column<string>(type: "CHAR(11)", nullable: true),
                    DtUltimoAcesso = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true, defaultValueSql: "GETDATE()"),
                    DtNascimentoPessoa = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    GeneroPessoa = table.Column<int>(type: "int", nullable: false),
                    ObsPacienteIncapaz = table.Column<string>(type: "VARCHAR(350)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "ContatoPessoas",
                columns: table => new
                {
                    ContatoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    TelefoneCelularObri = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    TelefoneCelularOpcional = table.Column<string>(type: "VARCHAR(11)", nullable: true),
                    TelefoneFixo = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    EmailContato = table.Column<string>(type: "VARCHAR(70)", nullable: true),
                    TipoCtt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoPessoas", x => x.ContatoId);
                    table.ForeignKey(
                        name: "FK_Pessoas_ContatosPessoas",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuidadorPacientes",
                columns: table => new
                {
                    CuidadorPacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuidadorId = table.Column<int>(type: "int", nullable: true),
                    PacienteIncapazId = table.Column<int>(type: "int", nullable: true),
                    ResponsavelId = table.Column<int>(type: "int", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuidadorPacienteId", x => x.CuidadorPacienteId);
                    table.ForeignKey(
                        name: "FK_PESSOAS_CUIDADORPACIENTE_CuidadorId",
                        column: x => x.CuidadorId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId");
                    table.ForeignKey(
                        name: "FK_PESSOAS_CUIDADORPACIENTE_PacienteIncapazId",
                        column: x => x.PacienteIncapazId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId");
                    table.ForeignKey(
                        name: "FK_PESSOAS_CUIDADORPACIENTE_RESPONSAVELID",
                        column: x => x.ResponsavelId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId");
                });

            migrationBuilder.CreateTable(
                name: "EnderecoPessoa",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    BairroEndereco = table.Column<string>(type: "VARCHAR(40)", nullable: true),
                    CidadeEndereco = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(40)", nullable: true),
                    CepEndereco = table.Column<string>(type: "CHAR(8)", nullable: false),
                    UfEndereco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoPessoa", x => x.PessoaId);
                    table.ForeignKey(
                        name: "FK_EnderecoPessoas_Pessoas",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescricaoPacientes",
                columns: table => new
                {
                    PrescricaoPacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: true),
                    DescFichaPessoa = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    Emissao = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescricaoPacienteId", x => x.PrescricaoPacienteId);
                    table.ForeignKey(
                        name: "FK_PESSOAS_PRESCRICAOPACIENTE_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId");
                });

            migrationBuilder.CreateTable(
                name: "ResponsaveisPacientes",
                columns: table => new
                {
                    ResponsavelPacienteId = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    PacienteInId = table.Column<int>(type: "int", nullable: true),
                    ResponsavelId = table.Column<int>(type: "int", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    GrauParentescoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsavelPacienteId", x => x.ResponsavelPacienteId);
                    table.ForeignKey(
                        name: "FK_PESSOAS_RESPONSAVELPACIENTE_PACIENTEINID",
                        column: x => x.PacienteInId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId");
                    table.ForeignKey(
                        name: "FK_PESSOAS_RESPONSAVELPACIENTE_RESPONSAVELID",
                        column: x => x.ResponsavelId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId");
                    table.ForeignKey(
                        name: "FK_ResponsavelPaciente_GRAUPARENTESCO",
                        column: x => x.GrauParentescoId,
                        principalTable: "GrausParentesco",
                        principalColumn: "GrauParentescoId");
                });

            migrationBuilder.CreateTable(
                name: "PrescricaoMedicamento",
                columns: table => new
                {
                    PrescricaoMedicamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescricaoPacienteId = table.Column<int>(type: "int", nullable: true),
                    HrDtMedicacao = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    DtTerminoTratamento = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    QtdDiariaMedia = table.Column<int>(type: "int", nullable: false),
                    CheckSituacao = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescricaoMedicamentoId", x => x.PrescricaoMedicamentoId);
                    table.ForeignKey(
                        name: "FK_PrescricaoPacienteId",
                        column: x => x.PrescricaoPacienteId,
                        principalTable: "PrescricaoPacientes",
                        principalColumn: "PrescricaoPacienteId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContatoPessoas_PessoaId",
                table: "ContatoPessoas",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_CuidadorPacientes_CuidadorId",
                table: "CuidadorPacientes",
                column: "CuidadorId");

            migrationBuilder.CreateIndex(
                name: "IX_CuidadorPacientes_PacienteIncapazId",
                table: "CuidadorPacientes",
                column: "PacienteIncapazId");

            migrationBuilder.CreateIndex(
                name: "IX_CuidadorPacientes_ResponsavelId",
                table: "CuidadorPacientes",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescricaoMedicamento_PrescricaoPacienteId",
                table: "PrescricaoMedicamento",
                column: "PrescricaoPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescricaoPacientes_PacienteId",
                table: "PrescricaoPacientes",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisPacientes_GrauParentescoId",
                table: "ResponsaveisPacientes",
                column: "GrauParentescoId",
                unique: true,
                filter: "[GrauParentescoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisPacientes_PacienteInId",
                table: "ResponsaveisPacientes",
                column: "PacienteInId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisPacientes_ResponsavelId",
                table: "ResponsaveisPacientes",
                column: "ResponsavelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContatoPessoas");

            migrationBuilder.DropTable(
                name: "CuidadorPacientes");

            migrationBuilder.DropTable(
                name: "EnderecoPessoa");

            migrationBuilder.DropTable(
                name: "PrescricaoMedicamento");

            migrationBuilder.DropTable(
                name: "ResponsaveisPacientes");

            migrationBuilder.DropTable(
                name: "PrescricaoPacientes");

            migrationBuilder.DropTable(
                name: "GrausParentesco");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
