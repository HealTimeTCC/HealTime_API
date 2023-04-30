using Newtonsoft.Json;

namespace WEB_API_HealTime.Models.Medicacoes;

public class AndamentoMedicacao
{
    public DateTime MtAndamentoMedicacao { get; set; }
    public int PrescricaoPacienteId { get; set; }
    [JsonIgnore]
    public PrescricaoPaciente PrescricaoPacientes { get; set; }
    public int MedicacaoId { get; set; }
    //[JsonIgnore]
    //public PrescricaoPaciente PrescricaoPacientes_MedicacaoId { get; set; }
    public int QtdeMedicao { get; set; }
    public DateTime CriadoEm { get; set; }
    public bool BaixaAndamentoMedicacao { get; set; }
    public DateTime? MtBaixaMedicacao { get; set; }
}
