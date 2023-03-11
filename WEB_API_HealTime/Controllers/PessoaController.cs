using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RpgApi.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;
    public PessoaController(DataContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    private string CriarToken(Pessoa pessoa)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim (ClaimTypes.NameIdentifier, pessoa.PessoaId.ToString()),
            new Claim (ClaimTypes.Name, pessoa.NomePessoa),
            new Claim (ClaimTypes.Surname, pessoa.SobreNomePessoa),
            new Claim (ClaimTypes.UserData, pessoa.TipoPessoaId.ToString())
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
        SecurityToken token = tokenHandler.CreateToken (tokenDescriptor);
        return tokenHandler.WriteToken (token);
    }
    [AllowAnonymous]
    [HttpPost("Registro")]
    public async Task<IActionResult> RegistraPessoaAsync(Pessoa pessoa)
    {
        try
        {
            Criptografia
                .CriarPasswordHash(pessoa.PasswordString, out byte[] hash, out byte[] salt);
            pessoa.PasswordString = string.Empty;
            pessoa.PasswordHash = hash;
            pessoa.PasswordSalt = salt;
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);  
        }
    }
    [AllowAnonymous]
    [HttpPost("Autenticar")]
    public async Task<IActionResult> AutenticarAsync(Pessoa pessoa)
    {
        try
        {
            Pessoa pessoaPesquisa = await _context.Pessoas
                .FirstOrDefaultAsync(user => user.NomePessoa.ToUpper() == pessoa.NomePessoa.ToUpper());
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
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Pessoas.ToListAsync());
    } 
    

}
