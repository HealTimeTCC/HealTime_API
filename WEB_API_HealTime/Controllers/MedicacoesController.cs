using Microsoft.AspNetCore.Mvc;
using WEB_API_HealTime.Models.Medicacoes;
using WEB_API_HealTime.Repository.Interfaces;
using WEB_API_HealTime.Utility;
using WEB_API_HealTime.Dto.GlobalEnums;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Dto.Paciente;
using WEB_API_HealTime.Dto.PrescricaoDto;
using WEB_API_HealTime.Dto.MedicacaoDto;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WEB_API_HealTime.Controllers;

//[Authorize]
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
                ? Ok(medicacao) : BadRequest("Erro ao inserir");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion

    #region Inclui prescricao
    [HttpPost]
    public async Task<IActionResult> IncluiPrescricao([FromBody] PrescricaoDto prescricaoDTO)
    {
        try
        {
            if (prescricaoDTO is null)
                throw new Exception("Objeto nulo");

            if (!await _medicacaoRepository.MedicoExiste(prescricaoDTO.MedicoId))
                return NotFound($"Medico ID {prescricaoDTO.MedicoId} não encontrado");

            PrescricaoPaciente prescricaoPaciente = new()
            {
                 CriadoEm =DateTime.Now,
                 DescFichaPessoa = prescricaoDTO.DescFichaPessoa,
                 Emissao = prescricaoDTO.Emissao,
                 FlagStatusAtivo = true,
                 MedicoId = prescricaoDTO.MedicoId,
                 PacienteId = prescricaoDTO.PacienteId,
                 Validade = prescricaoDTO.Validade,
            };

            int prescricaoPacienteId = await _medicacaoRepository.IncluiPrescricaoPaciente(prescricaoPaciente);

            if (prescricaoDTO.PrescricoesMedicacoesDto.Count < 1)
                return BadRequest("É necessario no minimo 1 medicamento");
            List<PrescricaoMedicacao> listPrescricaoMedicacoes = new();

            for (int i = 0; i < prescricaoDTO.PrescricoesMedicacoesDto.Count; i++)
            {
                if (!await _medicacaoRepository.MedicacaoExiste(prescricaoDTO.PrescricoesMedicacoesDto[i].MedicacaoId))
                    return NotFound($"Medicamento de ID {prescricaoDTO.PrescricoesMedicacoesDto[i].MedicacaoId} não encontrado");

                if (FormataDados.VerificaTempo(prescricaoDTO.PrescricoesMedicacoesDto[i].Intervalo))
                    return BadRequest("O intervalo das medicações deve estar entre 1h e 24h");

                PrescricaoMedicacao prescricao = new()
                {
                    MedicacaoId = prescricaoDTO.PrescricoesMedicacoesDto[i].MedicacaoId,
                    Duracao = prescricaoDTO.PrescricoesMedicacoesDto[i].Duracao,
                    HorariosDefinidos = false,
                    Intervalo = prescricaoDTO.PrescricoesMedicacoesDto[i].Intervalo,
                    PrescricaoPacienteId = prescricaoPacienteId,
                    Qtde = prescricaoDTO.PrescricoesMedicacoesDto[i].Qtde,
                    StatusMedicacaoFlag = true,
                };

                listPrescricaoMedicacoes.Add(prescricao);
            }
            //for (int i = 0; i < prescricaoDTO.PrescricoesMedicacoesDto.Count; i++)
            //foreach(var item in prescricaoDTO.PrescricoesMedicacoesDto)
            //{
            //    if (!await _medicacaoRepository.MedicacaoExiste(item.MedicacaoId))
            //        return NotFound($"Medicamento de ID {item.MedicacaoId} não encontrado");

            //    if (FormataDados.VerificaTempo(item.Intervalo))
            //        return BadRequest("O intervalo das medicações deve estar entre 1h e 24h");

            //    PrescricaoMedicacao prescricao = new()
            //    {
            //        MedicacaoId = item.MedicacaoId,
            //        Duracao = item.Duracao,
            //        HorariosDefinidos = false,
            //        Intervalo = item.Intervalo,
            //        PrescricaoPacienteId = prescricaoPacienteId,
            //        Qtde = item.Qtde,
            //        StatusMedicacaoFlag = true,
            //    };

            //    listPrescricaoMedicacoes.Add(prescricao);
            //}

            return await _medicacaoRepository.IncluiPrescricaoMedicacao(listPrescricaoMedicacoes) ? Ok("Inclusao feita com sucesso") : BadRequest();
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
                if (!prescricaoCancela.FlagStatusAtivo)// se false indica inativo
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

    [HttpGet("{codPessoa:int}")]
    public async Task<IActionResult> ListaMedicamentos(int codPessoa)
    {
        try
        {
            List<Medicacao> listMedicacao = await _medicacaoRepository.ListarMedicacoes(codPessoa);

            return listMedicacao.Count == 0 ? NotFound("Nada encontrado") : Ok(listMedicacao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> ListarTipoDeMedicacao()
    {
        try
        {
            List<TipoMedicacao> listTipoMedicacao = await _medicacaoRepository.ListarTipoMedicacao();
            return listTipoMedicacao.Count == 0 ? NotFound("Nada encontrado") : Ok(listTipoMedicacao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{codPaciente:int}")]
    public async Task<IActionResult> ListarPrescricoesPacientes(int codPaciente)
    {
        try
        {
            List<PrescricaoPaciente> list = await _medicacaoRepository.ListarPrescricaoPacientes(codPaciente);
            return list.Count == 0 ? NotFound("Nada encontrado") : Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{codPrescricaoPaciente:int}")]
    public async Task<IActionResult> ListarPrescricaoMedicacaoByCodPrescricaoPaciente(int codPrescricaoPaciente)
    {
        try
        {
            var list = await _medicacaoRepository.ListarPrescricaoMedicacoes(codPrescricaoPaciente);
            return list.Count == 0 ? NotFound("Nada encontrado") : Ok(list);
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

            if (await _medicacaoRepository.HorariosDefinidos(codPrescricaoMedicamento:horario.PrescricaoMedicamentoId))
                return BadRequest("Horários já definidos");
            else if (await _medicacaoRepository.ExecuteProcedureDefineHorario(horario: horario))
                return Ok("Horarios definido com sucesso");
            return BadRequest("Erro ao definir horarios");
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
            List<AndamentoMedicacao> list = await _medicacaoRepository.ListarAndamentoMedicacao(codMedicamento, codPrescicaoPacienteId);
            return list.Count == 0 ? NotFound("Nenhum medicamento em andamento encontrado") : Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{codMedicacao}/{codPrescriptionPatient}")]
    public async Task<IActionResult> ListarAndamentosMedicacao(int codMedicacao, int codPrescriptionPatient)
    {
        try
        {
            List<AndamentoMedicacao> list = await _medicacaoRepository.ListarAndamentoMedicacao(codMedicacao: codMedicacao, codPrescricaoPaciente:codPrescriptionPatient);
            return list.Count == 0 ? NotFound("Nenhum medicamento em andamento encontrado") : Ok(list);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> BaixaAndamentoMedicacao([FromBody]BaixaAndamentoMedicacaoDto baixaAndamentoMedicacaoDto)
    {
        try
        {
            return await _medicacaoRepository.BaixaMedicacao(baixaAndamentoMedicacaoDto) switch
            {
                StatusCodeEnum.Update or StatusCodeEnum.Success => Ok("Baixa efetuada com sucesso"),
                StatusCodeEnum.NotFound => NotFound("Andamento não encontrado"),
                StatusCodeEnum.NotContent => BadRequest("Dado não foi atualizado"),
                StatusCodeEnum.BadRequest => BadRequest("Erro ao encerrar andamento"),
                _ => BadRequest(),
            };
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}