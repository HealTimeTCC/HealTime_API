using Healtime.Domain.Entities.Medicacoes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Healtime.Domain.Entities.ConsultasMedicas;

public class Medico
{
    public int MedicoId { get; set; }
    public string NmMedico { get; set; }
    public string CrmMedico { get; set; }
    public string UfCrmMedico { get; set; }
    [JsonIgnore]
    public List<PrescricaoPaciente> PrescricoesPacientes { get; set; }
    [JsonIgnore]
    public List<ConsultaAgendada> ConsultaAgendadas { get; set; }
}
