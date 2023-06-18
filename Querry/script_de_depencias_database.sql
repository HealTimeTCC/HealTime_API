USE [DB-HEALTIME_II]
GO
-- Trigger que irá vigiar ANDAMENTOMEDICACOES
CREATE OR ALTER TRIGGER ControlStatePrescriptionMedicine
ON AndamentoMedicacoes 
FOR UPDATE
AS
BEGIN
	IF(EXISTS(SELECT 1 FROM inserted) AND EXISTS(SELECT 1 FROM deleted))
	BEGIN
		DECLARE 
			@QTD_ATUAL INT
			, @COD_PRESCRICAO_MEDICACAO INT
			, @QTD_CONTROLE_ESTADO INT
			, @COD_PRESCRICAO_PACIENTE INT;

		SELECT 
			@COD_PRESCRICAO_MEDICACAO = PrescricaoMedicacaoId
			, @COD_PRESCRICAO_PACIENTE = PrescricaoPacienteId 
		FROM inserted;

		SELECT @QTD_ATUAL = COUNT(*) FROM AndamentoMedicacoes 
			WHERE BaixaAndamentoMedicacao = 1 AND PrescricaoMedicacaoId = @COD_PRESCRICAO_MEDICACAO;

		SELECT @QTD_CONTROLE_ESTADO = QtdeHorarios 
			FROM ControleEstadoAndamentoMedicacao
			WHERE CodPrescricaoMedicamento = @COD_PRESCRICAO_MEDICACAO
		
		IF(@QTD_ATUAL = @QTD_CONTROLE_ESTADO)
		BEGIN
			--Muda o status da Prescriçao Para Inativo
			UPDATE PrescricoesMedicacoes SET StatusMedicacaoFlag = 0  
			WHERE PrescricaoMedicacaoId = @COD_PRESCRICAO_MEDICACAO;

			UPDATE PrescricaoPacientes SET FlagStatusAtivo = 0  
			WHERE PrescricaoPacienteId = @COD_PRESCRICAO_PACIENTE;
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
