
using Newtonsoft.Json;

namespace WEB_API_HealTime.Models;

public class PrescricaoPaciente
{
    public int PrescricaoPacienteId { get; set; }
    public int PacienteId { get; set; }
    [JsonIgnore]
    public Pessoa PacienteRePresc { get; set; }
    public string DescFichaPessoa { get; set; }
    public DateTime? DataCadastroSistema { get; set; }
    public DateTime? EmissaoPrescricao { get; set; }
    [JsonIgnore]
    public ICollection<PrescricaoMedicamento> PrescricaoMedicamentos { get; set; }
}
