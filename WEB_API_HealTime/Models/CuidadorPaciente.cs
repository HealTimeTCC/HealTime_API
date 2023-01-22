using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_HealTime.Models;

public class CuidadorPaciente
{
    public int Id { get; set; }//auto increment por se tratar de meio que um historico
    
    [Column(TypeName = "varchar(40)")]
    [ForeignKey("Pessoas")]
    public string CuidadorId { get; set; }

    [JsonIgnore]//Item de navegação Não aparece no edit do Json quando mencionado
    public Pessoa IdCuidador { get; set; }

    [Column(TypeName = "varchar(40)")]
    [ForeignKey("Pessoas")]
    public string PacienteIncapazId { get; set; }
    [JsonIgnore]//Item de navegação Não aparece no edit do Json quando mencionado
    public Pessoa IdPacienteIncapaz { get; set; }

    [Column(TypeName = "varchar(40)")]
    [ForeignKey("Pessoas")]
    public string ResponsavelId { get; set; }
    [JsonIgnore]//Item de navegação Não aparece no edit do Json quando mencionado
    public Pessoa IdResponsavel { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime CriadoEm { get; set; }
}
