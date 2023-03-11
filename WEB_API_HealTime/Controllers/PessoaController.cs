using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_HealTime.Data;

namespace WEB_API_HealTime.Controllers;

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
}
