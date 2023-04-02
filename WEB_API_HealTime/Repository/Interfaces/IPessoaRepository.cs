using WEB_API_HealTime.Models.Pessoas;

namespace WEB_API_HealTime.Repository.Interfaces;

public interface IPessoaRepository
{
    Task<string> IncluiPessoa(Pessoa pessoa);
}
