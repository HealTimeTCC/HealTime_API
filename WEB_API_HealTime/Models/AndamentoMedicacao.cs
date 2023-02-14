
using Newtonsoft.Json;

namespace WEB_API_HealTime.Models;

public class AndamentoMedicacao
{
    public int AndamentoMedicacaoId { get; set; }
    public int PrescricaoMedicamentoId { get; set; }
    [JsonIgnore]
    public PrescricaoMedicamento PrescricaoMedicamento { get; set; }
    public int QtdInicial { get; set; }
    public int QtdAtual { get; set; }
    public DateTime CriadoEm { get; set; }
}
