SELECT P.ObsPacienteIncapaz FROM Pessoas P
SELECT * FROM Pessoas
SELECT P.NomePessoa, P.DtUltimoAcesso, C.TelefoneCelularObri FROM Pessoas P
INNER JOIN ContatoPessoas C ON C.PessoaId = P.PessoaId

SELECT p.NomePessoa, c.CriadoEm FROM Pessoas p
INNER JOIN CuidadorPacientes c ON C.CuidadorId = p.PessoaId

UPDATE P SET P.ObsPacienteIncapaz = 'Al�rgico a leite' FROM Pessoas P

DELETE P FROM Pessoas P
WHERE TipoPessoa = 1

UPDATE P SET P.dtNascimentoPesssoa = '2004-02-15' FROM Pessoas P

UPDATE P SET P.dtUltimoAcesso= GETDATE() FROM Pessoas P

--Valor default caso necessario
INSERT INTO Pessoas VALUES ('4c6f9a05-f3ee-447f-be11-21e00ad0177e', 1, 'Dan', 'Marzo', '56053311839', '2023-01-8', '2004-02-15', 1,	'Nenhuma', 'R Santo Anacleto', 'CangaCity', 'S�o Paulo', 'Nenhuma u�', '03720110', 11)