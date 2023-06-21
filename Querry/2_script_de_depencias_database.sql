USE [DB-HEALTIME]

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

GO
-- Trigger que irá vigiar ANDAMENTOMEDICACOES
CREATE OR ALTER TRIGGER ControlStatePrescriptionMedicine
ON AndamentoMedicacoes 
FOR UPDATE
AS
BEGIN
	IF(EXISTS(SELECT 1 FROM inserted) AND EXISTS(SELECT 1 FROM deleted))
	BEGIN
		DECLARE @QTD_ATUAL INT, @COD_ANDAMENTO INT, @QTD_CONTROLE_ESTADO INT;
		SELECT @COD_ANDAMENTO = AndamentoMedicacaoId FROM inserted
		SELECT @QTD_ATUAL = COUNT(*) FROM AndamentoMedicacoes 
			WHERE BaixaAndamentoMedicacao = 1 
			AND AndamentoMedicacaoId = @COD_ANDAMENTO;

		SELECT @QTD_CONTROLE_ESTADO = QtdeHorarios 
			FROM ControleEstadoAndamentoMedicacao
			WHERE CodPrescricaoMedicamento = @COD_ANDAMENTO
		
		IF(@QTD_ATUAL = @QTD_CONTROLE_ESTADO)
		BEGIN
			UPDATE PrescricoesMedicacoes SET StatusMedicacaoFlag = 0  
			WHERE PrescricaoMedicacaoId = (
			SELECT TOP 1 PrescricaoMedicacaoId 
				FROM AndamentoMedicacoes 
			WHERE AndamentoMedicacaoId = @COD_ANDAMENTO
			);
			UPDATE PrescricaoPacientes SET FlagStatusAtivo = 0  
			WHERE PrescricaoPacienteId = (
			SELECT TOP 1 PrescricaoPacienteId FROM AndamentoMedicacoes 
			WHERE AndamentoMedicacaoId = @COD_ANDAMENTO
			);
		END
	END
END

GO

IF(EXISTS(SELECT 1 FROM sys.sequences WHERE name = 'AndamentoMedicacao_GenId'))
BEGIN
	DROP SEQUENCE AndamentoMedicacao_GenId
END
CREATE SEQUENCE AndamentoMedicacao_GenId
    START WITH 1
    INCREMENT BY 1;
GO

CREATE OR ALTER PROC CALCULA_HORARIO_MEDICACAO @PRESCRICAOPACIENTEID INT, @PRESCRICAOMEDICAMENTOID INT, @MEDICAMENTOID INT
AS
BEGIN
	DECLARE 
		 @DURACAO INT
		 , @INTERVALO TIME 
		 , @QTDE FLOAT 
		 , @MOMENTOMEDICACAO DATETIME
		 , @DATAATUAL DATETIME
		 , @DURACAODIAS DATETIME
		 , @QTD_LINHAS INT;
	SELECT 
		  @DURACAO = PM.Duracao -- é medido em dias
		, @INTERVALO = PM.Intervalo
		, @QTDE = PM.Qtde
		, @MEDICAMENTOID = PM.MedicacaoId
	FROM PrescricoesMedicacoes PM
	INNER JOIN PrescricaoPacientes PP ON PP.PrescricaoPacienteId = PM.PrescricaoPacienteId
	WHERE 
		PP.PrescricaoPacienteId = @PRESCRICAOPACIENTEID
		AND PM.PrescricaoMedicacaoId = @PRESCRICAOMEDICAMENTOID 
		AND PM.MedicacaoId = @MEDICAMENTOID
	SELECT @MOMENTOMEDICACAO = GETDATE();
	SELECT @DATAATUAL = GETDATE();
	SELECT @DURACAODIAS = DATEADD(DAY, @DURACAO, GETDATE());
	SELECT @QTD_LINHAS = 0;
	WHILE (@DURACAODIAS > @MOMENTOMEDICACAO )
	BEGIN
		-- Soma o tempo à data e hora atual
		SELECT @MOMENTOMEDICACAO = DATEADD(SECOND, DATEDIFF(SECOND, '00:00:00', @INTERVALO), @MOMENTOMEDICACAO);
		
		-- Verifica se o resultado é do dia seguinte
		IF CAST(@MOMENTOMEDICACAO AS DATE) < CAST(@DATAATUAL AS DATE)
		BEGIN
		    -- Adiciona um dia à data
		    SELECT @MOMENTOMEDICACAO = DATEADD(day, 1, @MOMENTOMEDICACAO);
			SELECT @DATAATUAL = @MOMENTOMEDICACAO;
		END
		
		INSERT 
			INTO AndamentoMedicacoes(
			 AndamentoMedicacaoId 
			, PrescricaoMedicacaoId 
			, MedicacaoId
			, MtAndamentoMedicacao
			, PrescricaoPacienteId
			, CriadoEm
			, QtdeMedicao
			) 
		VALUES (
		 NEXT VALUE FOR AndamentoMedicacao_GenId
		, @PRESCRICAOMEDICAMENTOID 
		, @MEDICAMENTOID
		, @MOMENTOMEDICACAO
		, @PRESCRICAOPACIENTEID
		, GETDATE()
		, @QTDE
		);
		SELECT @QTD_LINHAS = @QTD_LINHAS + 1;
	END
	IF(@QTD_LINHAS <> 0)
	BEGIN
		INSERT INTO ControleEstadoAndamentoMedicacao(
			CodPrescricaoMedicamento
			, DataContagem
			, QtdeHorarios
			) VALUES(
				@PRESCRICAOMEDICAMENTOID
				, CURRENT_TIMESTAMP
				, @QTD_LINHAS
			);
	END
END
