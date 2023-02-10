using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_HealTime.Models;

public class CuidadorPaciente
{
    public int CuidadorPacienteId { get; set; }//auto increment por se tratar de meio que um historico
    
    public int? CuidadorId { get; set; }
    [JsonIgnore]//Item de navegação Não aparece no edit do Json quando mencionado
    public Pessoa CuidadorRelacaoNoPessoas { get; set; }
    public int? PacienteIncapazId { get; set; }
    [JsonIgnore]//Item de navegação Não aparece no edit do Json quando mencionado
    public Pessoa PacienteIncapazRelacaoNoPessoas { get; set; }
    public int? ResponsavelId { get; set; }
    [JsonIgnore]//Item de navegação Não aparece no edit do Json quando mencionado
    public Pessoa ResponsavelRelacaoNoPessoas { get; set; }

    public DateTime? CriadoEm { get; set; }
}
