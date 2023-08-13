using Healtime.Domain.Entities.Medicacoes.Enums;
using Newtonsoft.Json;

namespace Healtime.Domain.Entities.Medicacoes;

public class TipoMedicacao
{
    public int TipoMedicacaoId { get; set; }
    public string DescMedicacao { get; set; }
    public string TituloTipoMedicacao { get; set; }
    public EnumClasseAplicacaoMedicacao ClasseAplicacao { get; set; }
    [JsonIgnore]
    public List<Medicacao> Medicacoes { get; set; }
}
