using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto.AgendaConsulta;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Repository.Interfaces;
using WEB_API_HealTime.Utility;
using WEB_API_HealTime.Utility.Enums;

namespace WEB_API_HealTime.Controllers;

[Route("[controller]")]
[ApiController]
public class ConsultaMedicaController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IConsultaMedicaRepository _consultaMedica;
    public ConsultaMedicaController(DataContext context, IConsultaMedicaRepository consultaMedica) { _context = context; _consultaMedica = consultaMedica; }

    #region Incluir Medico
    [HttpPost("IncluiMedico")]
    public async Task<IActionResult> IncluiMedico(Medico medico)
    {
        try
        {
            if (medico.UfCrmMedico is null
                || !FormataDados.StringLenght(medico.UfCrmMedico, TipoVerificadorCaracteresMinimos.UF))
                return BadRequest("UF inválido, verifique-o");
            if (!FormataDados.StringLenght(medico.CrmMedico, TipoVerificadorCaracteresMinimos.CRM))
                return BadRequest("O CRM do profissional da saúde deve ter 6 digitos");

            Medico medicoExiste =
                FormataDados.StringLenght(medico.NmMedico, TipoVerificadorCaracteresMinimos.Nome)
                ? throw new Exception("Nome demasiadamente pequeno")
                : await _consultaMedica.VerificaMedico(medico.CrmMedico, medico.UfCrmMedico);

            if (medicoExiste is not null)
                return BadRequest("O medico já está registrado");
            else
            {
                int linhas = await _consultaMedica.IncluiMedico(medico);
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
    [HttpPost("AgendarConsulta")]
    public async Task<IActionResult> IncluirConsulta(ConsultaAgendada consultaAgendada)
    {
        try
        {//FALTA VERIFICAR O PACIENTE
            if (await _consultaMedica.VerificaStatusConsulta(consultaAgendada.StatusConsultaId) is null)
                return NotFound("O ID do status não existe");

            if (await _consultaMedica.VerificaEspecialidade(consultaAgendada.EspecialidadeId) is null)
                return NotFound("Especialidade não existe, cadastre uma nova especialidade.");

            if (FormataDados.StringLenght(consultaAgendada.MotivoConsulta, TipoVerificadorCaracteresMinimos.MotivoCancelamentoConsulta))
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
    [HttpGet("Especialidades")]
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

    #region Consulta Por Paciente
    [HttpPost("ConsultaPorPaciente")]
    public async Task<IActionResult> ListaAgendamentosPacientes(ListConsultasDTO listConsultasDTO)
    {
        try
        {
            List<ConsultaAgendada> consultaAgendadas =
                await _consultaMedica.ListAgendamentosPacientes(listConsultasDTO);

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

    #region Cancelar Consulta por ID
    [HttpPatch("CancelarConsultaById")]
    public async Task<IActionResult> CancelarConsultaById(CancelaConsultaDto cancelaConsultaDto)
    {
        try
        {
            if (cancelaConsultaDto.MotivoCancelamento.Length < 5 || cancelaConsultaDto.MotivoCancelamento is null)
                return BadRequest("Insira no minimo 5 caracateres para o cancelamento");

            ConsultaAgendada cancelarConsulta = await _context.ConsultasAgendadas
                .Include(c => c.StatusConsulta)
                .FirstOrDefaultAsync(c => c.PacienteId == cancelaConsultaDto.PacienteId && c.ConsultasAgendadasId == cancelaConsultaDto.ConsultaId);

            if (cancelarConsulta is null)
                return NotFound("Consulta não encontrada, se isso acontecer é um problema no desenvolvimento");
            else if (cancelarConsulta.StatusConsultaId == 3)
                return BadRequest("Consulta já cancelada");

            ConsultaCancelada cancelada = new ConsultaCancelada()
            {
                ConsultaAgendadaId = cancelaConsultaDto.ConsultaId,
                DataCancelamento = DateTime.Now,
                MotivoCancelamento = cancelaConsultaDto.MotivoCancelamento
            };
            await _context.ConsultaCanceladas.AddAsync(cancelada);

            cancelarConsulta.StatusConsultaId = 3;
            var attach = _context.ConsultasAgendadas.Attach(cancelarConsulta);
            attach.Property(canc => canc.ConsultasAgendadasId).IsModified = false;
            attach.Property(canc => canc.StatusConsultaId).IsModified = true;
            attach.Property(canc => canc.PacienteId).IsModified = false;
            await _context.SaveChangesAsync();

            return Ok($"Consulta id {cancelaConsultaDto.ConsultaId} ");

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion

    #region Inclui Nova especialidade
    [HttpPost("IncluiNovaEspecialidade")]
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
}
