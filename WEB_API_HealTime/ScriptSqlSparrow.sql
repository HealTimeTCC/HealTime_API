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

CREATE TABLE [GrausParentesco] (
    [GrauParentescoId] int NOT NULL IDENTITY,
    [DescGrauParentesco] VARCHAR(30) NULL,
    CONSTRAINT [PK_GrauParentescoId] PRIMARY KEY ([GrauParentescoId])
);
GO

CREATE TABLE [Pessoas] (
    [PessoaId] int NOT NULL IDENTITY,
    [TipoPessoa] int NULL DEFAULT 1,
    [NomePessoa] VARCHAR(30) NULL,
    [SobrenomePessoa] VARCHAR(50) NULL,
    [CpfPessoa] CHAR(11) NULL,
    [DtUltimoAcesso] SMALLDATETIME NULL DEFAULT (GETDATE()),
    [DtNascimentoPessoa] SMALLDATETIME NOT NULL,
    [GeneroPessoa] int NOT NULL,
    [ObsPacienteIncapaz] VARCHAR(350) NULL,
    CONSTRAINT [PK_Pessoas] PRIMARY KEY ([PessoaId])
);
GO

CREATE TABLE [TipoMedicacao] (
    [TipoMedicacaoId] int NOT NULL IDENTITY,
    [DescMedicacao] VARCHAR(50) NULL,
    CONSTRAINT [PK_TipoMedicamentoId] PRIMARY KEY ([TipoMedicacaoId])
);
GO

CREATE TABLE [ContatoPessoas] (
    [ContatoId] int NOT NULL IDENTITY,
    [PessoaId] int NOT NULL,
    [TelefoneCelularObri] VARCHAR(11) NOT NULL,
    [TelefoneCelularOpcional] VARCHAR(11) NULL,
    [TelefoneFixo] VARCHAR(10) NULL,
    [EmailContato] VARCHAR(70) NULL,
    [TipoCtt] int NOT NULL,
    CONSTRAINT [PK_ContatoPessoas] PRIMARY KEY ([ContatoId]),
    CONSTRAINT [FK_Pessoas_ContatosPessoas] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([PessoaId]) ON DELETE CASCADE
);
GO

CREATE TABLE [CuidadorPacientes] (
    [CuidadorPacienteId] int NOT NULL IDENTITY,
    [CuidadorId] int NULL,
    [PacienteIncapazId] int NULL,
    [ResponsavelId] int NULL,
    [CriadoEm] SMALLDATETIME NULL DEFAULT (GETDATE()),
    CONSTRAINT [PK_CuidadorPacienteId] PRIMARY KEY ([CuidadorPacienteId]),
    CONSTRAINT [FK_PESSOAS_CUIDADORPACIENTE_CuidadorId] FOREIGN KEY ([CuidadorId]) REFERENCES [Pessoas] ([PessoaId]),
    CONSTRAINT [FK_PESSOAS_CUIDADORPACIENTE_PacienteIncapazId] FOREIGN KEY ([PacienteIncapazId]) REFERENCES [Pessoas] ([PessoaId]),
    CONSTRAINT [FK_PESSOAS_CUIDADORPACIENTE_RESPONSAVELID] FOREIGN KEY ([ResponsavelId]) REFERENCES [Pessoas] ([PessoaId])
);
GO

CREATE TABLE [EnderecoPessoas] (
    [PessoaId] int NOT NULL,
    [Endereco] VARCHAR(40) NOT NULL,
    [BairroEndereco] VARCHAR(40) NULL,
    [CidadeEndereco] VARCHAR(40) NOT NULL,
    [Complemento] VARCHAR(40) NULL,
    [CepEndereco] CHAR(8) NOT NULL,
    [UfEndereco] int NOT NULL,
    CONSTRAINT [PK_EnderecoPessoa] PRIMARY KEY ([PessoaId]),
    CONSTRAINT [FK_EnderecoPessoas_Pessoas] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([PessoaId]) ON DELETE CASCADE
);
GO

CREATE TABLE [PrescricaoPacientes] (
    [PrescricaoPacienteId] int NOT NULL IDENTITY,
    [PacienteId] int NULL,
    [DescFichaPessoa] VARCHAR(300) NULL,
    [Emissao] SMALLDATETIME NOT NULL,
    CONSTRAINT [PK_PrescricaoPacienteId] PRIMARY KEY ([PrescricaoPacienteId]),
    CONSTRAINT [FK_PESSOAS_PRESCRICAOPACIENTE_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [Pessoas] ([PessoaId])
);
GO

CREATE TABLE [ResponsaveisPacientes] (
    [ResponsavelPacienteId] VARCHAR(40) NOT NULL,
    [PacienteInId] int NULL,
    [ResponsavelId] int NULL,
    [CriadoEm] SMALLDATETIME NOT NULL DEFAULT (GETDATE()),
    [GrauParentescoId] int NULL,
    CONSTRAINT [PK_ResponsavelPacienteId] PRIMARY KEY ([ResponsavelPacienteId]),
    CONSTRAINT [FK_PESSOAS_RESPONSAVELPACIENTE_PACIENTEINID] FOREIGN KEY ([PacienteInId]) REFERENCES [Pessoas] ([PessoaId]),
    CONSTRAINT [FK_PESSOAS_RESPONSAVELPACIENTE_RESPONSAVELID] FOREIGN KEY ([ResponsavelId]) REFERENCES [Pessoas] ([PessoaId]),
    CONSTRAINT [FK_ResponsavelPaciente_GRAUPARENTESCO] FOREIGN KEY ([GrauParentescoId]) REFERENCES [GrausParentesco] ([GrauParentescoId])
);
GO

CREATE TABLE [Medicacoes] (
    [MedicacaoId] int NOT NULL IDENTITY,
    [Nome] VARCHAR(30) NOT NULL,
    [TipoMedicacaoId] int NOT NULL,
    [StatusMedicacao] bit NULL DEFAULT CAST(1 AS bit),
    [Fabricante] VARCHAR(300) NOT NULL,
    [DtValidade] SMALLDATETIME NOT NULL,
    [QtdMedicacao] int NOT NULL,
    CONSTRAINT [PK_MedicacaoId] PRIMARY KEY ([MedicacaoId]),
    CONSTRAINT [FK_Medicacao_TipoMedicacao_TipoMedicacaoId] FOREIGN KEY ([TipoMedicacaoId]) REFERENCES [TipoMedicacao] ([TipoMedicacaoId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Estoque] (
    [MedicacaoId] int NOT NULL,
    [QtdEstoque] int NOT NULL,
    [Nome] VARCHAR(40) NOT NULL,
    [Desc] VARCHAR(200) NOT NULL,
    [AtualizadoEm] SMALLDATETIME NULL DEFAULT (GETDATE()),
    [CriadoEm] SMALLDATETIME NOT NULL,
    CONSTRAINT [PK_Estoque_MedicacaoId] PRIMARY KEY ([MedicacaoId]),
    CONSTRAINT [FK_Estoque_Medicacoes] FOREIGN KEY ([MedicacaoId]) REFERENCES [Medicacoes] ([MedicacaoId]) ON DELETE CASCADE
);
GO

CREATE TABLE [PrescricaoMedicamento] (
    [PrescricaoMedicamentoId] int NOT NULL IDENTITY,
    [PrescricaoPacienteId] int NULL,
    [HrDtMedicacao] SMALLDATETIME NOT NULL,
    [DtTerminoTratamento] SMALLDATETIME NULL,
    [QtdDiariaMedia] int NOT NULL,
    [CheckSituacao] bit NULL DEFAULT CAST(1 AS bit),
    [MedicacaoId] int NOT NULL,
    CONSTRAINT [PK_PrescricaoMedicamentoId] PRIMARY KEY ([PrescricaoMedicamentoId]),
    CONSTRAINT [FK_PrescricaoMedicamento_Medicacoes__MedicamentoId] FOREIGN KEY ([MedicacaoId]) REFERENCES [Medicacoes] ([MedicacaoId]) ON DELETE CASCADE,
    CONSTRAINT [FK_PrescricaoPacienteId] FOREIGN KEY ([PrescricaoPacienteId]) REFERENCES [PrescricaoPacientes] ([PrescricaoPacienteId])
);
GO

CREATE TABLE [BaixaHistoricoEstoque] (
    [BaixaHistoricoEstoqueId] int NOT NULL IDENTITY,
    [EstoqueId] int NOT NULL,
    [BaixaEm] datetime2 NULL,
    [DescBaixa] nvarchar(max) NULL,
    CONSTRAINT [PK_BaixaHistoricoEstoqueId] PRIMARY KEY ([BaixaHistoricoEstoqueId]),
    CONSTRAINT [FK_Estoque_BaixaHistoricoEstoques] FOREIGN KEY ([EstoqueId]) REFERENCES [Estoque] ([MedicacaoId]) ON DELETE CASCADE
);
GO

CREATE TABLE [AndamentoMedicacao] (
    [AndamentoMedicacaoId] int NOT NULL IDENTITY,
    [PrescricaoMedicamentoId] int NOT NULL,
    [QtdInicial] int NOT NULL,
    [QtdAtual] int NOT NULL,
    [CriadoEm] SMALLDATETIME NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT [PK_AndamentoMedicacaoId] PRIMARY KEY ([AndamentoMedicacaoId]),
    CONSTRAINT [FK_PrescricaoMedicamentoId] FOREIGN KEY ([PrescricaoMedicamentoId]) REFERENCES [PrescricaoMedicamento] ([PrescricaoMedicamentoId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AndamentoMedicacao_PrescricaoMedicamentoId] ON [AndamentoMedicacao] ([PrescricaoMedicamentoId]);
GO

CREATE INDEX [IX_BaixaHistoricoEstoque_EstoqueId] ON [BaixaHistoricoEstoque] ([EstoqueId]);
GO

CREATE INDEX [IX_ContatoPessoas_PessoaId] ON [ContatoPessoas] ([PessoaId]);
GO

CREATE INDEX [IX_CuidadorPacientes_CuidadorId] ON [CuidadorPacientes] ([CuidadorId]);
GO

CREATE INDEX [IX_CuidadorPacientes_PacienteIncapazId] ON [CuidadorPacientes] ([PacienteIncapazId]);
GO

CREATE INDEX [IX_CuidadorPacientes_ResponsavelId] ON [CuidadorPacientes] ([ResponsavelId]);
GO

CREATE UNIQUE INDEX [IX_Medicacoes_TipoMedicacaoId] ON [Medicacoes] ([TipoMedicacaoId]);
GO

CREATE UNIQUE INDEX [IX_PrescricaoMedicamento_MedicacaoId] ON [PrescricaoMedicamento] ([MedicacaoId]);
GO

CREATE INDEX [IX_PrescricaoMedicamento_PrescricaoPacienteId] ON [PrescricaoMedicamento] ([PrescricaoPacienteId]);
GO

CREATE INDEX [IX_PrescricaoPacientes_PacienteId] ON [PrescricaoPacientes] ([PacienteId]);
GO

CREATE UNIQUE INDEX [IX_ResponsaveisPacientes_GrauParentescoId] ON [ResponsaveisPacientes] ([GrauParentescoId]) WHERE [GrauParentescoId] IS NOT NULL;
GO

CREATE INDEX [IX_ResponsaveisPacientes_PacienteInId] ON [ResponsaveisPacientes] ([PacienteInId]);
GO

CREATE INDEX [IX_ResponsaveisPacientes_ResponsavelId] ON [ResponsaveisPacientes] ([ResponsavelId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230214142647_Table', N'7.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [GrausParentesco] (
    [GrauParentescoId] int NOT NULL,
    [DescGrauParentesco] varchar(30) NOT NULL,
    CONSTRAINT [PK_GrausParentesco] PRIMARY KEY ([GrauParentescoId])
);
GO

CREATE TABLE [Pessoas] (
    [PessoaId] varchar(40) NOT NULL,
    [TipoPessoa] int NOT NULL,
    [NomePessoa] varchar(25) NULL,
    [SobrenomePessoa] varchar(40) NULL,
    [CpfPessoa] char(11) NULL,
    [DtUltimoAcesso] datetime2 NOT NULL,
    [DtNascimentoPesssoa] date NOT NULL,
    [GeneroPessoa] int NOT NULL,
    [ObsPacienteIncapaz] varchar(350) NULL,
    [EnderecoPessoa] varchar(45) NULL,
    [BairroEnderecoPessoa] varchar(30) NULL,
    [CidadeEnderecoPessoa] varchar(20) NULL,
    [ComplementoPessoa] varchar(45) NULL,
    [CepEndereco] char(8) NULL,
    [UfEndereco] int NOT NULL,
    CONSTRAINT [PK_Pessoas] PRIMARY KEY ([PessoaId])
);
GO

CREATE TABLE [ContatoPessoas] (
    [ContatoId] int NOT NULL IDENTITY,
    [PessoaId] varchar(40) NULL,
    [TelefoneCelularObri] VARCHAR(11) NULL,
    [TelefoneCelularOpcional] VARCHAR(11) NULL,
    [TelefoneFixo] VARCHAR(10) NULL,
    [EmailContato] VARCHAR(70) NULL,
    [TipoCtt] int NOT NULL,
    CONSTRAINT [PK_ContatoPessoas] PRIMARY KEY ([ContatoId]),
    CONSTRAINT [FK_ContatoPessoas_Pessoas_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([PessoaId])
);
GO

CREATE TABLE [CuidadorPacientes] (
    [Id] int NOT NULL IDENTITY,
    [CuidadorId] varchar(40) NULL,
    [IdCuidadorPessoaId] varchar(40) NULL,
    [PacienteIncapazId] varchar(40) NULL,
    [IdPacienteIncapazPessoaId] varchar(40) NULL,
    [ResponsavelId] varchar(40) NULL,
    [IdResponsavelPessoaId] varchar(40) NULL,
    [CriadoEm] smalldatetime NOT NULL,
    CONSTRAINT [PK_CuidadorPacientes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CuidadorPacientes_Pessoas_IdCuidadorPessoaId] FOREIGN KEY ([IdCuidadorPessoaId]) REFERENCES [Pessoas] ([PessoaId]),
    CONSTRAINT [FK_CuidadorPacientes_Pessoas_IdPacienteIncapazPessoaId] FOREIGN KEY ([IdPacienteIncapazPessoaId]) REFERENCES [Pessoas] ([PessoaId]),
    CONSTRAINT [FK_CuidadorPacientes_Pessoas_IdResponsavelPessoaId] FOREIGN KEY ([IdResponsavelPessoaId]) REFERENCES [Pessoas] ([PessoaId])
);
GO

CREATE TABLE [ResponsaveisPaciente] (
    [ResponsavelPacienteId] int NOT NULL,
    [PacienteInId] nvarchar(max) NULL,
    [PacienteIdPessoaId] varchar(40) NULL,
    [ResponsavelId] nvarchar(max) NULL,
    [IdResponsavelPessoaId] varchar(40) NULL,
    [GrauParentescoId] int NOT NULL,
    CONSTRAINT [PK_ResponsaveisPaciente] PRIMARY KEY ([ResponsavelPacienteId]),
    CONSTRAINT [FK_ResponsaveisPaciente_GrausParentesco_GrauParentescoId] FOREIGN KEY ([GrauParentescoId]) REFERENCES [GrausParentesco] ([GrauParentescoId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ResponsaveisPaciente_Pessoas_IdResponsavelPessoaId] FOREIGN KEY ([IdResponsavelPessoaId]) REFERENCES [Pessoas] ([PessoaId]),
    CONSTRAINT [FK_ResponsaveisPaciente_Pessoas_PacienteIdPessoaId] FOREIGN KEY ([PacienteIdPessoaId]) REFERENCES [Pessoas] ([PessoaId])
);
GO

CREATE INDEX [IX_ContatoPessoas_PessoaId] ON [ContatoPessoas] ([PessoaId]);
GO

CREATE INDEX [IX_CuidadorPacientes_IdCuidadorPessoaId] ON [CuidadorPacientes] ([IdCuidadorPessoaId]);
GO

CREATE INDEX [IX_CuidadorPacientes_IdPacienteIncapazPessoaId] ON [CuidadorPacientes] ([IdPacienteIncapazPessoaId]);
GO

CREATE INDEX [IX_CuidadorPacientes_IdResponsavelPessoaId] ON [CuidadorPacientes] ([IdResponsavelPessoaId]);
GO

CREATE INDEX [IX_ResponsaveisPaciente_GrauParentescoId] ON [ResponsaveisPaciente] ([GrauParentescoId]);
GO

CREATE INDEX [IX_ResponsaveisPaciente_IdResponsavelPessoaId] ON [ResponsaveisPaciente] ([IdResponsavelPessoaId]);
GO

CREATE INDEX [IX_ResponsaveisPaciente_PacienteIdPessoaId] ON [ResponsaveisPaciente] ([PacienteIdPessoaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230214221820_ScriptSql', N'7.0.1');
GO

COMMIT;
GO

