using System.Text.Json.Serialization;

namespace WEB_API_HealTime.Models.Medicacoes;

public class PrescricaoMedicacao
{
    public int PrescricaoMedicacaoId { get; set; }
    public int PrescricaoPacienteId { get; set; }
    [JsonIgnore]
    public PrescricaoPaciente PrescricaoPaciente { get; set; }
    public int MedicacaoId { get; set; }
    [JsonIgnore]
    public Medicacao Medicacao { get; set; }
    public decimal Qtde { get; set; }//perguntar como fica os liquidos
    public TimeSpan Intervalo { get; set; }
    public decimal Duracao { get; set; }//Por interpretamos como duracao de dias
    public string StatusMedicacaoFlag { get; set; }
}
