using WEB_API_HealTime.Models.Medicacoes.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto.PrescricaoDTO;
using WEB_API_HealTime.Models.Medicacoes;
using WEB_API_HealTime.Repository.Interfaces;
using WEB_API_HealTime.Utility;
using WEB_API_HealTime.Dto.GlobalEnums;
using WEB_API_HealTime.Repository;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Dto.IncluiMedicacaoDto;

namespace WEB_API_HealTime.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class MedicacoesController : ControllerBase
{
    private readonly IMedicacaoRepository _medicacaoRepository;
    public MedicacoesController(IMedicacaoRepository medicacaoRepository) { _medicacaoRepository = medicacaoRepository; }

    #region Listar Medicos
    [HttpGet]
    public async Task<IActionResult> ListarMedicos()
    {
        return Ok(await _medicacaoRepository.ListarMedicos());
    }

    #endregion
    #region Medico By Cod

    [HttpGet("{codMedico:int}")]
    public async Task<IActionResult> MedicoByCod(int codMedico)
    {
        try
        {
            Medico medico = await _medicacaoRepository.MedicoByCod(codMedico);
            return medico is null ? NotFound("Medico não encontrado") : Ok(medico);
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }

    #endregion

    #region Inclui medicacao
    [HttpPost]
    public async Task<IActionResult> IncluirMedicacoes(List<Medicacao> medicacao)
    {
        try
        {
            return await _medicacaoRepository.IncluiMedicacao(medicacao)
                ? BadRequest("Erro ao inserir") : Ok(medicacao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion

    #region Inclui prescricao
    [HttpPost]
    public async Task<IActionResult> IncluiPrescricao([FromBody] PrescricaoDTO prescricaoDTO)
    {
        try
        {
            if (prescricaoDTO is null)
                throw new Exception("Objeto nulo");

            if (!await _medicacaoRepository.MedicoExiste(prescricaoDTO.PrescricaoPaciente.MedicoId))
                return NotFound($"Medico ID {prescricaoDTO.PrescricaoPaciente.MedicoId} não encontrado");

            prescricaoDTO.PrescricaoPaciente.CriadoEm = DateTime.Now;

            int prescricaoPacienteId = await _medicacaoRepository.IncluiPrescricaoPaciente(prescricaoDTO.PrescricaoPaciente);

            if (prescricaoDTO.MedicacoesId.Count < 1)
                return BadRequest("É necessario no minimo 1 medicamento");

            for (int i = 0; i < prescricaoDTO.MedicacoesId.Count; i++)
            {
                if (!await _medicacaoRepository.MedicacaoExiste(prescricaoDTO.MedicacoesId[i]))
                    return NotFound($"Medicamento de ID {prescricaoDTO.MedicacoesId[i]} não encontrado");
            }

            for (int indice = 0; indice < prescricaoDTO.MedicacoesId.Count; indice++)
            {
                if (!FormataDados.VerificaTempo(prescricaoDTO.PrescricoesMedicacoes[indice].Intervalo))
                    return BadRequest("O intervalo das medicações deve estar entre 1h e 24h");
                prescricaoDTO.PrescricoesMedicacoes[indice].PrescricaoPacienteId = prescricaoPacienteId;
                prescricaoDTO.PrescricoesMedicacoes[indice].MedicacaoId = prescricaoPacienteId;
            }
            return await _medicacaoRepository.IncluiPrescricaoMedicacao(prescricaoDTO.PrescricoesMedicacoes) ? Ok("Inclusao feita com sucesso") : BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion

    /*  RETORNA UMA LISTA, SE SOBRE TEMPO INCLUA FILTROS  */
    /*
     * Tenha a seguinte visao:
     * A pessoa vai selecionar a Prescricao Atraves da lista fornecida de la ela tirará o ID que vai ser cancelado
     * Detalhe, mais para frente ele vai verificar CLAIM
     */
    /*Cancelamento de prescricao e medicamentos*/
    #region Cancelar Prescricao Completa por id e idPaciente
    //arrumar essa parte para verificar por paciente
    [HttpPatch("{id:int}/{idPaciente:int}")]
    public async Task<IActionResult> CancelaPrescricaoPacienteCompleta(int id)
    {
        try
        {
            PrescricaoPaciente prescricaoCancela = id < 1 ?
                throw new Exception("Não é aceito valor menor que 1 :(")
                : await _medicacaoRepository.PrescricaoByCod(id);

            if (prescricaoCancela != null)
            {
                if (prescricaoCancela.FlagStatus == "N")
                    return BadRequest("Prescrição já está Inativa");

                switch (await _medicacaoRepository.CancelaPrescricaoMedicacao(prescricaoCancela.PacienteId))
                {
                    case StatusCodeEnum.NotFound: return NotFound("Nenhuma medicacao relacionada a esta prescricao encontrada");
                    case StatusCodeEnum.Success:
                        switch (await _medicacaoRepository.CancelarPrescricaoPaciente(prescricaoCancela))
                        {
                            case StatusCodeEnum.Success:
                                return Ok("Prescricacao cancelada com sucesso");
                            case StatusCodeEnum.NotFound:
                            case StatusCodeEnum.BadRequest: return BadRequest("Erro ao cancelar");
                        }
                        break;
                    case StatusCodeEnum.BadRequest:
                        return BadRequest("Erro Aos salvar");
                };
            }
            return NotFound("Nenhuma prescricao encontrada");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion//Arrumar

    #region Cancela Medicacao
    [HttpPatch("{idPrescricao}/{idMedicacao}")]
    public async Task<IActionResult> CancelaItemMedicacaoPrescricao(int idPrescricao, int idMedicacao)
    {
        try
        {
            return await _medicacaoRepository.CancelaItemMedicacaoPrescricao(idPrescricao, idMedicacao) switch
            {
                StatusCodeEnum.Success => Ok("Item cancelado com sucesso"),
                StatusCodeEnum.NotFound => NotFound("Item não encontrado"),
                StatusCodeEnum.BadRequest => BadRequest(),
                _ => BadRequest(),
            };
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion

    #region Consulta Prescricao
    /*Consulta de prescricao e medicamentos*/
    [HttpGet("{id:int}")]
    public async Task<IActionResult> ConsultaPrescricaoById(int id)
    {
        try
        {
            var prescricoes = await _medicacaoRepository.ListPrescricaoByCod(id);
            return prescricoes.Count == 0 ? NotFound("Nada foi encontrado, verifique o ID") : Ok(prescricoes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
    //Arrumar a consulta prescricao
    #region COnsulta Medicacao By Id
    [HttpGet("{id:int}")]
    public async Task<IActionResult> ConsultaMedicacaoById(int id)
    {
        try
        {
            Medicacao medicacao = await _medicacaoRepository.MedicacaoById(id);

            return medicacao is null
                ? NotFound($"Medicamento com ID {id} não encontrado")
                : Ok(medicacao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
    //Arrumar
}