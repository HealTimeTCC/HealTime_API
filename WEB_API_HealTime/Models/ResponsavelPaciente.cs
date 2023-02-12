using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_HealTime.Models;
public class ResponsavelPaciente
{
    public string ResponsavelPacienteId { get; set; }
    public int? PacienteInId { get; set; }
    public Pessoa PacienteId { get; set; }
    public int? ResponsavelId { get; set; }
    public Pessoa IdResponsavel { get; set; }
    public DateTime CriadoEm { get; set; }
    public int? GrauParentescoId { get; set; }
    [JsonIgnore]
    public GrauParentesco GrauParentesco { get; set; }
}
