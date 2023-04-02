using WEB_API_HealTime.Models.Pessoas;

namespace WEB_API_HealTime.Models.Pacientes;

public class CuidadorPaciente
{
    public int PacienteId { get; set; }
    public Pessoa PessoaPaciente { get; set; }
    public int CuidadorId { get; set; }
    public Pessoa PessoaCuidador { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime FinalizadoEm { get; set; }
}
