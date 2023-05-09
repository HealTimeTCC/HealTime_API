using System.ComponentModel.DataAnnotations.Schema;
using WEB_API_HealTime.Models.Pessoas.Enums;

namespace WEB_API_HealTime.Dto.Paciente;

public class ResponsavelPacienteDTO
{
    public int PessoaId { get; set; }
    public EnumTipoPessoa TipoPessoa { get; set; }
    public string CpfPessoa { get; set; }
    public string NomePessoa { get; set; }
    public string SobreNomePessoa { get; set; }
    public string PasswordString { get; set; }
    public DateTime DtNascPessoa { get; set; }
}
