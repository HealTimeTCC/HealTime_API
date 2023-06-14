-- Tabela que fara o controle de andamentos medicacoes
-- Para que ela funcione deve ter uma trigger rodando name = 

USE [DB-HEALTIME_II]
GO

IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ControleEstadoAndamentoMedicacao')
	DROP TABLE ControleEstadoAndamentoMedicacao
ELSE
BEGIN
	CREATE TABLE ControleEstadoAndamentoMedicacao(
		CodControle INT IDENTITY(1,1) 
			CONSTRAINT PK_ControleEstadoAndamentoMedicacao 
			PRIMARY KEY (CodControle)
		, DataContagem DATETIME NOT NULL 
		, QtdeHorarios INT NOT NULL
		, CodAndamentoMedicacao INT NOT NULL 
			CONSTRAINT UQ_CodAndamentoMedicacao UNIQUE (CodAndamentoMedicacao)
	);
END

