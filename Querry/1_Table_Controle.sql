USE [DB_HEALTIME]

GO
--Primeiro cria a tabela de controle
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
		, CodPrescricaoMedicamento INT NOT NULL 
			CONSTRAINT UQ_CodAndamentoMedicacao UNIQUE (CodPrescricaoMedicamento)
	);
END
