IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Especialidades] (
    [EspecialidadeId] int NOT NULL IDENTITY,
    [DescEspecialidade] VARCHAR(25) NOT NULL,
    CONSTRAINT [PK_EspecialidadeId] PRIMARY KEY ([EspecialidadeId])
);
GO

CREATE TABLE [GrauParentesco] (
    [GrauParentescoId] int NOT NULL IDENTITY,
    [DescGrauParentesco] VARCHAR(15) NOT NULL,
    CONSTRAINT [PK_GrauParentescoId] PRIMARY KEY ([GrauParentescoId])
);
GO

CREATE TABLE [Medicos] (
    [MedicoId] int NOT NULL IDENTITY,
    [NmMedico] VARCHAR(40) NOT NULL,
    [CrmMedico] CHAR(6) NULL,
    [UfCrmMedico] CHAR(2) NOT NULL,
    CONSTRAINT [PK_MedicoId] PRIMARY KEY ([MedicoId])
);
GO

CREATE TABLE [Pessoas] (
    [PessoaId] int NOT NULL IDENTITY,
    [TipoPessoa] int NOT NULL,
    [CpfPessoa] CHAR(11) NOT NULL,
    [NomePessoa] VARCHAR(25) NOT NULL,
    [SobreNomePessoa] VARCHAR(30) NOT NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [DtNascPessoa] datetime2(0) NOT NULL,
    CONSTRAINT [PK_PessoaId] PRIMARY KEY ([PessoaId])
);
GO

CREATE TABLE [StatusConsultas] (
    [StatusConsultaId] int NOT NULL IDENTITY,
    [DescStatusConsulta] VARCHAR(25) NOT NULL,
    CONSTRAINT [PK_StatusConsultaId] PRIMARY KEY ([StatusConsultaId])
);
GO

CREATE TABLE [TiposMedicacoes] (
    [TipoMedicacaoId] int NOT NULL IDENTITY,
    [DescMedicacao] VARCHAR(100) NULL,
    [TituloTipoMedicacao] VARCHAR(100) NOT NULL,
    [ClasseAplicacao] int NOT NULL,
    CONSTRAINT [PK_TipoMedicacaoId] PRIMARY KEY ([TipoMedicacaoId])
);
GO

CREATE TABLE [ContatoPessoas] (
    [PessoaId] int NOT NULL,
    [Email] VARCHAR(100) NOT NULL,
    [CriadoEm] datetime2(0) NOT NULL DEFAULT (GETDATE()),
    [AtualizadoEm] datetime2 NULL,
    [Telefone] CHAR(10) NULL,
    [TelefoneSecundario] CHAR(10) NULL,
    [Celular] CHAR(11) NOT NULL,
    [CelularSecundario] CHAR(11) NULL,
    CONSTRAINT [PK_ContatoPessoaId] PRIMARY KEY ([PessoaId]),
    CONSTRAINT [FK_Pessoa_ContatoPessoa_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([PessoaId]) ON DELETE CASCADE
);
GO

CREATE TABLE [CuidadorPacientes] (
    [PacienteId] int NOT NULL,
    [CuidadorId] int NOT NULL,
    [CriadoEm] DATETIME2(0) NOT NULL,
    [FinalizadoEm] DATETIME2(0) NOT NULL,
    CONSTRAINT [PK_CuidadorPacientes_PacienteId_CuidadorId] PRIMARY KEY ([PacienteId], [CuidadorId], [CriadoEm]),
    CONSTRAINT [FK_Pessoa_CuidadorPaciente_CuidadorId] FOREIGN KEY ([CuidadorId]) REFERENCES [Pessoas] ([PessoaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Pessoa_CuidadorPaciente_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [Pessoas] ([PessoaId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [EnderecoPessoas] (
    [PessoaId] int NOT NULL,
    [Logradouro] VARCHAR(40) NOT NULL,
    [NroLogradouro] INT NOT NULL,
    [Complemento] VARCHAR(15) NULL,
    [BairroLogradouro] VARCHAR(25) NOT NULL,
    [CidadeEndereco] VARCHAR(25) NOT NULL,
    [UFEndereco] CHAR(2) NOT NULL,
    [CEPEndereco] CHAR(8) NOT NULL,
    CONSTRAINT [PK_FK_EnderecoPessoa] PRIMARY KEY ([PessoaId]),
    CONSTRAINT [FK_PK_EnderecoPessoa] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([PessoaId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ObservacoesPacientes] (
    [SqObservacao] int NOT NULL IDENTITY,
    [PacienteId] int NOT NULL,
    [MtObservacao] datetime2(0) NOT NULL,
    [Observacao] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_SqObservacao] PRIMARY KEY ([SqObservacao]),
    CONSTRAINT [FK_SqObservacao_Pessoas] FOREIGN KEY ([PacienteId]) REFERENCES [Pessoas] ([PessoaId]) ON DELETE CASCADE
);
GO

CREATE TABLE [PrescricaoPacientes] (
    [PrescricaoPacienteId] int NOT NULL IDENTITY,
    [MedicoId] int NOT NULL,
    [PacienteId] int NOT NULL,
    [CriadoEm] datetime2(0) NOT NULL,
    [Emissao] datetime2(0) NOT NULL,
    [Validade] datetime2(0) NOT NULL,
    [DescFichaPessoa] VARCHAR(350) NULL,
    [FlagStatus] CHAR(1) NOT NULL DEFAULT 'S',
    CONSTRAINT [PK_PrescricaoPacienteId] PRIMARY KEY ([PrescricaoPacienteId]),
    CONSTRAINT [FK_PacienteId_PrescricoesPacientes] FOREIGN KEY ([PacienteId]) REFERENCES [Pessoas] ([PessoaId]) ON DELETE CASCADE,
    CONSTRAINT [FK_PrescricaoPaciente_Medico] FOREIGN KEY ([MedicoId]) REFERENCES [Medicos] ([MedicoId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ResponsaveisPacientes] (
    [PacienteId] int NOT NULL,
    [ResponsavelId] int NOT NULL,
    [CriadoEm] datetime2(0) NOT NULL DEFAULT (GETDATE()),
    [GrauParentescoId] int NOT NULL,
    CONSTRAINT [PK_PacienteId_ResponsavelId] PRIMARY KEY ([PacienteId], [ResponsavelId]),
    CONSTRAINT [FK_GrauParentescoId_GrauParentesco_ResponsavelPaciente] FOREIGN KEY ([GrauParentescoId]) REFERENCES [GrauParentesco] ([GrauParentescoId]) ON DELETE CASCADE,
    CONSTRAINT [FK_PacienteId_Pessoas_ResponsavelPaciente] FOREIGN KEY ([PacienteId]) REFERENCES [Pessoas] ([PessoaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ResponsavelId_Pessoas_ResponsavelPaciente] FOREIGN KEY ([ResponsavelId]) REFERENCES [Pessoas] ([PessoaId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [ConsultasAgendadas] (
    [ConsultasAgendadasId] int NOT NULL IDENTITY,
    [StatusConsultaId] int NOT NULL,
    [EspecialidadeId] int NOT NULL,
    [PacienteId] int NOT NULL,
    [MedicoId] int NOT NULL,
    [DataSolicitacaoConsulta] datetime2(0) NOT NULL,
    [DataConsulta] datetime2(0) NOT NULL,
    [MotivoConsulta] VARCHAR(300) NULL,
    [Encaminhamento] CHAR(1) NOT NULL,
    CONSTRAINT [PK_ConsultaAgendadaId] PRIMARY KEY ([ConsultasAgendadasId]),
    CONSTRAINT [FK_ConsultaAgendadas_StatusConsulta] FOREIGN KEY ([StatusConsultaId]) REFERENCES [StatusConsultas] ([StatusConsultaId]) ON DELETE CASCADE,
    CONSTRAINT [FK_EspecialidadeId] FOREIGN KEY ([EspecialidadeId]) REFERENCES [Especialidades] ([EspecialidadeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_MedicoId_ConsultaAgendadaId] FOREIGN KEY ([MedicoId]) REFERENCES [Medicos] ([MedicoId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Medicacoes] (
    [MedicacaoId] int NOT NULL IDENTITY,
    [StatusMedicacao] int NOT NULL DEFAULT 1,
    [TipoMedicacaoId] int NOT NULL,
    [NomeMedicacao] VARCHAR(80) NOT NULL,
    [CompostoAtivoMedicacao] VARCHAR(50) NOT NULL,
    [LaboratorioMedicaocao] VARCHAR(80) NOT NULL,
    [Generico] CHAR(1) NOT NULL,
    CONSTRAINT [PK_MedicacaoId] PRIMARY KEY ([MedicacaoId]),
    CONSTRAINT [FK_Medicacao_TipoMedicacao] FOREIGN KEY ([TipoMedicacaoId]) REFERENCES [TiposMedicacoes] ([TipoMedicacaoId]) ON DELETE CASCADE
);
GO

CREATE TABLE [AndamentoMedicacoes] (
    [MtAndamentoMedicacao] datetime2(0) NOT NULL,
    [PrescricaoPacienteId] int NOT NULL,
    [MedicacaoId] int NOT NULL,
    [AndamentoMedicacaoId] int NOT NULL,
    [QtdeMedicao] int NOT NULL,
    [CriadoEm] datetime2(0) NOT NULL,
    [BaixaAndamentoMedicacao] bit NOT NULL DEFAULT CAST(0 AS bit),
    [MtBaixaMedicacao] datetime2(0) NULL,
    CONSTRAINT [PK_AndamentoMedicacao_MtAndamentoMedicacao_PrescricaoPacienteId_MedicacaoId] PRIMARY KEY ([MtAndamentoMedicacao], [PrescricaoPacienteId], [MedicacaoId]),
    CONSTRAINT [FK_PrescricaoPaciente_MedicacaoId_AndamentoMedicacoes] FOREIGN KEY ([MedicacaoId]) REFERENCES [PrescricaoPacientes] ([PrescricaoPacienteId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ConsultaCanceladas] (
    [ConsultaCanceladaId] int NOT NULL IDENTITY,
    [ConsultaAgendadaId] int NOT NULL,
    [MotivoCancelamento] VARCHAR(300) NOT NULL,
    [DataCancelamento] datetime2(0) NOT NULL,
    CONSTRAINT [PK_ConsultaCancelada_ConsultaAgendada] PRIMARY KEY ([ConsultaCanceladaId], [ConsultaAgendadaId]),
    CONSTRAINT [FK_ConsultaAgendadaId] FOREIGN KEY ([ConsultaAgendadaId]) REFERENCES [ConsultasAgendadas] ([ConsultasAgendadasId]) ON DELETE CASCADE
);
GO

CREATE TABLE [PrescricoesMedicacoes] (
    [PrescricaoMedicacaoId] int NOT NULL IDENTITY,
    [PrescricaoPacienteId] int NOT NULL,
    [MedicacaoId] int NOT NULL,
    [Qtde] FLOAT(10) NOT NULL,
    [Intervalo] TIME NOT NULL,
    [Duracao] int NOT NULL,
    [StatusMedicacaoFlag] CHAR(1) NULL DEFAULT 'S',
    [HorariosDefinidos] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK_CONCAT_PrescricaPacienteId_MedicacaoId] PRIMARY KEY ([PrescricaoPacienteId], [MedicacaoId], [PrescricaoMedicacaoId]),
    CONSTRAINT [PK_MedicacaoId_PrescricaoMedicao] FOREIGN KEY ([MedicacaoId]) REFERENCES [Medicacoes] ([MedicacaoId]) ON DELETE CASCADE,
    CONSTRAINT [PK_PrescricaoPacienteId_PrescricaoMedicao] FOREIGN KEY ([PrescricaoPacienteId]) REFERENCES [PrescricaoPacientes] ([PrescricaoPacienteId]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EspecialidadeId', N'DescEspecialidade') AND [object_id] = OBJECT_ID(N'[Especialidades]'))
    SET IDENTITY_INSERT [Especialidades] ON;
INSERT INTO [Especialidades] ([EspecialidadeId], [DescEspecialidade])
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
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EspecialidadeId', N'DescEspecialidade') AND [object_id] = OBJECT_ID(N'[Especialidades]'))
    SET IDENTITY_INSERT [Especialidades] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GrauParentescoId', N'DescGrauParentesco') AND [object_id] = OBJECT_ID(N'[GrauParentesco]'))
    SET IDENTITY_INSERT [GrauParentesco] ON;
INSERT INTO [GrauParentesco] ([GrauParentescoId], [DescGrauParentesco])
VALUES (1, 'Mãe'),
(2, 'Pai'),
(3, 'Filha/Filho');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GrauParentescoId', N'DescGrauParentesco') AND [object_id] = OBJECT_ID(N'[GrauParentesco]'))
    SET IDENTITY_INSERT [GrauParentesco] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MedicoId', N'CrmMedico', N'NmMedico', N'UfCrmMedico') AND [object_id] = OBJECT_ID(N'[Medicos]'))
    SET IDENTITY_INSERT [Medicos] ON;
INSERT INTO [Medicos] ([MedicoId], [CrmMedico], [NmMedico], [UfCrmMedico])
VALUES (1, '054321', 'Dr Val', 'SP'),
(2, '012345', 'Dr Teste', 'RJ');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MedicoId', N'CrmMedico', N'NmMedico', N'UfCrmMedico') AND [object_id] = OBJECT_ID(N'[Medicos]'))
    SET IDENTITY_INSERT [Medicos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PessoaId', N'CpfPessoa', N'DtNascPessoa', N'NomePessoa', N'PasswordHash', N'PasswordSalt', N'SobreNomePessoa', N'TipoPessoa') AND [object_id] = OBJECT_ID(N'[Pessoas]'))
    SET IDENTITY_INSERT [Pessoas] ON;
INSERT INTO [Pessoas] ([PessoaId], [CpfPessoa], [DtNascPessoa], [NomePessoa], [PasswordHash], [PasswordSalt], [SobreNomePessoa], [TipoPessoa])
VALUES (1, '67146867064', '2004-02-15T00:00:00', 'Responsavel', 0x654CAEF6E8D6AC2D85820587D38AE5FF41997B5EDFE9773391BA5FBD860F9E7D6D26E8504B6D469E816A23DF8BC6DA7FA0855525EB7E03CEB75142B888C3C5AB, 0xA3634D51F3C79FDBF7424C282C47EB8E5B66384A4D98CAC53BDBE0BC2FC101A7655E484AD476F766717A906FC872E18CE35A325A16DF0EDC4EFDBE324F4BD78A1984ED4963A82D3EB7B95231BE31ECDCDD6E186C294AC33268C3B100AD323E598F5CCC050314561EA3E8B3340877AC7DED50143256EDBB9AAD870C92AEEFE13B, 'Marzo', 3),
(2, '15063626050', '2004-02-15T00:00:00', 'PacienteIncapaz', 0x654CAEF6E8D6AC2D85820587D38AE5FF41997B5EDFE9773391BA5FBD860F9E7D6D26E8504B6D469E816A23DF8BC6DA7FA0855525EB7E03CEB75142B888C3C5AB, 0xA3634D51F3C79FDBF7424C282C47EB8E5B66384A4D98CAC53BDBE0BC2FC101A7655E484AD476F766717A906FC872E18CE35A325A16DF0EDC4EFDBE324F4BD78A1984ED4963A82D3EB7B95231BE31ECDCDD6E186C294AC33268C3B100AD323E598F5CCC050314561EA3E8B3340877AC7DED50143256EDBB9AAD870C92AEEFE13B, 'Marzo', 2),
(3, '94840911053', '2004-02-15T00:00:00', 'Cuidador', 0x654CAEF6E8D6AC2D85820587D38AE5FF41997B5EDFE9773391BA5FBD860F9E7D6D26E8504B6D469E816A23DF8BC6DA7FA0855525EB7E03CEB75142B888C3C5AB, 0xA3634D51F3C79FDBF7424C282C47EB8E5B66384A4D98CAC53BDBE0BC2FC101A7655E484AD476F766717A906FC872E18CE35A325A16DF0EDC4EFDBE324F4BD78A1984ED4963A82D3EB7B95231BE31ECDCDD6E186C294AC33268C3B100AD323E598F5CCC050314561EA3E8B3340877AC7DED50143256EDBB9AAD870C92AEEFE13B, 'Marzo', 4),
(4, '50967422027', '2004-02-15T00:00:00', 'Paciente', 0x654CAEF6E8D6AC2D85820587D38AE5FF41997B5EDFE9773391BA5FBD860F9E7D6D26E8504B6D469E816A23DF8BC6DA7FA0855525EB7E03CEB75142B888C3C5AB, 0xA3634D51F3C79FDBF7424C282C47EB8E5B66384A4D98CAC53BDBE0BC2FC101A7655E484AD476F766717A906FC872E18CE35A325A16DF0EDC4EFDBE324F4BD78A1984ED4963A82D3EB7B95231BE31ECDCDD6E186C294AC33268C3B100AD323E598F5CCC050314561EA3E8B3340877AC7DED50143256EDBB9AAD870C92AEEFE13B, 'Marzo', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PessoaId', N'CpfPessoa', N'DtNascPessoa', N'NomePessoa', N'PasswordHash', N'PasswordSalt', N'SobreNomePessoa', N'TipoPessoa') AND [object_id] = OBJECT_ID(N'[Pessoas]'))
    SET IDENTITY_INSERT [Pessoas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'StatusConsultaId', N'DescStatusConsulta') AND [object_id] = OBJECT_ID(N'[StatusConsultas]'))
    SET IDENTITY_INSERT [StatusConsultas] ON;
INSERT INTO [StatusConsultas] ([StatusConsultaId], [DescStatusConsulta])
VALUES (1, 'Agendada'),
(2, 'Encerrada'),
(3, 'Cancelada'),
(4, 'Remarcada'),
(5, 'Fila de espera');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'StatusConsultaId', N'DescStatusConsulta') AND [object_id] = OBJECT_ID(N'[StatusConsultas]'))
    SET IDENTITY_INSERT [StatusConsultas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TipoMedicacaoId', N'ClasseAplicacao', N'DescMedicacao', N'TituloTipoMedicacao') AND [object_id] = OBJECT_ID(N'[TiposMedicacoes]'))
    SET IDENTITY_INSERT [TiposMedicacoes] ON;
INSERT INTO [TiposMedicacoes] ([TipoMedicacaoId], [ClasseAplicacao], [DescMedicacao], [TituloTipoMedicacao])
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
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TipoMedicacaoId', N'ClasseAplicacao', N'DescMedicacao', N'TituloTipoMedicacao') AND [object_id] = OBJECT_ID(N'[TiposMedicacoes]'))
    SET IDENTITY_INSERT [TiposMedicacoes] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PessoaId', N'AtualizadoEm', N'Celular', N'CelularSecundario', N'CriadoEm', N'Email', N'Telefone', N'TelefoneSecundario') AND [object_id] = OBJECT_ID(N'[ContatoPessoas]'))
    SET IDENTITY_INSERT [ContatoPessoas] ON;
INSERT INTO [ContatoPessoas] ([PessoaId], [AtualizadoEm], [Celular], [CelularSecundario], [CriadoEm], [Email], [Telefone], [TelefoneSecundario])
VALUES (1, NULL, '11978486810', NULL, '2023-05-02T19:47:52-03:00', 'user@user.com', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PessoaId', N'AtualizadoEm', N'Celular', N'CelularSecundario', N'CriadoEm', N'Email', N'Telefone', N'TelefoneSecundario') AND [object_id] = OBJECT_ID(N'[ContatoPessoas]'))
    SET IDENTITY_INSERT [ContatoPessoas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MedicacaoId', N'CompostoAtivoMedicacao', N'Generico', N'LaboratorioMedicaocao', N'NomeMedicacao', N'StatusMedicacao', N'TipoMedicacaoId') AND [object_id] = OBJECT_ID(N'[Medicacoes]'))
    SET IDENTITY_INSERT [Medicacoes] ON;
INSERT INTO [Medicacoes] ([MedicacaoId], [CompostoAtivoMedicacao], [Generico], [LaboratorioMedicaocao], [NomeMedicacao], [StatusMedicacao], [TipoMedicacaoId])
VALUES (1, 'pirazolônico não narcótico ', 'S', 'Algum por ai', 'DIPIRONA 300ml', 1, 1),
(2, 'EXEMPLO ', 'N', 'Algum outro por ai', 'EXEMPLO', 1, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MedicacaoId', N'CompostoAtivoMedicacao', N'Generico', N'LaboratorioMedicaocao', N'NomeMedicacao', N'StatusMedicacao', N'TipoMedicacaoId') AND [object_id] = OBJECT_ID(N'[Medicacoes]'))
    SET IDENTITY_INSERT [Medicacoes] OFF;
GO

CREATE INDEX [IX_AndamentoMedicacoes_MedicacaoId] ON [AndamentoMedicacoes] ([MedicacaoId]);
GO

CREATE INDEX [IX_AndamentoMedicacoes_PrescricaoPacienteId] ON [AndamentoMedicacoes] ([PrescricaoPacienteId]);
GO

CREATE UNIQUE INDEX [IX_ConsultaCanceladas_ConsultaAgendadaId] ON [ConsultaCanceladas] ([ConsultaAgendadaId]);
GO

CREATE INDEX [IX_ConsultasAgendadas_EspecialidadeId] ON [ConsultasAgendadas] ([EspecialidadeId]);
GO

CREATE INDEX [IX_ConsultasAgendadas_MedicoId] ON [ConsultasAgendadas] ([MedicoId]);
GO

CREATE INDEX [IX_ConsultasAgendadas_StatusConsultaId] ON [ConsultasAgendadas] ([StatusConsultaId]);
GO

CREATE INDEX [IX_ContatoPessoas_Celular] ON [ContatoPessoas] ([Celular]);
GO

CREATE UNIQUE INDEX [IX_ContatoPessoas_Email] ON [ContatoPessoas] ([Email]);
GO

CREATE INDEX [IX_CuidadorPacientes_CuidadorId] ON [CuidadorPacientes] ([CuidadorId]);
GO

CREATE INDEX [IX_Medicacoes_TipoMedicacaoId] ON [Medicacoes] ([TipoMedicacaoId]);
GO

CREATE INDEX [IX_ObservacoesPacientes_PacienteId] ON [ObservacoesPacientes] ([PacienteId]);
GO

CREATE UNIQUE INDEX [UNIQUE_ON_CPF] ON [Pessoas] ([CpfPessoa]);
GO

CREATE INDEX [IX_PrescricaoPacientes_MedicoId] ON [PrescricaoPacientes] ([MedicoId]);
GO

CREATE INDEX [IX_PrescricaoPacientes_PacienteId] ON [PrescricaoPacientes] ([PacienteId]);
GO

CREATE INDEX [IX_PrescricoesMedicacoes_MedicacaoId] ON [PrescricoesMedicacoes] ([MedicacaoId]);
GO

CREATE INDEX [IX_ResponsaveisPacientes_GrauParentescoId] ON [ResponsaveisPacientes] ([GrauParentescoId]);
GO

CREATE INDEX [IX_ResponsaveisPacientes_ResponsavelId] ON [ResponsaveisPacientes] ([ResponsavelId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230502224752_Init', N'7.0.5');
GO

COMMIT;
GO

