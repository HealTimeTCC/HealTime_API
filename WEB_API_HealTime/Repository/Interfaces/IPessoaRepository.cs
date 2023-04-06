using WEB_API_HealTime.Dto.Pessoa;
using WEB_API_HealTime.Models.Pessoas;
using WEB_API_HealTime.Utility.EnumsGlobal;

namespace WEB_API_HealTime.Repository.Interfaces;

public interface IPessoaRepository
{
    Task<string> IncluiPessoa(Pessoa pessoa, ContatoPessoa contatoPessoa = null);
    Task<Pessoa> AutenticarPessoas(string email);
    Task<Pessoa> ConsultarPessoa(string dadoConsulta, TipoConsultaPessoa tipoConsultaPessoa);
    Task<bool> UpdatePessoa(Pessoa pessoa, TipoUpdatePessoa tipoConsultaPessoa);
    Task<bool> RegistrarNovoEndereco(EnderecoPessoa enderecoPessoa);
}
