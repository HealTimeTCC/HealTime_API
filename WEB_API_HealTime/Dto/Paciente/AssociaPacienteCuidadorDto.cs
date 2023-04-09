using System.ComponentModel.DataAnnotations;

namespace WEB_API_HealTime.Dto.Paciente;

public class AssociaPacienteCuidadorDto
{
    public int? PacienteId { get; set; }
    public int? CuidadorId { get; set; }
    public string CuidadorCpf { get; set; }
    public string PacienteCpf { get; set; }
    public DateTime CriadoEm { get; set; }
}
