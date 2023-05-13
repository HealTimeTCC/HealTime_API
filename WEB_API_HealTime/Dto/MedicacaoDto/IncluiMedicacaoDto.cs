
using WEB_API_HealTime.Models.Medicacoes;

namespace WEB_API_HealTime.Dto.IncluiMedicacaoDto;
public class IncluiMedicacaoDto
{
    public int PessoaIdInclusora { get; set; }
    public List<Medicacao> ListaMedicamentos { get; set; }
}
