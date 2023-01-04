SELECT P.ObsPacienteIncapaz FROM Pessoas P

UPDATE P SET P.ObsPacienteIncapaz = 'Alérgico a leite' FROM Pessoas P

DELETE P FROM Pessoas P
WHERE TipoPessoa = 1

UPDATE P SET P.dtNascimentoPesssoa = '2004-02-15' FROM Pessoas P

UPDATE P SET P.dtUltimoAcesso= GETDATE() FROM Pessoas P