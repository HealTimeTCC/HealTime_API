using Newtonsoft.Json;

namespace Healtime.Domain.Entities.ConsultasMedicas;

public class Especialidade
{
    public int EspecialidadeId { get; set; }
    public string DescEspecialidade { get; set; }
    [JsonIgnore]
    public List<ConsultaAgendada> ConsultaAgendadas { get; set; }
}