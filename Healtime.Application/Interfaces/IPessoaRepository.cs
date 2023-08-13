using Healtime.Application.Dto.Pessoa;
using Healtime.Domain.Entities.Pessoas;
using Healtime.Domain.Enums;

namespace Healtime.Application.Interfaces;

public interface IPessoaRepository
{
    Task<Pessoa> IncluiPessoa(Pessoa pessoa, ContatoPessoa contatoPessoa = null);
    Task<Pessoa> AutenticarPessoas(string email);
    Task<Pessoa> ConsultarPessoa(TipoConsultaPessoa tipoConsultaPessoa, string cpfConsulta = "", string emailConsulta = "", string idPessoa = "");
    Task<bool> UpdatePessoa(Pessoa pessoa, TipoUpdatePessoa tipoConsultaPessoa);
    Task<bool> RegistrarNovoEndereco(EnderecoPessoa enderecoPessoa);
    Task<StatusCodeEnum> IncluiFoto(IncluiFotoPessoaDto incluiFoto);
}
