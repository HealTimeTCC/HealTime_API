using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Utility;

namespace WEB_API_HealTime.Controllers;

[Route("[controller]")]
[ApiController]
public class ConsultaMedicaController : ControllerBase
{
    private readonly DataContext _context;
    public ConsultaMedicaController(DataContext context) { _context = context; }

    [HttpPost("IncluiMedico")]
    public async Task<IActionResult> IncluiMedico(Medico medico)
    {
        try
        {
            if (medico.UfCrmMedico is null)
                return BadRequest("Não é possivel inserir UF CRM com valor nulo");
            if (medico.CrmMedico.Length < 6)
                return BadRequest("O CRM do profissional da saúde deve ter 6 digitos");
            Medico medicoExiste =
                VerificaInfoPessoa.VerificaNome(medico.NmMedico)
                ? throw new Exception("Nome demasiadamente pequeno")
                : await _context.Medicos
                    .FirstOrDefaultAsync(crm => crm.CrmMedico == medico.CrmMedico && crm.UfCrmMedico.ToUpper().Trim() == medico.UfCrmMedico.ToUpper().Trim());
            if (medicoExiste is not null)
                return BadRequest("O medico já está registrado");
            else
            {
                await _context.Medicos.AddAsync(medico);
                int linhas = await _context.SaveChangesAsync();
                return Ok($"Medicos incluido {linhas}");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("AgendarConsulta")]
    public async Task<IActionResult> IncluirConsulta()
    {
        return Ok();
    }
}
