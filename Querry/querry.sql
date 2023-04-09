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
delete from Pessoas
where PessoaId = 5

sp_help ConsultaCanceladas
sp_help ConsultasAgendadas
--Paciente = 1,
--PacienteIncapaz = 2,
--Responsavel = 3,
--Cuidador = 4

--delete from Pessoas
SELECT * FROM Pessoas
SELECT * FROM EnderecoPessoas

SELECT * FROM Especialidades
INSERT INTO Especialidades(DescEspecialidade) values ( 'PEDIATRA')

SELECT * FROM GrauParentesco
SELECT * FROM Medicacoes
SELECT * FROM ConsultasAgendadas
SELECT * FROM StatusConsultas
SELECT * FROM PrescricaoPacientes
SELECT * FROM PrescricoesMedicacoes
SELECT * FROM TiposMedicacoes
SELECT * FROM Medicos
SELECT * FROM ContatoPessoas
SELECT * FROM EnderecoPessoas
update Medicacoes set NomeMedicacao = 'Novo teste'
where MedicacaoId = 3
UPDATE Pessoas SET TipoPessoa = 1
WHERE PessoaId = 1

--DELETE FROM Pessoas

--DELETE FROM PrescricaoPacientes
--DELETE FROM Medicacoes
--DELETE FROM PrescricoesMedicacoes
