using System.ComponentModel.DataAnnotations;

namespace WEB_API_HealTime.Dto.Paciente;

public class IncluiObservacaoDto
{
    [Required]
    public int PacienteId { get; set; }
    public string Observacao { get; set; }
}
