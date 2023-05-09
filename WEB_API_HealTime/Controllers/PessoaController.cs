using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WEB_API_HealTime.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WEB_API_HealTime.Models.Pessoas;
using WEB_API_HealTime.Dto.Pessoa;
using WEB_API_HealTime.Repository.Interfaces;
using WEB_API_HealTime.Models.Pessoas.Enums;
using WEB_API_HealTime.Utility.EnumsGlobal;
using WEB_API_HealTime.Utility.Enums;
using WEB_API_HealTime.Dto.GlobalEnums;
using WEB_API_HealTime.Models.Medicacoes;
using WEB_API_HealTime.Repository;

namespace WEB_API_HealTime.Controllers;

[Authorize]
[Route("[controller]/[action]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly IPessoaRepository _pessoasRepository;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public PessoaController(IPessoaRepository pessoaRepository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _pessoasRepository = pessoaRepository;
    }
    #region Criando Token
    private string CriarToken(Pessoa pessoa)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim (ClaimTypes.NameIdentifier, pessoa.PessoaId.ToString()),
            new Claim (ClaimTypes.Name, pessoa.NomePessoa),
            new Claim (ClaimTypes.Surname, pessoa.SobreNomePessoa),
            new Claim (ClaimTypes.UserData, pessoa.TipoPessoa.ToString())
        };
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_configuration.GetSection("ConfigurationToken:Key").Value));
        SigningCredentials credentials =
            new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = credentials
        };
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    #endregion
    //new Claim(ClaimTypes.NameIdentifier, pessoa.PessoaId.ToString()),
    //new Claim(ClaimTypes.Name, pessoa.NomePessoa),
    //new Claim(ClaimTypes.Surname, pessoa.SobreNomePessoa),
    //new Claim(ClaimTypes.UserData, pessoa.TipoPessoaId.ToString())
    #region RegistroPessoa
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Registro([FromBody] ResgistraPessoaDto pessoaDto)
    {
        try
        {
            Pessoa pessoa = new Pessoa();
            if (pessoaDto.TipoPessoa == EnumTipoPessoa.PacienteIncapaz)
            {
                pessoa.TipoPessoa = pessoaDto.TipoPessoa;
                pessoa.CpfPessoa = FormataDados.VerificadorCpfPessoa(pessoaDto.CpfPessoa)
                    ? pessoaDto.CpfPessoa
                    : throw new Exception("CPF com formato incorreto");
                pessoa.NomePessoa = pessoaDto.NomePessoa;
                pessoa.SobreNomePessoa = pessoaDto.SobreNomePessoa;
                pessoa.PasswordHash = null;
                pessoa.PasswordSalt = null;
                pessoa.DtNascPessoa = pessoaDto.DtNascPessoa;

                if (await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpf, cpfConsulta: pessoaDto.CpfPessoa) is not null)
                    return BadRequest("Paciente ja cadastrado no sistema");
                return Ok($"Paciente {await _pessoasRepository.IncluiPessoa(pessoa)} cadastrado com sucesso!");
            }
            else
            {
                ContatoPessoa contatoPessoa = new();
                contatoPessoa.Celular = pessoaDto.ContatoCelular.IsNullOrEmpty() ? throw new ArgumentNullException("O celular é obrigatório") : pessoaDto.ContatoCelular;
                contatoPessoa.Email = pessoaDto.ContatoEmail.IsNullOrEmpty() ? throw new ArgumentNullException("O e-mail é obrigatório") : pessoaDto.ContatoEmail;
                contatoPessoa.CriadoEm = DateTime.Now;

                Criptografia
                    .CriarPasswordHash(pessoaDto.PasswordString, out byte[] hash, out byte[] salt);
                pessoaDto.PasswordString = string.Empty;

                pessoa.TipoPessoa = pessoaDto.TipoPessoa;
                pessoa.CpfPessoa = FormataDados.VerificadorCpfPessoa(pessoaDto.CpfPessoa)
                                    ? pessoaDto.CpfPessoa
                                    : throw new Exception("CPF com formato incorreto"); pessoa.NomePessoa = pessoaDto.NomePessoa;
                pessoa.SobreNomePessoa = pessoaDto.SobreNomePessoa;
                pessoa.PasswordHash = hash;
                pessoa.PasswordSalt = salt;
                pessoa.DtNascPessoa = pessoaDto.DtNascPessoa;

                return Ok($"Usuario {await _pessoasRepository.IncluiPessoa(pessoa, contatoPessoa)} cadastrado com sucesso!");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
    #region Autenticar
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Autenticar(LoginPasswordDto pessoa)
    {
        try
        {
            Pessoa pessoaPesquisa = await _pessoasRepository.AutenticarPessoas(pessoa.Email);
            if (pessoaPesquisa is null)
                return NotFound("Usuário não encontrado, por cadastre-se no sistema ou chora :)");
            else if (!Criptografia.VerificarPasswordHash(pessoa.PasswordString, pessoaPesquisa.PasswordHash, pessoaPesquisa.PasswordSalt))
                throw new Exception("Senha errada");
            else
            {
                pessoaPesquisa.PasswordString = string.Empty;
                pessoaPesquisa.PasswordSalt = null;
                pessoaPesquisa.PasswordHash = null;
                pessoaPesquisa.TokenJwt = CriarToken(pessoaPesquisa);
                return Ok(pessoaPesquisa);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
    #region AlterarSenha
    [HttpPut]
    public async Task<IActionResult> AlteraSenha(ResetPasswordDto resetPasswordDto)
    {
        if (resetPasswordDto.Email is null && resetPasswordDto.PessoaId == null)
            return BadRequest("E-mail ou senha sao obrigatorios para a troca da senha");
        Pessoa pessoaTrocaSenha = new();
        if (resetPasswordDto.Email != null && resetPasswordDto.PessoaId is null)
            pessoaTrocaSenha = await _pessoasRepository.ConsultarPessoa(TipoConsultaPessoa.email, emailConsulta: resetPasswordDto.Email);
        else if (resetPasswordDto.Email == null && resetPasswordDto.PessoaId != null)
            pessoaTrocaSenha = await _pessoasRepository.ConsultarPessoa(TipoConsultaPessoa.pessoaId, idPessoa: resetPasswordDto.PessoaId.ToString());
        if (pessoaTrocaSenha is null)
            return NotFound("Usuario não encontrado");
        else if (!Criptografia.VerificarPasswordHash(resetPasswordDto.PasswordString, pessoaTrocaSenha.PasswordHash, pessoaTrocaSenha.PasswordSalt))
            return BadRequest("Senha invalida, tente recupera-la, so que isso eu não vou fazer :) voce que lute lembrando");
        else
        {
            Criptografia.CriarPasswordHash(resetPasswordDto.NewPasswordString, out byte[] hash, out byte[] salt);
            pessoaTrocaSenha.PasswordSalt = salt;
            pessoaTrocaSenha.PasswordHash = hash;
            pessoaTrocaSenha.PasswordString = string.Empty;
            bool salvo = await _pessoasRepository.UpdatePessoa(pessoaTrocaSenha, TipoUpdatePessoa.ReplacePassword);
            if (salvo is false)
                return BadRequest("Erro interno ao salvar, contate o suporte");
            else
                return Ok("Senha alterada");
        }
    }
    #endregion
    #region Incluir Endereco
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> NovoEndereco(EnderecoPessoaDto enderecoPessoaDto)
    {
        try
        {
            EnderecoPessoa enderecoPessoa = new();

            enderecoPessoa.PessoaId = enderecoPessoaDto.PessoaId;

            enderecoPessoa.CEPEndereco = FormataDados
                .StringLenght(enderecoPessoaDto.CEPEndereco, TipoVerificadorCaracteresMinimos.CEP) ?
                enderecoPessoaDto.CEPEndereco : throw new Exception("Erro no CEP");

            enderecoPessoa.UFEndereco = FormataDados
                .VerificarUF(enderecoPessoaDto.UFEndereco, out string ufString)
                ? ufString : throw new Exception("Código do estado inválido");

            enderecoPessoa.Logradouro = FormataDados.StringLenght(enderecoPessoaDto.Logradouro, TipoVerificadorCaracteresMinimos.Nome) ?
                enderecoPessoaDto.Logradouro : throw new Exception("Nome muito pequeno");

            enderecoPessoa.NroLogradouro = enderecoPessoaDto.NroLogradouro;

            enderecoPessoa.BairroLogradouro = enderecoPessoaDto.BairroLogradouro;
            enderecoPessoa.CidadeEndereco = FormataDados.StringLenght(enderecoPessoaDto.CidadeEndereco, TipoVerificadorCaracteresMinimos.Nome) ?
                    enderecoPessoaDto.CidadeEndereco : throw new Exception("Verique o endereco, tamanho de caracteres muito pequeno");

            if (enderecoPessoaDto.Complemento == null || enderecoPessoaDto.Complemento == string.Empty)
                enderecoPessoa.Complemento = null;
            else
                enderecoPessoa.Complemento = FormataDados.StringLenght(enderecoPessoaDto.Complemento, TipoVerificadorCaracteresMinimos.Nome) ?
                   enderecoPessoaDto.Complemento : throw new Exception("O preenchimento do campo é opcional, porem ao preencher deve ter um tamanho minimo de caracteres");

            if (await _pessoasRepository.RegistrarNovoEndereco(enderecoPessoa))
                return Ok("Endereco registrado com sucesso");
            return BadRequest("Erro interno");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
    #region Incluir Foto
    public async Task<IActionResult> IncluirFoto(IncluiFotoPessoaDto incluiFoto)
    {
        try
        {
            return await _pessoasRepository.IncluiFoto(incluiFoto) switch
            {
                StatusCodeEnum.Success => Ok("Inclusão de foto feita com sucesso"),
                StatusCodeEnum.NotFound => NotFound("Não foi encontrado a pessoa cadastrada com esse ID"),
                StatusCodeEnum.BadRequest => BadRequest("Erro interno"),
                _ => BadRequest("Erro interno"),
            };
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }
    #endregion
    #region Pesquisar Pessoa por ID
    [HttpGet("{codPessoa}")]
    public async Task<IActionResult> PessoaById(int codPessoa)
    {
        try
        {
            Pessoa pessoa = await _pessoasRepository.ConsultarPessoa(TipoConsultaPessoa.pessoaId, idPessoa: codPessoa.ToString());
            return pessoa is null ? NotFound("Nenhum resultado") : Ok(pessoa);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion
}
