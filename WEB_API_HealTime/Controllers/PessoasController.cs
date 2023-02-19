using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;
using WEB_API_HealTime.Models.Enuns;
using WEB_API_HealTime.Utility;

namespace WEB_API_HealTime.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoasController : ControllerBase
{
    private readonly DataContext _context;
    public PessoasController(DataContext context){ _context = context; }
    


    [HttpPost("Cadastro")]
    public async Task<IActionResult> CadastroAsync([FromBody] Pessoa pessoa)
    {
		try
		{
            VerificarInfoPessoa verificarInfoPessoa = new VerificarInfoPessoa();

            Pessoa buscaP = await _context.Pessoas.FirstOrDefaultAsync(x => x.CpfPessoa == pessoa.CpfPessoa);
            if (buscaP != null)
                throw new Exception("Cpf já cadastrado.");
            //O endereço tera como auto preenchimento será consumida em outra api

            if (!verificarInfoPessoa.VerificadorCpfPessoa(pessoa.CpfPessoa))
                throw new Exception($"Cpf '{pessoa.CpfPessoa}' está inválido.");
            if(!verificarInfoPessoa.VerificarNomePessoa(pessoa.NomePessoa, pessoa.SobrenomePessoa))
                throw new Exception($"O nome está inválido.");
            if(!verificarInfoPessoa.VerificarDtNascimentoPessoa((DateTime)pessoa.DtNascimentoPessoa, (TipoPessoa)pessoa.TipoPessoa))
                throw new Exception($"Data de nascimento está inválido.");

            //Uso de variavel Global para criação de contato
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
            return Ok($"{pessoa.NomePessoa} salvo!");
        }
		catch (Exception ex)
		{
            return BadRequest(ex.Message);
		}
    }

    [HttpPost("InfoContato")]
    public async Task<IActionResult> InfoContatoAsync([FromBody] ContatoPessoa ctt)
    {
        VerificarInfoPessoa verificarInfoPessoa = new();
        try
        {
            if (ctt.TelefoneCelularObri != null)
            {
                if (!verificarInfoPessoa.VerificarTelefoneCelular(ctt.TelefoneCelularObri))
                    throw new Exception("Telefone Celular invalido");
                if (ctt.TelefoneCelularOpcional != null && !verificarInfoPessoa.VerificarTelefoneCelular(ctt.TelefoneCelularOpcional))
                {
                    throw new Exception("Telefone Celular invalido");
                }
            }
            else
                throw new Exception("O telefone é obrigatório!");

            if (ctt.TelefoneFixo != null && !verificarInfoPessoa.VerificarTelefoneFixo(ctt.TelefoneFixo))
            {
                throw new Exception("Telefone Fixo Invalido");
            }

            await _context.ContatoPessoas.AddAsync(ctt);
            await _context.SaveChangesAsync();

            return Ok("Cadastrado com sucesso");

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }            
    }
    
    [HttpPost("IncluiInfoPacienteIn")]//Cria model so para molde do Pa In?
    public async Task<IActionResult> IncluiInfoPacienteIn(string cpfBusca, string obs)
    {
        try
        {
            if (cpfBusca is null)
                throw new Exception("O CPF é obrigatório");
            
            if (obs is null)
                throw new Exception("O campo Observação não deve estar em branco");
            
            Pessoa buscaInfP = await _context.Pessoas.FirstOrDefaultAsync(p => p.CpfPessoa == cpfBusca);

            if (buscaInfP is null)
                throw new Exception("CPF não cadastrado {Ideia para o front Redirection}");

            if (buscaInfP.ObsPacienteIncapaz is null)
                buscaInfP.ObsPacienteIncapaz = obs;

            buscaInfP.ObsPacienteIncapaz += " - ";
            buscaInfP.ObsPacienteIncapaz += obs;


            _context.Update(buscaInfP);
            await _context.SaveChangesAsync();


            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //Verificar o relacionamento no model *THIAGO ANOTAÇÕES :)*
    [HttpPost("AssociarGrauParentesco/{idPaciente:int}")]
    public async Task<IActionResult> IncluirParentescoAsync(int idResponsavel, int grauParentesco,[FromRoute] int idPaciente)
    {
        ResponsavelPaciente responsavelPaciente = new ResponsavelPaciente();

        try
        {
            Pessoa pessoaPaciente = await _context.Pessoas.FirstOrDefaultAsync(pac => pac.PessoaId == idPaciente);

            if (pessoaPaciente is null)
                return NotFound("Paciente não encontrado.");

            if (pessoaPaciente.TipoPessoa == Models.Enuns.TipoPessoa.Responsavel
                        || pessoaPaciente.TipoPessoa == Models.Enuns.TipoPessoa.Cuidador)
                throw new Exception("Paciente inválido.");


            Pessoa pessoaResponsavel = await _context.Pessoas.FirstOrDefaultAsync(res => res.PessoaId == idResponsavel);

            if (pessoaResponsavel is null)
                return NotFound("Pessoa não encontrada");
            if (pessoaResponsavel.TipoPessoa != Models.Enuns.TipoPessoa.Responsavel)
                throw new Exception("Essa pessoa não pode ser associada a esse paciente.");

            GrauParentesco parentesco = await _context.GrausParentesco.FirstOrDefaultAsync
                                            (grau => grau.GrauParentescoId == grauParentesco);

            if (parentesco is null)
            {
                return NotFound("Grau de parentesco não cadastrado.");
            }

            responsavelPaciente.GrauParentescoId = parentesco.GrauParentescoId;
            responsavelPaciente.ResponsavelId = idResponsavel;
            responsavelPaciente.PacienteInId = idPaciente;

            await _context.ResponsaveisPacientes.AddAsync(responsavelPaciente);
            await _context.SaveChangesAsync();

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpDelete("DeleteContato/{idContato:int}")]
    public async Task<IActionResult> DeleteContatoAsync([FromRoute] int idContato)
    {
        try
        {
            ContatoPessoa contatoPessoa = await _context.ContatoPessoas.
                                        FirstOrDefaultAsync(contato => contato.ContatoId == idContato);

            if (contatoPessoa is null)
                return NotFound("Não foi possível excluir o contato.");

            _context.ContatoPessoas.Remove(contatoPessoa);
            await _context.SaveChangesAsync();

            return Ok("Contato removido com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetInfoContato/{idPessoa:int}")]
    public async Task<IActionResult> GetInfoContatosAsync(int idPessoa)
    {
        try
        {
            Pessoa pessoaContatos = await _context.Pessoas
                                    .Include(contato => contato.ContatosPessoas)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(pessoa => pessoa.PessoaId == idPessoa);

            if (pessoaContatos is null)
                return NotFound("Pessoa não encontrada.");

            return Ok(pessoaContatos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //Não sei se o grau de parentesco vai ser o usuario que cadastre, eu acho que não deveria ter, ou deveria ter uns valores padrões
    //ele cadastrasse caso queira
    [HttpPost("CadastrarGrauParentesco")]
    public async Task<IActionResult> CadastrarGrauParentescoAsync([FromBody] GrauParentesco grauParentesco)
    {
        try
        {
            if (grauParentesco.DescGrauParentesco is null)
                throw new Exception("Descrição vazia, campo obrigatório.");

            //Incrementar o id
            await _context.GrausParentesco.AddAsync(grauParentesco);
            await _context.SaveChangesAsync();

            return Ok("Cadastrado com sucesso!");

        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("VerificarResponsavelPaciente/{idResponsavel:int}")]
    public async Task<IActionResult> VerificarResponsavelPacienteAsync([FromQuery] int idResponsavel)
    {
        try
        {
            List<ResponsavelPaciente> responsavelPacientes;
            Pessoa pessoaPaciente;
            List<Pessoa> pessoasPacientes = new List<Pessoa>();
            Pessoa responsavel;

            responsavel = await _context.Pessoas.FirstOrDefaultAsync(re => re.PessoaId == idResponsavel);

            if (responsavel.TipoPessoa != Models.Enuns.TipoPessoa.Responsavel)
                throw new Exception($"{responsavel.NomePessoa} não está cadastrado como responsavel.");

            responsavelPacientes = _context.ResponsaveisPacientes
                    .Where(re => re.ResponsavelId == idResponsavel)
                    .Include(pa => pa.PacienteId).ToList();

            if (responsavelPacientes is null)
                return NotFound("No momento não tem nenhum paciente associado a esse responsavel");

            foreach (var item in responsavelPacientes)
            {
                pessoaPaciente = await _context.Pessoas.FirstAsync(pe => pe.PessoaId == item.PacienteInId);
                pessoasPacientes.Add(pessoaPaciente);
            }

            return Ok(pessoasPacientes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("ObsPaciente")]
    public async Task<IActionResult> IncluirObservacoesPacienteAsync([FromQuery] int idPaciente, [FromQuery] int tipo)
    {
        try
        {
            Pessoa pessoa = await _context.Pessoas.FirstOrDefaultAsync(pessoa => pessoa.PessoaId == idPaciente && (int)TipoPessoa.Paciente_Incapaz == tipo);

            return Ok();
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}