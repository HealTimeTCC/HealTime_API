SELECT * FROM PrescricaoPacientes
SELECT * FROM Medicacoes
SELECT * FROM PrescricoesMedicacoes

SELECT 
PM.PrescricaoPacienteId 
,PM.Qtde
,PM.Duracao
,PM.Intervalo
,M.NomeMedicacao
FROM PrescricoesMedicacoes PM
INNER JOIN Medicacoes M ON PM.MedicacaoId = M.MedicacaoId



sp_help Medicacoes

SELECT * FROM Pessoas
SELECT * FROM TiposMedicacoes
SELECT * FROM Medicos

update Medicacoes set NomeMedicacao = 'Novo teste'
where MedicacaoId = 3


--DELETE FROM PrescricaoPacientes
--DELETE FROM Medicacoes
--DELETE FROM PrescricoesMedicacoes
