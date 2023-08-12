using Newtonsoft.Json;

namespace WEB_API_HealTime.Models.ConsultasMedicas;

public class ConsultaAgendada
{
    public int ConsultasAgendadasId { get; set; }
    public int StatusConsultaId { get; set; }
    [JsonIgnore]
    public StatusConsulta StatusConsulta { get; set; }
    public int EspecialidadeId { get; set; }
    [JsonIgnore]
    public Especialidade Especialidade { get; set; }
    public int PacienteId { get; set; }
    public int MedicoId { get; set; }
    [JsonIgnore]
    public Medico Medico { get; set; }
    public DateTime DataSolicitacaoConsulta { get; set; }
    public DateTime DataConsulta { get; set; }
    public string MotivoConsulta { get; set; }
    public string Encaminhamento { get; set; }
    [JsonIgnore]
    public ConsultaCancelada ConsultaCancelada { get; set; }
}
