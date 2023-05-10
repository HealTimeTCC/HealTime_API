using Microsoft.AspNetCore.Mvc;
using WEB_API_HealTime.Dto.Paciente;
using WEB_API_HealTime.Utility.EnumsGlobal;
using WEB_API_HealTime.Models.Pessoas;
using WEB_API_HealTime.Models.Pessoas.Enums;
using WEB_API_HealTime.Repository.Interfaces;
using WEB_API_HealTime.Utility;
using WEB_API_HealTime.Models.Pacientes;
using WEB_API_HealTime.Utility.Enums;
using WEB_API_HealTime.Models.Medicacoes;
using WEB_API_HealTime.Dto.GlobalEnums;
using System.Diagnostics;
using Xunit.Sdk;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WEB_API_HealTime.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class PacienteController : ControllerBase
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IPessoaRepository _pessoasRepository;
    public PacienteController(IPacienteRepository pacienteRepository, IPessoaRepository pessoaRepository)
    {
        _pessoasRepository = pessoaRepository;
        _pacienteRepository = pacienteRepository;
    }
    [HttpPost]
    public async Task<IActionResult> AssociarResponsavel(AssociaPacienteResponsavelDto pacienteResponsavelDto)
    {
        try
        {
            int[] id = new int[2] { 0, 0 };
            int[] tipoPessoa = new int[2] { 0, 0 };
            #region Responsável

            if (pacienteResponsavelDto.ResponsavelCpf != null && pacienteResponsavelDto.ResponsavelId != null)
            {
                if (!FormataDados.VerificadorCpfPessoa(pacienteResponsavelDto.ResponsavelCpf))
                    return BadRequest("CPF inválido");
                using (Pessoa responsavel = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpfEIdPessoa, cpfConsulta: pacienteResponsavelDto.ResponsavelCpf, idPessoa: pacienteResponsavelDto.ResponsavelId.ToString()))
                {
                    if (responsavel is null || responsavel.TipoPessoa != EnumTipoPessoa.Responsavel)
                        return NotFound("Responsavel com essas caracteristicas não encontrado(a)");
                    id[0] = responsavel.PessoaId;
                    responsavel.Dispose();
                }
            }
            else if (pacienteResponsavelDto.ResponsavelCpf != null && pacienteResponsavelDto.ResponsavelId == null)
            {
                if (!FormataDados.VerificadorCpfPessoa(pacienteResponsavelDto.ResponsavelCpf))
                    return BadRequest("CPF inválido");
                using (Pessoa responsavel = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpf, cpfConsulta: pacienteResponsavelDto.ResponsavelCpf))
                {
                    if (responsavel is null || responsavel.TipoPessoa != EnumTipoPessoa.Responsavel)
                        return NotFound("Responsavel com essas caracteristicas não encontrado(a)");
                    id[0] = responsavel.PessoaId;
                    responsavel.Dispose();
                }
            }
            else if (pacienteResponsavelDto.ResponsavelCpf == null && pacienteResponsavelDto.ResponsavelId != null)
            {
                using (Pessoa responsavel = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.pessoaId, idPessoa: pacienteResponsavelDto.ResponsavelId.ToString()))
                {
                    if (responsavel is null || responsavel.TipoPessoa != EnumTipoPessoa.Responsavel)
                        return NotFound("Responsavel com essas caracteristicas não encontrado(a)");
                    id[0] = responsavel.PessoaId;
                    responsavel.Dispose();
                }
            }
            else return BadRequest("Insira todos os campos necessários");
            #endregion

            #region Paciente

            if (pacienteResponsavelDto.PacienteCpf != null && pacienteResponsavelDto.PacienteId != null)
            {
                if (!FormataDados.VerificadorCpfPessoa(pacienteResponsavelDto.PacienteCpf))
                    return BadRequest("CPF inválido");
                using (Pessoa paciente = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpfEIdPessoa, cpfConsulta: pacienteResponsavelDto.PacienteCpf, idPessoa: pacienteResponsavelDto.PacienteId.ToString()))
                {
                    if (paciente is null || paciente.TipoPessoa != EnumTipoPessoa.PacienteIncapaz)
                        return NotFound("paciente com essas caracteristicas não encontrado(a)");
                    id[1] = paciente.PessoaId;
                    paciente.Dispose();
                }
            }
            else if (pacienteResponsavelDto.PacienteCpf != null && pacienteResponsavelDto.PacienteId == null)
            {
                if (!FormataDados.VerificadorCpfPessoa(pacienteResponsavelDto.PacienteCpf))
                    return BadRequest("CPF inválido");
                using (Pessoa paciente = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpf, cpfConsulta: pacienteResponsavelDto.PacienteCpf))
                {
                    if (paciente is null || paciente.TipoPessoa != EnumTipoPessoa.PacienteIncapaz)
                        return NotFound("paciente com essas caracteristicas não encontrado(a)");
                    id[1] = paciente.PessoaId;
                    paciente.Dispose();

                }
            }
            else if (pacienteResponsavelDto.PacienteCpf == null && pacienteResponsavelDto.PacienteId != null)
            {
                using (Pessoa paciente = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.pessoaId, idPessoa: pacienteResponsavelDto.PacienteId.ToString()))
                {
                    if (paciente is null || paciente.TipoPessoa != EnumTipoPessoa.PacienteIncapaz)
                        return NotFound("paciente com essas caracteristicas não encontrado(a)");
                    id[1] = paciente.PessoaId;
                    paciente.Dispose();
                }
            }
            else return BadRequest("Insira todos os campos necessários");
            #endregion

            ResponsavelPaciente responsavelPaciente = new()
            {
                ResponsavelId = id[0],
                PacienteId = id[1],
                CriadoEm = DateTime.Now,
                GrauParentescoId = pacienteResponsavelDto.GrauParentescoId
            };

            return await _pacienteRepository.SaveResponsavelPaciente(responsavelPaciente) ? Ok("Responsável adicionado com sucesso") : BadRequest("Duplicidade invalida");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> AssociarCuidador(AssociaPacienteCuidadorDto pacienteCuidadorDto)
    {
        try
        {
            int[] id = new int[2] { 0, 0 };
            int[] tipoPessoa = new int[2] { 0, 0 };
            #region Cuidador

            if (pacienteCuidadorDto.CuidadorCpf != null && pacienteCuidadorDto.CuidadorId != null)
            {
                if (!FormataDados.VerificadorCpfPessoa(pacienteCuidadorDto.CuidadorCpf))
                    return BadRequest("CPF inválido");
                using (Pessoa cuidador = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpfEIdPessoa, cpfConsulta: pacienteCuidadorDto.CuidadorCpf, idPessoa: pacienteCuidadorDto.CuidadorId.ToString()))
                {
                    if (cuidador is null || cuidador.TipoPessoa != EnumTipoPessoa.Cuidador)
                        return NotFound("Responsavel com essas caracteristicas não encontrado(a)");
                    id[0] = cuidador.PessoaId;
                    cuidador.Dispose();
                }
            }
            else if (pacienteCuidadorDto.CuidadorCpf != null && pacienteCuidadorDto.CuidadorId == null)
            {
                if (!FormataDados.VerificadorCpfPessoa(pacienteCuidadorDto.CuidadorCpf))
                    return BadRequest("CPF inválido");
                using (Pessoa responsavel = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpf, cpfConsulta: pacienteCuidadorDto.CuidadorCpf))
                {
                    if (responsavel is null || responsavel.TipoPessoa != EnumTipoPessoa.Cuidador)
                        return NotFound("Responsavel com essas caracteristicas não encontrado(a)");
                    id[0] = responsavel.PessoaId;
                    responsavel.Dispose();
                }
            }
            else if (pacienteCuidadorDto.CuidadorCpf == null && pacienteCuidadorDto.CuidadorId != null)
            {
                using (Pessoa responsavel = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.pessoaId, idPessoa: pacienteCuidadorDto.CuidadorId.ToString()))
                {
                    if (responsavel is null || responsavel.TipoPessoa != EnumTipoPessoa.Cuidador)
                        return NotFound("Responsavel com essas caracteristicas não encontrado(a)");
                    id[0] = responsavel.PessoaId;
                    responsavel.Dispose();
                }
            }
            else return BadRequest("Insira todos os campos necessários");
            #endregion

            #region Paciente

            if (pacienteCuidadorDto.PacienteCpf != null && pacienteCuidadorDto.PacienteId != null)
            {
                if (!FormataDados.VerificadorCpfPessoa(pacienteCuidadorDto.PacienteCpf))
                    return BadRequest("CPF inválido");
                using (Pessoa paciente = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpfEIdPessoa, cpfConsulta: pacienteCuidadorDto.PacienteCpf, idPessoa: pacienteCuidadorDto.PacienteId.ToString()))
                {
                    if (paciente is null || paciente.TipoPessoa != EnumTipoPessoa.PacienteIncapaz)
                        return NotFound("paciente com essas caracteristicas não encontrado(a)");
                    id[1] = paciente.PessoaId;
                    paciente.Dispose();
                }
            }
            else if (pacienteCuidadorDto.PacienteCpf != null && pacienteCuidadorDto.PacienteId == null)
            {
                if (!FormataDados.VerificadorCpfPessoa(pacienteCuidadorDto.PacienteCpf))
                    return BadRequest("CPF inválido");
                using (Pessoa paciente = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpf, cpfConsulta: pacienteCuidadorDto.PacienteCpf))
                {
                    if (paciente is null || paciente.TipoPessoa != EnumTipoPessoa.PacienteIncapaz)
                        return NotFound("paciente com essas caracteristicas não encontrado(a)");
                    id[1] = paciente.PessoaId;
                    paciente.Dispose();

                }
            }
            else if (pacienteCuidadorDto.PacienteCpf == null && pacienteCuidadorDto.PacienteId != null)
            {
                using (Pessoa paciente = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.pessoaId, idPessoa: pacienteCuidadorDto.PacienteId.ToString()))
                {
                    if (paciente is null || paciente.TipoPessoa != EnumTipoPessoa.PacienteIncapaz)
                        return NotFound("paciente com essas caracteristicas não encontrado(a)");
                    id[1] = paciente.PessoaId;
                    paciente.Dispose();
                }
            }
            else return BadRequest("Insira todos os campos necessários");
            #endregion

            CuidadorPaciente CuidadorPaciente = new()
            {
                CuidadorId = id[0],
                PacienteId = id[1],
                CriadoEm = DateTime.Now,
            };

            return await _pacienteRepository.SaveCuidadorPaciente(CuidadorPaciente) ? Ok("Cuidador adicionado com sucesso") : BadRequest("Duplicidade invalida");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> IncluiObservacao([FromBody] IncluiObservacaoDto obs)
    {
        try
        {
            using (Pessoa pessoa = await _pessoasRepository
                .ConsultarPessoa(TipoConsultaPessoa.pessoaId, idPessoa: obs.PacienteId.ToString()))
            {
                if (pessoa == null) return NotFound("Nada encontrado");
                if (pessoa.TipoPessoa != EnumTipoPessoa.PacienteIncapaz) return BadRequest("Observação somente a paciente incapaz");
            }
            if (!FormataDados.StringLenght(obs.Observacao, TipoVerificadorCaracteresMinimos.MotivoCancelamentoConsulta))
                return BadRequest("Quantidade minima de observacao 10 caracteres");
            return await _pacienteRepository.IncluirObservacoes(obs) ? Ok("Incluido com sucesso") : BadRequest("Falha");

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> GerarHorarios(GerarHorarioDto horario)
    {
        try
        {
            if (await _pacienteRepository.ExecuteProcedureDefineHorario(horario: horario))
            {
                return Ok("Horarios definido com sucesso");
            }
            return BadRequest("Erro ao definir horarios");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    public async Task<IActionResult> ListarAndamentosMedicacao()
    {
        try
        {
            List<AndamentoMedicacao> list = await _pacienteRepository.ListarAndamentoMedicacao();
            return list.Count == 0 ? NotFound("Nenhum medicamento em andamento encontrado") : Ok(list);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("{codPessoa:int}")]
    public async Task<IActionResult> PacienteByCodRespOrCuidador(int codPessoa)
    {
        try
        {
            List<Pessoa> listPacientes = new();
            Pessoa respOuCuidador = await _pessoasRepository.ConsultarPessoa(TipoConsultaPessoa.pessoaId, idPessoa: codPessoa.ToString());
            if (respOuCuidador is null)
                return NotFound("Pessoa não encontrado!");
            if (respOuCuidador.TipoPessoa == EnumTipoPessoa.Responsavel)
                listPacientes = await _pacienteRepository.ListPacienteByCodResposavelOrCuidador(enumTipoPessoa: EnumTipoPessoa.Responsavel, codResOrCuidador: codPessoa);
            else if (respOuCuidador.TipoPessoa == EnumTipoPessoa.Cuidador)
                listPacientes = await _pacienteRepository.ListPacienteByCodResposavelOrCuidador(enumTipoPessoa: EnumTipoPessoa.Cuidador, codResOrCuidador: codPessoa);
            else
                return BadRequest("Somente insira codigo de responsavel ou cuidador");
            return listPacientes.Count == 0 ? NotFound("Nenhum paciente associado") : Ok(listPacientes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{codMedicamento:int}/{codPrescicaoPacienteId:int}")]
    public async Task<IActionResult> ListHorarioByCodRemedio(int codMedicamento, int codPrescicaoPacienteId)
    {
        try
        {
            List<AndamentoMedicacao> list = await _pacienteRepository.ListarAndamentoMedicacao(codMedicamento, codPrescicaoPacienteId);
            return list.Count == 0 ? NotFound("Nenhum medicamento em andamento encontrado") : Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPatch]
    public async Task<IActionResult> BaixaMedicacao(BaixaHorarioMedicacaoDto medicacao)
    {
        try
        {
            return await _pacienteRepository.BaixaAndamentoMedicacao(medicacao) switch
            {
                StatusCodeEnum.Success => Ok("Baixa feita com sucesso"),
                StatusCodeEnum.NotFound => NotFound("Não foi encontrado esse andamento medicacao"),
                StatusCodeEnum.BadRequest => BadRequest("Erro interno"),
                _ => BadRequest("Erro interno"),
            };
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}
