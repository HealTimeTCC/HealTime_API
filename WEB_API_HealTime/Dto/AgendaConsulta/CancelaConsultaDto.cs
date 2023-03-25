using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_HealTime.Dto.AgendaConsulta;

[NotMapped]
public class CancelaConsultaDto
{
    public int IdConsulta { get; set; }
    public string MotivoCancelamento { get; set; }
    public DateTime DataCancela { get; set; }
}
