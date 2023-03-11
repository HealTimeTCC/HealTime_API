using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Controllers;

[Route("[controller]")]
[ApiController]
public class MedicacoesController : ControllerBase
{
    private readonly DataContext _context;
    public MedicacoesController(DataContext context) { _context = context; }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _context.Medicos.ToListAsync());
    }

    [HttpPost("IncluiPrescricao")]
    public async Task<IActionResult> IncluiPrescricaoAsync([FromBody] DtoPrescricaoPaciente prescricaoPaciente)
    {
        try
        {
            Medico medico = prescricaoPaciente is null ?
                throw new Exception("Objeto nulo")
                : await _context.Medicos
                .FirstOrDefaultAsync(x => x.MedicoId == prescricaoPaciente.MedicoId);
            PrescricaoPaciente insertPrescricaoPaciente = new()
            {
                CriadoEm = DateTime.Now,
                MedicoId = prescricaoPaciente.MedicoId,
                Emissao = prescricaoPaciente.Emissao,
                PacienteId = prescricaoPaciente.PacienteId,
                Validade = prescricaoPaciente.Validade,
                DescFichaPessoa = prescricaoPaciente.DescFichaPessoa
            };
            await _context.PrescricaoPacientes.AddAsync(insertPrescricaoPaciente);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}