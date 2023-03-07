using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto;
using WEB_API_HealTime.Models;
using WEB_API_HealTime.Models.Enuns;

namespace WEB_API_HealTime.Controllers;

[Route("[controller]")]
[ApiController]
public class PrescricoesController : ControllerBase
{
    private readonly DataContext _context;
    public PrescricoesController (DataContext dataContext){_context = dataContext;}

	//PENDENTE DE TESTE
    [HttpPost]
    public async Task<IActionResult> IncluirPrescricoes(DtoPrescricoes dtoPrescricaoPaciente)
    {
		//Ter no minimo 1 paciente e 1 responsavel cadastrado
		try
		{
            Pessoa paciente = dtoPrescricaoPaciente.EmissaoPrescricao is null ?
				throw new Exception("É obrigatorio a data de emissao da prescricao")
				: await _context.Pessoas
                .FirstOrDefaultAsync(p => p.PessoaId == dtoPrescricaoPaciente.PacienteId);

            if (paciente != null)
            {
                switch ((int)paciente.TipoPessoa)
                {
                    case 3: throw new Exception("O perfil Responsavel não pode receber Prescrições, atualize seu cadastro");
                    case 4: throw new Exception("O perfil Cuidador não pode receber Prescrições, atualize seu cadastro");
                    default:
						PrescricaoPaciente prescricaoPaciente = new();
						prescricaoPaciente.PacienteId = dtoPrescricaoPaciente.PacienteId;
						prescricaoPaciente.EmissaoPrescricao = dtoPrescricaoPaciente.EmissaoPrescricao;
						prescricaoPaciente.DescFichaPessoa = dtoPrescricaoPaciente.DescFichaPessoa;
						prescricaoPaciente.DataCadastroSistema = DateTime.Now;

                        await _context.PrescricaoPacientes.AddAsync(prescricaoPaciente);
                        await _context.SaveChangesAsync();
                        return Ok("Nova prescrição adicionada");
                }
            }
			return NotFound("Paciente não encontrado");
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
			//a propria api fornecerá o id do paciente
			if (prescricaoMedicamento.PrescricaoPacienteId is null) 
				throw new ArgumentNullException("Id Prescricao é obrigatorio : erro interno");

			if (prescricaoMedicamento.IntervaloMedicacao is null) 
				throw new ArgumentNullException("Intervalo obrigatorio : erro externo");
			if(prescricaoMedicamento.IntervaloMedicacao >= 1 && prescricaoMedicamento.IntervaloMedicacao <= 24)
			{
				await _context.PrescricaoMedicamentos.AddAsync(prescricaoMedicamento);
				await _context.SaveChangesAsync();
				return Ok("Bom :)");
			}
			throw new Exception("O intervalo deve ser de 1h a no maximo 24h");
			//O nome do medicamento é incluido atraves do resultado de outra controller

		}
		catch (Exception ex)
		{

			return BadRequest(ex.Message);
		}
	}
	public async Task<IActionResult> CalculaHorarioMedicacao(DateTime horaInicio, int prescricaoMedicamentoId)
	{
		try
		{
			PrescricaoMedicamento remedio = await _context.PrescricaoMedicamentos
				.FirstOrDefaultAsync(x => x.PrescricaoMedicamentoId == prescricaoMedicamentoId);
			AndamentoMedicacao andamento = new();
			andamento.CriadoEm = DateTime.Now;
			for (int i = 0; i < remedio.TotalDeDosesNecessaria; i++)
			{
				AndamentoMedicacao registroPendentes = new();
				registroPendentes.
			}

            //Por enquanto ele retorna uma array com as horas
            return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
	
} 
