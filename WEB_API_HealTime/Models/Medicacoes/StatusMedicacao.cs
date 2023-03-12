using Newtonsoft.Json;

namespace WEB_API_HealTime.Models.Medicacoes;

public class StatusMedicacao
{
    public int StatusMedicacaoId { get; set; }
    public string DescStatusMedicacao { get; set; }
    [JsonIgnore]
    public List<Medicacao> Medicacoes { get; set; }
}