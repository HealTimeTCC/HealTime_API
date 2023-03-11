using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
            Expires = DateTime.Now.AddHours(1),
            SigningCredentials = credentials
        };
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken (tokenDescriptor);
        return tokenHandler.WriteToken (token);
    }

    [HttpPost("Registro")]
    public async Task<IActionResult> RegistraPessoa(Pessoa pessoa)
    {
        try
        {

            _context.Pessoas.Add (pessoa);
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);  
        }
    }
}
