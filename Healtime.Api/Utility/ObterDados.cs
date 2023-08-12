using System.Security.Claims;
using System.Text;
using WEB_API_HealTime.Models.Pessoas;
using WEB_API_HealTime.Models.Pessoas.Enums;

namespace WEB_API_HealTime.Utility;

public class ObterDados
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private ObterDados(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    //new Claim(ClaimTypes.NameIdentifier, pessoa.PessoaId.ToString()),
    //new Claim(ClaimTypes.Name, pessoa.NomePessoa),
    //new Claim(ClaimTypes.Surname, pessoa.SobreNomePessoa),
    //new Claim(ClaimTypes.UserData, pessoa.TipoPessoaId.ToString())

    public string ObterNomePessoa()
    {
        StringBuilder nomeCompleto = new StringBuilder();
        nomeCompleto.Append(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name) + " ");
        nomeCompleto.Append(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Surname));
        return nomeCompleto.ToString();
    }
    public int ObterUsuarioId()
    {
        return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
    public EnumTipoPessoa ObterTipoPessoa()
    {
        return (EnumTipoPessoa)Enum.Parse(typeof(EnumTipoPessoa),_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.UserData));
    }
}
