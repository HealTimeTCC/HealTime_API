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

UPDATE P SET P.dtNascimentoPesssoa = '2004-02-15' FROM Pessoas P

UPDATE P SET P.dtUltimoAcesso= GETDATE() FROM Pessoas P

--Valor default caso necessario
INSERT INTO Pessoas VALUES ('4c6f9a05-f3ee-447f-be11-21e00ad0177e', 1, 'Dan', 'Marzo', '56053311839', '2023-01-8', '2004-02-15', 1,	'Nenhuma', 'R Santo Anacleto', 'CangaCity', 'São Paulo', 'Nenhuma ué', '03720110', 11)



