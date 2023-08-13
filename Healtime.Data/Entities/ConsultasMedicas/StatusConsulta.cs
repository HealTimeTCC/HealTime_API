using Newtonsoft.Json;

namespace Healtime.Domain.Entities.ConsultasMedicas;

public class StatusConsulta
{
    public int StatusConsultaId { get; set; }
    public string DescStatusConsulta { get; set; }
    [JsonIgnore]
    public List<ConsultaAgendada> ConsultasAgendadas { get; set; }
}
