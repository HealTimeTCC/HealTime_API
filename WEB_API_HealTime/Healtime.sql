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
    [ContatoPessoaId] int NOT NULL IDENTITY,
    [PessoaId] int NOT NULL,
    [Email] VARCHAR(100) NOT NULL,
    [CriadoEm] datetime2(0) NOT NULL DEFAULT (GETDATE()),
    [AtualizadoEm] datetime2 NOT NULL,
    [Telefone] CHAR(11) NOT NULL,
    [TelefoneSecundario] CHAR(11) NULL,
    [Celular] nvarchar(max) NULL,
    [TipoContato] int NOT NULL DEFAULT 1,
    CONSTRAINT [PK_ContatoPessoaId] PRIMARY KEY ([ContatoPessoaId]),
    CONSTRAINT [FK_Pessoa_ContatoPessoa_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([PessoaId]) ON DELETE CASCADE
);
GO

CREATE TABLE [CuidadorPacientes] (
    [PacienteId] int NOT NULL,
    [CuidadorId] int NOT NULL,
    [CriadoEm] DATETIME2(0) NOT NULL,
    [FinalizadoEm] DATETIME2(0) NOT NULL,
    CONSTRAINT [PK_CuidadorPacientes_PacienteId_CuidadorId] PRIMARY KEY ([PacienteId], [CuidadorId]),
    CONSTRAINT [FK_Pessoa_CuidadorPaciente_CuidadorId] FOREIGN KEY ([CuidadorId]) REFERENCES [Pessoas] ([PessoaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Pessoa_CuidadorPaciente_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [Pessoas] ([PessoaId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [EnderecoPessoas] (
    [PessoaId] int NOT NULL,
    [Logradouro] VARCHAR(40) NOT NULL,
    [NroLogradouro] VARCHAR(10) NOT NULL,
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
    [QtdeMedicao] int NOT NULL,
    [CriadoEm] datetime2(0) NOT NULL,
    [AcaoMedicacao] CHAR(1) NOT NULL,
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
    [PrescricaoPacienteId] int NOT NULL,
    [MedicacaoId] int NOT NULL,
    [Qtde] int NOT NULL,
    [Intervalo] int NOT NULL,
    [Duracao] int NOT NULL,
    [StatusMedicacaoFlag] CHAR(1) NULL DEFAULT 'S',
    CONSTRAINT [PK_CONCAT_PrescricaPacienteId_MedicacaoId] PRIMARY KEY ([PrescricaoPacienteId], [MedicacaoId]),
    CONSTRAINT [PK_MedicacaoId_PrescricaoMedicao] FOREIGN KEY ([MedicacaoId]) REFERENCES [Medicacoes] ([MedicacaoId]) ON DELETE CASCADE,
    CONSTRAINT [PK_PrescricaoPacienteId_PrescricaoMedicao] FOREIGN KEY ([PrescricaoPacienteId]) REFERENCES [PrescricaoPacientes] ([PrescricaoPacienteId]) ON DELETE CASCADE
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
VALUES (1, '12345678909', '2004-02-15T00:00:00', 'Dan', 0xFFCAE36C457D4F5B20D52ECAC50ADCF9F6155E9A335862726D2833E887F64940C5E6ACDA48EB571D9F81AF5C7330A06182CC58558C8E29F45788512E3AD6A158, 0x06DBA2BC1B275BC53CCFCDADA95AFD17B7D8F5515F0E359C3E2829E1EFBDFD95141A64CB925EB866F3F8DEEA8921A8C9B8D979EFD280A114C7576C8A2C4A25F1054D6AF9239153761BA8A9121CBEA841457EE504F350248158E173E37C31324EEDAC3E9D433C3C61E3FE2AFD5D2848E737955586C6D0796264566C748C40322A, 'Marzo', 3);
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

CREATE INDEX [IX_AndamentoMedicacoes_MedicacaoId] ON [AndamentoMedicacoes] ([MedicacaoId]);
GO

CREATE UNIQUE INDEX [IX_ConsultaCanceladas_ConsultaAgendadaId] ON [ConsultaCanceladas] ([ConsultaAgendadaId]);
GO

CREATE INDEX [IX_ConsultasAgendadas_EspecialidadeId] ON [ConsultasAgendadas] ([EspecialidadeId]);
GO

CREATE INDEX [IX_ConsultasAgendadas_MedicoId] ON [ConsultasAgendadas] ([MedicoId]);
GO

CREATE INDEX [IX_ConsultasAgendadas_StatusConsultaId] ON [ConsultasAgendadas] ([StatusConsultaId]);
GO

CREATE UNIQUE INDEX [IX_ContatoPessoas_PessoaId] ON [ContatoPessoas] ([PessoaId]);
GO

CREATE INDEX [IX_CuidadorPacientes_CuidadorId] ON [CuidadorPacientes] ([CuidadorId]);
GO

CREATE INDEX [IX_Medicacoes_TipoMedicacaoId] ON [Medicacoes] ([TipoMedicacaoId]);
GO

CREATE INDEX [IX_ObservacoesPacientes_PacienteId] ON [ObservacoesPacientes] ([PacienteId]);
GO

CREATE INDEX [IX_PrescricaoPacientes_MedicoId] ON [PrescricaoPacientes] ([MedicoId]);
GO

CREATE INDEX [IX_PrescricaoPacientes_PacienteId] ON [PrescricaoPacientes] ([PacienteId]);
GO

CREATE UNIQUE INDEX [IX_PrescricoesMedicacoes_MedicacaoId] ON [PrescricoesMedicacoes] ([MedicacaoId]);
GO

CREATE INDEX [IX_PrescricoesMedicacoes_PrescricaoPacienteId] ON [PrescricoesMedicacoes] ([PrescricaoPacienteId]);
GO

CREATE UNIQUE INDEX [IX_ResponsaveisPacientes_GrauParentescoId] ON [ResponsaveisPacientes] ([GrauParentescoId]);
GO

CREATE INDEX [IX_ResponsaveisPacientes_ResponsavelId] ON [ResponsaveisPacientes] ([ResponsavelId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230402144642_InitNew', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP INDEX [IX_PrescricoesMedicacoes_PrescricaoPacienteId] ON [PrescricoesMedicacoes];
GO

ALTER TABLE [ContatoPessoas] DROP CONSTRAINT [PK_ContatoPessoaId];
GO

DROP INDEX [IX_ContatoPessoas_PessoaId] ON [ContatoPessoas];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ContatoPessoas]') AND [c].[name] = N'ContatoPessoaId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ContatoPessoas] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [ContatoPessoas] DROP COLUMN [ContatoPessoaId];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ContatoPessoas]') AND [c].[name] = N'TipoContato');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ContatoPessoas] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [ContatoPessoas] DROP COLUMN [TipoContato];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ContatoPessoas]') AND [c].[name] = N'TelefoneSecundario');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [ContatoPessoas] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [ContatoPessoas] ALTER COLUMN [TelefoneSecundario] CHAR(10) NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ContatoPessoas]') AND [c].[name] = N'Telefone');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [ContatoPessoas] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [ContatoPessoas] ALTER COLUMN [Telefone] CHAR(10) NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ContatoPessoas]') AND [c].[name] = N'Celular');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ContatoPessoas] DROP CONSTRAINT [' + @var4 + '];');
UPDATE [ContatoPessoas] SET [Celular] = '' WHERE [Celular] IS NULL;
ALTER TABLE [ContatoPessoas] ALTER COLUMN [Celular] CHAR(11) NOT NULL;
ALTER TABLE [ContatoPessoas] ADD DEFAULT '' FOR [Celular];
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ContatoPessoas]') AND [c].[name] = N'AtualizadoEm');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [ContatoPessoas] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [ContatoPessoas] ALTER COLUMN [AtualizadoEm] datetime2 NULL;
GO

ALTER TABLE [ContatoPessoas] ADD [CelularSecundario] CHAR(11) NULL;
GO

ALTER TABLE [ContatoPessoas] ADD CONSTRAINT [PK_ContatoPessoaId] PRIMARY KEY ([PessoaId]);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PessoaId', N'AtualizadoEm', N'Celular', N'CelularSecundario', N'CriadoEm', N'Email', N'Telefone', N'TelefoneSecundario') AND [object_id] = OBJECT_ID(N'[ContatoPessoas]'))
    SET IDENTITY_INSERT [ContatoPessoas] ON;
INSERT INTO [ContatoPessoas] ([PessoaId], [AtualizadoEm], [Celular], [CelularSecundario], [CriadoEm], [Email], [Telefone], [TelefoneSecundario])
VALUES (1, NULL, '11978486810', NULL, '2023-04-02T16:18:27-03:00', 'user@user.com', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PessoaId', N'AtualizadoEm', N'Celular', N'CelularSecundario', N'CriadoEm', N'Email', N'Telefone', N'TelefoneSecundario') AND [object_id] = OBJECT_ID(N'[ContatoPessoas]'))
    SET IDENTITY_INSERT [ContatoPessoas] OFF;
GO

UPDATE [Pessoas] SET [PasswordHash] = 0xF92701ECCACD8C041A5A577BE8D043DAC3649B413F72F9CCCA627064A24A87E9B084AF511D3488BDE57E476C4C517B3D4F9FA4E82448431210F850DC11034B93, [PasswordSalt] = 0x529C432CABC0BA15A549962F77F2A0CABEEB1BA1563F80D2BF8CCE24AFEF98D9F9CE0DF5E338CC529BFE16721DF86F5FFF14512FBA24B6940D2B1183B27D10200DEFE3D76620C3217E1FA2A869E9702082C9F504928C281BD3CD43A478D4FE751E37DE15E2AB98ED5F141A220558DEDE999AEA4AEF0FE7A233EAA3CC3563C17B
WHERE [PessoaId] = 1;
SELECT @@ROWCOUNT;

GO

CREATE UNIQUE INDEX [IX_ContatoPessoas_Email] ON [ContatoPessoas] ([Email]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230402191828_DefaultValues', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [ContatoPessoas] SET [CriadoEm] = '2023-04-02T18:38:02-03:00'
WHERE [PessoaId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Pessoas] SET [PasswordHash] = 0xA3829A721FAA2A6C9D0283F095E534A9BBDD8DBC2AF7631E6FE8362136C840466CF593472A5B2BE6CD293CF19E529E90F414ECC30727C9B4C7A65CE8CBC30F4A, [PasswordSalt] = 0x9390B62755408BCEA51EE901EA2A02573ED00A384C0D2288C28587262CBF66CDBED9E02D32350EE20D58DFBE9DDCA820F0DADCA7CB8E0B88C52AE5F5DBE867CEDC7D722381AAB09B56288165566622A40736B591D14C9F554AFDB5A39A61D783D88CC38BD19B80F8553605EF120906BEA9E55CB5449C7B155A591327D28E15F3
WHERE [PessoaId] = 1;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_ContatoPessoas_Celular] ON [ContatoPessoas] ([Celular]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230402213803_AlterandoUniqueContato', N'7.0.4');
GO

COMMIT;
GO

