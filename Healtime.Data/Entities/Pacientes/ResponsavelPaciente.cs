using Healtime.Domain.Entities.Pessoas;
using Newtonsoft.Json;

namespace Healtime.Domain.Entities.Pacientes;

public class ResponsavelPaciente
{
    public int PacienteId { get; set; }
    public Pessoa Paciente { get; set; }
    public int ResponsavelId { get; set; }
    public Pessoa Responsavel { get; set; }
    public DateTime CriadoEm { get; set; }
    public int GrauParentescoId { get; set; }
    public GrauParentesco GrauParentesco { get; set; }
}
