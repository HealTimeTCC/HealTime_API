using Microsoft.AspNetCore.Mvc;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Controllers;

public class PessoasController : ControllerBase
{
    private readonly DataContext _context;
    public PessoasController(DataContext context){ _context = context; }

    [HttpPost]
    public async Task<IActionResult> AddPessoa(Pessoas pessoa)
    {
		try
		{
            Pessoas buscaP = await _context.Pessoas.FirstOrDefault(x => x.PessoaId == pessoa.PessoaId);
		}
		catch (Exception ex)
		{
            return BadRequest(ex.Message);
		}
    }
}
