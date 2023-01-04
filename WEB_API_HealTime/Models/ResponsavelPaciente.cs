using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_HealTime.Models;
public class ResponsavelPaciente
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ResponsavelPacienteId { get; set; }

    //Tem que testar esse relacionamento para ver se vai dar certo, tenho minhas dúvidas ksks
    public int PacienteInId { get; set; }
    public Pessoa Id { get; set; }

    //Esse vai funcionar normal, só precisa saber do de cima
    public int ResponsavelId { get; set; }
    public Pessoa PessoaId { get; set; }

    public int GrauParentescoId { get; set; }
    public GrauParentesco GrauParentesco { get; set; }
}
