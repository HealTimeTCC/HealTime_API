namespace Healtime.Application.Dto.Pessoa;

public class EnderecoPessoaDto
{
    public int PessoaId { get; set; }
    public string Logradouro { get; set; }
    public int NroLogradouro { get; set; }
    public string Complemento { get; set; }
    public string BairroLogradouro { get; set; }
    public string CidadeEndereco { get; set; }
    public int    UFEndereco { get; set; }
    public string CEPEndereco { get; set; }
}
