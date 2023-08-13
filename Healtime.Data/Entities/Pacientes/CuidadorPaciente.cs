using Healtime.Domain.Entities.Pessoas;

namespace Healtime.Domain.Entities.Pacientes;

public class CuidadorPaciente
{
    public int PacienteId { get; set; }
    public Pessoa PessoaPaciente { get; set; }
    public int CuidadorId { get; set; }
    public Pessoa PessoaCuidador { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime? FinalizadoEm { get; set; }
}
