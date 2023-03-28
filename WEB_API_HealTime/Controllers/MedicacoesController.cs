using WEB_API_HealTime.Models.Medicacoes.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto.PrescricaoDTO;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Models.Medicacoes;

namespace WEB_API_HealTime.Controllers;

[Route("[controller]")]
[ApiController]
public class MedicacoesController : ControllerBase
{
    private readonly DataContext _context;
    public MedicacoesController(DataContext context) { _context = context; }

    #region Existe Medicacao (Pendente)

    private bool ExisteMedicacao(List<Medicacao> medicacoes, out List<Medicacao> existe)
    {
        existe = new List<Medicacao>();
        bool confirmaExiste = false;
        foreach (var item in medicacoes)
        {
            Medicacao existeMedi = _context.Medicacoes
            .FirstOrDefault(x => x.NomeMedicacao.ToUpper().Trim() == item.NomeMedicacao.ToUpper().Trim());
            if (existeMedi is not null)
            {
                existe.Add(existeMedi);
                confirmaExiste = true;
            }
        }
        return confirmaExiste;

    }

    #endregion


    #region Listar Medicos
    [HttpGet("ListarMedicos")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _context.Medicos.ToListAsync());
    }

    #endregion

    #region Inclui medicacao
    [HttpPost("IncluiMedicacao")]
    public async Task<IActionResult> IncluirMedicacoes(List<Medicacao> medicacao)
    {
        try
        {
            await _context.Medicacoes.AddRangeAsync(medicacao);
            await _context.SaveChangesAsync();
            //Bloco ABAIXO FAZ INCLUSAO DE LISTA, POREM VAMOS FAZER O SIMPLES PRIMEIRO
            //string frase = string.Empty;
            //if (medicacao is null)
            //{
            //    if (!ExisteMedicacao(medicacao, out List<Medicacao> listaExistente))
            //    {
            //        frase = $"Medicamentos existentes {listaExistente}";
            //        List<Medicacao> medicacaoExistentes = new List<Medicacao>();
            //        medicacaoExistentes.AddRange(listaExistente);
            //        medicacaoExistentes.Find(x => x.)
            //        _context.Medicacoes.AddRange(medicacao);
            //    }
            //    else { return BadRequest("Medicacao Existe"); }
            //}

            return Ok(medicacao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion

    #region Inclui prescricao

    [HttpPost("IncluiPrescricao")]
    public async Task<IActionResult> IncluiPrescricaoAsync([FromBody] PrescricaoDTO prescricaoDTO)
    {
        try
        {
            if (prescricaoDTO is null)
                throw new Exception("Objeto nulo");

            //Using para guardar dados da PRESCRIÇÃO DO PACIENTE

            Medico medico = await _context.Medicos
            .FirstOrDefaultAsync(x => x.MedicoId == prescricaoDTO.PrescricaoPaciente.MedicoId);

            if (medico is null)
                return NotFound($"Medico ID {prescricaoDTO.PrescricaoPaciente.MedicoId} não encontrado");

            prescricaoDTO.PrescricaoPaciente.CriadoEm = DateTime.Now;

            using (_context.PrescricaoPacientes.AddRangeAsync(prescricaoDTO.PrescricaoPaciente))
            {
                await _context.SaveChangesAsync();
            }

            if (prescricaoDTO.MedicacoesId.Count < 1)
                return BadRequest("É necessario no minimo 1 medicamento");

            for (int i = 0; i < prescricaoDTO.MedicacoesId.Count; i++)
            {
                Medicacao busca = await _context.Medicacoes
                    .FirstOrDefaultAsync(x => x.MedicacaoId == prescricaoDTO.MedicacoesId[i]);
                if (busca is null)
                    return NotFound($"Medicamento de ID {prescricaoDTO.MedicacoesId[i]} não encontrado");
            }

            for (int indice = 0; indice < prescricaoDTO.MedicacoesId.Count; indice++)
            {
                if (prescricaoDTO.PrescricoesMedicacoes[indice].Intervalo < 1 || prescricaoDTO.PrescricoesMedicacoes[indice].Intervalo > 24)
                    return BadRequest("O intervalo das medicações deve estar entre 1h e 24h");
                prescricaoDTO.PrescricoesMedicacoes[indice].PrescricaoPacienteId = prescricaoDTO.PrescricaoPaciente.PrescricaoPacienteId;
                prescricaoDTO.PrescricoesMedicacoes[indice].MedicacaoId = prescricaoDTO.MedicacoesId[indice];
            }

            await _context.PrescricoesMedicacoes
                .AddRangeAsync(prescricaoDTO.PrescricoesMedicacoes);
            await _context.SaveChangesAsync();

            return Ok();
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
    [HttpPatch("CancelaPrescPacienteCompleta/{id:int}/{idPaciente:int}")]
    public async Task<IActionResult> CancelaPrescricaoPacienteCompleta(int id)
    {
        try
        {
            var prescricaoCancela = id < 1 ?
                throw new Exception("Não é aceito valor menor que 1 :(")
                : await _context.PrescricaoPacientes
                    .FirstOrDefaultAsync(can => can.PrescricaoPacienteId == id);

            if (prescricaoCancela != null)
            {
                if (prescricaoCancela.FlagStatus == "N")
                    return BadRequest("Prescrição já está Inativa");

                List<PrescricaoMedicacao> listOff = await _context.PrescricoesMedicacoes
                    .Where(fl => fl.PrescricaoPacienteId == prescricaoCancela.PacienteId).ToListAsync();
                listOff.ForEach(x => x.StatusMedicacaoFlag = "N");
                _context.UpdateRange(listOff);
                await _context.SaveChangesAsync();

                prescricaoCancela.FlagStatus = "N";
                _context.PrescricaoPacientes.Update(prescricaoCancela);
                await _context.SaveChangesAsync();
                return Ok(prescricaoCancela);
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
    [HttpPatch("CancelaMedicacao/{idPrescricao}/{idMedicacao}")]
    public async Task<IActionResult> CancelaItemMedicacaoPrescricao(int idPrescricao, int idMedicacao)
    {
        try
        {
            var prescricaoMedicacao = await _context.PrescricoesMedicacoes
                .Include(x => x.Medicacao)
                .FirstOrDefaultAsync(m => m.PrescricaoPacienteId == idPrescricao && m.MedicacaoId == idMedicacao);

            if (prescricaoMedicacao is null)
                return NotFound("O medicamento da prescrição não foi encontrado");

            /*Alterando status*/
            prescricaoMedicacao.StatusMedicacaoFlag = "N";
            prescricaoMedicacao.Medicacao.StatusMedicacao = EnumStatusMedicacao.INATIVO;

            //salvando e definindo o que foi mudado
            var attachMedicao = _context.Attach(prescricaoMedicacao.Medicacao);
            attachMedicao.Property(med => med.MedicacaoId).IsModified = false;
            attachMedicao.Property(med => med.NomeMedicacao).IsModified = false;
            attachMedicao.Property(med => med.StatusMedicacao).IsModified = true;

            var attachPrescricao = _context.Attach(prescricaoMedicacao);
            attachPrescricao.Property(pre => pre.PrescricaoPacienteId).IsModified = false;
            attachPrescricao.Property(pre => pre.MedicacaoId).IsModified = false;
            attachPrescricao.Property(pre => pre.StatusMedicacaoFlag).IsModified = true;

            int linhasAfetadas = await _context.SaveChangesAsync();

            return Ok($"Medicamento {prescricaoMedicacao.Medicacao.NomeMedicacao}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion

    #region Consulta Prescricao
    /*Consulta de prescricao e medicamentos*/
    [HttpGet("ConsultaPrescricao/{id:int}")]
    public async Task<IActionResult> ConsultaPrescricaoById(int id)
    {
        try
        {
            var prescricaoPacienteById = await _context.PrescricaoPacientes
                .Include(p => p.PrescricoesMedicacoes)
                .ThenInclude(p => p.Medicacao)
                .Where(x => x.PacienteId == id).ToListAsync();
            if (prescricaoPacienteById != null)
            {
                return Ok(prescricaoPacienteById);
            }
            return NotFound("Nada foi encontrado, verifique o ID");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
    //Arrumar a consulta prescricao
    #region COnsulta Medicacao By Id
    [HttpGet("ConsultaMedicacaoById/{id:int}")]
    public async Task<IActionResult> ConsultaMedicacaoById(int id)
    {
        try
        {
            Medicacao medicacao = await _context.Medicacoes
                .FirstOrDefaultAsync(m => m.MedicacaoId == id);
            if (medicacao is null)
                return NotFound($"Medicamento com ID {id} não encontrado");
            return Ok(medicacao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
    //Arrumar
}