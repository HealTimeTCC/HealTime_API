using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    /// <inheritdoc />
    public partial class AdendoContatoPessoa : Migration
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
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<string>(type: "varchar(40)", nullable: false),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    NomePessoa = table.Column<string>(type: "varchar(25)", nullable: true),
                    SobrenomePessoa = table.Column<string>(type: "varchar(40)", nullable: true),
                    CpfPessoa = table.Column<string>(type: "char(11)", nullable: true),
                    DtUltimoAcesso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtNascimentoPesssoa = table.Column<DateTime>(type: "date", nullable: false),
                    GeneroPessoa = table.Column<int>(type: "int", nullable: false),
                    ObsPacienteIncapaz = table.Column<string>(type: "varchar(350)", nullable: true),
                    EnderecoPessoa = table.Column<string>(type: "varchar(45)", nullable: true),
                    BairroEnderecoPessoa = table.Column<string>(type: "varchar(30)", nullable: true),
                    CidadeEnderecoPessoa = table.Column<string>(type: "varchar(20)", nullable: true),
                    ComplementoPessoa = table.Column<string>(type: "varchar(45)", nullable: true),
                    CepEndereco = table.Column<string>(type: "char(8)", nullable: true),
                    UfEndereco = table.Column<int>(type: "int", nullable: false)
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
                    PessoaId = table.Column<string>(type: "varchar(40)", nullable: true),
                    TelefoneCelularObri = table.Column<string>(type: "VARCHAR(11)", nullable: true),
                    TelefoneCelularOpcional = table.Column<string>(type: "VARCHAR(11)", nullable: true),
                    TelefoneFixo = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    EmailContato = table.Column<string>(type: "VARCHAR(70)", nullable: true),
                    TipoCtt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoPessoas", x => x.ContatoId);
                    table.ForeignKey(
                        name: "FK_ContatoPessoas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId");
                });

            migrationBuilder.CreateTable(
                name: "ResponsaveisPaciente",
                columns: table => new
                {
                    ResponsavelPacienteId = table.Column<int>(type: "int", nullable: false),
                    PacienteInId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteIdPessoaId = table.Column<string>(type: "varchar(40)", nullable: true),
                    ResponsavelId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "IX_ContatoPessoas_PessoaId",
                table: "ContatoPessoas",
                column: "PessoaId");

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
                name: "ContatoPessoas");

            migrationBuilder.DropTable(
                name: "ResponsaveisPaciente");

            migrationBuilder.DropTable(
                name: "GrausParentesco");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
