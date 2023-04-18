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
-
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
CREATE PROC CALCULA_HORARIO_MEDICACAO @PrescricaoPacienteId decimal, @PrescricaoMedicacaoId decimal, @MedicacaoId decimal
AS
BEGIN
	DECLARE @DURACAO decimal, 
	
	SELECT
		 PM.Duracao 
		, PM.Intervalo
		, PM.Qtde
	FROM PrescricoesMedicacoes PM
	INNER JOIN PrescricaoPacientes PP ON PP.PrescricaoPacienteId = PM.PrescricaoPacienteId
	WHERE 
		PP.PrescricaoPacienteId = @PrescricaoPacienteId
		AND PM.PrescricaoMedicacaoId = @PrescricaoMedicacaoId 
		AND PM.MedicacaoId = @MedicacaoId

END
