using Microsoft.AspNetCore.Mvc;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;
using WEB_API_HealTime.Utility;
using WEB_API_HealTime.Models.Enuns;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.OData;
using System.Reflection.Metadata.Ecma335;
using System.Data.Entity;
using WEBAPIHealTime.Migrations;

namespace WEB_API_HealTime.Controllers;

[ApiController]
[Route("[Controller]")]
public class AssociarPessoasController : ControllerBase
{

    private readonly DataContext _context;
    public AssociarPessoasController(DataContext context){_context = context;}
    /*
    [HttpPost]
    public async Task<IActionResult> AssociaPacienteCuidador(Registrar registrar)
    {
        try//Ha de verificar o tipo de pessoa especialmente no caso do cuidador
        {   
            VerificarInfoPessoa verificar = new VerificarInfoPessoa();      

            //metodo de adaptação para o codigo funcionar -> os fraco dirão que é gambiarra :0
            if((registrar.CPFCuidador == registrar.CPFPacienteIn) || (registrar.CPFCuidador == registrar.CPFPacienteIn))

            if (!verificar.VerificadorCpfPessoa(registrar.CPFCuidador))
                throw new Exception($"CPF do cuidador {registrar.CPFCuidador} é invalido!");
            Pessoa cuidador = _context.Pessoas.FirstOrDefault(x => x.CpfPessoa == registrar.CPFCuidador);
                if (cuidador is null) return NotFound($"O cuidador portador do CPF {registrar.CPFCuidador} não existe");
                if (cuidador.TipoPessoa != TipoPessoa.Cuidador) throw new Exception($"{cuidador.NomePessoa}, portador(a) do CPF {cuidador.CpfPessoa} não esta cadastrado(a) como Cuidador");

            if (!verificar.VerificadorCpfPessoa(registrar.CPFResponsavel))
                throw new Exception($"O CPF do responsável {registrar.CPFResponsavel} é invalido!");
            Pessoa responsavel = _context.Pessoas.FirstOrDefault(x => x.CpfPessoa == registrar.CPFResponsavel);
                if (responsavel is null) return NotFound($"O cuidador portador do CPF {registrar.CPFResponsavel} não existe");
                if (responsavel.TipoPessoa != TipoPessoa.Responsavel) throw new Exception($"{responsavel.NomePessoa}, portador(a) do CPF {responsavel.CpfPessoa} não esta cadastrado(a) como Responsavel");

            if (!verificar.VerificadorCpfPessoa(registrar.CPFPacienteIn))
                throw new Exception($"O CPF do paciente incapaz {registrar.CPFPacienteIn} é invalido!");
            Pessoa paciente = _context.Pessoas.FirstOrDefault(x => x.CpfPessoa == registrar.CPFPacienteIn);
                if (paciente is null) return NotFound($"O cuidador portador do CPF {registrar.CPFPacienteIn} não existe");
                if (paciente.TipoPessoa != TipoPessoa.Paciente_Incapaz) throw new Exception($"{paciente.NomePessoa}, portador(a) do CPF {paciente.CpfPessoa} não esta cadastrado(a) como Paciente Incapaz");
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

    [HttpPost("Pessoa")]
    public async Task<IActionResult> BuscaPessoa(string cpfPessoa)
    {
        try
        {
            VerificarInfoPessoa verificarInfo = new();
            if (!verificarInfo.VerificadorCpfPessoa(cpfPessoa))
                throw new Exception("CPF invalido");

            List<CuidadorPaciente> cuidadorPacientes = await _context.CuidadorPacientes
                .Where(cp => cp.CPFPacienteIncapaz == cpfPessoa || cp.CPFCuidador == cpfPessoa || cp.CPFResponsavel == cpfPessoa)
                .ToListAsync();
            if (cuidadorPacientes is null)
                return NotFound("Nada encontrado");
            return Ok(cuidadorPacientes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }*/
}

public class Registrar
{
    public string CPFCuidador { get; set; }
    public string CPFResponsavel { get; set; }
    public string CPFPacienteIn { get; set; }
}

