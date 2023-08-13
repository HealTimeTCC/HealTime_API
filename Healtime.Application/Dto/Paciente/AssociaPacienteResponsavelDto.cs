using System.ComponentModel.DataAnnotations;

namespace Healtime.Application.Dto.Paciente;

public class AssociaPacienteResponsavelDto
{
    public int? PacienteId { get; set; }
    public int? ResponsavelId { get; set; }
    public string ResponsavelCpf { get; set; }
    public string PacienteCpf { get; set; }
    public DateTime CriadoEm { get; set; }
    [Required]
    public int GrauParentescoId { get; set; }
}
