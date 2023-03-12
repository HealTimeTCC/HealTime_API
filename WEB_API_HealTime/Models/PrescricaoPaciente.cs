using Newtonsoft.Json;

namespace WEB_API_HealTime.Models;

public class PrescricaoPaciente
{
    public int PrescricaoPacienteId { get; set; }
    public int MedicoId { get; set; }
    [JsonIgnore]
    public Medico Medico { get; set; }
    public int PacienteId { get; set; }
    public DateTime? CriadoEm { get; set; }
    public DateTime Emissao { get; set; }
    public DateTime Validade { get; set; }
    public string DescFichaPessoa{ get; set; }
    [JsonIgnore]
    public List<PrescricaoMedicacao> PrescricoesMedicacoes { get; set; }
}
