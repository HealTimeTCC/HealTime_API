using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_HealTime.Models;

public class Pessoa
{
    public int PessoaId { get; set; }
    public int TipoPessoaId { get; set; }
    public string CpfPessoa { get; set; }
    public string NomePessoa { get; set; }
    public string SobreNomePessoa { get; set; }
    [NotMapped]
    public string PasswordString { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public DateTime DtNascPessoa { get; set; }
    [NotMapped]
    public string TokenJwt { get; set; }
}
