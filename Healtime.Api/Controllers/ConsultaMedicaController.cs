using Healtime.Application.Dto.AgendaConsulta;
using Healtime.Application.Dto.ConsultaMedica;
using Healtime.Application.Interfaces;
using Healtime.Domain.Entities.ConsultasMedicas;
using Healtime.Domain.Enums;
using Healtime.Infra.Data.Utility;
using Microsoft.AspNetCore.Mvc;

namespace WEB_API_HealTime.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class ConsultaMedicaController : ControllerBase
{
    private readonly IConsultaMedicaRepository _consultaMedica;
    private readonly IPessoaRepository _pessoaRepository;
    public ConsultaMedicaController(IConsultaMedicaRepository consultaMedica, IPessoaRepository pessoaRepository) { _consultaMedica = consultaMedica; _pessoaRepository = pessoaRepository; }

    #region Incluir Medico
    [HttpPost]
    public async Task<IActionResult> IncluiMedico(IncluiMedicoDto medico)
    {
        try
        {
            string uf = FormataDados.VerificarUF(medico.CodigoIgbeUfCrmMedico, out string ufString)
                ? ufString
                : throw new ArgumentNullException("Código IBGE invalido");

            if (!FormataDados.StringLenght(medico.CrmMedico, TipoVerificadorCaracteresMinimos.CRM))
                return BadRequest("O CRM do profissional da saúde deve ter 6 digitos");

            Medico medicoExiste =
                FormataDados.StringLenght(medico.NmMedico, TipoVerificadorCaracteresMinimos.Nome)
                ? await _consultaMedica.VerificaMedico(medico.CrmMedico, medico.CodigoIgbeUfCrmMedico.ToString())
                : throw new Exception("Nome demasiadamente pequeno");

            if (medicoExiste is not null)
                return BadRequest("O medico já está registrado");
            else
            {
                int linhas = await _consultaMedica.IncluiMedico(medico, uf);
                return Ok($"Medicos incluido {linhas}");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
    #region Agendar Consulta
    [HttpPost]
    public async Task<IActionResult> AgendarConsulta(ConsultaAgendada consultaAgendada)
    {
        try
        {//FALTA VERIFICAR O PACIENTE
            if (await _consultaMedica.VerificaStatusConsulta(consultaAgendada.StatusConsultaId) is null)
                return NotFound("O ID do status não existe");

            if (await _consultaMedica.VerificaEspecialidade(consultaAgendada.EspecialidadeId) is null)
                return NotFound("Especialidade não existe, cadastre uma nova especialidade.");

            if (!FormataDados.StringLenght(consultaAgendada.MotivoConsulta, TipoVerificadorCaracteresMinimos.MotivoCancelamentoConsulta))
                return BadRequest("Para melhor interpretação da leitura dessa consulta, insira mais detalhes do motivo");

            return Ok(await _consultaMedica.IncluiConsulta(consultaAgendada));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
    #region Buscar Especialidades
    [HttpGet]
    public async Task<IActionResult> GetEspecialidades()
    {
        try
        {

            List<Especialidade> especialidade = await _consultaMedica.BuscarEspecialidades();
            if (especialidade.Count == 0)
                return NotFound("Não há especialidades cadastradas");
            return Ok(especialidade);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
    #region Especialidade By COd

    [HttpGet("{codEspecialidade:int}")]
    public async Task<IActionResult> EspecialidadeByCod(int codEspecialidade)
    {
        try
        {
            Especialidade Especialidade = await _consultaMedica.EspecialidadeByCod(codEspecialidade);
            return Especialidade is null ? NotFound("Especialidade não encontrada") : Ok(Especialidade);
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }

    #endregion
    #region Consulta Por Paciente
    [HttpPost]
    public async Task<IActionResult> ListaAgendamentosPacientes(ListConsultasDTO listConsultasDTO)
    {
        try
        {
            List<ConsultaAgendada> consultaAgendadas = await _consultaMedica.ListAgendamentosPacientes(listConsultasDTO);

            if (consultaAgendadas.Count < 1)
                return NotFound("Nenhuma consulta encontrada");
            else
                return Ok(consultaAgendadas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion    
    #region Inclui Nova especialidade
    [HttpPost]
    public async Task<IActionResult> IncluirNovaEspecialidade(Especialidade especialidade)
    {
        try
        {
            if (!FormataDados.StringLenght(especialidade.DescEspecialidade, TipoVerificadorCaracteresMinimos.MotivoCancelamentoConsulta))
                return Ok($"Nova especialidade adicionada {await _consultaMedica.IncluiEspecialidade(especialidade)}");
            else
                return BadRequest("A descrição deve ter no minimo 10 caracteres");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
    #region Verificar ByIdConsultaAndIdPessoa

    [HttpGet("{idpessoa:int}/{idconsulta:int}")]
    public async Task<IActionResult> ConsultaAgendadaConsultaCodPessoaCod(int idpessoa, int idconsulta)
    {
        try
        {
            ConsultaAgendada consulta = await _consultaMedica.ConsultaAgendadaByCodConsultaCodPessoa(idpessoa, idconsulta);
            return consulta is null ? NotFound("Nenhuma consulta encontrado") : Ok(consulta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion
    #region Consultar medico ById
    [HttpGet("{codMedico:int}")]
    public async Task<IActionResult> ConsultarMedicoById(int codMedico)
    {
        try
        {
            Medico medico = await _consultaMedica.VerificaMedico(codMedico: codMedico);
            return medico is null ? NotFound($"{codMedico} não encontrado") : Ok(medico);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion
    #region Atualiza Consulta Medica

    [HttpPut]
    public async Task<IActionResult> AtualizarConsulta(AtualizaStatusConsultaDto atualizaStatusConsulta)
    {
        try
        {
            if(!FormataDados.StringLenght(atualizaStatusConsulta.MotivoAlteracao, TipoVerificadorCaracteresMinimos.MotivoCancelamentoConsulta))
                return BadRequest("É necessário mais de 10 caracteres no motivo para alteração");
            if (await _pessoaRepository.ConsultarPessoa(TipoConsultaPessoa.pessoaId, idPessoa: atualizaStatusConsulta.PacienteId.ToString()) is null)
                return NotFound("Usuario não cadastrado");
            atualizaStatusConsulta.DataAlteracao = DateTime.Now;
            return await _consultaMedica.AtualizaSituacaoConsultaAgendada(atualizaStatusConsulta) switch
            {
                StatusCodeEnum.Success => Ok("Cancelamento feito com sucesso"),
                StatusCodeEnum.NotFound => NotFound("Verifique os dados fornecidos"),
                StatusCodeEnum.BadRequest => BadRequest("Erro ao salvar, por favor tente novamente"),
                StatusCodeEnum.NotContent => BadRequest("Dado da atualização é o mesmo que o anterior"),
                StatusCodeEnum.Update => Ok("Dados atualizados com sucesso"),
                _ => BadRequest("Verifique os dados fornecidos"),
            };
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
}
