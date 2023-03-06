SELECT P.ObsPacienteIncapaz FROM Pessoas P  WHERE TipoPessoa = 2

SELECT * FROM Pessoas P  WHERE TipoPessoa = 2
UPDATE P SET P.NomePessoa = 'Dan', p.SobrenomePessoa = 'Marzo' FROM Pessoas P WHERE CpfPessoa = '56053311839'  
--1 -> paciente capaz   -> Nenhum
--2 -> Paciente incapaz -> Thiagao
--3 -> Responsavel      -> mayara 
--4 -> Cuidador	        -> Dan
SELECT * FROM Pessoas

SELECT P.NomePessoa, P.DtUltimoAcesso, C.TelefoneCelularObri FROM Pessoas P
INNER JOIN ContatoPessoas C ON C.PessoaId = P.PessoaId

SELECT p.NomePessoa, c.CriadoEm FROM Pessoas p
INNER JOIN CuidadorPacientes c ON C.CuidadorId = p.PessoaId

SELECT * FROM  CuidadorPacientes C

UPDATE P SET P.ObsPacienteIncapaz = 'Alérgico a leite' FROM Pessoas P

--DELETE C FROM CuidadorPacientes C

--DELETE P FROM Pessoas P WHERE TipoPessoa = 1

UPDATE P SET P.DtNascimentoPessoa = form FROM Pessoas P

UPDATE P SET P.dtUltimoAcesso= GETDATE() FROM Pessoas P

select * from PrescricaoPacientes

--Valor default caso necessario delete from pessoas
INSERT INTO Pessoas(TipoPessoa, NomePessoa,SobrenomePessoa,CpfPessoa,DtUltimoAcesso, DtNascimentoPessoa, GeneroPessoa,ObsPacienteIncapaz) VALUES(3,'Dan','Marzo','56053311839',GETDATE(),2004-02-15,1,'sdfsadfasfd')
INSERT INTO Pessoas(TipoPessoa, NomePessoa,SobrenomePessoa,CpfPessoa,DtUltimoAcesso, DtNascimentoPessoa, GeneroPessoa,ObsPacienteIncapaz) VALUES(2,'thiago','sla','12345678909',GETDATE(),2004-02-15,1,'sdfsadfasfd')
INSERT INTO Pessoas(TipoPessoa, NomePessoa,SobrenomePessoa,CpfPessoa,DtUltimoAcesso, DtNascimentoPessoa, GeneroPessoa,ObsPacienteIncapaz) VALUES(4,'mayara','sla','56053294802',GETDATE(),2004-02-15,1,'sdfsadfasfd')

INSERT INTO Medicacoes(Nome, QtdMedicacao, StatusMedicacao, TipoMedicacaoId, Composicao) VALUES('Dipirona', 10, 1, 2,1)

INSERT INTO PrescricaoPacientes(PacienteId, EmissaoPrescricao, DataCadastroSistema, DescFichaPessoa) VALUES (1, GETDATE(), GETDATE(), 'Efetuando teste')


SELECT * FROM PrescricaoMedicamentos

--Pessoas DAN

SELECT * FROM TipoMedicacoes
