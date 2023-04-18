sp_help ConsultaCanceladas
sp_help ConsultasAgendadas
sp_help Medicacoes
sp_help Medicos

--Paciente = 1,
--PacienteIncapaz = 2,
--Responsavel = 3,
--Cuidador = 4

SELECT 
PM.PrescricaoPacienteId 
,PM.Qtde
,PM.Duracao
,PM.Intervalo
,M.NomeMedicacao
FROM PrescricoesMedicacoes PM
INNER JOIN Medicacoes M ON PM.MedicacaoId = M.MedicacaoId

SELECT P.CpfPessoa, P.DtNascPessoa, RP.CriadoEm AS RESPONSAVEL, CP.CriadoEm AS CUIDADOR FROM Pessoas P 
LEFT JOIN ResponsaveisPacientes RP ON RP.PacienteId = P.PessoaId 
--INNER JOIN ResponsaveisPacientes RP ON RP.ResponsavelId = P.PessoaId 
LEFT JOIN CuidadorPacientes CP ON CP.CuidadorId = P.PessoaId

SELECT * FROM Pessoas
SELECT * FROM PrescricoesMedicacoes
SELECT * FROM Medicacoes
SELECT * FROM Medicos

SELECT * FROM TiposMedicacoes
select * FROM ObservacoesPacientes
SELECT * FROM ResponsaveisPacientes
SELECT * FROM EnderecoPessoas
SELECT * FROM Especialidades
SELECT * FROM GrauParentesco
SELECT * FROM ConsultasAgendadas
SELECT * FROM StatusConsultas
SELECT * FROM PrescricaoPacientes
SELECT * FROM ContatoPessoas
SELECT * FROM EnderecoPessoas


delete FROM Medicacoes
delete from Pessoas
where PessoaId = 5


update Medicacoes set NomeMedicacao = 'Novo teste'
where MedicacaoId = 3
UPDATE Pessoas SET TipoPessoa = 1
WHERE PessoaId = 1