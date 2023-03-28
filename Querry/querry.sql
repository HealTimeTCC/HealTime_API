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

select * from TiposMedicacoes

sp_help Medicacoes
sp_help Medicos

insert into Medicos(CrmMedico,NmMedico, UfCrmMedico) values('123456', 'Dan Marzo', 'UF')

delete FROM Medicacoes


sp_help ConsultaCanceladas
sp_help ConsultasAgendadas





SELECT * FROM Especialidades
INSERT INTO Especialidades(DescEspecialidade) values ( 'PEDIATRA')

SELECT * FROM Medicacoes
SELECT * FROM ConsultasAgendadas
SELECT * FROM StatusConsultas
SELECT * FROM PrescricaoPacientes
SELECT * FROM PrescricoesMedicacoes
SELECT * FROM Pessoas
SELECT * FROM TiposMedicacoes
SELECT * FROM Medicos

update Medicacoes set NomeMedicacao = 'Novo teste'
where MedicacaoId = 3


--DELETE FROM PrescricaoPacientes
--DELETE FROM Medicacoes
--DELETE FROM PrescricoesMedicacoes
