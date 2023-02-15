using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;
using WEB_API_HealTime.Models.Enuns;

namespace WEB_API_HealTime.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescricoesController : ControllerBase
{
    private readonly DataContext _context;
    public PrescricoesController (DataContext dataContext){_context = dataContext;}

	//PENDENTE DE TESTE
    [HttpPost]
    public async Task<IActionResult> IncluirPrescricoes(PrescricaoPaciente prescricaoPaciente)
    {
		
		try
		{
            Pessoa paciente = prescricaoPaciente.EmissaoPrescricao is null ?
				throw new Exception("É obrigatorio a data de emissao da prescricao")
				: await _context.Pessoas
                .FirstOrDefaultAsync(p => p.PessoaId == prescricaoPaciente.PacienteId);

			if (paciente != null)
			{
                await _context.PrescricaoPacientes.AddAsync(prescricaoPaciente);
				await _context.SaveChangesAsync();
                return Ok("Nova prescrição adicionada");
            }
			return NotFound("Paciente não encontrado");
            
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
    }

	[HttpPost("PesquisaMed")]
	public async Task<IActionResult> PesquisaMedicacao(string nomeMedicacao)
	{
		try
		{
			List<Medicacao> resultado = nomeMedicacao is null || nomeMedicacao == "" ? 
				throw new Exception("Insira o nome para busca")
				: await _context.Medicacoes.Where(nome => nome.Nome.ToLower() == nomeMedicacao.ToLower()).ToListAsync();
			
			if (resultado.Count == 0) return NotFound("Nada encontrado, inclua o medicamento");

			return Ok(resultado);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	//Controller abaixo somente para uso no BACK, não disponivel para uso final
	[HttpPost("PrescricaoMedicamento")]
	public async Task<IActionResult> IncluirMedicamentos(PrescricaoMedicamento prescricaoMedicamento)
	{
		try
		{
			if (prescricaoMedicamento.PrescricaoPacienteId is null) 
				throw new Exception("Id Prescricao é obrigatorio : erro interno");

			if (prescricaoMedicamento.IntervaloMedicacao is null) 
				throw new Exception("Intervalo obrigatorio : erro externo");
			if(prescricaoMedicamento.IntervaloMedicacao >= 1 && prescricaoMedicamento.IntervaloMedicacao <= 24)
			{
				await _context.PrescricaoMedicamentos.AddAsync(prescricaoMedicamento);
				await _context.SaveChangesAsync();
				return Ok("Bom :)");
			}

			throw new Exception("O intervalo deve ser de 1h a no maximo 24");
			//O nome do medicamento é incluido atraves do resultado de outra controller

		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
} 
