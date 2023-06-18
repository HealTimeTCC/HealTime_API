USE [DB-HEALTIME_II]

GO
--SELECT * FROM sys.sequences WHERE name = 'nome_da_sequencia';

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
		 , @DURACAODIAS DATETIME;
	
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
	END
END
