using System.Text.Json.Serialization;

namespace WEB_API_HealTime.Models.Medicacoes;

public class PrescricaoMedicacao
{
    public int PrescricaoMedicacaoId { get; set; }
    public int PrescricaoPacienteId { get; set; }
    [JsonIgnore]
    public PrescricaoPaciente PrescricaoPaciente { get; set; }
    public int MedicacaoId { get; set; }
    public Medicacao Medicacao { get; set; }
    public decimal Qtde { get; set; }//perguntar como fica os liquidos
    public TimeSpan Intervalo { get; set; }
    public int Duracao { get; set; }//Por interpretamos como duracao de dias
    public bool StatusMedicacaoFlag { get; set; }
    public bool HorariosDefinidos { get; set; }
    [JsonIgnore]
    public List<AndamentoMedicacao> AndamentoMedicacoes { get; set; }
}
