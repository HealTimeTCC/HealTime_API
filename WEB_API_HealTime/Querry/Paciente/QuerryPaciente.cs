using System.Text;
using WEB_API_HealTime.Models.Medicacoes;
using WEB_API_HealTime.Models.Pessoas;
using WEB_API_HealTime.Models.Pessoas.Enums;

namespace WEB_API_HealTime.Querry.PacienteQuerry;

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
        selectUltimaDosage.AppendLine("SELECT TOP 1 MtBaixaMedicacao FROM AndamentoMedicacoes");
        selectUltimaDosage.AppendLine($"    WHERE CodAplicadorMedicacao = {codAplicador}     ");
        selectUltimaDosage.AppendLine("    ORDER BY MtBaixaMedicacao DESC                    ");
        string cmd = selectUltimaDosage.ToString();
        return selectUltimaDosage.ToString();

    }
}

