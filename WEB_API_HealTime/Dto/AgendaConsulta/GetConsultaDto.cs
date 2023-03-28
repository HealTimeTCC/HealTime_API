using System.ComponentModel.DataAnnotations;

namespace WEB_API_HealTime.Dto.AgendaConsulta;

public class GetConsultaDto
{
    [Required]
    public int ConsultaId { get; set; }
    [Required]
    public int Status { get; set; }
}
