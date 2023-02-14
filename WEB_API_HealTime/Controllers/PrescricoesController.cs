using Microsoft.AspNetCore.Mvc;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescricoesController : ControllerBase
{
    private DataContext _dataContext;
    public PrescricoesController (DataContext dataContext){_dataContext = dataContext;}

    [HttpPost]
    public async Task<IActionResult> IncluirPrescricoes(PrescricaoPaciente prescricaoPaciente)
    {
		try
		{


			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
    }
}
