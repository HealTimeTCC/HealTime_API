using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEB_API_HealTime.Models.Enuns;

namespace WEB_API_HealTime.Models;

public class ContatoPessoa
{
    [Key]
    public int ContatoId { get; set; }
    
    [NotMapped]
    public Pessoa Pessoas { get; set; }
    public Guid PessoaId { get; set; }

    [Column(TypeName = "VARCHAR(11)")]
    public string TelefoneContato { get; set; }
    
    [Column(TypeName = "VARCHAR(70)")]
    public string EmailContato { get; set; }
    public TipoCtt TipoCtt { get; set; }
}
