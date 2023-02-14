
using Newtonsoft.Json;

namespace WEB_API_HealTime.Models;

public class TipoMedicacao
{
    public int TipoMedicacaoId { get; set; }
    public string DescMedicacao { get; set; }
    [JsonIgnore]
    public Medicacao Medicacao { get; set; }
}
