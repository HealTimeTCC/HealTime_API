using System.ComponentModel.DataAnnotations;

namespace Healtime.Application.Dto.Paciente;

public class IncluiObservacaoDto
{
    [Required]
    public int PacienteId { get; set; }
    public string Observacao { get; set; }
}
