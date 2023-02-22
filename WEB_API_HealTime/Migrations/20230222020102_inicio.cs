using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
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
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ObsPacienteIncapaz = table.Column<string>(type: "VARCHAR(350)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMedicacoes",
                columns: table => new
                {
                    TipoMedicacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TituloTipoMedicacao = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ClasseAplicacao = table.Column<int>(type: "int", nullable: false),
                    DescMedicacao = table.Column<string>(type: "VARCHAR(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMedicamentoId", x => x.TipoMedicacaoId);
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
                name: "EnderecoPessoas",
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
                    DataCadastroSistemaPrescricao = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true, defaultValueSql: "GETDATE()"),
                    EmissaoPrescricao = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false)
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
                name: "Medicacoes",
                columns: table => new
                {
                    MedicacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    TipoMedicacaoId = table.Column<int>(type: "int", nullable: false),
                    Composicao = table.Column<int>(type: "int", nullable: false),
                    StatusMedicacao = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    QtdMedicacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicacaoId", x => x.MedicacaoId);
                    table.ForeignKey(
                        name: "FK_Medicacao_TipoMedicacao_TipoMedicacaoId",
                        column: x => x.TipoMedicacaoId,
                        principalTable: "TipoMedicacoes",
                        principalColumn: "TipoMedicacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    MedicacaoId = table.Column<int>(type: "int", nullable: false),
                    QtdEstoque = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    Desc = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true, defaultValueSql: "GETDATE()"),
                    CriadoEm = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque_EstoqueId", x => x.MedicacaoId);
                    table.ForeignKey(
                        name: "FK_Estoque_Medicacoes",
                        column: x => x.MedicacaoId,
                        principalTable: "Medicacoes",
                        principalColumn: "MedicacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescricaoMedicamentos",
                columns: table => new
                {
                    PrescricaoMedicamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescricaoPacienteId = table.Column<int>(type: "int", nullable: true),
                    NomeMedicamento = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    HrInicioDtMedicacao = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    DtTerminoTratamento = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    IntervaloMedicacao = table.Column<int>(type: "int", nullable: true),
                    QtdDiariaMedia = table.Column<int>(type: "int", nullable: false),
                    CheckSituacao = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    MedicacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescricaoMedicamentoId", x => x.PrescricaoMedicamentoId);
                    table.ForeignKey(
                        name: "FK_PrescricaoMedicamento_Medicacoes__MedicamentoId",
                        column: x => x.MedicacaoId,
                        principalTable: "Medicacoes",
                        principalColumn: "MedicacaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescricaoPacienteId",
                        column: x => x.PrescricaoPacienteId,
                        principalTable: "PrescricaoPacientes",
                        principalColumn: "PrescricaoPacienteId");
                });

            migrationBuilder.CreateTable(
                name: "BaixaHistoricoEstoque",
                columns: table => new
                {
                    BaixaHistoricoEstoqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstoqueId = table.Column<int>(type: "int", nullable: false),
                    BaixaEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DescBaixa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaixaHistoricoEstoqueId", x => x.BaixaHistoricoEstoqueId);
                    table.ForeignKey(
                        name: "FK_Estoque_BaixaHistoricoEstoques",
                        column: x => x.EstoqueId,
                        principalTable: "Estoque",
                        principalColumn: "MedicacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AndamentoMedicacao",
                columns: table => new
                {
                    AndamentoMedicacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescricaoMedicamentoId = table.Column<int>(type: "int", nullable: false),
                    QtdInicial = table.Column<int>(type: "int", nullable: false),
                    QtdAtual = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AndamentoMedicacaoId", x => x.AndamentoMedicacaoId);
                    table.ForeignKey(
                        name: "FK_PrescricaoMedicamentoId",
                        column: x => x.PrescricaoMedicamentoId,
                        principalTable: "PrescricaoMedicamentos",
                        principalColumn: "PrescricaoMedicamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoMedicacoes",
                columns: new[] { "TipoMedicacaoId", "ClasseAplicacao", "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[,]
                {
                    { 1, 1, "Aplicação pela boca", "Via oral" },
                    { 2, 1, "Aplicação por debaixo da lingua", "Sublingual" },
                    { 3, 1, "Aplicação retal", "Supositorios" },
                    { 4, 2, "Direta no sangue", "Intravenosa" },
                    { 5, 2, "Direta no músculo", "Intramuscular" },
                    { 6, 2, "Debaixo da pele", "Subcutânea" },
                    { 7, 2, "Via que se estende desde a mucosa nasal até os pulmões", "Respiratória" },
                    { 8, 2, "Aplicação na pele (Pomadas)", "Via tópica" },
                    { 9, 2, "Aplicação direta no olho", "Via Ocular" },
                    { 10, 2, "Aplicação pelo nariz", "Via Nasal" },
                    { 11, 2, "Aplicação no ouvido", "Via Auricular" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AndamentoMedicacao_PrescricaoMedicamentoId",
                table: "AndamentoMedicacao",
                column: "PrescricaoMedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_BaixaHistoricoEstoque_EstoqueId",
                table: "BaixaHistoricoEstoque",
                column: "EstoqueId");

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
                name: "IX_Medicacoes_TipoMedicacaoId",
                table: "Medicacoes",
                column: "TipoMedicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescricaoMedicamentos_MedicacaoId",
                table: "PrescricaoMedicamentos",
                column: "MedicacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrescricaoMedicamentos_PrescricaoPacienteId",
                table: "PrescricaoMedicamentos",
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
                name: "AndamentoMedicacao");

            migrationBuilder.DropTable(
                name: "BaixaHistoricoEstoque");

            migrationBuilder.DropTable(
                name: "ContatoPessoas");

            migrationBuilder.DropTable(
                name: "CuidadorPacientes");

            migrationBuilder.DropTable(
                name: "EnderecoPessoas");

            migrationBuilder.DropTable(
                name: "ResponsaveisPacientes");

            migrationBuilder.DropTable(
                name: "PrescricaoMedicamentos");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "GrausParentesco");

            migrationBuilder.DropTable(
                name: "PrescricaoPacientes");

            migrationBuilder.DropTable(
                name: "Medicacoes");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "TipoMedicacoes");
        }
    }
}
