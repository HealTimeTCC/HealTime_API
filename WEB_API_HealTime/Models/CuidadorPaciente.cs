using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using WEB_API_HealTime.Models.Enuns;

namespace WEB_API_HealTime.Models;

public class CuidadorPaciente
{
    internal object Pessoas;

    public int Id { get; set; }//auto increment por se tratar de meio que um historico
    
    [Column(TypeName = "varchar(40)")]
    [ForeignKey("Pessoas")]
    public string CuidadorId { get; set; }

    [JsonIgnore]//Item de navegação Não aparece no edit do Json quando mencionado
    public Pessoa IdCuidador { get; set; }

    public string NomeCuidador { get;set; }
    public string CPFCuidador { get; set; }


    [Column(TypeName = "varchar(40)")]
    [ForeignKey("Pessoas")]
    public string PacienteIncapazId { get; set; }
    [JsonIgnore]//Item de navegação Não aparece no edit do Json quando mencionado
    public Pessoa IdPacienteIncapaz { get; set; }
    public string NomePacienteIncapaz { get; set; }
    public string CPFPacienteIncapaz { get; set; }

    
    
    [Column(TypeName = "varchar(40)")]
    [ForeignKey("Pessoas")]
    public string ResponsavelId { get; set; }
    [JsonIgnore]//Item de navegação Não aparece no edit do Json quando mencionado
    public Pessoa IdResponsavel { get; set; }
    public string NomeResponsavel { get; set; }
    public string CPFResponsavel { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime CriadoEm { get; set; }
}
