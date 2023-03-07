using WEB_API_HealTime.Models.Enuns;

namespace WEB_API_HealTime.Dto;

public class DtoPessoas
{
    public int PessoaId { get; set; }
    public string NomePessoa { get; set; }
    public string SobrenomePessoas { get; set; }
    public string CpfPessoa { get; set; }
    public DateTime? DtNascimentoPessoa { get; set; }
    public string ObsPacienteIncapaz { get; set; }
    public TipoPessoa TipoPessoa { get; set; }
    public Generos Genero { get; set; }
}
