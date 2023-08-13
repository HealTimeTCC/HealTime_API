using System.ComponentModel.DataAnnotations;

namespace Healtime.Application.Dto.AgendaConsulta;

public class ListConsultasDTO
{
    [Required]
    public int PacienteId { get; set; }
    public int? StatusConsultaId { get; set; }
}
