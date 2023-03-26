using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto.AgendaConsulta;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Utility;
using WEB_API_HealTime.Utility.Enums;

namespace WEB_API_HealTime.Controllers;

[Route("[controller]")]
[ApiController]
public class ConsultaMedicaController : ControllerBase
{
    private readonly DataContext _context;
    public ConsultaMedicaController(DataContext context) { _context = context; }

    [HttpPost("IncluiMedico")]
    public async Task<IActionResult> IncluiMedico(Medico medico)
    {
        try
        {
            if (medico.UfCrmMedico is null)
                return BadRequest("Não é possivel inserir UF CRM com valor nulo");
            if (medico.CrmMedico.Length < 6)
                return BadRequest("O CRM do profissional da saúde deve ter 6 digitos");
            Medico medicoExiste =
                VerificaInfoPessoa.VerificaNome(medico.NmMedico)
                ? throw new Exception("Nome demasiadamente pequeno")
                : await _context.Medicos
                    .FirstOrDefaultAsync(crm => crm.CrmMedico == medico.CrmMedico && crm.UfCrmMedico.ToUpper().Trim() == medico.UfCrmMedico.ToUpper().Trim());
            if (medicoExiste is not null)
                return BadRequest("O medico já está registrado");
            else
            {
                await _context.Medicos.AddAsync(medico);
                int linhas = await _context.SaveChangesAsync();
                return Ok($"Medicos incluido {linhas}");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("AgendarConsulta")]
    public async Task<IActionResult> IncluirConsulta(ConsultaAgendada consultaAgendada)
    {
        try
        {//FALTA VERIFICAR O PACIENTE
            StatusConsulta statusConsulta = await _context
            .StatusConsultas.FirstOrDefaultAsync(x => x.StatusConsultaId == consultaAgendada.StatusConsultasId);
            if (statusConsulta == null) return BadRequest("O ID do status não existe");
            Especialidade especialidade = await _context.Especialidades
                .FirstOrDefaultAsync(x => x.EspecialidadeId == consultaAgendada.EspecialidadeId);
            if (especialidade == null)
                return BadRequest("Especialidade não existe, cadastre uma nova especialidade.");
            if (consultaAgendada.MotivoConsulta.Length < 5)
                return BadRequest("Para melhor interpretação da leitura dessa consulta, insira mais detalhes do motivo");

            await _context.ConsultasAgendadas.AddAsync(consultaAgendada);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("Especialidades")]
    public async Task<IActionResult> GetEspecialidades()
    {
        try
        {
            return Ok(await _context.Especialidades.AsNoTracking().ToListAsync() is List<Especialidade> especialidade);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("ConsultaPorPaciente")]
    public async Task<IActionResult> ListaAgendamentosPacientes(int id, int statusConsulta)
    {
        try
        {
            List<ConsultaAgendada> consultaAgendadas = await _context.ConsultasAgendadas
                .AsNoTracking()
                .Include(inc => inc.Especialidade)
                    .Where(list => list.PacienteId == id
                    && list.StatusConsultasId == statusConsulta).ToListAsync();

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
            else if (cancelarConsulta.StatusConsultasId == 3)
                return BadRequest("Consulta já cancelada");

            ConsultaCancelada cancelada = new ConsultaCancelada()
            {
                ConsultaAgendadaId = cancelaConsultaDto.ConsultaId,
                DataCancelamento = DateTime.Now,
                MotivoCancelamento = cancelaConsultaDto.MotivoCancelamento
            };
            await _context.ConsultaCanceladas.AddAsync(cancelada);

            cancelarConsulta.StatusConsultasId = 3;
            var attach = _context.ConsultasAgendadas.Attach(cancelarConsulta);
            attach.Property(canc => canc.ConsultasAgendadasId).IsModified = false;
            attach.Property(canc => canc.StatusConsultasId).IsModified = true;
            attach.Property(canc => canc.PacienteId).IsModified = false;
            await _context.SaveChangesAsync();

            return Ok($"Consulta id {cancelaConsultaDto.ConsultaId} ");

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("IncluiNovaEspecialidade")]
    public async Task<IActionResult> IncluirNovaEspecialidade(Especialidade especialidade)
    {
        try
        {
            if (!FormataDados.VerificadorCaracteresMinimos(especialidade.DescEspecialidade, TipoVerificadorCaracteresMinimos.MotivoCancelamentoConsulta))
            {
                await _context.Especialidades.AddAsync(especialidade);
                await _context.SaveChangesAsync();
                return Ok($"Nova especialidade adicionada {especialidade.DescEspecialidade}");
            }
            else
                return BadRequest("A descrição deve ter no minimo 10 caracteres");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
