using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Data;
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
    public async Task<IActionResult> IncluirPrescricoes(PrescricaoPaciente prescricaoPaciente)
    {
		//Ter no minimo 1 paciente e 1 responsavel cadastrado
		try
		{
            Pessoa paciente = prescricaoPaciente.EmissaoPrescricao is null ?
				throw new Exception("É obrigatorio a data de emissao da prescricao")
				: await _context.Pessoas
                .FirstOrDefaultAsync(p => p.PessoaId == prescricaoPaciente.PacienteId);

            if (paciente.TipoPessoa == TipoPessoa.Paciente_Incapaz)
			{

			}

			if (paciente != null)
			{
                switch ((int)paciente.TipoPessoa)
                {
                    case 3: throw new Exception("O perfil Responsavel não pode receber Prescrições, atualize seu cadastro");
                    case 4: throw new Exception("O perfil Cuidador não pode receber Prescrições, atualize seu cadastro");
					default:
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
				throw new ArgumentNullException("Id Prescricao é obrigatorio : erro interno");

			if (prescricaoMedicamento.IntervaloMedicacao is null) 
				throw new ArgumentNullException("Intervalo obrigatorio : erro externo");
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
	[HttpPost("Estoque")]
	public async Task<IActionResult> NovaMedicacao(Medicacao novaMedicacao)
	{
		try
		{

			Medicacao medicacao = novaMedicacao.Nome is null?
				throw new ArgumentNullException("Nome não pode ser nulo")
				: await _context.Medicacoes.
                FirstOrDefaultAsync(m => m.Nome.ToLower() == novaMedicacao.Nome.ToLower());

			TipoMedicacao tipo = novaMedicacao.TipoMedicacao is null ?
				throw new ArgumentNullException("O tipo da medicação deve ser especificado")
				: await _context.TipoMedicacoes.FirstOrDefaultAsync(tp => tp.TipoMedicacaoId == novaMedicacao.TipoMedicacaoId);
			if (novaMedicacao.QtdMedicacao is null)
				throw new ArgumentNullException("Informe a quantidade");
			
			if (tipo is null)
				throw new Exception("Direcionar Inclusão");

            if (medicacao is null)
			{
				//Poder ser colocado aqui outra função, tipo Update cadastro
				throw new Exception("Erro por enquanto, se achar igual");
			}

			await _context.Medicacoes.AddAsync(novaMedicacao);
			await _context.SaveChangesAsync();
			return Ok(novaMedicacao);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
} 
