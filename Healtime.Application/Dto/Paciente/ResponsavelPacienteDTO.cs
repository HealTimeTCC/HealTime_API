using Healtime.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healtime.Application.Dto.Paciente;

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
