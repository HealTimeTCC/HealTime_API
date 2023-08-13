using Healtime.Application.Dto.MedicacaoDto;

namespace Healtime.Application.Dto.PrescricaoDto;
public class PrescricaoDto
{
    public int PrescricaoPacienteId { get; set; }
    public int MedicoId { get; set; }
    public int PacienteId { get; set; }
    public DateTime? CriadoEm { get; set; }
    public DateTime Emissao { get; set; }
    public DateTime Validade { get; set; }
    public string DescFichaPessoa { get; set; }
    public bool? FlagStatusAtivo { get; set; }
    public List<PrescricaoMedicacaoDto> PrescricoesMedicacoesDto { get; set; }
}
