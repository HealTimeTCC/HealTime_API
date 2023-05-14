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
using WEB_API_HealTime.Repository;
using Microsoft.EntityFrameworkCore;

namespace WEB_API_HealTime.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class PacienteController : ControllerBase
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IPessoaRepository _pessoasRepository;
    private readonly IMedicacaoRepository _medicacaoRepository;
    public PacienteController(IPacienteRepository pacienteRepository, IPessoaRepository pessoaRepository, IMedicacaoRepository medicacaoRepository)
    {
        _pessoasRepository = pessoaRepository;
        _pacienteRepository = pacienteRepository;
        _medicacaoRepository = medicacaoRepository;
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
                Pessoa responsavel = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpfEIdPessoa, cpfConsulta: pacienteResponsavelDto.ResponsavelCpf, idPessoa: pacienteResponsavelDto.ResponsavelId.ToString());

                if (responsavel is null || responsavel.TipoPessoa != EnumTipoPessoa.Responsavel)
                    return NotFound("Responsavel com essas caracteristicas não encontrado(a)");
                id[0] = responsavel.PessoaId;


            }
            else if (pacienteResponsavelDto.ResponsavelCpf != null && pacienteResponsavelDto.ResponsavelId == null)
            {
                if (!FormataDados.VerificadorCpfPessoa(pacienteResponsavelDto.ResponsavelCpf))
                    return BadRequest("CPF inválido");
                Pessoa responsavel = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpf, cpfConsulta: pacienteResponsavelDto.ResponsavelCpf);

                if (responsavel is null || responsavel.TipoPessoa != EnumTipoPessoa.Responsavel)
                    return NotFound("Responsavel com essas caracteristicas não encontrado(a)");
                id[0] = responsavel.PessoaId;


            }
            else if (pacienteResponsavelDto.ResponsavelCpf == null && pacienteResponsavelDto.ResponsavelId != null)
            {
                Pessoa responsavel = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.pessoaId, idPessoa: pacienteResponsavelDto.ResponsavelId.ToString());

                if (responsavel is null || responsavel.TipoPessoa != EnumTipoPessoa.Responsavel)
                    return NotFound("Responsavel com essas caracteristicas não encontrado(a)");
                id[0] = responsavel.PessoaId;


            }
            else return BadRequest("Insira todos os campos necessários");
            #endregion

            #region Paciente

            if (pacienteResponsavelDto.PacienteCpf != null && pacienteResponsavelDto.PacienteId != null)
            {
                if (!FormataDados.VerificadorCpfPessoa(pacienteResponsavelDto.PacienteCpf))
                    return BadRequest("CPF inválido");
                Pessoa paciente = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpfEIdPessoa, cpfConsulta: pacienteResponsavelDto.PacienteCpf, idPessoa: pacienteResponsavelDto.PacienteId.ToString());

                if (paciente is null || paciente.TipoPessoa != EnumTipoPessoa.PacienteIncapaz)
                    return NotFound("paciente com essas caracteristicas não encontrado(a)");
                id[1] = paciente.PessoaId;


            }
            else if (pacienteResponsavelDto.PacienteCpf != null && pacienteResponsavelDto.PacienteId == null)
            {
                if (!FormataDados.VerificadorCpfPessoa(pacienteResponsavelDto.PacienteCpf))
                    return BadRequest("CPF inválido");
                Pessoa paciente = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpf, cpfConsulta: pacienteResponsavelDto.PacienteCpf);

                if (paciente is null || paciente.TipoPessoa != EnumTipoPessoa.PacienteIncapaz)
                    return NotFound("paciente com essas caracteristicas não encontrado(a)");
                id[1] = paciente.PessoaId;


            }
            else if (pacienteResponsavelDto.PacienteCpf == null && pacienteResponsavelDto.PacienteId != null)
            {
                Pessoa paciente = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.pessoaId, idPessoa: pacienteResponsavelDto.PacienteId.ToString());

                if (paciente is null || paciente.TipoPessoa != EnumTipoPessoa.PacienteIncapaz)
                    return NotFound("paciente com essas caracteristicas não encontrado(a)");
                id[1] = paciente.PessoaId;

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
                Pessoa cuidador = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpfEIdPessoa, cpfConsulta: pacienteCuidadorDto.CuidadorCpf, idPessoa: pacienteCuidadorDto.CuidadorId.ToString());

                if (cuidador is null || cuidador.TipoPessoa != EnumTipoPessoa.Cuidador)
                    return NotFound("Responsavel com essas caracteristicas não encontrado(a)");
                id[0] = cuidador.PessoaId;


            }
            else if (pacienteCuidadorDto.CuidadorCpf != null && pacienteCuidadorDto.CuidadorId == null)
            {
                if (!FormataDados.VerificadorCpfPessoa(pacienteCuidadorDto.CuidadorCpf))
                    return BadRequest("CPF inválido");
                Pessoa responsavel = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpf, cpfConsulta: pacienteCuidadorDto.CuidadorCpf);

                if (responsavel is null || responsavel.TipoPessoa != EnumTipoPessoa.Cuidador)
                    return NotFound("Responsavel com essas caracteristicas não encontrado(a)");
                id[0] = responsavel.PessoaId;

            }
            else if (pacienteCuidadorDto.CuidadorCpf == null && pacienteCuidadorDto.CuidadorId != null)
            {
                Pessoa responsavel = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.pessoaId, idPessoa: pacienteCuidadorDto.CuidadorId.ToString());

                if (responsavel is null || responsavel.TipoPessoa != EnumTipoPessoa.Cuidador)
                    return NotFound("Responsavel com essas caracteristicas não encontrado(a)");
                id[0] = responsavel.PessoaId;

            }
            else return BadRequest("Insira todos os campos necessários");
            #endregion

            #region Paciente

            if (pacienteCuidadorDto.PacienteCpf != null && pacienteCuidadorDto.PacienteId != null)
            {
                if (!FormataDados.VerificadorCpfPessoa(pacienteCuidadorDto.PacienteCpf))
                    return BadRequest("CPF inválido");
                Pessoa paciente = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpfEIdPessoa, cpfConsulta: pacienteCuidadorDto.PacienteCpf, idPessoa: pacienteCuidadorDto.PacienteId.ToString());
                if (paciente is null || paciente.TipoPessoa != EnumTipoPessoa.PacienteIncapaz)
                    return NotFound("paciente com essas caracteristicas não encontrado(a)");
                id[1] = paciente.PessoaId;

            }
            else if (pacienteCuidadorDto.PacienteCpf != null && pacienteCuidadorDto.PacienteId == null)
            {
                if (!FormataDados.VerificadorCpfPessoa(pacienteCuidadorDto.PacienteCpf))
                    return BadRequest("CPF inválido");
                Pessoa paciente = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.cpf, cpfConsulta: pacienteCuidadorDto.PacienteCpf);
                
                   if (paciente is null || paciente.TipoPessoa != EnumTipoPessoa.PacienteIncapaz)
                    return NotFound("paciente com essas caracteristicas não encontrado(a)");
                id[1] = paciente.PessoaId;


            }
            else if (pacienteCuidadorDto.PacienteCpf == null && pacienteCuidadorDto.PacienteId != null)
            {
                Pessoa paciente = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.pessoaId, idPessoa: pacienteCuidadorDto.PacienteId.ToString());

                if (paciente is null || paciente.TipoPessoa != EnumTipoPessoa.PacienteIncapaz)
                    return NotFound("paciente com essas caracteristicas não encontrado(a)");
                id[1] = paciente.PessoaId;

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
            Pessoa pessoa = await _pessoasRepository
                .ConsultarPessoa(TipoConsultaPessoa.pessoaId, idPessoa: obs.PacienteId.ToString());

            if (pessoa == null) return NotFound("Nada encontrado");
            if (pessoa.TipoPessoa != EnumTipoPessoa.PacienteIncapaz) return BadRequest("Observação somente a paciente incapaz");

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
            Pessoa consultaTipo = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa:TipoConsultaPessoa.pessoaId, idPessoa: medicacao.CodAplicadorMedicacao.ToString());
            if (consultaTipo == null)
                return NotFound("Por favor verifique o codigo do aplicador");
            if (consultaTipo.TipoPessoa == EnumTipoPessoa.PacienteIncapaz)
                return BadRequest("Cod Invalido");
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
    [HttpPost]
    public async Task<IActionResult> EncerrarCuidadorPaciente(EncerrarCuidadorPacienteDto encerrarCuidadorPaciente)
    {
        try
        {
            Pessoa cuidador = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.pessoaId, idPessoa: encerrarCuidadorPaciente.CuidadorId.ToString());

            if (cuidador == null) return NotFound("Nenhum Cuidador foi encontrado");
            if (cuidador.TipoPessoa != EnumTipoPessoa.Cuidador) return BadRequest("Codigo enviado não confere com o tipo de cadastro da pessoa");

            Pessoa paciente = await _pessoasRepository.ConsultarPessoa(tipoConsultaPessoa: TipoConsultaPessoa.pessoaId, idPessoa: encerrarCuidadorPaciente.PacienteId.ToString());

            if (paciente == null) return NotFound("Nenhum Paciente foi encontrado");
            if (paciente.TipoPessoa != EnumTipoPessoa.PacienteIncapaz) return BadRequest("Codigo enviado não confere com o tipo de cadastro da pessoa");

            return await _pacienteRepository.EncerrarRelacaoCuidadorPaciente(encerrarCuidadorPaciente) switch
            {
                StatusCodeEnum.NotFound => NotFound("Nenhum item relacionado a busca foi encontrado"),
                StatusCodeEnum.BadRequest => BadRequest("Erro ao salvar"),
                StatusCodeEnum.NotContent => BadRequest("Não é possivel salvar um encerramento em um item ja finalizado"),
                StatusCodeEnum.Success or StatusCodeEnum.Update => Ok("Finalizado com sucesso"),
                _ => BadRequest("Erro ao salvar"),
            };
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{codCuidadorResponsavel:int}")]
    public async Task<IActionResult> UltimaDosagem(int codCuidadorResponsavel)
    {
        try
        {
            DateTime? ultimaDosagem = await _pacienteRepository.HoraUltimaDoseAplicada(codCuidadorResponsavel);
            return ultimaDosagem is null ? NotFound("Vazio") : Ok(ultimaDosagem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
