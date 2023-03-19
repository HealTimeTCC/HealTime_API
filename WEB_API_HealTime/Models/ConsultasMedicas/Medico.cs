using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WEB_API_HealTime.Models.Medicacoes;

namespace WEB_API_HealTime.Models.ConsultasMedicas;

public class Medico
{
    public int MedicoId { get; set; }
    public string NmMedico { get; set; }
    public string CrmMedico { get; set; }
    public string UfCrmMedico { get; set; }
    [JsonIgnore]
    public List<PrescricaoPaciente> PrescricoesPacientes { get; set; }
}
