using System.ComponentModel.DataAnnotations;

namespace WEB_API_HealTime.Dto.Paciente;

public class IncluiObservacaoDto
{
    public int SqObservacao { get; set; }
    [Required]
    public int PacienteId { get; set; }
    public DateTime MtObservacao { get; set; }
    public string Observacao { get; set; }
}
