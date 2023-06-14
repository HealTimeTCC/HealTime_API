using Newtonsoft.Json;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Models.Pessoas;

namespace WEB_API_HealTime.Models.Medicacoes;

public class PrescricaoPaciente
{
    public int PrescricaoPacienteId { get; set; }
    public int MedicoId { get; set; }
    [JsonIgnore]
    public Medico Medico { get; set; }
    public int PacienteId { get; set; }
    [JsonIgnore]
    public Pessoa Pessoa { get; set; }
    public DateTime? CriadoEm { get; set; }
    public DateTime Emissao { get; set; }
    public DateTime Validade { get; set; }
    public string DescFichaPessoa { get; set; }
    public bool FlagStatusAtivo { get; set; }
    [JsonIgnore]
    public List<PrescricaoMedicacao> PrescricoesMedicacoes { get; set; }
}
