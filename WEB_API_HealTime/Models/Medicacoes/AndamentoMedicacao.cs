
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WEB_API_HealTime.Models.Medicacoes;

public class AndamentoMedicacao
{
    public int AndamentoMedicacaoId { get; set; }
    public int PrescricaoMedicacaoId { get; set; }
    [JsonIgnore]
    public PrescricaoMedicacao PrescricaoMedicacao { get; set; }
    public int MedicacaoId { get; set; }
    public int PrescricaoPacienteId { get; set; }
    //[JsonIgnore]
    //public PrescricaoPaciente PrescricaoPacientes { get; set; }
    public DateTime MtAndamentoMedicacao { get; set; }
    public int QtdeMedicao { get; set; }
    public DateTime CriadoEm { get; set; }
    public bool BaixaAndamentoMedicacao { get; set; }
    public DateTime? MtBaixaMedicacao { get; set; }
    public int? CodAplicadorMedicacao { get; set; }
}
