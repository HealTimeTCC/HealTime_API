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

