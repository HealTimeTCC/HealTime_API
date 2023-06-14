
--select * from PrescricoesMedicacoes

CREATE OR ALTER TRIGGER ControlStatePrescriptionMedicine
ON AndamentoMedicacoes 
FOR INSERT, UPDATE
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
			WHERE CodAndamentoMedicacao = @COD_ANDAMENTO
		
		IF(@QTD_ATUAL = @QTD_CONTROLE_ESTADO)
		BEGIN
			UPDATE PrescricoesMedicacoes 
				SET StatusMedicacaoFlag = 0  
			WHERE PrescricaoMedicacaoId = (
			SELECT TOP 1 PrescricaoMedicacaoId 
				FROM AndamentoMedicacoes 
			WHERE AndamentoMedicacaoId = @COD_ANDAMENTO
			);
			UPDATE PrescricaoPacientes 
				SET FlagStatusAtivo = 0  
			WHERE PrescricaoPacienteId = (
			SELECT TOP 1 PrescricaoPacienteId 
				FROM AndamentoMedicacoes 
			WHERE AndamentoMedicacaoId = @COD_ANDAMENTO
			);
		END
	END
	ELSE
	BEGIN 
		IF(EXISTS(SELECT 1 FROM inserted))
		BEGIN
			INSERT INTO ControleEstadoAndamentoMedicacao(
			DataContagem
			, QtdeHorarios
			) VALUES(
				CURRENT_TIMESTAMP
				, (SELECT COUNT(*) FROM inserted)
			);
		END
	END
END