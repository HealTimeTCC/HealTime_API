
using Newtonsoft.Json;

namespace WEB_API_HealTime.Models;

public class PrescricaoPaciente
{
    //esse modelo devera ser arrumado conforme alguns padroes que deve ser adotados
    public int PrescricaoPacienteId { get; set; }
    public int? PacienteId { get; set; }
    [JsonIgnore]
    public Pessoa PacienteRePresc { get; set; }
    public string DescFichaPessoa { get; set; }
    public DateTime Emissao { get; set; }
    [JsonIgnore]
    public ICollection<PrescricaoMedicamento> PrescricaoMedicamentos { get; set; }
}
