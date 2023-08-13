using Healtime.Domain.Entities.Pessoas;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Healtime.Domain.Entities.Pacientes;

public class ObservacaoPaciente
{
    public int SqObservacao { get; set; }
    [Required]
    public int PacienteId { get; set; }
    [JsonIgnore]
    public Pessoa Paciente { get; set; }
    public DateTime MtObservacao { get; set; }
    public string Observacao { get; set; }
}
