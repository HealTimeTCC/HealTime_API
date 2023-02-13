
using System.Text.Json.Serialization;

namespace WEB_API_HealTime.Models;

public class PrescricaoMedicamento
{
    public int PrescricaoMedicamentoId { get; set; }
    public int? PrescricaoPacienteId { get; set; }
    [JsonIgnore]
    public PrescricaoPaciente PrescricaoPaciente { get; set; }
    /*public int AndamentoMedicacaoId { get; set; }
    [JsonIgnore]
    public AndamentoMedicacao AndamentoMedicacao { get; set; }*/
    public DateTime? HrDtMedicacao { get; set; }
    public DateTime? DtTerminoTratamento { get; set; }
    public int? QtdDiariaMedia { get; set; }
    public bool CheckSituacao { get; set; }
    public int MedicacaoId { get; set; }
    [JsonIgnore]
    public ICollection<Medicacao> Medicacoes { get; set; }
}
