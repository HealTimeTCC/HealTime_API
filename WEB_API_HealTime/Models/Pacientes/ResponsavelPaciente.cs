using Newtonsoft.Json;
using WEB_API_HealTime.Models.Pessoas;

namespace WEB_API_HealTime.Models.Pacientes;

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
