using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class InitNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    EspecialidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescEspecialidade = table.Column<string>(type: "VARCHAR(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadeId", x => x.EspecialidadeId);
                });

            migrationBuilder.CreateTable(
                name: "GrauParentesco",
                columns: table => new
                {
                    GrauParentescoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescGrauParentesco = table.Column<string>(type: "VARCHAR(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrauParentescoId", x => x.GrauParentescoId);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmMedico = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    CrmMedico = table.Column<string>(type: "CHAR(6)", nullable: true),
                    UfCrmMedico = table.Column<string>(type: "CHAR(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoId", x => x.MedicoId);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    CpfPessoa = table.Column<string>(type: "CHAR(11)", nullable: false),
                    NomePessoa = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    SobreNomePessoa = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DtNascPessoa = table.Column<DateTime>(type: "datetime2(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaId", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "StatusConsultas",
                columns: table => new
                {
                    StatusConsultaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescStatusConsulta = table.Column<string>(type: "VARCHAR(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusConsultaId", x => x.StatusConsultaId);
                });

            migrationBuilder.CreateTable(
                name: "TiposMedicacoes",
                columns: table => new
                {
                    TipoMedicacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescMedicacao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    TituloTipoMedicacao = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ClasseAplicacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMedicacaoId", x => x.TipoMedicacaoId);
                });

            migrationBuilder.CreateTable(
                name: "ContatoPessoas",
                columns: table => new
                {
                    ContatoPessoaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "GETDATE()"),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "CHAR(11)", nullable: false),
                    TelefoneSecundario = table.Column<string>(type: "CHAR(11)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoContato = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoPessoaId", x => x.ContatoPessoaId);
                    table.ForeignKey(
                        name: "FK_Pessoa_ContatoPessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuidadorPacientes",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    CuidadorId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "DATETIME2(0)", nullable: false),
                    FinalizadoEm = table.Column<DateTime>(type: "DATETIME2(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuidadorPacientes_PacienteId_CuidadorId", x => new { x.PacienteId, x.CuidadorId });
                    table.ForeignKey(
                        name: "FK_Pessoa_CuidadorPaciente_CuidadorId",
                        column: x => x.CuidadorId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pessoa_CuidadorPaciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoPessoas",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    NroLogradouro = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    BairroLogradouro = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    CidadeEndereco = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    UFEndereco = table.Column<string>(type: "CHAR(2)", nullable: false),
                    CEPEndereco = table.Column<string>(type: "CHAR(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FK_EnderecoPessoa", x => x.PessoaId);
                    table.ForeignKey(
                        name: "FK_PK_EnderecoPessoa",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObservacoesPacientes",
                columns: table => new
                {
                    SqObservacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MtObservacao = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SqObservacao", x => x.SqObservacao);
                    table.ForeignKey(
                        name: "FK_SqObservacao_Pessoas",
                        column: x => x.PacienteId,
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
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    Emissao = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    DescFichaPessoa = table.Column<string>(type: "VARCHAR(350)", nullable: true),
                    FlagStatus = table.Column<string>(type: "CHAR(1)", nullable: false, defaultValue: "S")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescricaoPacienteId", x => x.PrescricaoPacienteId);
                    table.ForeignKey(
                        name: "FK_PacienteId_PrescricoesPacientes",
                        column: x => x.PacienteId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescricaoPaciente_Medico",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponsaveisPacientes",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    ResponsavelId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "GETDATE()"),
                    GrauParentescoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteId_ResponsavelId", x => new { x.PacienteId, x.ResponsavelId });
                    table.ForeignKey(
                        name: "FK_GrauParentescoId_GrauParentesco_ResponsavelPaciente",
                        column: x => x.GrauParentescoId,
                        principalTable: "GrauParentesco",
                        principalColumn: "GrauParentescoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacienteId_Pessoas_ResponsavelPaciente",
                        column: x => x.PacienteId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponsavelId_Pessoas_ResponsavelPaciente",
                        column: x => x.ResponsavelId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsultasAgendadas",
                columns: table => new
                {
                    ConsultasAgendadasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusConsultaId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadeId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    DataSolicitacaoConsulta = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    DataConsulta = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    MotivoConsulta = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    Encaminhamento = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaAgendadaId", x => x.ConsultasAgendadasId);
                    table.ForeignKey(
                        name: "FK_ConsultaAgendadas_StatusConsulta",
                        column: x => x.StatusConsultaId,
                        principalTable: "StatusConsultas",
                        principalColumn: "StatusConsultaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "EspecialidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoId_ConsultaAgendadaId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicacoes",
                columns: table => new
                {
                    MedicacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusMedicacao = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    TipoMedicacaoId = table.Column<int>(type: "int", nullable: false),
                    NomeMedicacao = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    CompostoAtivoMedicacao = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    LaboratorioMedicaocao = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Generico = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicacaoId", x => x.MedicacaoId);
                    table.ForeignKey(
                        name: "FK_Medicacao_TipoMedicacao",
                        column: x => x.TipoMedicacaoId,
                        principalTable: "TiposMedicacoes",
                        principalColumn: "TipoMedicacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AndamentoMedicacoes",
                columns: table => new
                {
                    MtAndamentoMedicacao = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    PrescricaoPacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicacaoId = table.Column<int>(type: "int", nullable: false),
                    QtdeMedicao = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    AcaoMedicacao = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AndamentoMedicacao_MtAndamentoMedicacao_PrescricaoPacienteId_MedicacaoId", x => new { x.MtAndamentoMedicacao, x.PrescricaoPacienteId, x.MedicacaoId });
                    table.ForeignKey(
                        name: "FK_PrescricaoPaciente_MedicacaoId_AndamentoMedicacoes",
                        column: x => x.MedicacaoId,
                        principalTable: "PrescricaoPacientes",
                        principalColumn: "PrescricaoPacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultaCanceladas",
                columns: table => new
                {
                    ConsultaCanceladaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultaAgendadaId = table.Column<int>(type: "int", nullable: false),
                    MotivoCancelamento = table.Column<string>(type: "VARCHAR(300)", nullable: false),
                    DataCancelamento = table.Column<DateTime>(type: "datetime2(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaCancelada_ConsultaAgendada", x => new { x.ConsultaCanceladaId, x.ConsultaAgendadaId });
                    table.ForeignKey(
                        name: "FK_ConsultaAgendadaId",
                        column: x => x.ConsultaAgendadaId,
                        principalTable: "ConsultasAgendadas",
                        principalColumn: "ConsultasAgendadasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescricoesMedicacoes",
                columns: table => new
                {
                    PrescricaoPacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicacaoId = table.Column<int>(type: "int", nullable: false),
                    Qtde = table.Column<int>(type: "int", nullable: false),
                    Intervalo = table.Column<int>(type: "int", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    StatusMedicacaoFlag = table.Column<string>(type: "CHAR(1)", nullable: true, defaultValue: "S")
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

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "EspecialidadeId", "DescEspecialidade" },
                values: new object[,]
                {
                    { 1, "Cardiologia" },
                    { 2, "Dermatologia" },
                    { 3, "Ginecologia/Obstetrícia" },
                    { 4, "Ortopedia" },
                    { 5, "Anestesiologia" },
                    { 6, "Pediatria" },
                    { 7, "Oftalmologia" },
                    { 8, "Psiquiatria" },
                    { 9, "Urologia" },
                    { 10, "Oncologia" },
                    { 11, "Endocrinologia" },
                    { 12, "Neurologia" },
                    { 13, "Hematologia" },
                    { 14, "Cirurgia Plástica" }
                });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "MedicoId", "CrmMedico", "NmMedico", "UfCrmMedico" },
                values: new object[,]
                {
                    { 1, "054321", "Dr Val", "SP" },
                    { 2, "012345", "Dr Teste", "RJ" }
                });

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "PessoaId", "CpfPessoa", "DtNascPessoa", "NomePessoa", "PasswordHash", "PasswordSalt", "SobreNomePessoa", "TipoPessoa" },
                values: new object[] { 1, "12345678909", new DateTime(2004, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dan", new byte[] { 255, 202, 227, 108, 69, 125, 79, 91, 32, 213, 46, 202, 197, 10, 220, 249, 246, 21, 94, 154, 51, 88, 98, 114, 109, 40, 51, 232, 135, 246, 73, 64, 197, 230, 172, 218, 72, 235, 87, 29, 159, 129, 175, 92, 115, 48, 160, 97, 130, 204, 88, 85, 140, 142, 41, 244, 87, 136, 81, 46, 58, 214, 161, 88 }, new byte[] { 6, 219, 162, 188, 27, 39, 91, 197, 60, 207, 205, 173, 169, 90, 253, 23, 183, 216, 245, 81, 95, 14, 53, 156, 62, 40, 41, 225, 239, 189, 253, 149, 20, 26, 100, 203, 146, 94, 184, 102, 243, 248, 222, 234, 137, 33, 168, 201, 184, 217, 121, 239, 210, 128, 161, 20, 199, 87, 108, 138, 44, 74, 37, 241, 5, 77, 106, 249, 35, 145, 83, 118, 27, 168, 169, 18, 28, 190, 168, 65, 69, 126, 229, 4, 243, 80, 36, 129, 88, 225, 115, 227, 124, 49, 50, 78, 237, 172, 62, 157, 67, 60, 60, 97, 227, 254, 42, 253, 93, 40, 72, 231, 55, 149, 85, 134, 198, 208, 121, 98, 100, 86, 108, 116, 140, 64, 50, 42 }, "Marzo", 3 });

            migrationBuilder.InsertData(
                table: "StatusConsultas",
                columns: new[] { "StatusConsultaId", "DescStatusConsulta" },
                values: new object[,]
                {
                    { 1, "Agendada" },
                    { 2, "Encerrada" },
                    { 3, "Cancelada" },
                    { 4, "Remarcada" },
                    { 5, "Fila de espera" }
                });

            migrationBuilder.InsertData(
                table: "TiposMedicacoes",
                columns: new[] { "TipoMedicacaoId", "ClasseAplicacao", "DescMedicacao", "TituloTipoMedicacao" },
                values: new object[,]
                {
                    { 1, 1, "Aplicado pela boca", "Via oral" },
                    { 2, 1, "Aplicado  por dembaixo da língua", "Sublingual" },
                    { 3, 1, "Aplicado pelo canal retal", "Supositorios" },
                    { 4, 2, "Aplicada diretamente no sangue", "Intravenosa" },
                    { 5, 2, "Aplicada diretamente no músculo", "Intramuscular" },
                    { 6, 2, "Aplicada debaixo da pele", "Subcutânea" },
                    { 7, 2, "", "Respiratória" },
                    { 8, 2, "Aplicada por pomadas", "Via tópica" },
                    { 9, 2, "", "Via Ocular" },
                    { 10, 2, "", "Via Nasal" },
                    { 11, 2, "", "Via Auricular" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AndamentoMedicacoes_MedicacaoId",
                table: "AndamentoMedicacoes",
                column: "MedicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaCanceladas_ConsultaAgendadaId",
                table: "ConsultaCanceladas",
                column: "ConsultaAgendadaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasAgendadas_EspecialidadeId",
                table: "ConsultasAgendadas",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasAgendadas_MedicoId",
                table: "ConsultasAgendadas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasAgendadas_StatusConsultaId",
                table: "ConsultasAgendadas",
                column: "StatusConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContatoPessoas_PessoaId",
                table: "ContatoPessoas",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuidadorPacientes_CuidadorId",
                table: "CuidadorPacientes",
                column: "CuidadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicacoes_TipoMedicacaoId",
                table: "Medicacoes",
                column: "TipoMedicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ObservacoesPacientes_PacienteId",
                table: "ObservacoesPacientes",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescricaoPacientes_MedicoId",
                table: "PrescricaoPacientes",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescricaoPacientes_PacienteId",
                table: "PrescricaoPacientes",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescricoesMedicacoes_MedicacaoId",
                table: "PrescricoesMedicacoes",
                column: "MedicacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrescricoesMedicacoes_PrescricaoPacienteId",
                table: "PrescricoesMedicacoes",
                column: "PrescricaoPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisPacientes_GrauParentescoId",
                table: "ResponsaveisPacientes",
                column: "GrauParentescoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisPacientes_ResponsavelId",
                table: "ResponsaveisPacientes",
                column: "ResponsavelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AndamentoMedicacoes");

            migrationBuilder.DropTable(
                name: "ConsultaCanceladas");

            migrationBuilder.DropTable(
                name: "ContatoPessoas");

            migrationBuilder.DropTable(
                name: "CuidadorPacientes");

            migrationBuilder.DropTable(
                name: "EnderecoPessoas");

            migrationBuilder.DropTable(
                name: "ObservacoesPacientes");

            migrationBuilder.DropTable(
                name: "PrescricoesMedicacoes");

            migrationBuilder.DropTable(
                name: "ResponsaveisPacientes");

            migrationBuilder.DropTable(
                name: "ConsultasAgendadas");

            migrationBuilder.DropTable(
                name: "Medicacoes");

            migrationBuilder.DropTable(
                name: "PrescricaoPacientes");

            migrationBuilder.DropTable(
                name: "GrauParentesco");

            migrationBuilder.DropTable(
                name: "StatusConsultas");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "TiposMedicacoes");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
