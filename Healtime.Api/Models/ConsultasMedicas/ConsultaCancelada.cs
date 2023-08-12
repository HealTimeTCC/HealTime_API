using Newtonsoft.Json;

namespace WEB_API_HealTime.Models.ConsultasMedicas;

public class ConsultaCancelada
{
    public int ConsultaCanceladaId { get; set; }
    public int ConsultaAgendadaId { get; set; }
    [JsonIgnore]
    public ConsultaAgendada ConsultaAgendada { get; set; }
    public string MotivoCancelamento { get; set; }
    public DateTime DataCancelamento { get; set; }
}
