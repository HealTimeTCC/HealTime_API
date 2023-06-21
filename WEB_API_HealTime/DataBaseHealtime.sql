CREATE DATABASE [DB-HEALTIME]
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Especialidades] (
    [EspecialidadeId] INT NOT NULL IDENTITY,
    [DescEspecialidade] VARCHAR(25) NOT NULL,
    CONSTRAINT [PK_EspecialidadeId] 
		PRIMARY KEY ([EspecialidadeId])
);
GO

CREATE TABLE [GrauParentesco] (
    [GrauParentescoId] INT NOT NULL IDENTITY,
    [DescGrauParentesco] VARCHAR(15) NOT NULL,
    CONSTRAINT [PK_GrauParentescoId] 
		PRIMARY KEY ([GrauParentescoId])
);
GO

CREATE TABLE [Medicos] (
    [MedicoId] INT NOT NULL IDENTITY,
    [NmMedico] VARCHAR(40) NOT NULL,
    [CrmMedico] CHAR(6) NULL,
    [UfCrmMedico] CHAR(2) NOT NULL,
    CONSTRAINT [PK_MedicoId] 
		PRIMARY KEY ([MedicoId])
);
GO

CREATE TABLE [Pessoas] (
    [PessoaId] INT NOT NULL IDENTITY,
    [TipoPessoa] INT NOT NULL,
    [CpfPessoa] CHAR(11) NOT NULL,
    [NomePessoa] VARCHAR(25) NOT NULL,
    [SobreNomePessoa] VARCHAR(30) NOT NULL,
    [PasswordHash] VARBINARY(MAX) NULL,
    [PasswordSalt] VARBINARY(MAX) NULL,
    [DtNascPessoa] DATETIME2(0) NOT NULL,
    [FotoUsuario] VARBINARY(MAX) NULL,
    CONSTRAINT [PK_PessoaId] 
		PRIMARY KEY ([PessoaId])
);
GO

CREATE TABLE [StatusConsultas] (
    [StatusConsultaId] INT NOT NULL IDENTITY,
    [DescStatusConsulta] VARCHAR(25) NOT NULL,
    CONSTRAINT [PK_StatusConsultaId] 
		PRIMARY KEY ([StatusConsultaId])
);
GO

CREATE TABLE [TiposMedicacoes] (
    [TipoMedicacaoId] INT NOT NULL IDENTITY,
    [DescMedicacao] VARCHAR(100) NULL,
    [TituloTipoMedicacao] VARCHAR(100) NOT NULL,
    [ClasseAplicacao] INT NOT NULL,
    CONSTRAINT [PK_TipoMedicacaoId] 
		PRIMARY KEY ([TipoMedicacaoId])
);
GO

CREATE TABLE [ContatoPessoas] (
    [PessoaId] INT NOT NULL,
    [Email] VARCHAR(100) NOT NULL,
    [CriadoEm] DATETIME2(0) NOT NULL 
		DEFAULT (GETDATE()),
    [AtualizadoEm] DATETIME2 NULL,
    [Telefone] CHAR(10) NULL,
    [TelefoneSecundario] CHAR(10) NULL,
    [Celular] CHAR(11) NOT NULL,
    [CelularSecundario] CHAR(11) NULL,
    CONSTRAINT [PK_ContatoPessoaId] 
		PRIMARY KEY ([PessoaId]),
    CONSTRAINT [FK_Pessoa_ContatoPessoa_PessoaId] 
		FOREIGN KEY ([PessoaId]) 
			REFERENCES [Pessoas] ([PessoaId]) 
				ON DELETE CASCADE
);
GO

CREATE TABLE [CuidadorPacientes] (
    [PacienteId] INT NOT NULL,
    [CuidadorId] INT NOT NULL,
    [CriadoEm] DATETIME2(0) NOT NULL,
    [FinalizadoEm] DATETIME2(0) NULL,
    CONSTRAINT [PK_CuidadorPacientes_PacienteId_CuidadorId] 
		PRIMARY KEY ([PacienteId], [CuidadorId], [CriadoEm]),
    CONSTRAINT [FK_Pessoa_CuidadorPaciente_CuidadorId] 
		FOREIGN KEY ([CuidadorId]) 
			REFERENCES [Pessoas] ([PessoaId]) 
				ON DELETE NO ACTION,
    CONSTRAINT [FK_Pessoa_CuidadorPaciente_PacienteId] 
		FOREIGN KEY ([PacienteId]) 
			REFERENCES [Pessoas] ([PessoaId]) 
				ON DELETE NO ACTION
);
GO

CREATE TABLE [EnderecoPessoas] (
    [PessoaId] INT NOT NULL,
    [Logradouro] VARCHAR(40) NOT NULL,
    [NroLogradouro] INT NOT NULL,
    [Complemento] VARCHAR(15) NULL,
    [BairroLogradouro] VARCHAR(25) NOT NULL,
    [CidadeEndereco] VARCHAR(25) NOT NULL,
    [UFEndereco] CHAR(2) NOT NULL,
    [CEPEndereco] CHAR(8) NOT NULL,
    CONSTRAINT [PK_FK_EnderecoPessoa] 
		PRIMARY KEY ([PessoaId]),
    CONSTRAINT [FK_PK_EnderecoPessoa] 
		FOREIGN KEY ([PessoaId]) 
			REFERENCES [Pessoas] ([PessoaId]) 
				ON DELETE CASCADE
);
GO

CREATE TABLE [ObservacoesPacientes] (
    [SqObservacao] INT NOT NULL IDENTITY,
    [PacienteId] INT NOT NULL,
    [MtObservacao] DATETIME2(0) NOT NULL,
    [Observacao] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_SqObservacao] 
		PRIMARY KEY ([SqObservacao]),
    CONSTRAINT [FK_SqObservacao_Pessoas] 
		FOREIGN KEY ([PacienteId]) 
			REFERENCES [Pessoas] ([PessoaId]) 
				ON DELETE CASCADE
);
GO

CREATE TABLE [PrescricaoPacientes] (
    [PrescricaoPacienteId] INT NOT NULL IDENTITY,
    [MedicoId] INT NOT NULL,
    [PacienteId] INT NOT NULL,
    [CriadoEm] DATETIME2(0) NOT NULL,
    [Emissao] DATETIME2(0) NOT NULL,
    [Validade] DATETIME2(0) NOT NULL,
    [DescFichaPessoa] VARCHAR(350) NULL,
    [FlagStatusAtivo] BIT NOT NULL DEFAULT CAST(1 AS BIT),
    CONSTRAINT [PK_PrescricaoPacienteId] 
		PRIMARY KEY ([PrescricaoPacienteId]),
    CONSTRAINT [FK_PacienteId_PrescricoesPacientes] 
		FOREIGN KEY ([PacienteId]) 
			REFERENCES [Pessoas] ([PessoaId])	
				ON DELETE CASCADE,
    CONSTRAINT [FK_PrescricaoPaciente_Medico] 
		FOREIGN KEY ([MedicoId]) 
			REFERENCES [Medicos] ([MedicoId]) 
				ON DELETE CASCADE
);
GO

CREATE TABLE [ResponsaveisPacientes] (
    [PacienteId] INT NOT NULL,
    [ResponsavelId] INT NOT NULL,
    [CriadoEm] DATETIME2(0) NOT NULL DEFAULT (GETDATE()),
    [GrauParentescoId] INT NOT NULL,
    CONSTRAINT [PK_PacienteId_ResponsavelId] 
		PRIMARY KEY ([PacienteId], [ResponsavelId]),
    CONSTRAINT [FK_GrauParentescoId_GrauParentesco_ResponsavelPaciente] 
		FOREIGN KEY ([GrauParentescoId]) 
			REFERENCES [GrauParentesco] ([GrauParentescoId]) 
				ON DELETE CASCADE,
    CONSTRAINT [FK_PacienteId_Pessoas_ResponsavelPaciente] 
		FOREIGN KEY ([PacienteId]) 
			REFERENCES [Pessoas] ([PessoaId]) 
				ON DELETE NO ACTION,
    CONSTRAINT [FK_ResponsavelId_Pessoas_ResponsavelPaciente] 
		FOREIGN KEY ([ResponsavelId]) 
			REFERENCES [Pessoas] ([PessoaId]) 
				ON DELETE NO ACTION
);
GO

CREATE TABLE [ConsultasAgendadas] (
    [ConsultasAgendadasId] INT NOT NULL IDENTITY,
    [StatusConsultaId] INT NOT NULL,
    [EspecialidadeId] INT NOT NULL,
    [PacienteId] INT NOT NULL,
    [MedicoId] INT NOT NULL,
    [DataSolicitacaoConsulta] DATETIME2(0) NOT NULL,
    [DataConsulta] DATETIME2(0) NOT NULL,
    [MotivoConsulta] VARCHAR(300) NULL,
    [Encaminhamento] CHAR(1) NOT NULL,
    CONSTRAINT [PK_ConsultaAgendadaId] 
		PRIMARY KEY ([ConsultasAgendadasId]),
    CONSTRAINT [FK_ConsultaAgendadas_StatusConsulta] 
		FOREIGN KEY ([StatusConsultaId]) 
			REFERENCES [StatusConsultas] ([StatusConsultaId]) 
				ON DELETE CASCADE,
    CONSTRAINT [FK_EspecialidadeId] 
		FOREIGN KEY ([EspecialidadeId]) 
			REFERENCES [Especialidades] ([EspecialidadeId]) 
				ON DELETE CASCADE,
    CONSTRAINT [FK_MedicoId_ConsultaAgendadaId] 
		FOREIGN KEY ([MedicoId]) 
			REFERENCES [Medicos] ([MedicoId]) 
				ON DELETE CASCADE
);
GO

CREATE TABLE [Medicacoes] (
    [MedicacaoId] INT NOT NULL IDENTITY,
    [StatusMedicacao] INT NOT NULL DEFAULT 1,
    [TipoMedicacaoId] INT NOT NULL,
    [NomeMedicacao] VARCHAR(80) NOT NULL,
    [CompostoAtivoMedicacao] VARCHAR(50) NOT NULL,
    [LaboratorioMedicacao] VARCHAR(80) NOT NULL,
    [Generico] CHAR(1) NOT NULL,
    [CodPessoaAlter] INT NOT NULL,
    CONSTRAINT [PK_MedicacaoId] 
		PRIMARY KEY ([MedicacaoId]),
    CONSTRAINT [FK_Medicacao_TipoMedicacao] 
		FOREIGN KEY ([TipoMedicacaoId]) 
			REFERENCES [TiposMedicacoes] ([TipoMedicacaoId]) 
				ON DELETE CASCADE
);
GO

CREATE TABLE [ConsultaCanceladas] (
    [ConsultaCanceladaId] INT NOT NULL IDENTITY,
    [ConsultaAgendadaId] INT NOT NULL,
    [MotivoCancelamento] VARCHAR(300) NOT NULL,
    [DataCancelamento] DATETIME2(0) NOT NULL,
    CONSTRAINT [PK_ConsultaCancelada_ConsultaAgendada] 
		PRIMARY KEY ([ConsultaCanceladaId], [ConsultaAgendadaId]),
    CONSTRAINT [FK_ConsultaAgendadaId] 
		FOREIGN KEY ([ConsultaAgendadaId]) 
			REFERENCES [ConsultasAgendadas] ([ConsultasAgendadasId])
				ON DELETE CASCADE
);
GO

CREATE TABLE [PrescricoesMedicacoes] (
    [PrescricaoMedicacaoId] INT NOT NULL IDENTITY,
    [PrescricaoPacienteId] INT NOT NULL,
    [MedicacaoId] INT NOT NULL,
    [Qtde] FLOAT(10) NOT NULL,
    [Intervalo] TIME NOT NULL,
    [Duracao] INT NOT NULL,
    [StatusMedicacaoFlag] BIT NOT NULL DEFAULT CAST(1 AS BIT),
    [HorariosDefinidos] BIT NOT NULL DEFAULT CAST(0 AS BIT),
    CONSTRAINT [PK__PrescricaPacienteId] 
		PRIMARY KEY ([PrescricaoMedicacaoId]),
    CONSTRAINT [PK_MedicacaoId_PrescricaoMedicao] 
		FOREIGN KEY ([MedicacaoId]) 
			REFERENCES [Medicacoes] ([MedicacaoId]) 
				ON DELETE CASCADE,
    CONSTRAINT [PK_PrescricaoPacienteId_PrescricaoMedicao] 
		FOREIGN KEY ([PrescricaoPacienteId]) 
			REFERENCES [PrescricaoPacientes] ([PrescricaoPacienteId]) 
				ON DELETE NO ACTION
);
GO

CREATE TABLE [AndamentoMedicacoes] (
    [AndamentoMedicacaoId] INT NOT NULL,
    [PrescricaoMedicacaoId] INT NOT NULL,
    [MedicacaoId] INT NOT NULL,
    [PrescricaoPacienteId] INT NOT NULL,
    [MtAndamentoMedicacao] DATETIME2(0) NOT NULL,
    [QtdeMedicao] INT NOT NULL,
    [CriadoEm] DATETIME2(0) NOT NULL,
    [BaixaAndamentoMedicacao] BIT NOT NULL DEFAULT CAST(0 AS BIT),
    [MtBaixaMedicacao] DATETIME2(0) NULL,
    [CodAplicadorMedicacao] INT NULL,
    CONSTRAINT [PK_AndamentoMedicacao_AndamentoMedicacaoId] 
		PRIMARY KEY ([AndamentoMedicacaoId], [PrescricaoMedicacaoId], 
					[MedicacaoId], [PrescricaoPacienteId]),
    CONSTRAINT [FK_AndamentoMedicacao_PrescricaoMedicacao] 
		FOREIGN KEY ([PrescricaoMedicacaoId]) 
			REFERENCES [PrescricoesMedicacoes] ([PrescricaoMedicacaoId]) 
				ON DELETE CASCADE
);
GO

IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'EspecialidadeId', N'DescEspecialidade') 
	AND [object_id] = OBJECT_ID(N'[Especialidades]')
	)
    SET IDENTITY_INSERT [Especialidades] ON;
INSERT INTO [Especialidades] (
	[EspecialidadeId]
	, [DescEspecialidade])
VALUES (1, 'Cardiologia'),
	   (2, 'Dermatologia'),
	   (3, 'Ginecologia/Obstetrícia'),
	   (4, 'Ortopedia'),
	   (5, 'Anestesiologia'),
	   (6, 'Pediatria'),
	   (7, 'Oftalmologia'),
	   (8, 'Psiquiatria'),
	   (9, 'Urologia'),
	   (10, 'Oncologia'),
	   (11, 'Endocrinologia'),
	   (12, 'Neurologia'),
	   (13, 'Hematologia'),
	   (14, 'Cirurgia Plástica');
IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'EspecialidadeId', N'DescEspecialidade') 
	AND [object_id] = OBJECT_ID(N'[Especialidades]')
	)
    SET IDENTITY_INSERT [Especialidades] OFF;
GO

IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'GrauParentescoId', N'DescGrauParentesco') 
	AND [object_id] = OBJECT_ID(N'[GrauParentesco]')
	)
    SET IDENTITY_INSERT [GrauParentesco] ON;
INSERT INTO [GrauParentesco] (
	[GrauParentescoId]
	, [DescGrauParentesco])
VALUES (1, 'Mãe'),
	   (2, 'Pai'),
	   (3, 'Filha/Filho'),
	   (4, 'Esposa'),
	   (5, 'Marido');
IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'GrauParentescoId', N'DescGrauParentesco') 
	AND [object_id] = OBJECT_ID(N'[GrauParentesco]')
	)
    SET IDENTITY_INSERT [GrauParentesco] OFF;
GO

IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'MedicoId', N'CrmMedico', N'NmMedico', N'UfCrmMedico') 
	AND [object_id] = OBJECT_ID(N'[Medicos]'))
    SET IDENTITY_INSERT [Medicos] ON;

INSERT INTO [Medicos] (
	[MedicoId]
	, [CrmMedico]
	, [NmMedico]
	, [UfCrmMedico])
VALUES (1, '054321'
		, 'Dr Guilherme Costa'
		, 'SP'),
	   (2
		, '012345'
		, 'Dr Adriana Gomes'
		, 'RJ');
IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'MedicoId', N'CrmMedico', N'NmMedico', N'UfCrmMedico') 
		AND [object_id] = OBJECT_ID(N'[Medicos]'))
    SET IDENTITY_INSERT [Medicos] OFF;
GO

IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'PessoaId', N'CpfPessoa', N'DtNascPessoa', N'FotoUsuario',
			N'NomePessoa', N'PasswordHash', N'PasswordSalt',
			N'SobreNomePessoa', N'TipoPessoa') 
		AND [object_id] = OBJECT_ID(N'[Pessoas]'))
    SET IDENTITY_INSERT [Pessoas] ON;
INSERT INTO [Pessoas] (
		[PessoaId]
		, [CpfPessoa]
		, [DtNascPessoa]
		, [FotoUsuario]
		, [NomePessoa]
		, [PasswordHash]
		, [PasswordSalt]
		, [SobreNomePessoa]
		, [TipoPessoa])
VALUES (1, '67146867064', '2003-12-15T00:00:00', NULL,'Mayara'
		, 0x845DC11381A18B7AF1AFA1977FE096A5737EE2DEF11D0D73798A8259BA67F18331BA152DA19D6E5F586F7DF10B8FA174F81A409B551173B9C2BA87FD33F0DC73, 0xCF9F3115CABFCB9E842E08BE90B99DFE40764B0490513E6E01D923EBB3E45C2E9BFFB653588A42DD67AC050816B59E11C97A7C7FB69E48095A45C07E5D1625A842A71B4CD059FCF0BA831F61C217122ABE8112A5AD180CE2CF2505CF09E9EF47C88FC03E44A77926DAA6538935BC12038F051E68F0F776309F66FA6FC8D961FD, 
		'Pilecarte', 3),
		(2, '94840911053', '2003-07-28T00:00:00', NULL, 'Thiago'
		, 0x845DC11381A18B7AF1AFA1977FE096A5737EE2DEF11D0D73798A8259BA67F18331BA152DA19D6E5F586F7DF10B8FA174F81A409B551173B9C2BA87FD33F0DC73, 0xCF9F3115CABFCB9E842E08BE90B99DFE40764B0490513E6E01D923EBB3E45C2E9BFFB653588A42DD67AC050816B59E11C97A7C7FB69E48095A45C07E5D1625A842A71B4CD059FCF0BA831F61C217122ABE8112A5AD180CE2CF2505CF09E9EF47C88FC03E44A77926DAA6538935BC12038F051E68F0F776309F66FA6FC8D961FD, 'Roque', 4),
		(3, '50967422027', '2004-02-15T00:00:00', NULL, 'Dan'
		, 0x845DC11381A18B7AF1AFA1977FE096A5737EE2DEF11D0D73798A8259BA67F18331BA152DA19D6E5F586F7DF10B8FA174F81A409B551173B9C2BA87FD33F0DC73, 0xCF9F3115CABFCB9E842E08BE90B99DFE40764B0490513E6E01D923EBB3E45C2E9BFFB653588A42DD67AC050816B59E11C97A7C7FB69E48095A45C07E5D1625A842A71B4CD059FCF0BA831F61C217122ABE8112A5AD180CE2CF2505CF09E9EF47C88FC03E44A77926DAA6538935BC12038F051E68F0F776309F66FA6FC8D961FD, 'Marzo', 1),
		(4, '15063626050', '2004-02-15T00:00:00', NULL, 'Nicolly'
		, NULL, NULL, 'Sodré', 2),
		(5, '70414926056', '2004-02-15T00:00:00', NULL, 'Giovana'
		, NULL, NULL, 'Silva', 2),
		(6, '46473986090', '2004-02-15T00:00:00', NULL, 'Pedro'
		, NULL, NULL, 'Rocha', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] 
	IN (N'PessoaId', N'CpfPessoa', N'DtNascPessoa', N'FotoUsuario'
	, N'NomePessoa', N'PasswordHash', N'PasswordSalt', N'SobreNomePessoa'
	, N'TipoPessoa') AND [object_id] = OBJECT_ID(N'[Pessoas]'))
    SET IDENTITY_INSERT [Pessoas] OFF;
GO

IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'StatusConsultaId', N'DescStatusConsulta') 
		AND [object_id] = OBJECT_ID(N'[StatusConsultas]'))
    SET IDENTITY_INSERT [StatusConsultas] ON;
INSERT INTO [StatusConsultas] (
	[StatusConsultaId]
	, [DescStatusConsulta])
VALUES (1, 'Agendada'),
	   (2, 'Encerrada'),
	   (3, 'Cancelada'),
	   (4, 'Remarcada'),
	   (5, 'Fila de espera');
IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'StatusConsultaId', N'DescStatusConsulta') 
		AND [object_id] = OBJECT_ID(N'[StatusConsultas]'))
    SET IDENTITY_INSERT [StatusConsultas] OFF;
GO

IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'TipoMedicacaoId', N'ClasseAplicacao', N'DescMedicacao'
		, N'TituloTipoMedicacao') 
		AND [object_id] = OBJECT_ID(N'[TiposMedicacoes]'))
    SET IDENTITY_INSERT [TiposMedicacoes] ON;
INSERT INTO [TiposMedicacoes] (
	[TipoMedicacaoId]
	, [ClasseAplicacao]
	, [DescMedicacao]
	, [TituloTipoMedicacao])
VALUES (1, 1, 'Aplicado pela boca', 'Via oral'),
	   (2, 1, 'Aplicado  por dembaixo da língua', 'Sublingual'),
	   (3, 1, 'Aplicado pelo canal retal', 'Supositorios'),
	   (4, 2, 'Aplicada diretamente no sangue', 'Intravenosa'),
	   (5, 2, 'Aplicada diretamente no músculo', 'Intramuscular'),
	   (6, 2, 'Aplicada debaixo da pele', 'Subcutânea'),
	   (7, 2, '', 'Respiratória'),
	   (8, 2, 'Aplicada por pomadas', 'Via tópica'),
	   (9, 2, '', 'Via Ocular'),
	   (10, 2, '', 'Via Nasal'),
	   (11, 2, '', 'Via Auricular');
IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'TipoMedicacaoId', N'ClasseAplicacao', N'DescMedicacao'
		, N'TituloTipoMedicacao') 
		AND [object_id] = OBJECT_ID(N'[TiposMedicacoes]'))
    SET IDENTITY_INSERT [TiposMedicacoes] OFF;
GO

IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'PessoaId', N'AtualizadoEm', N'Celular', N'CelularSecundario'
		, N'CriadoEm', N'Email', N'Telefone', N'TelefoneSecundario') 
		AND [object_id] = OBJECT_ID(N'[ContatoPessoas]'))
    SET IDENTITY_INSERT [ContatoPessoas] ON;
INSERT INTO [ContatoPessoas] (
	[PessoaId]
	, [AtualizadoEm]
	, [Celular]
	, [CelularSecundario]
	, [CriadoEm]
	, [Email]
	, [Telefone]
	, [TelefoneSecundario])
VALUES (1, NULL, '11978486810', NULL, '2023-06-20T20:00:11-03:00'
		, 'may@may.com', NULL, NULL),
	   (2, NULL, '11978486810', NULL, '2023-06-20T20:00:11-03:00'
	   , 'thi@thi.com', NULL, NULL),
	   (3, NULL, '11978486810', NULL, '2023-06-20T20:00:11-03:00'
	   , 'dan@dan.com', NULL, NULL);
IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'PessoaId', N'AtualizadoEm', N'Celular', N'CelularSecundario'
		, N'CriadoEm', N'Email', N'Telefone', N'TelefoneSecundario') 
		AND [object_id] = OBJECT_ID(N'[ContatoPessoas]'))
    SET IDENTITY_INSERT [ContatoPessoas] OFF;
GO

IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'CriadoEm', N'CuidadorId', N'PacienteId', N'FinalizadoEm') 
		AND [object_id] = OBJECT_ID(N'[CuidadorPacientes]'))
    SET IDENTITY_INSERT [CuidadorPacientes] ON;
INSERT INTO [CuidadorPacientes] (
	[CriadoEm]
	, [CuidadorId]
	, [PacienteId]
	, [FinalizadoEm])
VALUES ('2023-06-20T20:00:11-03:00', 2, 4, NULL),
	   ('2023-06-20T20:00:11-03:00', 2, 5, NULL),
	   ('2023-06-20T20:00:11-03:00', 2, 6, NULL);
IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'CriadoEm', N'CuidadorId', N'PacienteId', N'FinalizadoEm') 
		AND [object_id] = OBJECT_ID(N'[CuidadorPacientes]'))
    SET IDENTITY_INSERT [CuidadorPacientes] OFF;
GO

IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'MedicacaoId', N'CodPessoaAlter', N'CompostoAtivoMedicacao'
		, N'Generico', N'LaboratorioMedicacao', N'NomeMedicacao'
		, N'StatusMedicacao', N'TipoMedicacaoId') 
		AND [object_id] = OBJECT_ID(N'[Medicacoes]'))
    SET IDENTITY_INSERT [Medicacoes] ON;
INSERT INTO [Medicacoes] (
	[MedicacaoId]
	, [CodPessoaAlter]
	, [CompostoAtivoMedicacao]
	, [Generico]
	, [LaboratorioMedicacao]
	, [NomeMedicacao]
	, [StatusMedicacao]
	, [TipoMedicacaoId])
VALUES (1, 0, 'pirazolônico não narcótico ', 'S', 'Sanofi-Aventis'
		, 'DIPIRONA 80g', 1, 1),
	   (2, 0, 'ceftriaxona', 'S', 'Roche', 'Rocefin', 1, 2);
IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'MedicacaoId', N'CodPessoaAlter', N'CompostoAtivoMedicacao'
		, N'Generico', N'LaboratorioMedicacao', N'NomeMedicacao'
		, N'StatusMedicacao', N'TipoMedicacaoId') 
		AND [object_id] = OBJECT_ID(N'[Medicacoes]'))
    SET IDENTITY_INSERT [Medicacoes] OFF;
GO

IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'PacienteId', N'ResponsavelId', N'CriadoEm'
		, N'GrauParentescoId') 
		AND [object_id] = OBJECT_ID(N'[ResponsaveisPacientes]'))
    SET IDENTITY_INSERT [ResponsaveisPacientes] ON;
INSERT INTO [ResponsaveisPacientes] (
	[PacienteId]
	, [ResponsavelId]
	, [CriadoEm]
	, [GrauParentescoId])
VALUES (4, 1, '2023-06-20T20:00:11-03:00', 1),
(5, 1, '2023-06-20T20:00:11-03:00', 3);
IF EXISTS (
	SELECT * FROM [sys].[identity_columns] WHERE [name] 
		IN (N'PacienteId', N'ResponsavelId', N'CriadoEm'
		, N'GrauParentescoId') 
		AND [object_id] = OBJECT_ID(N'[ResponsaveisPacientes]'))
    SET IDENTITY_INSERT [ResponsaveisPacientes] OFF;
GO

CREATE INDEX [IX_AndamentoMedicacoes_PrescricaoMedicacaoId] 
	ON [AndamentoMedicacoes] ([PrescricaoMedicacaoId]);
GO

CREATE INDEX [IX_AndamentoMedicacoes_PrescricaoPacienteId] 
	ON [AndamentoMedicacoes] ([PrescricaoPacienteId]);
GO

CREATE UNIQUE INDEX [IX_ConsultaCanceladas_ConsultaAgendadaId] 
	ON [ConsultaCanceladas] ([ConsultaAgendadaId]);
GO

CREATE INDEX [IX_ConsultasAgendadas_EspecialidadeId] 
	ON [ConsultasAgendadas] ([EspecialidadeId]);
GO

CREATE INDEX [IX_ConsultasAgendadas_MedicoId] 
	ON [ConsultasAgendadas] ([MedicoId]);
GO

CREATE INDEX [IX_ConsultasAgendadas_StatusConsultaId] 
	ON [ConsultasAgendadas] ([StatusConsultaId]);
GO

CREATE INDEX [IX_ContatoPessoas_Celular] 
	ON [ContatoPessoas] ([Celular]);
GO

CREATE UNIQUE INDEX [IX_ContatoPessoas_Email] 
	ON [ContatoPessoas] ([Email]);
GO

CREATE INDEX [IX_CuidadorPacientes_CuidadorId] 
	ON [CuidadorPacientes] ([CuidadorId]);
GO

CREATE INDEX [IX_Medicacoes_TipoMedicacaoId] 
	ON [Medicacoes] ([TipoMedicacaoId]);
GO

CREATE INDEX [IX_ObservacoesPacientes_PacienteId] 
	ON [ObservacoesPacientes] ([PacienteId]);
GO

CREATE UNIQUE INDEX [UNIQUE_ON_CPF] 
	ON [Pessoas] ([CpfPessoa]);
GO

CREATE INDEX [IX_PrescricaoPacientes_MedicoId] 
	ON [PrescricaoPacientes] ([MedicoId]);
GO

CREATE INDEX [IX_PrescricaoPacientes_PacienteId] 
	ON [PrescricaoPacientes] ([PacienteId]);
GO

CREATE INDEX [IX_PrescricoesMedicacoes_MedicacaoId] 
	ON [PrescricoesMedicacoes] ([MedicacaoId]);
GO

CREATE INDEX [IX_PrescricoesMedicacoes_PrescricaoPacienteId] 
	ON [PrescricoesMedicacoes] ([PrescricaoPacienteId]);
GO

CREATE INDEX [IX_ResponsaveisPacientes_GrauParentescoId] 
	ON [ResponsaveisPacientes] ([GrauParentescoId]);
GO

CREATE INDEX [IX_ResponsaveisPacientes_ResponsavelId] 
	ON [ResponsaveisPacientes] ([ResponsavelId]);
GO

COMMIT;
GO

