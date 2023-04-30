using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;
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
    private readonly DataContext _context;
    private readonly IConsultaMedicaRepository _consultaMedica;
    public ConsultaMedicaController(DataContext context, IConsultaMedicaRepository consultaMedica) { _context = context; _consultaMedica = consultaMedica; }

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

    #region Cancelar Consulta por ID
    [HttpPatch]
    public async Task<IActionResult> AtualizarConsulta(AtualizaStatusConsultaDto atualizaStatusConsultaDto)
    {
        try
        {
            if (!FormataDados.StringLenght(atualizaStatusConsultaDto.MotivoAlteracao, TipoVerificadorCaracteresMinimos.MotivoCancelamentoConsulta))
                return BadRequest("Insira no minimo 10 caracateres para a alteração");

            switch (await _consultaMedica.AtualizaSituacaoConsultaAgendada(atualizaStatusConsultaDto))
            {
                case EnumAtualizaStatus.Update: 
                    return Ok("Atualização feita com sucesso");
                case EnumAtualizaStatus.NotUpdate: 
                    return BadRequest("Não houve alteração verifique os dados da solicitação");
                case EnumAtualizaStatus.NotFound: 
                    return NotFound("Consulta não foi encontrada");
                case EnumAtualizaStatus.Close: 
                    return Ok("Consulta encerrada com sucesso");
                default: return BadRequest("Erro interno, consulte o suporte");
            }
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

    #region ConsultaByIdConsultaAndIdPessoa

    [HttpGet("{idpessoa:int}/{idconsulta:int}")]
    public async Task<IActionResult> ConsultaByCodPessoaCod(int idpessoa, int idconsulta)
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
}
