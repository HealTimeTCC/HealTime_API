using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WEB_API_HealTime.Models;
public class GrauParentesco
{
    public int GrauParentescoId { get; set; }
    public string DescGrauParentesco { get; set; }
    [JsonIgnore]
    public ResponsavelPaciente ResponsavelPacientes { get; set; }
}

