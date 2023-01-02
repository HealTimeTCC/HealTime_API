using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_HealTime.Models;
public class GrauParentesco
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int GrauParentescoId { get; set; }

    [Required]
    [Column(TypeName = "varchar(30)")]
    public string DescGrauParentesco { get; set; }

    public List<ResponsavelPaciente> ResponsavelPacientes { get; set; }
}

