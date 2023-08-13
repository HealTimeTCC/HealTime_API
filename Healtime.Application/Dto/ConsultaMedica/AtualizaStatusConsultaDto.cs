using System.ComponentModel.DataAnnotations.Schema;

namespace Healtime.Application.Dto.AgendaConsulta;

[NotMapped]
public class AtualizaStatusConsultaDto
{
    public int ConsultaId { get; set; }
    public int PacienteId { get; set; }
    public string MotivoAlteracao { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public int StatusConsultaId { get; set; }
}
