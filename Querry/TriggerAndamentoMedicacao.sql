
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
		SELECT @QTD_ATUAL = (
		SELECT COUNT(*) FROM AndamentoMedicacoes 
			WHERE MtBaixaMedicacao IS NOT NULL 
			AND AndamentoMedicacaoId = @COD_ANDAMENTO )

		SELECT @QTD_CONTROLE_ESTADO = QtdeHorarios FROM ControleEstadoAndamentoMedicacao
		
		IF(@QTD_ATUAL = @QTD_CONTROLE_ESTADO)
		BEGIN
			UPDATE 
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