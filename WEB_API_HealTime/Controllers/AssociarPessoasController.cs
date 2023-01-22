using Microsoft.AspNetCore.Mvc;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Controllers;

[ApiController]
[Route("[Controller]")]
public class AssociarPessoasController : ControllerBase
{

    private readonly DataContext _context;
    public AssociarPessoasController(DataContext context){_context = context;}

    [HttpPost]
    public async Task<IActionResult> AssociaPacienteCuidador(Registrar registrar)
    {
        try//Ha de verificar o tipo de pessoa especialmente no caso do cuidador
        {   //NotFound ele fica mais robusto porem ele para de executar o codigo quando um ja não é encontrado
            Pessoa cuidador = _context.Pessoas.FirstOrDefault(x => x.CpfPessoa == registrar.CPFCuidador);
                if (cuidador is null) return NotFound($"O cuidador portador do CPF {registrar.CPFCuidador}");
            
            Pessoa responsavel = _context.Pessoas.FirstOrDefault(x => x.CpfPessoa == registrar.CPFResponsavel);
                if (responsavel is null) return NotFound($"O cuidador portador do CPF {registrar.CPFResponsavel}");
            
            Pessoa paciente = _context.Pessoas.FirstOrDefault(x => x.CpfPessoa == registrar.CPFPacienteIn);
                if (paciente is null) return NotFound($"O cuidador portador do CPF {registrar.CPFPacienteIn}");

            CuidadorPaciente novo = new();

            novo.CuidadorId = cuidador.PessoaId;
            novo.ResponsavelId = responsavel.PessoaId;
            novo.PacienteIncapazId = paciente.PessoaId;
            novo.CriadoEm = DateTime.Now;
            await _context.CuidadorPacientes.AddAsync(novo);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("PesquisaIdPaciente", new { id = novo.PacienteIncapazId}, novo);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("id:string",Name ="PesquisaIdPaciente") ]
    public async Task<IActionResult> Teste()
    {
        return Ok();
    }
}

public class Registrar
{
    public string CPFCuidador { get; set; }
    public string CPFResponsavel { get; set; }
    public string CPFPacienteIn { get; set; }
}
