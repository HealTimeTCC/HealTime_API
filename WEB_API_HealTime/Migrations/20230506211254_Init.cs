using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API_HealTime.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    DtNascPessoa = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    FotoUsuario = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
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
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "GETDATE()"),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Telefone = table.Column<string>(type: "CHAR(10)", nullable: true),
                    TelefoneSecundario = table.Column<string>(type: "CHAR(10)", nullable: true),
                    Celular = table.Column<string>(type: "CHAR(11)", nullable: false),
                    CelularSecundario = table.Column<string>(type: "CHAR(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoPessoaId", x => x.PessoaId);
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
                    table.PrimaryKey("PK_CuidadorPacientes_PacienteId_CuidadorId", x => new { x.PacienteId, x.CuidadorId, x.CriadoEm });
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
                    NroLogradouro = table.Column<int>(type: "INT", nullable: false),
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
                    AndamentoMedicacaoId = table.Column<int>(type: "int", nullable: false),
                    PrescricaoPacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicacaoId = table.Column<int>(type: "int", nullable: false),
                    MtAndamentoMedicacao = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    QtdeMedicao = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    BaixaAndamentoMedicacao = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MtBaixaMedicacao = table.Column<DateTime>(type: "datetime2(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AndamentoMedicacao_AndamentoMedicacaoId_PrescricaoPacienteId_MedicacaoId", x => new { x.AndamentoMedicacaoId, x.PrescricaoPacienteId, x.MedicacaoId });
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
                    PrescricaoMedicacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescricaoPacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicacaoId = table.Column<int>(type: "int", nullable: false),
                    Qtde = table.Column<double>(type: "FLOAT(10)", nullable: false),
                    Intervalo = table.Column<TimeSpan>(type: "TIME", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    StatusMedicacaoFlag = table.Column<string>(type: "CHAR(1)", nullable: true, defaultValue: "S"),
                    HorariosDefinidos = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONCAT_PrescricaPacienteId_MedicacaoId", x => new { x.PrescricaoPacienteId, x.MedicacaoId, x.PrescricaoMedicacaoId });
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
                        onDelete: ReferentialAction.Restrict);
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
                table: "GrauParentesco",
                columns: new[] { "GrauParentescoId", "DescGrauParentesco" },
                values: new object[,]
                {
                    { 1, "Mãe" },
                    { 2, "Pai" },
                    { 3, "Filha/Filho" }
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
                columns: new[] { "PessoaId", "CpfPessoa", "DtNascPessoa", "FotoUsuario", "NomePessoa", "PasswordHash", "PasswordSalt", "SobreNomePessoa", "TipoPessoa" },
                values: new object[,]
                {
                    { 1, "67146867064", new DateTime(2004, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Responsavel", new byte[] { 126, 220, 191, 245, 176, 86, 8, 22, 177, 148, 8, 114, 146, 219, 44, 252, 206, 227, 226, 223, 118, 151, 2, 216, 221, 190, 150, 53, 106, 200, 95, 225, 134, 187, 121, 240, 218, 196, 244, 240, 48, 94, 8, 0, 124, 188, 3, 230, 175, 192, 208, 210, 202, 92, 184, 245, 236, 191, 251, 193, 207, 196, 167, 128 }, new byte[] { 254, 193, 104, 183, 154, 190, 7, 59, 173, 189, 127, 108, 202, 18, 74, 225, 24, 135, 34, 174, 52, 187, 173, 235, 173, 211, 136, 162, 26, 104, 7, 83, 233, 238, 249, 100, 209, 128, 159, 77, 140, 190, 119, 241, 6, 84, 86, 118, 236, 171, 16, 132, 152, 27, 28, 208, 54, 159, 127, 107, 106, 209, 242, 150, 218, 7, 129, 113, 138, 208, 254, 237, 129, 193, 43, 235, 194, 92, 224, 251, 3, 9, 184, 68, 93, 98, 224, 200, 236, 28, 167, 213, 190, 27, 151, 111, 180, 173, 104, 28, 69, 180, 76, 223, 114, 160, 168, 223, 71, 120, 24, 65, 123, 176, 206, 144, 9, 187, 242, 21, 61, 4, 190, 36, 183, 129, 18, 213 }, "Marzo", 3 },
                    { 2, "15063626050", new DateTime(2004, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PacienteIncapaz", new byte[] { 126, 220, 191, 245, 176, 86, 8, 22, 177, 148, 8, 114, 146, 219, 44, 252, 206, 227, 226, 223, 118, 151, 2, 216, 221, 190, 150, 53, 106, 200, 95, 225, 134, 187, 121, 240, 218, 196, 244, 240, 48, 94, 8, 0, 124, 188, 3, 230, 175, 192, 208, 210, 202, 92, 184, 245, 236, 191, 251, 193, 207, 196, 167, 128 }, new byte[] { 254, 193, 104, 183, 154, 190, 7, 59, 173, 189, 127, 108, 202, 18, 74, 225, 24, 135, 34, 174, 52, 187, 173, 235, 173, 211, 136, 162, 26, 104, 7, 83, 233, 238, 249, 100, 209, 128, 159, 77, 140, 190, 119, 241, 6, 84, 86, 118, 236, 171, 16, 132, 152, 27, 28, 208, 54, 159, 127, 107, 106, 209, 242, 150, 218, 7, 129, 113, 138, 208, 254, 237, 129, 193, 43, 235, 194, 92, 224, 251, 3, 9, 184, 68, 93, 98, 224, 200, 236, 28, 167, 213, 190, 27, 151, 111, 180, 173, 104, 28, 69, 180, 76, 223, 114, 160, 168, 223, 71, 120, 24, 65, 123, 176, 206, 144, 9, 187, 242, 21, 61, 4, 190, 36, 183, 129, 18, 213 }, "Marzo", 2 },
                    { 3, "94840911053", new DateTime(2004, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cuidador", new byte[] { 126, 220, 191, 245, 176, 86, 8, 22, 177, 148, 8, 114, 146, 219, 44, 252, 206, 227, 226, 223, 118, 151, 2, 216, 221, 190, 150, 53, 106, 200, 95, 225, 134, 187, 121, 240, 218, 196, 244, 240, 48, 94, 8, 0, 124, 188, 3, 230, 175, 192, 208, 210, 202, 92, 184, 245, 236, 191, 251, 193, 207, 196, 167, 128 }, new byte[] { 254, 193, 104, 183, 154, 190, 7, 59, 173, 189, 127, 108, 202, 18, 74, 225, 24, 135, 34, 174, 52, 187, 173, 235, 173, 211, 136, 162, 26, 104, 7, 83, 233, 238, 249, 100, 209, 128, 159, 77, 140, 190, 119, 241, 6, 84, 86, 118, 236, 171, 16, 132, 152, 27, 28, 208, 54, 159, 127, 107, 106, 209, 242, 150, 218, 7, 129, 113, 138, 208, 254, 237, 129, 193, 43, 235, 194, 92, 224, 251, 3, 9, 184, 68, 93, 98, 224, 200, 236, 28, 167, 213, 190, 27, 151, 111, 180, 173, 104, 28, 69, 180, 76, 223, 114, 160, 168, 223, 71, 120, 24, 65, 123, 176, 206, 144, 9, 187, 242, 21, 61, 4, 190, 36, 183, 129, 18, 213 }, "Marzo", 4 },
                    { 4, "50967422027", new DateTime(2004, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paciente", new byte[] { 126, 220, 191, 245, 176, 86, 8, 22, 177, 148, 8, 114, 146, 219, 44, 252, 206, 227, 226, 223, 118, 151, 2, 216, 221, 190, 150, 53, 106, 200, 95, 225, 134, 187, 121, 240, 218, 196, 244, 240, 48, 94, 8, 0, 124, 188, 3, 230, 175, 192, 208, 210, 202, 92, 184, 245, 236, 191, 251, 193, 207, 196, 167, 128 }, new byte[] { 254, 193, 104, 183, 154, 190, 7, 59, 173, 189, 127, 108, 202, 18, 74, 225, 24, 135, 34, 174, 52, 187, 173, 235, 173, 211, 136, 162, 26, 104, 7, 83, 233, 238, 249, 100, 209, 128, 159, 77, 140, 190, 119, 241, 6, 84, 86, 118, 236, 171, 16, 132, 152, 27, 28, 208, 54, 159, 127, 107, 106, 209, 242, 150, 218, 7, 129, 113, 138, 208, 254, 237, 129, 193, 43, 235, 194, 92, 224, 251, 3, 9, 184, 68, 93, 98, 224, 200, 236, 28, 167, 213, 190, 27, 151, 111, 180, 173, 104, 28, 69, 180, 76, 223, 114, 160, 168, 223, 71, 120, 24, 65, 123, 176, 206, 144, 9, 187, 242, 21, 61, 4, 190, 36, 183, 129, 18, 213 }, "Marzo", 1 }
                });

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

            migrationBuilder.InsertData(
                table: "ContatoPessoas",
                columns: new[] { "PessoaId", "AtualizadoEm", "Celular", "CelularSecundario", "CriadoEm", "Email", "Telefone", "TelefoneSecundario" },
                values: new object[] { 1, null, "11978486810", null, new DateTime(2023, 5, 6, 18, 12, 54, 272, DateTimeKind.Local).AddTicks(6723), "user@user.com", null, null });

            migrationBuilder.InsertData(
                table: "Medicacoes",
                columns: new[] { "MedicacaoId", "CompostoAtivoMedicacao", "Generico", "LaboratorioMedicaocao", "NomeMedicacao", "StatusMedicacao", "TipoMedicacaoId" },
                values: new object[,]
                {
                    { 1, "pirazolônico não narcótico ", "S", "Algum por ai", "DIPIRONA 300ml", 1, 1 },
                    { 2, "EXEMPLO ", "N", "Algum outro por ai", "EXEMPLO", 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AndamentoMedicacoes_MedicacaoId",
                table: "AndamentoMedicacoes",
                column: "MedicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AndamentoMedicacoes_PrescricaoPacienteId",
                table: "AndamentoMedicacoes",
                column: "PrescricaoPacienteId");

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
                name: "IX_ContatoPessoas_Celular",
                table: "ContatoPessoas",
                column: "Celular");

            migrationBuilder.CreateIndex(
                name: "IX_ContatoPessoas_Email",
                table: "ContatoPessoas",
                column: "Email",
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
                name: "UNIQUE_ON_CPF",
                table: "Pessoas",
                column: "CpfPessoa",
                unique: true);

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
                column: "MedicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisPacientes_GrauParentescoId",
                table: "ResponsaveisPacientes",
                column: "GrauParentescoId");

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
