namespace WEB_API_HealTime.Models.ConsultasMedicas;

public class ConsultasAgendadas
{
    public int ConsultasAgendadasId { get; set; }
    public int StatusConsultasId { get; set; }
    public int Especialidade { get; set; }
    public int PacienteId { get; set; }
    public int MedicoId { get; set; }
    public DateTime DataSolicitacaoConsulta { get; set; }
    public DateTime DataConsulta { get; set; }
    public string MotivoConsulta { get; set; }
    public string Encaminhamento { get; set; }
}
