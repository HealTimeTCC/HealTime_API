namespace Healtime.Application.Dto.MedicacaoDto;

public class PrescricaoMedicacaoDto
{
    public int PrescricaoMedicacaoId { get; set; }
    public int PrescricaoPacienteId { get; set; }
    public int MedicacaoId { get; set; }
    public decimal Qtde { get; set; }//perguntar como fica os liquidos
    public TimeSpan Intervalo { get; set; }
    public int Duracao { get; set; }//Por interpretamos como duracao de dias
    //public bool? StatusMedicacaoFlag { get; set; }
    //public bool HorariosDefinidos { get; set; }

}
