using Newtonsoft.Json;

namespace WEB_API_HealTime.Models.ConsultasMedicas;

public class StatusConsulta
{
    public int StatusConsultaId { get; set; }
    public string DescStatusConsulta { get; set; }
    [JsonIgnore]
    public List<ConsultaAgendada> ConsultasAgendadas { get; set; }
}
