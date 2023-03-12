using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto;
using WEB_API_HealTime.Dto.PrescricaoDTO;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Models.Medicacoes;

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
    public async Task<IActionResult> IncluiPrescricaoAsync([FromBody]PrescricaoDTO prescricaoDTO)
    {
        try
        {
            using (var context = _context)
            {
                Medico medico = prescricaoDTO.PrescricaoPaciente is null ?
                throw new Exception("Objeto nulo")
                : await context.Medicos
                .FirstOrDefaultAsync(x => x.MedicoId == prescricaoDTO.PrescricaoPaciente.MedicoId);
                
                PrescricaoPaciente insertPrescricaoPaciente = new();
                insertPrescricaoPaciente.CriadoEm = DateTime.Now;
                insertPrescricaoPaciente.MedicoId = prescricaoDTO.PrescricaoPaciente.MedicoId;
                insertPrescricaoPaciente.Emissao = prescricaoDTO.PrescricaoPaciente.Emissao;
                insertPrescricaoPaciente.PacienteId = prescricaoDTO.PrescricaoPaciente.PacienteId;
                insertPrescricaoPaciente.Validade = prescricaoDTO.PrescricaoPaciente.Validade;
                insertPrescricaoPaciente.DescFichaPessoa = prescricaoDTO.PrescricaoPaciente.DescFichaPessoa;
                
                await context.PrescricaoPacientes.AddAsync(insertPrescricaoPaciente);
                await context.SaveChangesAsync();
            }
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    //[HttpPost]
    //public async Task<IActionResult> IncluiMedicacao(Medicacao medicacao, pre)
    //{

    //}
}