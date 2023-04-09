using Microsoft.AspNetCore.Mvc;
using WEB_API_HealTime.Dto.Paciente;
using WEB_API_HealTime.Utility.EnumsGlobal;
using WEB_API_HealTime.Models.Pessoas;
using WEB_API_HealTime.Models.Pessoas.Enums;
using WEB_API_HealTime.Repository.Interfaces;
using WEB_API_HealTime.Utility;
using WEB_API_HealTime.Models.Pacientes;
using System.Reflection.Metadata.Ecma335;

namespace WEB_API_HealTime.Controllers;

[Route("[controller]")]
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


    [HttpPost("AssociarResponsavel")]
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

    [HttpPost("AssociarCuidador")]
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
}
