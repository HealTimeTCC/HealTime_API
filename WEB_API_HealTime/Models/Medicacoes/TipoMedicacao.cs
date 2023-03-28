using Newtonsoft.Json;
using WEB_API_HealTime.Models.Medicacoes.Enums;

namespace WEB_API_HealTime.Models.Medicacoes;

public class TipoMedicacao
{
    public int TipoMedicacaoId { get; set; }
    public string DescMedicacao { get; set; }
    public string TituloTipoMedicacao { get; set; }
    public EnumClasseAplicacaoMedicacao ClasseAplicacao { get; set; }
    [JsonIgnore]
    public List<Medicacao> Medicacoes { get; set; }
}
