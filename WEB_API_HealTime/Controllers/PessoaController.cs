﻿using Microsoft.AspNetCore.Authorization;
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
    private readonly DataContext _context;
    private readonly IPessoaRepository _pessoasRepository;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public PessoaController(IPessoaRepository pessoaRepository, DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _pessoasRepository = pessoaRepository;
    }
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

    //new Claim(ClaimTypes.NameIdentifier, pessoa.PessoaId.ToString()),
    //new Claim(ClaimTypes.Name, pessoa.NomePessoa),
    //new Claim(ClaimTypes.Surname, pessoa.SobreNomePessoa),
    //new Claim(ClaimTypes.UserData, pessoa.TipoPessoaId.ToString())


    //private 
    #region RegistroPessoa
    [AllowAnonymous]
    [HttpPost("Registro")]
    public async Task<IActionResult> RegistraPessoaAsync(ResgistraPessoDTO pessoaDto)
    {
        try
        {
            Criptografia
                .CriarPasswordHash(pessoaDto.PasswordString, out byte[] hash, out byte[] salt);
            pessoaDto.PasswordString = string.Empty;
            Pessoa pessoa = new Pessoa()
            {
                TipoPessoa = pessoaDto.TipoPessoa,
                CpfPessoa = pessoaDto.CpfPessoa, // Falta verificador
                NomePessoa = pessoaDto.NomePessoa,
                SobreNomePessoa = pessoaDto.SobreNomePessoa,
                PasswordHash = hash,
                PasswordSalt = salt,
                DtNascPessoa = pessoaDto.DtNascPessoa,
            };
            return Ok($"Usuario {await _pessoasRepository.IncluiPessoa(pessoa)} cadastrado com sucesso!");
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
            Pessoa pessoaPesquisa = await _context.Pessoas
                .FirstOrDefaultAsync(user => user.NomePessoa.ToUpper() == pessoa.Email.ToUpper());
            if (pessoaPesquisa is null)
                throw new Exception("User nulo");
            else if (!Criptografia.VerificarPasswordHash(pessoa.PasswordString, pessoaPesquisa.PasswordHash, pessoaPesquisa.PasswordSalt))
                throw new Exception("Senha errada");
            else
            {
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
    public async Task<IActionResult> AlteraSenha(Pessoa pessoa, string novasenha)
    {
        if (pessoa.NomePessoa is null || pessoa.PasswordString is null)
            throw new Exception("Nome ou senha sao obrigatorios para a troca da senha");
        Pessoa pessoaTrocaSenha = await _context.Pessoas
            .FirstOrDefaultAsync(x => x.NomePessoa.ToUpper() == pessoa.NomePessoa.ToUpper());
        if (!Criptografia.VerificarPasswordHash(pessoa.PasswordString, pessoaTrocaSenha.PasswordHash, pessoaTrocaSenha.PasswordSalt))
        {
            throw new Exception("Senha invalida, tente recupera-la, so que isso eu não vou fazer :) voce que lute lembrando");
        }
        else
        {
            Criptografia.CriarPasswordHash(novasenha, out byte[] hash, out byte[] salt);
            pessoaTrocaSenha.PasswordSalt = salt;
            pessoaTrocaSenha.PasswordHash = hash;
            pessoaTrocaSenha.PasswordString = string.Empty;
            _context.Update(pessoaTrocaSenha);
            await _context.SaveChangesAsync();
            return Ok("Senha alterada");
        }
    }
    #endregion

    #region lista pessoas Buscar de acordo com o tipo

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Pessoas.ToListAsync());
    }
    #endregion
}
