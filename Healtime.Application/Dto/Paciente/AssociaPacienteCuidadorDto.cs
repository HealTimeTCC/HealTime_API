
namespace Healtime.Application.Dto.Paciente;

public class AssociaPacienteCuidadorDto
{
    public int? PacienteId { get; set; }
    public int? CuidadorId { get; set; }
    public string CuidadorCpf { get; set; }
    public string PacienteCpf { get; set; }
    public DateTime? CriadoEm { get; set; }
}
