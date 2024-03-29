﻿using Healtime.Domain.Enums;
using System.Text;

namespace Healtime.Application.Querry.PacienteQuerry;

public class QuerryPaciente
{
    public static string SelectPacienteByCodResponsavelCuidador(int cod, EnumTipoPessoa tipo)
    {
        StringBuilder querry = new();

        querry.AppendLine("SELECT            ");
        querry.AppendLine("  PessoaId,       ");
        querry.AppendLine("  TipoPessoa,     ");
        querry.AppendLine("  CpfPessoa,      ");
        querry.AppendLine("  NomePessoa,     ");
        querry.AppendLine("  SobreNomePessoa,");
        querry.AppendLine("  DtNascPessoa    ");
        querry.AppendLine("FROM Pessoas P    ");
        if (tipo == EnumTipoPessoa.Responsavel)
        {
            querry.AppendLine(" INNER JOIN ResponsaveisPacientes RP ON P.PessoaId = RP.PacienteId ");
            querry.AppendLine($" WHERE RP.ResponsavelId = {cod}; ");

        }
        else
        {
            querry.AppendLine(" INNER JOIN CuidadorPacientes CP ON P.PessoaId = CP.PacienteId ");
            querry.AppendLine($" WHERE CP.CuidadorId  = {cod}; ");
        }

        return querry.ToString();
    }
    public static string SelectUltimaDosagemMedicamento(int codAplicador)
    {
        StringBuilder selectUltimaDosage = new();

        selectUltimaDosage.AppendLine("SELECT TOP 1 P.NomePessoa, P.PessoaId AS PacienteId, AM.MtBaixaMedicacao, AM.CodAplicadorMedicacao   ");  
        selectUltimaDosage.AppendLine("    FROM AndamentoMedicacoes AM                                                        ");
        selectUltimaDosage.AppendLine("INNER JOIN PrescricaoPacientes PP ON PP.PrescricaoPacienteId = AM.PrescricaoPacienteId ");
        selectUltimaDosage.AppendLine("INNER JOIN Pessoas P ON P.PessoaId = PP.PacienteId                                     ");
        selectUltimaDosage.AppendLine($"WHERE CodAplicadorMedicacao = {codAplicador}                                          ");
        selectUltimaDosage.AppendLine("ORDER BY MtBaixaMedicacao DESC;                                                        ");
        string cmd = selectUltimaDosage.ToString();
        return selectUltimaDosage.ToString();

    }
}

