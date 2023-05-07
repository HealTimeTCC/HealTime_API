using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto.AgendaConsulta;
using WEB_API_HealTime.Dto.ConsultaMedica;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Repository.Interfaces;
using WEB_API_HealTime.Utility;
using WEB_API_HealTime.Utility.Enums;

namespace WEB_API_HealTime.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class ConsultaMedicaController : ControllerBase
{
    private readonly IConsultaMedicaRepository _consultaMedica;
    private readonly IRateLimitCounterStore _counterStore;

    public ConsultaMedicaController(IRateLimitCounterStore counterStore, IConsultaMedicaRepository consultaMedica) { _consultaMedica = consultaMedica; _counterStore = counterStore; }

    #region Incluir Medico
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
}
