using System.Text.Json.Serialization;

namespace WEB_API_HealTime.Models;

public class Medico
{
    public int MedicoId { get; set; }
    public string NmMedico { get; set;}
    public int CrmMedico { get; set; }
    public string UfCrmMedico { get; set; }
    [JsonIgnore]
    public PrescricaoPaciente PrescricaoPaciente { get; set; }
}
