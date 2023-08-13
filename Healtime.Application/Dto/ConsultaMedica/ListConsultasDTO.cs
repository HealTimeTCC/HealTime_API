using System.ComponentModel.DataAnnotations;

namespace WEB_API_HealTime.Dto.AgendaConsulta;

public class ListConsultasDTO
{
    [Required]
    public int PacienteId { get; set; }
    public int? StatusConsultaId { get; set; }
}
