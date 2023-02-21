
using Newtonsoft.Json;
using WEB_API_HealTime.Models.Enuns;

namespace WEB_API_HealTime.Models;

public class TipoMedicacao
{
    public int TipoMedicacaoId { get; set; }
    public string TituloTipoMedicacao { get; set; }
    public ClasseAplicacao ClasseAplicacao { get; set; }
    public string DescMedicacao { get; set; }
    [JsonIgnore]
    public Medicacao Medicacao { get; set; }
}
