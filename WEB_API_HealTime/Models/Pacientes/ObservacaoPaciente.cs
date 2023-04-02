using Newtonsoft.Json;
using WEB_API_HealTime.Models.Pessoas;

namespace WEB_API_HealTime.Models.Pacientes;

public class ObservacaoPaciente
{
    public int SqObservacao { get; set; }
    public int PacienteId { get; set; }
    [JsonIgnore]
    public Pessoa Paciente { get; set; }
    public DateTime MtObservacao { get; set; }
    public string Observacao { get; set; }
}
