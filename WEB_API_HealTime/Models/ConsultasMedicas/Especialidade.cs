using Newtonsoft.Json;

namespace WEB_API_HealTime.Models.ConsultasMedicas;

public class Especialidade
{
    public int EspecialidadeId { get; set; }
    public string DescEspecialidade { get; set; }
    [JsonIgnore]
    public List<ConsultaAgendada> ConsultaAgendadas { get; set; }
}