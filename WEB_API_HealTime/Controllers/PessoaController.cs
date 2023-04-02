using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WEB_API_HealTime.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models.Pessoas;
using WEB_API_HealTime.Dto.Pessoa;
using WEB_API_HealTime.Repository.Interfaces;
using WEB_API_HealTime.Models.Pessoas.Enums;
using WEB_API_HealTime.Utility.EnumsGlobal;
using Microsoft.AspNetCore.Identity;

namespace WEB_API_HealTime.Controllers;

[Authorize]
[Route("[controller]")]
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
    [HttpPost("Registro")]
    public async Task<IActionResult> RegistraPessoaAsync([FromBody] ResgistraPessoaDto pessoaDto)
    {
        try
        {
            Pessoa pessoa = new Pessoa();
            if (pessoaDto.TipoPessoa == EnumTipoPessoa.PacienteIncapaz)
            {
                pessoa.TipoPessoa = pessoaDto.TipoPessoa;
                pessoa.CpfPessoa = pessoaDto.CpfPessoa;// Falta verificador
                pessoa.NomePessoa = pessoaDto.NomePessoa;
                pessoa.SobreNomePessoa = pessoaDto.SobreNomePessoa;
                pessoa.PasswordHash = null;
                pessoa.PasswordSalt = null;
                pessoa.DtNascPessoa = pessoaDto.DtNascPessoa;
                if (await _pessoasRepository.ConsultarPessoa(pessoaDto.CpfPessoa, TipoConsultaPessoa.cpf) is not null)
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
                pessoa.CpfPessoa = pessoaDto.CpfPessoa; // Falta verificador
                pessoa.NomePessoa = pessoaDto.NomePessoa;
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
    [HttpPost("Autenticar")]
    public async Task<IActionResult> AutenticarAsync(LoginPasswordDto pessoa)
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
    [AllowAnonymous]
    [HttpPut("AlteraSenha")]
    public async Task<IActionResult> AlteraSenha(ResetPasswordDto resetPasswordDto)
    {
        if (resetPasswordDto.Email is null && resetPasswordDto.PessoaId == null)
            return BadRequest("E-mail ou senha sao obrigatorios para a troca da senha");
        Pessoa pessoaTrocaSenha = new();
        if (resetPasswordDto.Email != null && resetPasswordDto.PessoaId is null)
            pessoaTrocaSenha = await _pessoasRepository.ConsultarPessoa(resetPasswordDto.Email, Utility.EnumsGlobal.TipoConsultaPessoa.email);
        else if (resetPasswordDto.Email == null && resetPasswordDto.PessoaId != null)
            pessoaTrocaSenha = await _pessoasRepository.ConsultarPessoa(resetPasswordDto.PessoaId.ToString(), Utility.EnumsGlobal.TipoConsultaPessoa.pacienteId);
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
            bool salvo = await _pessoasRepository.UpdatePessoa(pessoaTrocaSenha, Utility.EnumsGlobal.TipoUpdatePessoa.ReplacePassword);
            if (salvo is false)
                return BadRequest("Erro interno ao salvar, contate o suporte");
            else
                return Ok("Senha alterada");
        }
    }
    #endregion

}
