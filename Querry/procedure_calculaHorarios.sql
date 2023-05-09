GO
SELECT
	  PP.PrescricaoPacienteId
	, PM.PrescricaoMedicacaoId
	, PM.MedicacaoId
	, PM.Duracao 
	, PM.Intervalo
	, PM.Qtde
FROM PrescricoesMedicacoes PM
INNER JOIN PrescricaoPacientes PP ON PP.PrescricaoPacienteId = PM.PrescricaoPacienteId
GO
------------------------
SELECT
	 PM.Duracao 
	, PM.Intervalo
	, PM.Qtde
FROM PrescricoesMedicacoes PM
INNER JOIN PrescricaoPacientes PP ON PP.PrescricaoPacienteId = PM.PrescricaoPacienteId
WHERE 
	PP.PrescricaoPacienteId = 1
	AND PM.PrescricaoMedicacaoId = 2 
	AND PM.MedicacaoId = 2

GO
/***** PROCEDURE: CALCULO DE HORARIOS DE MEDICACOES *****/
CREATE OR ALTER PROC CALCULA_HORARIO_MEDICACAO @PRESCRICAOPACIENTEID INT, @PRESCRICAOMEDICAMENTOID INT, @MEDICAMENTOID INT
AS
BEGIN
	DECLARE 
		 @DURACAO INT
		 , @INTERVALO TIME 
		 , @QTDE FLOAT 
		 , @MOMENTOMEDICACAO DATETIME
		 , @DATAATUAL DATETIME
	
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
	WHILE (@DURACAO > 0)
	BEGIN
		SELECT @DURACAO = @DURACAO - 1;
		SELECT @DURACAO; 

		-- Soma o tempo à data e hora atual
		SELECT @MOMENTOMEDICACAO = DATEADD(SECOND, DATEDIFF(SECOND, '00:00:00', @INTERVALO), @MOMENTOMEDICACAO);
		
		-- Verifica se o resultado é do dia seguinte
		IF CAST(@MOMENTOMEDICACAO AS DATE) > CAST(@DATAATUAL AS DATE)
		BEGIN
		    -- Adiciona um dia à data
			select 'entrei nova data data atual' + @DATAATUAL 
		    SELECT @MOMENTOMEDICACAO = DATEADD(day, 1, @MOMENTOMEDICACAO);
			SELECT @DATAATUAL = @MOMENTOMEDICACAO;
		END
		
		INSERT 
			INTO AndamentoMedicacoes(
			MedicacaoId
			, MtAndamentoMedicacao
			, PrescricaoPacienteId
			, CriadoEm
			, QtdeMedicao
			) 
		VALUES (
		@MEDICAMENTOID
		, @MOMENTOMEDICACAO
		, @PRESCRICAOPACIENTEID
		, GETDATE()
		, @QTDE
		);
	END
END

--SP_HELP AndamentoMedicacoes