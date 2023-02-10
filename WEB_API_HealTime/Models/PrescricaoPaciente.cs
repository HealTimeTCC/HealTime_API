
namespace WEB_API_HealTime.Models;

public class PrescricaoPaciente
{
    public int PrescricaoPacienteId { get; set; }
    public int PacienteId { get; set; }
    [JsonIgnore]
    public string DescFichaPessoa { get; set; }
    public DateTime Emissao { get; set; }
}
